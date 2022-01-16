using Newtonsoft.Json;

namespace xamarin_blogges.Models.Input
{
    public class Category
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
