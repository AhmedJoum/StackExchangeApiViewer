using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace StackExchangeApiViewer.Models
{
    public class RootObject
    {
        public List<Question> Items{ get; set; }
        public bool has_more { get; set; }
        public int quota_max { get; set; }
        public int quota_remaining { get; set; }



        public void GetLatestQuestions()
        {

            HttpClientHandler handler = new HttpClientHandler();
            handler.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
            using (var Client = new HttpClient(handler))
            {
                Client.BaseAddress = new Uri("https://api.stackexchange.com/");
                //HTTP GET
                Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/jason"));
                var response = Client.GetAsync("2.2/questions?site=stackoverflow");
                response.Wait();
                var result = response.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<RootObject>();
                    readTask.Wait();
                    this.Items = readTask.Result.Items;
                }

            }
        }
    }
}