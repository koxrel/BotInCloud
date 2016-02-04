using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BotInCloud.Entities
{
    public class Assignment
    {
        public int Id { get; set; }
        public DateTime DueDate { get; set; }
        public string Name { get; set; }
    }
}