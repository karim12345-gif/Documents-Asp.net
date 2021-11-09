using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DocumentsProject.Models
{
    public class Document 
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public DateTime time { get; set; }
        public string filePath { get; set; }

        public Document()
        {

        }


    }


    public class MyContext : DbContext
    {
        public DbSet<Document> DocumentTabel { get; set; }

        public MyContext():base()
        {

        }

    }
}