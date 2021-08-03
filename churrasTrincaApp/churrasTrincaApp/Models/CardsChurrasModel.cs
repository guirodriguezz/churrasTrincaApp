using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;

namespace churrasTrincaApp.Models
{
    public partial class CardsChurrasModel
    {
        [JsonProperty("data")]
        public ObservableCollection<DataCardsChurras> Data { get; set; }
    }

    public partial class DataCardsChurras
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("date")]
        public DateTime Date { get; set; }

        public double value_per_person { get; set; }

        [JsonProperty("participants")]
        public ObservableCollection<DataListPeople> Participants { get; set; }
    }
}