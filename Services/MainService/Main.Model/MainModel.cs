using Newtonsoft.Json;
using System;

namespace Main.Model
{
    public class MainModel
    {
        [JsonIgnore]
        [JsonProperty(PropertyName = "id")]
        public Guid Id { get; set; } = Guid.NewGuid();
        [JsonIgnore]
        [JsonProperty(PropertyName = "isDeleted")]
        public bool IsDeleted { get; set; }
    }
}
