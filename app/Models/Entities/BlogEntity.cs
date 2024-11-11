using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiAuthor.Models.Entities
{
    public class BlogEntity
    {
        public int id { get; set; }
        public string title { get; set; }
        public string thema { get; set; }
        public string content { get; set; }
        public string periodicity { get; set; }
        public bool allowComments { get; set; }
        public DateTime creationDate { get; set; }
        public DateTime updatedDate { get; set; } = DateTime.Now;
    }
}