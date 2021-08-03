using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace churrasTrincaApp.Models
{
    public class ListPeopleModel
    {
        [JsonProperty("data")]
        public ObservableCollection<DataListPeople> Data { get; set; }
    }

    public partial class DataListPeople
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("confirmed")]
        public bool Confirmed { get; set; }

        public double value_paid { get; set; }
    }
}