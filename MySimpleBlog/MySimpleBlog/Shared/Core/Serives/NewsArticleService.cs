using MySimpleBlog.Shared.Core.Interfaces;
using MySimpleBlog.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace MySimpleBlog.Shared.Core.Serives
{
    public class NewsArticleService : INewsArticleService
    {
        private readonly HttpClient _httpClient;

        public NewsArticleService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        //using a service to get all News Articles from the NewsArticle API 
        public async Task<IEnumerable<NewsArticle>> GetAllAsync()
        {
            return await _httpClient.GetFromJsonAsync<NewsArticle[]>("api/NewsArticle");
        }

        //using a service to get one News Article by ID from the NewsArticle API 
        public async Task<NewsArticle> GetAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<NewsArticle>($"api/NewsArticle/{id}");
        }
    }
}
