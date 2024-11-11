using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiAuthor.Data.Repositories;
using WebApiAuthor.Models;
using WebApiAuthor.Models.Entities;

namespace WebApiAuthor.Controllers
{
    public class AuthorController : ApiController
    {
        [HttpGet]
        [Route("api/authors")]
        public List<AuthorEntity> GetAuthors()
        {
            return AuthorRepository.getAuthorList();
        }

        [HttpGet]
        [Route("api/authors/{id}")]
        public AuthorEntity GetAuthor(int id)
        {
            return AuthorRepository.getFindId(id);
        }

        [HttpPost]
        [Route("api/authors")]
        public bool PostAuthor([FromBody] AuthorEntity authorEntity)
        {
            return AuthorRepository.registerAuthor(authorEntity);
        }

        [HttpPut]
        [Route("api/authors")]
        public bool PutAuthor([FromBody] AuthorEntity authorEntity)
        {
            return AuthorRepository.updateAuthor(authorEntity);
        }

        [HttpDelete]
        [Route("api/authors/{id}")]
        public bool DeleteAuthor(int id)
        {
            return AuthorRepository.delete(id);
        }

        [HttpGet]
        [Route("api/blogs")]
        public List<BlogEntity> GetBlogs()
        {
            return BlogRepository.listBlog();
        }

        [HttpGet]
        [Route("api/blogs/{id}")]
        public BlogEntity GetBlog(int id)
        {
            return BlogRepository.findBlog(id);
        }

        [HttpPost]
        [Route("api/blogs")]
        public bool PostBlog([FromBody] BlogEntity request)
        {
            return BlogRepository.registerBlog(request);
        }

        [HttpPut]
        [Route("api/blogs")]
        public bool PutBlog([FromBody] BlogEntity request)
        {
            return BlogRepository.updateBlog(request);
        }

        [HttpDelete]
        [Route("api/blogs/{id}")]
        public bool DeleteBlog(int id)
        {
            return BlogRepository.deleteBlog(id);
        }
    }

}