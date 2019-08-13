using Microsoft.Owin.Security;
using System;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;


namespace WebAutomat.Infrastructure
{
    public class AdminAttribute : FilterAttribute, IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var segment = filterContext.RequestContext.RouteData.Values;
            if (!filterContext.HttpContext.Request.IsAuthenticated)
            {
                if (segment.Count <= 2)
                    filterContext.Result = new System.Web.Mvc.HttpStatusCodeResult(401);
                else
                {
                    //Получение хеша ключа из адресной строки и хеша ключа из web.config
                    SHA512 sm = new SHA512Managed();
                    byte[] hash = sm.ComputeHash(Encoding.UTF8.GetBytes(segment["id"].ToString()));
                    string word = Convert.ToBase64String(hash);
                    string password = WebConfigurationManager.AppSettings["Admin"];

                    if (word != password)
                        filterContext.Result = new System.Web.Mvc.HttpStatusCodeResult(401);
                    else
                    {
                        //Аутентификация через куки
                        var claims = new[] {
                            new Claim(ClaimTypes.Name, "Admin")};

                        var identity = new ClaimsIdentity(claims, "ApplicationCookie");

                        var context = filterContext.HttpContext.Request.GetOwinContext();
                        var authManager = context.Authentication;

                        authManager.SignIn(new AuthenticationProperties
                        { IsPersistent = false }, identity);
                    }
                }
            }
        }

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {

        }
    }
}