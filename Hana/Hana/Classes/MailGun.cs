using Microsoft.AspNet.Identity;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hana.Models;
using Hana.Classes;
using System.Data.Entity;


namespace Hana.Classes
{
    public class MailGun
    {
        public static IRestResponse SendCustomerConfirmation(string recipient, string body)
        {
            string key = Keys.MailGunAPIPKey;
            string domain = Keys.MailGunAPIDomain;
            string sender = "Hana <mailgun@" + domain + ">";
            RestClient client = new RestClient();
            client.BaseUrl = new Uri("https://api.mailgun.net/v3/");
            client.Authenticator = new HttpBasicAuthenticator("api", key);
            RestRequest request = new RestRequest();
            request.AddParameter("domain", domain, ParameterType.UrlSegment);
            request.Resource = "{domain}/messages";
            request.AddParameter("from", sender);
            request.AddParameter("to", recipient);
            request.AddParameter("subject", "Your Receipt of Purchase from Hana");
            request.AddParameter("text", body);
            request.Method = Method.POST;
            return client.Execute(request);
        }
        public static IRestResponse SendOrderDetails(string orderID, string body)
        {
            string key = Keys.MailGunAPIPKey;
            string domain = Keys.MailGunAPIDomain;
            string sender = "Hana <mailgun@" + domain + ">";
            RestClient client = new RestClient();
            client.BaseUrl = new Uri("https://api.mailgun.net/v3/");
            client.Authenticator = new HttpBasicAuthenticator("api", key);
            RestRequest request = new RestRequest();
            request.AddParameter("domain", domain, ParameterType.UrlSegment);
            request.Resource = "{domain}/messages";
            request.AddParameter("from", sender);
            request.AddParameter("to", sender);
            request.AddParameter("subject", "Order: " + orderID);
            request.AddParameter("text", "Hi! Thanks for ordering from Hana! Your order will arriving to you soon " + body);
            request.Method = Method.POST;
            return client.Execute(request);
        }
    }
}