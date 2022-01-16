using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace xamarin_blogges.Models.Input
{
    public class User
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("login")]
        public string Login { get; set; }
        [JsonProperty("Email")]
        public string Email { get; set; }
        [JsonProperty("comments")]
        public ICollection<Comments> Comments { get; set; }
        [JsonProperty("posts")]
        public ICollection<Posts> Posts { get; set; }
    }

    public class Comments
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("text")]
        public string Text { get; set; }
        [JsonProperty("date")]
        public DateTime Date { get; set; }
        [JsonProperty("userid")]
        public int UserId { get; set; }
        [JsonProperty("postid")]
        public int PostId { get; set; }
    }

    public class Posts
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("text")]
        public string Text { get; set; }
        [JsonProperty("date")]
        public DateTime Date { get; set; }
    }
}
