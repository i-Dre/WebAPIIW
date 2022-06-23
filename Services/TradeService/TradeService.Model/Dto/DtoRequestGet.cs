using Newtonsoft.Json;
using System;

namespace TradeService.Model.Dto
{
    public class DtoRequestGet
    {
        [JsonProperty(PropertyName = "id")]
        public Guid Id { get; set; }
    }
}
