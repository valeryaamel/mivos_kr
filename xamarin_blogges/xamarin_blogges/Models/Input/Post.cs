using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace xamarin_blogges.Models.Input
{
    public class Post
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("text")]
        public string Text { get; set; }
        [JsonProperty("date")]
        public DateTime Date { get; set; }
        [JsonProperty("user")]
        public string Username { get; set; }
        [JsonProperty("categories")]
        public ICollection<Category> Categories { get; set; }
        [JsonProperty("languages")]
        public ICollection<Language> Languages { get; set; }
        [JsonProperty("comments")]
        public ICollection<Comment> Comments { get; set; }
    }
}
