using Newtonsoft.Json;
using System;

namespace Main.Model.Dto
{
    public class DtoMainModel
    {
        [JsonIgnore]
        [JsonProperty(PropertyName = "id")]
        public Guid Id { get; set; } = Guid.NewGuid();
        //TODO Добавить ис делит?
    }
}
