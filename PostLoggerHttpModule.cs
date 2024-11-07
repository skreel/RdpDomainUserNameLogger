using System;
using System.Web;

namespace RdpDomainUserNameLogger
{

    public class PostLoggerHttpModule : IHttpModule
    {
        public void Dispose()
        {
        }

        public void Init(HttpApplication context)
        {
            context.BeginRequest += new EventHandler(context_BeginRequest);
        }

        private void context_BeginRequest(object sender, EventArgs e)
        {
            if (sender != null && sender is HttpApplication)
            {
                var request = (sender as HttpApplication).Request;
                var response = (sender as HttpApplication).Response;

                if (request != null && response != null && request.HttpMethod.ToUpper() == "POST")
                {
                    if (request.Form["DomainUserName"] != null)
                    {
                        var body = HttpUtility.UrlDecode(request.Form["DomainUserName"].ToString());

                        if (!string.IsNullOrWhiteSpace(body))
                        {
                            if (request.QueryString.Count > 0)
                            {
                                response.AppendToLog("&");
                            }
                            response.AppendToLog("DomainUserName=");
                            response.AppendToLog(body);
                        }

                    }
                }
            }
        }
    }
}
