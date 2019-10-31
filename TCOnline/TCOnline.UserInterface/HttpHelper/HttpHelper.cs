﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace TCOnline.UserInterface.HttpHelper
{
    public class HttpClientHelper
    {
        public HttpClient Client { get; set; }
        public HttpClientHelper()
        {
            Client = new HttpClient();
            Client.BaseAddress = new Uri(ConfigurationManager.AppSettings["ServiceUrl"].ToString());
        }
        public HttpResponseMessage GetResponse(string url)
        {
            return Client.GetAsync(url).Result;
        }
        public HttpResponseMessage PutResponse(string url, object model)
        {
            return Client.PutAsJsonAsync(url, model).Result;
        }
        public HttpResponseMessage PostResponse(string url, object model)
        {
            return Client.PostAsJsonAsync(url, model).Result;
        }
        public HttpResponseMessage DeleteResponse(string url)
        {
            return Client.DeleteAsync(url).Result;
        }
    } //end of class
}