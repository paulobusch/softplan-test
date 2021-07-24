using System.Text.Json.Serialization;

namespace Softplan.Domain.Params
{
    public class FeesParams
    {
        [JsonPropertyName("valorinicial")]
        public decimal Capital { get; set; }

        [JsonPropertyName("meses")]
        public int Time { get; set; }

        [JsonIgnore] 
        public decimal Fee { get; set; }
    }
}
