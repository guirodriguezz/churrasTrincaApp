using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;

namespace churrasTrincaApp.Models
{
    public partial class CardsChurrasModel
    {
        [JsonProperty("data")]
        public ObservableCollection<DataCardsChurras> DataCardsChurras { get; set; }
    }

    public partial class DataCardsChurras
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("date")]
        public DateTimeOffset Date { get; set; }

        [JsonProperty("value_per_person")]
        public double ValuePerPerson { get; set; }
    }
}