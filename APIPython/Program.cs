using System;
using System.Collections.Generic;
using System.Data;
using Newtonsoft.Json;
using System.IO;

namespace APIPython
{
    class Clients
    {
        static void Main(string[] args)
        {

            Clients task = new Clients();
            
            string clientsconfig = task.DataLoadJson();

           // Console.WriteLine(clientsconfig);

            List<Parameters> items = JsonConvert.DeserializeObject<List<Parameters>>(clientsconfig);
            //Console.WriteLine("Items", items);

            foreach (Parameters client in items)
            {
                //Console.WriteLine("Hi JP!!");
                DataManipulation data = new DataManipulation();
                DataTable cases = new DataTable();
                HtmlBody body = new HtmlBody();
                SendEmails email = new SendEmails();
                String htmlBody;
                cases = data.ExecuteCommand("python CurrentMonth.py > CurrentMonth.txt");
                //Console.WriteLine("After ExecuteCommand");
               // Console.WriteLine(cases);

                htmlBody = body.MailBodyData(cases);
                email.sendEmail(htmlBody, client);

            }

           // Console.WriteLine("Hey!!");
           // Console.ReadLine();
            
        }

        public string DataLoadJson()
        {
            using (StreamReader r = new StreamReader("clients.json"))
            {
                string json = r.ReadToEnd();

                return json;
            }
        }

    }

}

