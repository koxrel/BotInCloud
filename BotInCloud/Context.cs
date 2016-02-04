using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using BotInCloud.Entities;

namespace BotInCloud
{
    public class Context : DbContext
    {
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<EnglishHomeTask> EnglishHomeTasks { get; set; }
        public Context() : base("Azure")
        {
            
        }
    }
}