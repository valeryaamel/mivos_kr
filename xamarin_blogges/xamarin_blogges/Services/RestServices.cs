using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using xamarin_blogges.Models.Input;
using xamarin_blogges.Models.Output;

namespace xamarin_blogges.Services
{
    public class RestServices : IRestServices
    {
        private readonly string _url = "http://www.bloge.somee.com/";

        public async Task<Comments> AddComment(Comments comment)
        {
            HttpClient client = new HttpClient();
            JsonSerializerOptions serializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };

            var json = System.Text.Json.JsonSerializer.Serialize<Comments>(comment, serializerOptions);
            StringContent stringContent = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync(_url + "api/Comment", stringContent);
            HttpContent responseContent = response.Content;
            var json2 = await responseContent.ReadAsStringAsync();
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return JsonConvert.DeserializeObject<Comments>(json2);
            }
            else throw new Exception(json2);

        }

        public async Task<bool> DeleteComment(int id)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.DeleteAsync(_url + $"api/Comment/{id}");
            return true;
        }

        public async Task<bool> DeletePost(int id)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.DeleteAsync(_url + $"api/Post/{id}");
            return true;
        }

        public async Task<List<Category>> GetCategoriesAsync()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(_url + "api/Categorie");
            if (response.StatusCode == HttpStatusCode.OK)
            {
                HttpContent responseContent = response.Content;
                var json = await responseContent.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Category>>(json);
            }
            else throw new Exception();
        }

        public async Task<List<Language>> GetLanguagesAsync()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(_url + "api/Language");
            if (response.StatusCode == HttpStatusCode.OK)
            {
                HttpContent responseContent = response.Content;
                var json = await responseContent.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Language>>(json);
            }
            else throw new Exception();
        }

        public async Task<List<Post>> GetPostsAsync()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(_url + "api/Post");
            if (response.StatusCode == HttpStatusCode.OK)
            {
                HttpContent responseContent = response.Content;
                var json = await responseContent.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Post>>(json);
            }
            else throw new Exception();
        }

        public async Task<User> Registration(Registration registration)
        {
            HttpClient client = new HttpClient();
            var url = _url + "api/User";

            JsonSerializerOptions serializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };

            var json = System.Text.Json.JsonSerializer.Serialize<Registration>(registration, serializerOptions);
            StringContent stringContent = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync(url, stringContent);
            HttpContent responseContent = response.Content;
            var json2 = await responseContent.ReadAsStringAsync();
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return JsonConvert.DeserializeObject<User>(json2);
            }
            else throw new Exception(json2);
        }

        public async Task<bool> SentPost(AddPost post)
        {
            HttpClient client = new HttpClient();
            var url = _url + "api/Post";

            JsonSerializerOptions serializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };

            var json = System.Text.Json.JsonSerializer.Serialize<AddPost>(post, serializerOptions);
            StringContent stringContent = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync(url, stringContent);
            HttpContent responseContent = response.Content;
            var json2 = await responseContent.ReadAsStringAsync();
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return true;
            }
            else throw new Exception(json2);
        }

        public async Task<User> SignIn(string username, string password)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(_url + $"api/User/{username}/{password}");
            HttpContent responseContent = response.Content;
            var json = await responseContent.ReadAsStringAsync();
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return JsonConvert.DeserializeObject<User>(json);
            }
            else throw new Exception(json);
        }
    }
}
