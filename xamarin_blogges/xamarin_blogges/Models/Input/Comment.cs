using Newtonsoft.Json;
using System;

namespace xamarin_blogges.Models.Input
{
    public class Comment
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("user")]
        public string Username { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("text")]
        public string Text { get; set; }
        [JsonProperty("date")]
        public DateTime Date { get; set; }
    }
}
