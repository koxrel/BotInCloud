using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using BotInCloud.DTO;
using Newtonsoft.Json;

namespace BotInCloud
{
    public class APICall
    {
        private APICall _apiCall;
        public APICall GetApiCall => _apiCall ?? (_apiCall = new APICall());

        private const string Token = "169127553:AAGycF92iqxYcaQF5_DMhDNzEITjFTKJYgY";
        private readonly HttpClient _client = new HttpClient();
        private int _lastUpdateId;
        private CancellationTokenSource _cts;
        private const string Keyboard =
            @"{""keyboard"":[[""/homework_ielts"",""/homework_infotech""],[""/deadlines""]],""resize_keyboard"":true}";
        private Updates GetUpdates()
        {
            var response =
                    _client.GetAsync($"https://api.telegram.org/bot{Token}/getupdates?offset={_lastUpdateId}").Result;

            return JsonConvert.DeserializeObject<Updates>(response.Content.ReadAsStringAsync().Result);
        }

        private string GetDeadlines(Context db)
        {
            var query = db.Assignments.Where(a => a.DueDate >= DateTime.Now)
                                .OrderBy(a => a.DueDate)
                                .Select(a => a.ToString());

            var sb = new StringBuilder();
            sb.Append("Крайние сроки сдачи работ\n");
            foreach (var assign in query)
            {
                sb.Append(assign);
                sb.Append('\n');
            }

            return sb.ToString();
        }

        private void SendMessages(IEnumerable<Update> updates)
        {
            using (var db = new Context())  
            {
                foreach (var update in updates)
                {
                    string replyText;
                    if (update.Message.Text.StartsWith("/start"))
                        replyText = Replies.Start;
                    else if (update.Message.Text.StartsWith("/homework_ie"))
                        replyText = GetHomeTask(db, "IELTS");
                    else if (update.Message.Text.StartsWith("/homework_inf"))
                        replyText = GetHomeTask(db, "InfoTech");
                    else if (update.Message.Text.StartsWith("/dead"))
                        replyText = GetDeadlines(db);
                    else if (update.Message.Text.Contains("Игорь") || update.Message.Text.Contains("игорь"))
                        replyText = Replies.Comments;
                    else
                        replyText = Replies.IncorrectCommand;

                    _client.GetAsync(
                        $"https://api.telegram.org/bot{Token}/sendmessage?chat_id={update.Message.Chat.Id}&text={replyText}&reply_markup={Keyboard}");
                    System.Diagnostics.Trace.TraceError($"Sent a message to {update.Message.User.Name} {update.Message.User.Surname} - {update.Message.Text}");
                    _lastUpdateId = update.UpdateID + 1;
                } 
            }
            Task.Delay(700).Wait();
        }

        private string GetHomeTask(Context db, string module)
        {
            return db.EnglishHomeTasks
                .FirstOrDefault(h => h.Module == module && h.DueDate >= DateTime.Today)?.ToString();
        }

        private void Process(CancellationToken ct)
        {
            while (!ct.IsCancellationRequested)
            {
                SendMessages(GetUpdates().UpdateArr);
            }
        }

        public void StartProcessing()
        {
            _cts = new CancellationTokenSource();
            Task.Run(() => Process(_cts.Token));
        }

        public void CancelProcessing()
        {
            _cts.Cancel();
        }
    }
}