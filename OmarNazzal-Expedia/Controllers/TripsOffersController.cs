using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OmarNazzalExpedia.Models;

namespace OmarNazzalExpedia.Controllers
{
    public class TripsOffersController : Controller
    {
        string tripsOffers;
        public async Task<IActionResult> Index()
        {
            var url = "https://offersvc.expedia.com/offers/v2/getOffers?scenario=deal-finder&page=foo&uid=foo&productType=Hotel";
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage response = await client.GetAsync(url))
                {
                    using (HttpContent content = response.Content)
                    {
                        tripsOffers = await content.ReadAsStringAsync();
                    }

                }
            }
            Trips trips = JsonConvert.DeserializeObject<Trips>(tripsOffers);
            ViewBag.Hotels = trips.offers.Hotel;

            return View();


        }

        public async Task<IActionResult> Filter(string city)
        {
            var url = "https://offersvc.expedia.com/offers/v2/getOffers?scenario=deal-finder&page=foo&uid=foo&productType=Hotel&destinationName=" + city;
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage response = await client.GetAsync(url))
                {
                    using (HttpContent content = response.Content)
                    {
                        tripsOffers = await content.ReadAsStringAsync();
                    }

                }
            }
            Trips trips = JsonConvert.DeserializeObject<Trips>(tripsOffers);
            ViewBag.Hotels = trips.offers.Hotel;

            return View();
        }

 
    }
}
