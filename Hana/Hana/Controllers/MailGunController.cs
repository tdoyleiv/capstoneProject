using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.IO;
using RestSharp;
using RestSharp.Authenticators;
using Hana.Classes;
using Hana.Models;

namespace Hana.Controllers
{
    public class MailGunController
    {
        //public static IRestResponse SendConfirmation()
        //{
        //    string key = Keys.MailGunAPIPKey;
        //    string domain = Keys.MailGunAPIDomain;
        //    string sender = "Hana <mailgun@" + domain + ">";
        //    RestClient client = new RestClient();
        //    client.BaseUrl = new Uri("https://api.mailgun.net/v3/");
        //    client.Authenticator = new HttpBasicAuthenticator("api", key);
        //    RestRequest request = new RestRequest();
        //    request.AddParameter("domain", domain, ParameterType.UrlSegment);
        //    request.Resource = "{domain}/messages";
        //    request.AddParameter ("from", sender);
        //    request.AddParameter("to", );
        //}
    }
}