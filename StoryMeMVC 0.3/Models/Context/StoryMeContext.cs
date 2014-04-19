using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace StoryMeMVC.Models.Context
{
    public class StoryMeContext : DbContext
    {
        public StoryMeContext() : base("StoryMeDB") {  }
        public DbSet<Usuarios> Usuarios { get; set; }
    }
}