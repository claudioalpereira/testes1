using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace TripRqst.Utils
{
    public class MyEmailService : SmtpClient
    {
        // email user-name
        public string UserName { get; set; }

        public MyEmailService() :
        base(ConfigurationManager.AppSettings["EmailHost"], int.Parse(ConfigurationManager.AppSettings["EmailPort"]) )
        {
            //Get values from web.config file:
            this.UserName = ConfigurationManager.AppSettings["EmailUserName"];
            this.EnableSsl = Boolean.Parse(ConfigurationManager.AppSettings["EmailSsl"]);
            this.UseDefaultCredentials = false;
            this.Credentials = new System.Net.NetworkCredential(this.UserName, ConfigurationManager.AppSettings["EmailPassword"]);
        }
    }
}