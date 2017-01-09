using Spring.Social.Twitter.Api;
using Spring.Social.Twitter.Api.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace DogAdoption.Twitter_Integration
{
    public class InitTwitter
    {
        private string consumerKey { get; set; } // The application's consumer key
        private string consumerSecret { get; set; } // The application's consumer secret
        private string accessToken { get; set; } // The access token granted after OAuth authorization
        private string accessTokenSecret { get; set; } // The access token secret granted after OAuth authorization

        public void RetrieveKeys()
        {
            WebClient client = new WebClient();
            consumerKey = client.DownloadString("https://arcane-ridge-72999.herokuapp.com/key/consumer");
            consumerSecret = client.DownloadString("https://arcane-ridge-72999.herokuapp.com/key/secret");
        }

        public void InitializeTwitter(string _accessToken, string _accessTokenSecret)
        {
            RetrieveKeys();
            accessToken = _accessToken;
            accessTokenSecret = _accessTokenSecret;
            ITwitter twitter = new TwitterTemplate(consumerKey, consumerSecret, accessToken, accessTokenSecret);
        }


    }
}