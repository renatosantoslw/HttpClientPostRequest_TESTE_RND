using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using HtmlAgilityPack;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using System.Security.Principal;
using System.Text.Json;
using System.Runtime.Serialization;
using System.Net.Http;

namespace HttpClientPostRequest
{
    internal class HttpCli
    {
        //CASO QUEIRA ENVIAR UM ARQUIVO BEM GRANDE
        public static string strTXTBiblia = string.Empty;
               
        public static void Client(long i)
        {
            Random rnd = new Random();
            var strRNS = rnd.Next(000000, 999999).ToString("D6");
            Console.ForegroundColor = ConsoleColor.White;
            //Console.WriteLine($"TaskAtualID: {Task.CurrentId}");
            Console.Write($"Testando Combinações:");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"{strRNS}");
                
            try
            {              
                CookieContainer cookies = new CookieContainer();
                HttpClientHandler handler = new HttpClientHandler();
                handler.CookieContainer = cookies;
                handler.UseCookies = true;
                handler.AllowAutoRedirect = true;

                using (HttpClient client = new HttpClient(handler))
                {
                    var strSeuNome = "Renato";
                    var strUsuario = "admin";
                                      
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Add("User-Agent", "App");
                    client.DefaultRequestHeaders.Add("usuario", $"{strSeuNome}");

                    client.DefaultRequestHeaders.Authorization
                    = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer",
                    Convert.ToBase64String(Encoding.ASCII.GetBytes($"{strUsuario}:{strRNS}")));
                    string strGETDNS = "http://localhost:81/login/";
                    var Response = client.GetAsync(strGETDNS).Result;

                    if (Response.StatusCode == HttpStatusCode.OK)
                    {
                        //Console.Clear();                                             
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write($"Combinação encontrada:");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"{strRNS}");
                        Console.ForegroundColor = ConsoleColor.White;
                        var ContentResponse1 = Response.Content.ReadAsStringAsync().Result;
                        Console.WriteLine(ContentResponse1);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Read(); 
                        //Task.WaitAll(Task.Delay(900000));   
                        //Thread.Sleep(900000);
                    }

                    
                    //Console.ForegroundColor = ConsoleColor.Green;
                    //Console.WriteLine($"{i} - Resposta = {(int)Response.StatusCode} - {Response.ReasonPhrase}");
                    //Console.Write($"Testando combinações: ");
                    //Console.WriteLine($"{strRNS}");
                    //var ContentResponse = Response.Content.ReadAsStringAsync().Result;
                    //Console.WriteLine(ContentResponse);                
                    //Console.ForegroundColor = ConsoleColor.White;
                    //Thread.Sleep(500);
                    //Console.Clear();
                }
            }
            catch (Exception ex)
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"ChildTaskException: {ex.Message}");
                    Console.ForegroundColor = ConsoleColor.White;

                    /*
                    using (StreamWriter writer = new StreamWriter($"ChildTaskException{i}.txt", append: false))
                    {
                        writer.WriteLine($"ChildTaskException: {ex.Message}");
                    }
                    */
                }
                catch (Exception exx)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"ChildTaskException_GravarArquivoTXT: {exx.Message}");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
        }
    
    
    
    }
}
