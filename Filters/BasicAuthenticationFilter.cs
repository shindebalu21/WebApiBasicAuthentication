using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using WebApiBasicAuthentication.Helper;

namespace WebApiBasicAuthentication.Filters
{
    public class BasicAuthentication : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (actionContext.Request.Headers.Authorization==null)
            {
                actionContext.Response = actionContext.Request.
                    CreateResponse(HttpStatusCode.Unauthorized,"You are not autherized to access this service");
            }
            else
            {
                string authenticationToken = actionContext.Request.Headers.Authorization.Parameter;
                string decodedAuthenticationToken = Encoding.UTF8.GetString(Convert.FromBase64String(authenticationToken));
               string [] usernamepasswordArray=  decodedAuthenticationToken.Split(':');
                string userName = usernamepasswordArray[0].ToString();
                string passWord = usernamepasswordArray[1];
                if (CustomerSecurity.Login(userName,passWord))
                {
                    Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(userName),null);
                }
                else
                {
                    actionContext.Response = actionContext.Request.
                        CreateResponse(HttpStatusCode.Unauthorized);
                }
            }
            base.OnAuthorization(actionContext);    
        }
    }
}