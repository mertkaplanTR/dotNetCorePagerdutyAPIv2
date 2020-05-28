using System;
using System.IO;
using System.Net;

namespace dotNetCore_pagerduty_APIv2
{
    class Program
    {
        static void Main(string[] args)
        {
            HttpWebRequest myHttpWebRequest = (HttpWebRequest)WebRequest.Create("https://api.pagerduty.com/incidents");
            WebHeaderCollection myWebHeaderCollection = myHttpWebRequest.Headers;
            myWebHeaderCollection.Add("Authorization:Token token=XXXXXXXXXXXXXXXXXXXXXXXX");
            myWebHeaderCollection.Add("Accept:application/vnd.pagerduty+json;version=2");
            myWebHeaderCollection.Add("From:XXXXXXXXXXXXXXXXXXXXXXXX@XXXXXXXXXXXXXXXXXXXXXXXX");
            myHttpWebRequest.ContentType = "application/json";
            myHttpWebRequest.Method = "POST";
            StreamReader r = new StreamReader("/XXXXXXXXXXXXXXXXXXXXXXXX/simplerequest.json");
            String myJson = r.ReadToEnd();
            //check your json
            Console.WriteLine(myJson);
            using (var streamWriter = new StreamWriter(myHttpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(myJson);
                streamWriter.Flush();
                streamWriter.Close();
                var httpResponse = (HttpWebResponse)myHttpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    Console.WriteLine(result);
                }
            }
        }
    }
}
