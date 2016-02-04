using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BotInCloud.Entities
{
    public class EnglishHomeTask
    {
        public int Id { get; set; }
        public DateTime DueDate { get; set; }
        public string Module { get; set; }
        public string Description { get; set; }

        public override string ToString()
        {
            return $"{Module}:\n{Description}";
        }
    }
}