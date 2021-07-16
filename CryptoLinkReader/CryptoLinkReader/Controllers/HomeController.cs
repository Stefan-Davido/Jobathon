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

            var content = await client.GetStringAsync(url);
            string myEncodedString = HttpUtility.HtmlEncode(content.ToLower());        
 
            string[] splitcontent = content.Split("<");
            string Bitcoin = "Bitcoin".ToLower();
            string Tether = "Tether".ToLower();
            string Ethereum = "Ethereum".ToLower();
            string DogeCoin = "DogeCoin".ToLower();
            string USDCoin = "USDCoin".ToLower();

            var raising = "raising".ToLower();
            var falling = "falling".ToLower();
            var countrising = 0;
            var countfalling = 0;

            int BitcoinCounter = 0;
            int DogeCoinCounter = 0;
            int EthereumCounter = 0;
            int TetherCounter = 0;
            int USDCoinCounter = 0;

            for (int i = 0; i < splitcontent.Length; i++)
            {
                if (splitcontent[i].Contains(raising.ToLower()) && splitcontent[i].Contains(falling.ToLower()))
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

                if (splitcontent[i].ToLower().Contains(Bitcoin.ToLower()))
                {
                    BitcoinCounter += 1;
                }
                if (splitcontent[i].ToLower().Contains(Tether.ToLower()))
                {
                    TetherCounter += 1;
                }
                if (splitcontent[i].ToLower().Contains(Ethereum.ToLower()))
                {
                    EthereumCounter += 1;
                }
                if (splitcontent[i].ToLower().Contains(DogeCoin.ToLower()))
                {
                    DogeCoinCounter += 1;
                }
                if (splitcontent[i].ToLower().Contains(USDCoin.ToLower()))
                {
                    USDCoinCounter += 1;
                }                
            }

            if(BitcoinCounter > EthereumCounter &&
                BitcoinCounter > DogeCoinCounter &&
                BitcoinCounter > TetherCounter &&
                BitcoinCounter > USDCoinCounter)
            {
                cryptoModel.Title = Bitcoin;
                cryptoModel.img = "download.jpg";
            }
            else if(EthereumCounter > BitcoinCounter &&
                EthereumCounter > DogeCoinCounter &&
                EthereumCounter > TetherCounter &&
                EthereumCounter > USDCoinCounter)
            {
                cryptoModel.Title = Ethereum;
                cryptoModel.img = "etherium).jpg";
            } 
            else if(DogeCoinCounter > BitcoinCounter &&
                DogeCoinCounter > EthereumCounter &&
                DogeCoinCounter > TetherCounter &&
                DogeCoinCounter > USDCoinCounter)
            {
                cryptoModel.Title = DogeCoin;
                cryptoModel.img = "dogecoin.jpg";
            }
            else if(TetherCounter > BitcoinCounter &&
                TetherCounter > DogeCoinCounter &&
                TetherCounter > EthereumCounter &&
                TetherCounter > USDCoinCounter)
            {
                cryptoModel.Title = Tether;
                cryptoModel.img = "tether.jpg";
            }
            else if(USDCoinCounter > BitcoinCounter &&
                USDCoinCounter > DogeCoinCounter &&
                USDCoinCounter > TetherCounter &&
                USDCoinCounter > EthereumCounter)
            {
                cryptoModel.Title = USDCoin;
                cryptoModel.img = "usdCoin.jpg";
            }

            return View(cryptoModel);
        }     
    }
}
