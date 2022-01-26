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
            Facebook facebook = new Facebook("EAAMfvTfUa48BAMVi3mkBdUT9NIdYO0XAGDx4uVfMPdZAI4AHD1fF6eItQgiJwYY2AtZAdY7itufNAEgbybItupCx0X948MqAGAKL6LFxaA4QjuuQRQZARlZBYivA1siRZCn3BnPndxZBZCxCq4ZC4fDa7nCVYRXJayf6OjZCuKou3kBlZCILDPYzqJ", "104587057971075");
            Job Jobs = new Job();
            Jobs.Title = "Office Admin Assistant";
            Jobs.Description = $@"We are looking for a reliable Office Administrator. They will undertake administrative tasks, ensuring the rest of the staff has adequate support to work efficiently.

 

The tasks of the office administrator will include bookkeeping and mentoring office assistants. The ideal candidate will be competent in prioritizing and working with little supervision. They will be self-motivated and trustworthy.

 

The office administrator ensures smooth running of our company’s offices and contributes in driving sustainable growth.

Responsibilities

- Coordinate office activities and operations to secure efficiency and compliance to company policies

- Supervise administrative staff and divide responsibilities to ensure performance

- Manage agendas/travel arrangements/appointments etc. for the upper management

- Manage phone calls and correspondence (e-mail, letters, packages etc.)

- Support budgeting and bookkeeping procedures

- Create and update records and databases with personnel, financial and other data

- Track stocks of office supplies and place orders when necessary

- Submit timely reports and prepare presentations/proposals as assigned

- Assist colleagues whenever necessary";
            Jobs.Location = "JHB Central";
            Jobs.Company = "VSCO Ltd";
            var rezText = Task.Run(async () =>
             {

                 using (var http = new HttpClient())
                 {
                     return await facebook.PublishSimplePost(Jobs.ToString());
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
