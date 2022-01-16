using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace xamarin_blogges.Models.Output
{
    public class AddPost
    {
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("text")]
        public string Text { get; set; }
        [JsonProperty("date")]
        public DateTime Date { get; set; }
        [JsonProperty("userId")]
        public int UserId { get; set; }
        [JsonProperty("categories")]
        public int[] Categories { get; set; }
        [JsonProperty("languages")]
        public int[] Languages { get; set; }
    }
}
