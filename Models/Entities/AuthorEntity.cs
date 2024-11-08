using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiAuthor.Models
{
    public class AuthorEntity
    {
        public int Id { get; set; }
        public string Names { get; set; }
        public string FirstName { get; set; }
        public string SecondSurname { get; set; }
        public DateTime BirthDate{ get; set; }
        public string CountryResidence { get; set; }
        public string Mail { get; set; }


    }
}