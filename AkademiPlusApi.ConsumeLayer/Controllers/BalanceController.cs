﻿using AkademiPlusApi.ConsumeLayer.Models;
using AkademiPlusApi.ConsumeLayer.Models.BalanceViewModel;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AkademiPlusApi.ConsumeLayer.Controllers
{
    public class BalanceController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BalanceController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44356/api/Balance");
            
            if(responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<BalanceListViewModel>>(jsonData);
                var customerResponseMessage = await client.GetAsync("https://localhost:44356/api/Customer");
                if (customerResponseMessage.IsSuccessStatusCode)
                {
                    var jsonDataCustomer = await customerResponseMessage.Content.ReadAsStringAsync();
                    var valuesCustomer = JsonConvert.DeserializeObject<List<CustomerListViewModel>>(jsonDataCustomer);
                    foreach (var item in values)
                    {
                        var customer = valuesCustomer.FirstOrDefault(x=>x.AccountNumber == item.AccountNumber);
                        item.Name = customer.CustomerName + " " + customer.CustomerSurname;
                    }
                }

                return View(values);
            }
            
            return View();
        }
        [HttpGet]
        public IActionResult AddBalance()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddBalance(BalanceAddViewModel balanceAddViewModel)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(balanceAddViewModel);
            StringContent stringContent= new StringContent(jsonData,Encoding.UTF8,"application/json");
            var responseMessage = await client.PostAsync("https://localhost:44356/api/Balance", stringContent);
            if(responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        public async Task<IActionResult> DeleteBalance (int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync("https://localhost:44356/api/Balance?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> UpdateBalance(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44356/api/Balance/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData =await responseMessage.Content.ReadAsStringAsync();
                var values =JsonConvert.DeserializeObject<BalanceUpdateViewModel>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateBalance(BalanceUpdateViewModel balanceUpdateViewModel)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(balanceUpdateViewModel);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:44356/api/Balance/", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
