using Newtonsoft.Json;

namespace churrasTrincaApp.Models
{
    public class TokenModel
    {
        [JsonProperty("token")]
        public string Token { get; set; }
    }
}
