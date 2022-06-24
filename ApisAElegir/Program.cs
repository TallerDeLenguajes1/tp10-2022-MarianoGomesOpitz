// See https://aka.ms/new-console-template for more information
using System;
using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ApisVarias
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var links = new string[] {
                $"https://age-of-empires-2-api.herokuapp.com/api/v1/civilizations",
                $"https://age-of-empires-2-api.herokuapp.com/api/v1/units",
                $"https://age-of-empires-2-api.herokuapp.com/api/v1/structures",
                $"https://age-of-empires-2-api.herokuapp.com/api/v1/technologies"
                }; //Los links de las respectivas apis

            int k;
            do
            {
                Console.WriteLine("\nElija que tipo de contenido mostrar:");
                Console.WriteLine("Civilizaciones: 1");
                Console.WriteLine("Unidades: 2");
                Console.WriteLine("Estructuras: 3");
                Console.WriteLine("Tecnologías: 4");
                k = (Convert.ToInt32(Console.ReadLine())) - 1;
            } while (k < 0 || k > 3);//Se elige cual es la api a mostrar

            string url = links[k]; //Como ya se posee cual es la api, voy realizando el request
            HttpWebRequest request = ProcesoRequest(url);

            //Utilizo un switch para obtener la clase de la api elegida
            switch (k)
            {
                case 0:
                    RootCivilization civ = null;
                    civ = JsonCivilizaciones(request, civ);//Obtengo la api de las civilizaciones
                    break;

                case 1:
                    RootUnit uni = null;
                    //Obtengo la api de las unidades
                    uni = JsonUnidades(request, uni);
                    break;

                case 2:
                    RootStructure estu = null;
                    //Obtengo la api de las estructuras
                    estu = JsonEstructuras(request, estu);
                    break;

                case 3:
                    RootTechnology tech = null;
                    //Obtengo la api de las tecnologías
                    tech = JsonTecnologias(request, tech);

                    break;
            }
        }

        private static RootTechnology JsonTecnologias(HttpWebRequest request, RootTechnology tech)
        {
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

                                tech = JsonSerializer.Deserialize<RootTechnology>(texto);

                                foreach (var item in tech.Technologies)
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

            return tech;
        }

        private static RootStructure JsonEstructuras(HttpWebRequest request, RootStructure estu)
        {
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

                                estu = JsonSerializer.Deserialize<RootStructure>(texto);

                                foreach (var item in estu.Structures)
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

            return estu;
        }

        private static RootUnit JsonUnidades(HttpWebRequest request, RootUnit uni)
        {
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

                                uni = JsonSerializer.Deserialize<RootUnit>(texto);

                                foreach (var item in uni.Units)
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

            return uni;
        }

        private static RootCivilization JsonCivilizaciones(HttpWebRequest request, RootCivilization civ)
        {

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

                                civ = JsonSerializer.Deserialize<RootCivilization>(texto);

                                foreach (var item in civ.Civilizations)
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

            return civ;
        }

        private static HttpWebRequest ProcesoRequest(string url)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/json";
            request.Accept = "application/json";
            return request;
        }
    }
}
