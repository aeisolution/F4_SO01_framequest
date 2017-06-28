using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace frameQuest.Models
{
    public class frameQuestContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public frameQuestContext() : base("name=frameQuestContext")
        {
        }

        public DbSet<Alunno> Alunnoes { get; set; }
        public DbSet<Docente> Docenti { get; set; }
        public DbSet<Classe> Classi { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<Argomento> Argomenti { get; set; }
        public DbSet<Fase> Fasi { get; set; }
        public DbSet<Domanda> Domande { get; set; }
    }
}
