using CryptoLinkReader.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;

namespace CryptoLinkReader.Controllers
{
    public class HomeController : Controller
    {
       

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Index(CryptoLinkModel cryptoModel)
        {
            var url = cryptoModel.URL;
            using var client = new HttpClient();
            client.DefaultRequestHeaders.Add("User-Agent", "C# console program");

            //var content = await client.GetStringAsync("http://webcode.me");

             var content = await client.GetStringAsync(url);
            string myEncodedString = HttpUtility.HtmlEncode(content.ToLower());        

            string[] splitcontent = content.Split("<");
             string Bitcoin = "Bitcoin".ToLower();
             string Tether = "Tether".ToLower();
             string Etherium = "Etherium".ToLower();
             string DogeCoin = "DogeCoin".ToLower();
             string USDCoin = "USDCoin".ToLower();

             var raising = "raising".ToLower();
            var falling = "falling".ToLower();
            var countrising = 0;
            var countfalling = 0;

            for (int i = 0; i < splitcontent.Length; i++)
            {
                if (splitcontent[i].Contains(raising.ToLower()) && splitcontent[i].Contains(raising.ToLower()))
                {
                    countrising++;
                    countfalling++;
                }
                if (splitcontent[i].Contains(raising))
                {
                    countrising++;
                }
                if (splitcontent[i].Contains(falling))
                {
                    countfalling++;
                }

                cryptoModel.RaisingCounter = countrising;
                cryptoModel.FallingCounter = countfalling;

                if (splitcontent[i].Contains(Bitcoin.ToLower()))
                {
                    cryptoModel.Title = Bitcoin;
                    cryptoModel.img = "download.jpg";
                }
                if (splitcontent[i].Contains(Tether.ToLower()))
                {
                    cryptoModel.Title = Tether;
                    cryptoModel.img = "tether.jpg";
                }
                if (splitcontent[i].Contains(Etherium.ToLower()))
                {
                    cryptoModel.Title = Etherium;
                    cryptoModel.img = "etherium).jpg/";
                }
                if (splitcontent[i].Contains(DogeCoin.ToLower()))
                {
                    cryptoModel.Title = DogeCoin;
                    cryptoModel.img = "dogecoin.jpg";
                }
                if (splitcontent[i].Contains(USDCoin.ToLower()))
                {
                    cryptoModel.Title = USDCoin;
                    cryptoModel.img = "usdCoin.jpg";
                }
            }

            return RedirectToAction("IndexResult", "Home", cryptoModel);
        }

        public IActionResult IndexResult(CryptoLinkModel cryptoModel)
        {
            return View(cryptoModel);
        }
        //public IActionResult Index()
        //{
        //    return View();
        //}
        //[HttpGet]
        //public async Task<IActionResult> Index()
        //{
        //    string raising = "raising";
        //    string falling = "falling";
        //    int raisingCounter = 0;
        //    int fallingCounter = 0;

        //    string meta = "meta";
        //    int metaCounter = 0;

        //    using var client = new HttpClient();
        //    client.DefaultRequestHeaders.Add("User-Agent", "C# console program");

        //    var content = await client.GetStringAsync("https://stackoverflow.com/questions/1048199/easiest-way-to-read-from-a-url-into-a-string-in-net");
        //    var content = await client.GetStringAsync("");
        //    //var content = await client.GetStringAsync(urlString);

        //    string myEncodedString = HttpUtility.HtmlEncode(content.ToLower());

        //    for (int i = 0; i < content.Length; i++)
        //    {
        //        if (content.Contains(raising))
        //        {
        //            raisingCounter++;
        //        }
        //        else if (content.Contains(falling))
        //        {
        //            fallingCounter++;
        //        }
        //    }


        //    CryptoLinkModel cryptoModel = new CryptoLinkModel();
        //    cryptoModel.RaisingCounter = raisingCounter;
        //    cryptoModel.FallingCounter = fallingCounter;

        //    return View(cryptoModel);
        //}

        //[HttpPost]
        //public async Task<IActionResult> IndexResult(string urlString)
        //{
        //    string raising = "raising";
        //    string falling = "falling";
        //    int raisingCounter = 0;
        //    int fallingCounter = 0;

        //    string meta = "meta";
        //    int metaCounter = 0;

        //    using var client = new HttpClient();
        //    client.DefaultRequestHeaders.Add("User-Agent", "C# console program");

        //    //var content = await client.GetStringAsync("http://webcode.me");
        //    var content = await client.GetStringAsync(urlString);

        //    string myEncodedString = HttpUtility.HtmlEncode(content.ToLower());

        //    for(int i = 0; i < content.Length; i++)
        //    {
        //        if (content.Contains(raising)
        //        {
        //            raisingCounter++;
        //        }
        //        else if (content.Contains(falling))
        //        {
        //            fallingCounter++;
        //        }
        //    }
        //    //}for (int i = 0; i < content.Length; i++)
        //    //{
        //    //    if (content[i] == raising)
        //    //    {
        //    //        raisingCounter++;
        //    //    }
        //    //    else if (content[i] == falling)
        //    //    {
        //    //        fallingCounter++;
        //    //    }
        //    //}

        //    CryptoLinkModel cryptoModel = new CryptoLinkModel();
        //    cryptoModel.RaisingCounter = raisingCounter;
        //    cryptoModel.FallingCounter = fallingCounter;

        //    return View(cryptoModel);
        //}

       

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
