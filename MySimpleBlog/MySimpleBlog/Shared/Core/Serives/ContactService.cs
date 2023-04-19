using MySimpleBlog.Shared.Core.Interfaces;
using MySimpleBlog.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace MySimpleBlog.Shared.Core.Serives
{
    public class ContactService : IContactService
    {
        private readonly HttpClient _httpClient;

        public ContactService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        //using a service to get all Blog Contacts from the BlogContacts API 
        public async Task<IEnumerable<BlogContact>> GetAllAsync()
        {
            return await _httpClient.GetFromJsonAsync<BlogContact[]>("api/BlogContacts");
        }

        //using a service to get one Blog Contact by ID from the BlogContacts API 
        public async Task<BlogContact> GetAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<BlogContact>($"api/BlogContacts/{id}");
        }

        //Saving Blog Contact Message
        public async Task<string> PostAsync(BlogContact blogContact) 
        {
            var response = await _httpClient.PostAsJsonAsync("api/BlogContacts", blogContact);
            return response.IsSuccessStatusCode.ToString();
        }
    }
}
