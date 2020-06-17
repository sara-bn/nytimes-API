using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using static TopStories.StoryContext;

namespace TopStories
{
    class Program
    {
        const string Base_URL = "https://api.nytimes.com/svc/topstories/v2/arts.json?api-key=";
        const string API_key = "";
        const string URL = Base_URL + API_key;

        static void Main(string[] args)
        {
            string json = GetDataFromUrl(URL);

            Rootobject obj = JsonConvert.DeserializeObject<Rootobject>(json);


            // write all titles in a txt file
            int count = 1;
            using (StreamWriter sw = new StreamWriter("titles.txt"))
            {
                foreach (var record in obj.results)
                {
                    sw.WriteLine($"{count}. {record.title}");
                    count++;
                }
            }

            //seed data in database
            using (var db = new APIConsumerContext())
            {
                foreach (var record in obj.results)
                {
                    db.Add(new StoryContext()
                    {

                        section = record.section,
                        title = record.title,
                        published_date = record.published_date,
                        byline = record.byline

    });

                    db.SaveChanges();
                }
            }

        }

        static string GetDataFromUrl(string url)
        {
            try
            {
                WebClient client = new WebClient();
                var jsonResult = client.DownloadString(URL);
                return jsonResult;
            }
            catch (Exception e)
            {
                string result = $"{{'Error': 'Error ocurred. Could not get data from {url}','Message':'{e.Message}'}}";
                return result;
            }
        }
    }
}
