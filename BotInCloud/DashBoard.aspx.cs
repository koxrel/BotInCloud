using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BotInCloud.Entities;

namespace BotInCloud
{
    public partial class DashBoard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SubmitBut_Click(object sender, EventArgs e)
        {
            using (var db = new Context())  
            {
                switch (RBList.SelectedIndex)
                {
                    case 0:
                        var home = new EnglishHomeTask()
                        {
                            Description = string.Format(DescTB.Text),
                            Module = NameTB.Text,
                            DueDate = new DateTime(int.Parse(YearTB.Text), int.Parse(MonthTB.Text), int.Parse(DateTB.Text),
                                int.Parse(HoursTB.Text), int.Parse(MinTB.Text), int.Parse(SecTB.Text))
                        };
                        db.EnglishHomeTasks.Add(home);
                        break;
                    case 1:
                        var assign = new Assignment()
                        {
                            Description = string.Format(DescTB.Text),
                            DueDate =
                                new DateTime(int.Parse(YearTB.Text), int.Parse(MonthTB.Text), int.Parse(DateTB.Text),
                                    int.Parse(HoursTB.Text), int.Parse(MinTB.Text), int.Parse(SecTB.Text)),
                            Name = NameTB.Text
                        };
                        db.Assignments.Add(assign);
                        break;
                }
                db.SaveChanges();
            }
        }

        protected void ClearBut_Click(object sender, EventArgs e)
        {
            using (var db = new Context())
            {
                var forRemovalAssign = db.Assignments.Where(a => a.DueDate < DateTime.Today).ToArray();
                db.Assignments.RemoveRange(forRemovalAssign);

                var forRemovalHometasks = db.EnglishHomeTasks.Where(h => h.DueDate < DateTime.Today).ToArray();
                db.EnglishHomeTasks.RemoveRange(forRemovalHometasks);

                db.SaveChanges();
            }
        }

        protected void RunBut_Click(object sender, EventArgs e)
        {
            var a = APICall.GetApiCall;
            a.StartProcessing();
        }

        protected void StopBut_Click(object sender, EventArgs e)
        {
            var a = APICall.GetApiCall;
            a.CancelProcessing();
        }
    }
}