// See https://aka.ms/new-console-template for more information
using System;
using System.IO;
using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Civilizaciones
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var url = $"https://age-of-empires-2-api.herokuapp.com/api/v1/civilizations";
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/json";
            request.Accept = "application/json";

            Root civ = null;

            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream strReader = response.GetResponseStream())
                    {
                        if (strReader != null)
                        {
                            using (StreamReader objReader = new StreamReader(strReader))
                            {
                                string texto = objReader.ReadToEnd();

                                civ = JsonSerializer.Deserialize<Root>(texto);

                                foreach (var item in civ.Civilization)
                                {
                                    Console.WriteLine($"ID: {item.Id}, Nombre: {item.Name}");
                                }

                            }
                        }
                    }
                }
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}
