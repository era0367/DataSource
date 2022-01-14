using System;
using RestSharp;
using Newtonsoft.Json.Linq;

namespace XDSDataSource
{
    public class RestSender
    {
        public static readonly string VERSION = "1.0.0";
        public static readonly string REPOSITORY_ENDPOINT = "http://localhost:15000/";
        public static readonly string PATH = "/metadata";

        public static string SendRest(string body)
        {
            RestClient restClient = new RestClient(REPOSITORY_ENDPOINT);
            RestRequest restRequest = new RestRequest(PATH, Method.POST);

            restRequest.AddJsonBody(body);
            IRestResponse response = restClient.Execute(restRequest);
            return JObject.Parse(response.Content).ToString();
        }
    }
}
