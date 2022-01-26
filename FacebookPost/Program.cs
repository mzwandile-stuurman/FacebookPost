using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace FacebookPost
{
    class Program
    {
        static void Main(string[] args)
        {
            Facebook facebook = new Facebook("EAAMfvTfUa48BAB6KBjbsUHIZCvNnmaDBAG8fPTLUJ0ttHv0Id065A2ZAM6NyfFVnyEQDQu4fSEK3WoE2pbFXANUZCgV7psC8GFVkmZCJnEdbBXhmncmSC7WZCJBN9AywBNTnznXHpB0ND4plxZACPQiB5qqgfYKUwzMXEnAZAPtZCie4tjEOXZAATTq2kdPqBmh4gNf3PprxHTwZDZD", "104587057971075");

            var rezText = Task.Run(async () =>
             {

                 using (var http = new HttpClient())
                 {
                     return await facebook.PublishSimplePost("Good day everyone. How may we be of service?");
                 }
             });
             var rezTextJson = JObject.Parse(rezText.Result.Item2);
             if (rezText.Result.Item1 != 200)
             {
                 try // return error from JSON
                 {
                     Console.WriteLine($"Error posting to Facebook. {rezTextJson["error"]["message"].Value<string>()}");
                     return;
                 }
                 catch (Exception ex) // return unknown error
                 {
                      //log exception somewhere
                     Console.WriteLine($"Unknown error posting to Facebook. {ex.Message}");
                     return;
                 }
             }
            Console.WriteLine(rezTextJson);

           /* var rez = Task.Run(async () =>
            {
                //string url = "https://graph.facebook.com/879322476080015?fields=access_token";
                //string url = "https://graph.facebook.com/oauth/access_token?client_id=879322476080015&client_secret=4dea3999ae99694de7f62efbb72a0126&grant_type=client_credentials";
                //string url = "https://graph.facebook.com/879322476080015?fields=access_token&access_token=879322476080015|NN7B9WaYxER00dVQxlgegLaLSeY";
                string token = "EAAMfvTfUa48BACxpgjdMTHxmmTBxKwLAdVnBaHv4KkCNCRCMhWvV6Y8kfKBhFyoA2Cv4VsOobbN0t31wG8K9wMwfryY31gvaj5guKYwsDmgNUmI3gO88t3x48EZCwAbnPDsZCUQIWYEhXUBOgqSfhuhvFOVZCpJlYqXXZBZBzbXNUzXh4QwETH0zNvW5CknBnkzjAxY4ZBLwZDZD";
                string url = "https://graph.facebook.com/me/accounts?access_token=EAAMfvTfUa48BACxpgjdMTHxmmTBxKwLAdVnBaHv4KkCNCRCMhWvV6Y8kfKBhFyoA2Cv4VsOobbN0t31wG8K9wMwfryY31gvaj5guKYwsDmgNUmI3gO88t3x48EZCwAbnPDsZCUQIWYEhXUBOgqSfhuhvFOVZCpJlYqXXZBZBzbXNUzXh4QwETH0zNvW5CknBnkzjAxY4ZBLwZDZD";




                using (var http = new HttpClient())
                {
                    var httpResponse = await http.GetAsync(url);
                    var httpContent = await httpResponse.Content.ReadAsStringAsync();

                    return httpContent;
                }
            });
            var rezJson = JObject.Parse(rez.Result);
            Console.WriteLine(rezJson);*/
        }
    }


}
