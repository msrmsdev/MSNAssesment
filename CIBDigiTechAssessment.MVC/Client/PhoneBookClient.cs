using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using CIBDigiTechAssessment.MVC.Models;

namespace CIBDigiTechAssessment.MVC.Client
{

    public class PhoneBookClient
    {
        private string Base_URL = ConfigurationManager.AppSettings["apiUrl_Path"];

        public IEnumerable<PhoneBook> findAll()
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(Base_URL);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync("PhoneBooks").Result;

                if (response.IsSuccessStatusCode)
                    return response.Content.ReadAsAsync<IEnumerable<PhoneBook>>().Result;
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public PhoneBook find(int? id)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(Base_URL);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync("PhoneBooks/" + id).Result;

                if (response.IsSuccessStatusCode)
                    return response.Content.ReadAsAsync<PhoneBook>().Result;
                return null;
            }
            catch
            {
                return null;
            }
        }

        public bool Create(PhoneBook phoneBook)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(Base_URL);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.PostAsJsonAsync("PhoneBooks", phoneBook).Result;
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }
    }
}