using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SimpleSolution.WebApp
{
    public class UsersController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage GetUserById(int id)
        {
            return Request.Text(HttpStatusCode.OK, $"user(id={id}) found");
        }

        [HttpPut]
        public HttpResponseMessage Put(int id, string name)
        {
            return Request.Text(HttpStatusCode.OK, $"user(id={id})'s name updated to superman");
        }

        [HttpGet]
        public HttpResponseMessage Get(string name)
        {
            return Request.Text(HttpStatusCode.OK, $"user(name={name}) found");
        }

        [HttpGet]
        public HttpResponseMessage Get()
        {
            return Request.Text(HttpStatusCode.OK, "This will get all users's dependents");
        }

        [HttpGet]
        public HttpResponseMessage DependentById(int userId)
        {
            return Request.Text(HttpStatusCode.OK, $"This will get user(id={userId})'s dependents");
        }
    }
}