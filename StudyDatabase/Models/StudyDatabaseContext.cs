using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace StudyDatabase.Models
{
    public class StudyDatabaseContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public StudyDatabaseContext() : base("name=StudyDatabaseContext")
        {
        }

        public System.Data.Entity.DbSet<StudyDatabase.Models.StudyFile> StudyFiles { get; set; }

        public System.Data.Entity.DbSet<StudyDatabase.Models.Keyword> Keywords { get; set; }
    
    }
}
