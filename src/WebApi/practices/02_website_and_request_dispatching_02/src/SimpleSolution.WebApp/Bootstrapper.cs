using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Routing;

namespace SimpleSolution.WebApp
{
    public class Bootstrapper
    {
        public static void Init(HttpConfiguration configuration)
        {
            // Note. Since response message generation is out of scope
            // of our test. So I have create an extension method called
            // Request.Text(HttpStatusCode, string) to help you generating
            // a textual response.
            configuration.Routes.MapHttpRoute(
                "user dependents",
                "users/dependents",
                new {controller = "Users"},
                new {httpMethod = new HttpMethodConstraint(HttpMethod.Get)});

            configuration.Routes.MapHttpRoute(
                "user dependents by id",
                "users/{userId}/dependents",
                new {controller = "Users", action= "DependentById" },
                new {httpMethod = new HttpMethodConstraint(HttpMethod.Get)});

            configuration.Routes.MapHttpRoute(
                "user",
                "users/{id}",
                new {controller = "Users"},
                new {id=@"\d+" , httpMethod = new HttpMethodConstraint(HttpMethod.Get, HttpMethod.Put) }
                );

            configuration.Routes.MapHttpRoute(
                "user name",
                "users",
                new {controller = "Users"},
                new {httpMethod = new HttpMethodConstraint(HttpMethod.Get)});
        }
    }
}