using Newtonsoft.Json;
using churrasTrincaApp.Models;
using Xamarin.Essentials;

namespace churrasTrincaApp.Services
{
    public static class SharedServices
    {
        public static TokenModel SavedToken
        {
            get
            {
                TokenModel savedList = Deserialize<TokenModel>(Preferences.Get(nameof(SavedToken), null));
                return savedList ?? new TokenModel();
            }
            set
            {
                string serializedList = Serialize(value);
                Preferences.Set(nameof(SavedToken), serializedList);
            }
        }

        static T Deserialize<T>(string serializedObject) => JsonConvert.DeserializeObject<T>(serializedObject);

        static string Serialize<T>(T objectToSerialize) => JsonConvert.SerializeObject(objectToSerialize);
    }
}
