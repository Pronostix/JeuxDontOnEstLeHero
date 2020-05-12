using JeuxDontOnEstLeHero.Core.data;
using JeuxDontOnEstLeHero.Core.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace JeuxDontOnEstLeHero.Core.Data
{
    public class DefaultContext : DbContext
    {
        public DefaultContext(DbContextOptions options) : base(options)
        {
        }

        protected DefaultContext()
        {
        }

        public DbSet<Aventure> Aventure { get; set; }

        public DbSet<Quest> Quest { get; set; }

        public DbSet<Question> Question { get; set; }

        public DbSet<Answer> Answer { get; set; }
    }
}
