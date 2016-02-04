using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BotInCloud.DTO;
using Newtonsoft.Json;

namespace BotInCloud
{
    public partial class MainForm : System.Web.UI.Page
    {
        private const string Password = "API_Bot";

        private const string Token = "169127553:AAGycF92iqxYcaQF5_DMhDNzEITjFTKJYgY";

        private const string HomeworkTech =
            "InfoTech:\nДоделать файл прошлого ДЗ (2016_29.01)\nЗадание 4 оттуда - Summary(~100 words)";

        private const string HomeworkIELTS = "IELTS:\nWB: 44-45\nSB: 82-83";

        private const string Deadlines = "Крайние сроки сдачи работ:\n11.02.2016 23:59:59 - Программирование (Assignment 6)\n14.02.2016 21:00 - Майнор ИАД (Задания 1 и 2)\n15.02.2016 23:59 - Управление данными";

        private const string Keyboard =
            @"{""keyboard"":[[""/homework_ielts"",""/homework_infotech""],[""/deadlines""]],""resize_keyboard"":true}";

        private bool IsCancelled = false;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void RunningBot()
        {
            int lastUpdateId = 0;
            var client = new HttpClient();
            while (true)
            {
                var response =
                    client.GetAsync($"https://api.telegram.org/bot{Token}/getupdates?offset={lastUpdateId}").Result;

                var updates = JsonConvert.DeserializeObject<Updates>(response.Content.ReadAsStringAsync().Result);

                foreach (var update in updates.UpdateArr)
                {
                    string replyText;
                    if (update.Message.Text.StartsWith("/start"))
                        replyText =
                            "Рад видеть Вас здесь! Наберите одну из команд. Сначала нажмите / ...\nВсе вопросы, пожелания и замеченные ошибки направляйте @koxrel\nБота обслуживает Microsoft Azure";
                    else if (update.Message.Text.StartsWith("/homework_ie"))
                        replyText = HomeworkIELTS;
                    else if (update.Message.Text.StartsWith("/homework_inf"))
                        replyText = HomeworkTech;
                    else if (update.Message.Text.StartsWith("/dead"))
                        replyText = Deadlines;
                    else if (update.Message.Text.Contains("Игорь") || update.Message.Text.Contains("игорь"))
                        replyText = "Все комментарии отправляйте @koxrel ))";
                    else
                        replyText = "Введите правильную команду. Сначала нажмите / ...";


                    //client.GetAsync(
                    //    $"https://api.telegram.org/bot{Token}/sendmessage?chat_id={update.Message.Chat.Id}&text=Hello!&reply_markup={Keyboard}");
                    client.GetAsync(
                        $"https://api.telegram.org/bot{Token}/sendmessage?chat_id={update.Message.Chat.Id}&text={replyText}&reply_markup={Keyboard}");
                    System.Diagnostics.Trace.TraceError($"Sent a message to {update.Message.User.Name} {update.Message.User.Surname} - {update.Message.Text}");
                    //Console.WriteLine($"Sent a message to {update.Message.User.Name} {update.Message.User.Surname}");
                    lastUpdateId = update.UpdateID + 1;
                }
                Task.Delay(700).Wait();
            }
        }

        protected void RunButton_Click(object sender, EventArgs e)
        {
            if (Password != PasswordTB.Text) return;
            Task.Run(() => RunningBot());
        }

        protected void StopButton_Click(object sender, EventArgs e)
        {
            IsCancelled = true;
        }
    }
}