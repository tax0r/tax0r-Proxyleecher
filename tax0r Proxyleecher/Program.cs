using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using tax0r_Proxyleecher.Classes;
using Console = Colorful.Console;

namespace tax0r_Proxyleecher
{
    class Program
    {
        static void Main(string[] args)
        {
            int scrapedAmount = 0;
            int sourcesAmount = 0;
            string pGood = "{ + } ";
            string pNeutral = "{ = } ";
            
            FileClass fileClass = new FileClass();
            LeecherClass leecherClass = new LeecherClass();
            
            Console.Title = $"tax0r's Proxyleecher 2021 - Scraped -> {scrapedAmount} | Sources -> {sourcesAmount}";

            Console.WriteLine($"{pGood}Drag&Drop sources.txt", Color.LightPink);
            
            string input = Console.ReadLine();
            string toReplace = '"'.ToString();
            string path = input.Replace(toReplace, string.Empty);
            string[] sources = fileClass.Read(path);
            List<string> proxies = new List<string>();

            sourcesAmount = sources.Length;
            Console.Title = $"tax0r's Proxyleecher 2021 - Scraped -> {scrapedAmount} | Sources -> {sourcesAmount}";

            foreach (string source in sources)
            {
                Console.WriteLine(pNeutral + source, Color.Green);
                
                string[] proxiesFound = leecherClass.GetProxies(source);
                foreach (string proxieFound in proxiesFound)
                {
                    Console.WriteLine(pGood + proxieFound, Color.LightGreen);
                    proxies.Add(proxieFound);
                    scrapedAmount++;
                    Console.Title = $"tax0r's Proxyleecher 2021 - Scraped -> {scrapedAmount} | Sources -> {sourcesAmount}";
                }
            }

            string[] disctinctProxies = proxies.Distinct().ToArray();
            Console.WriteLine($"{pNeutral}Total proxies found -> " + proxies.ToArray().Length, Color.LightPink);
            Console.WriteLine($"{pNeutral}Distinct proxies found -> "+ disctinctProxies.Length, Color.LightPink);

            path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\" + fileClass.Name(disctinctProxies.Length);
            fileClass.Save(path, disctinctProxies);

            Console.WriteLine("press any key to continue...");
            Console.ReadKey();
        }
    }
}
