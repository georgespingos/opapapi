using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.IO;
using Tzoker.Results.Base;
using System.Configuration;
using MongoDB.Driver;

namespace Tzoker.Results.Lib
{
    public class Helper
    {
        public string JsonResponse { get; set; }
        
        public Helper (int DrawID, string URL)
        {
            this.JsonResponse = GetJsonResponse(DrawID, URL);
        }

        private static string GetJsonResponse(int DrawID, string URL) 
        {
            string result = string.Empty;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL+DrawID);

            request.Method = "GET";
            using (var stream = request.GetResponse().GetResponseStream())

            using (var reader = new StreamReader(stream))
            {
                result = reader.ReadToEnd();
            }
            return result;
        }

        public static DateTime ToGreekDate(string Date)
        {
            string tmp = Date.Split(new char[] { ' ' })[1].ToString();
            System.Globalization.CultureInfo GrCulture = new System.Globalization.CultureInfo("el-GR");
            return Convert.ToDateTime(tmp, GrCulture);
        }

        public MongoDatabase Database
        {
            get
            {
                return MongoDatabase.Create(GetMongoDbConnectionString());
            }
        }

        private string GetMongoDbConnectionString()
        {
            return ConfigurationManager.AppSettings.Get("MONGOHQ_URL") ??
                ConfigurationManager.AppSettings.Get("MONGOLAB_URI") ??
                "mongodb://localhost/OpapDraws";
        }
    }
}