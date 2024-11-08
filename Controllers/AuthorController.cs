using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiAuthor.Data.Repositories;
using WebApiAuthor.Models;

namespace WebApiAuthor.Controllers
{
    public class AuthorController : ApiController
    {
        // GET api/<controller>
        public List<AuthorEntity>  Get()
        {
            return AuthorRepository.getAuthorList();
        }

        // GET api/<controller>/5
        public AuthorEntity Get(int id)
        {
            return  AuthorRepository.getFindId(id);
        }

        // POST api/<controller>
        public bool Post([FromBody] AuthorEntity authorEntity)
        {
            return AuthorRepository.registerAuthor(authorEntity);
        }

        // PUT api/<controller>/5
        public bool Put([FromBody] AuthorEntity authorEntity)
        {
            return AuthorRepository.updateAuthor(authorEntity);
        }

        // DELETE api/<controller>/5
        public bool Delete(int id)
        {
            return AuthorRepository.delete(id);
        }
    }
}