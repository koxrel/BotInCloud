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
        public string Description { get; set; }

        public override string ToString()
        {
            return $"{DueDate:d.MM.yyyy hh:mm:ss} - {Name}: {Description}";
        }
    }
}