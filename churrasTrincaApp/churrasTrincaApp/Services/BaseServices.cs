using churrasTrincaApp.Models;
using churrasTrincaApp.Models.Interfaces;
using Refit;
using System.Threading.Tasks;

namespace churrasTrincaApp.Services
{
    public static class BaseServices
    {
        private static string BaseUrl => "https://trinca-api.herokuapp.com";
        private static IEndPoints Endpoint => RestService.For<IEndPoints>(BaseUrl);

        #region Gets
        public static async Task<ApiResponse<CardsChurrasModel>> GetChurrascos()
        {
            string token = SharedServices.SavedToken.Token;

            return await Endpoint.GetChurrascos(token);
        }

        public static async Task<ApiResponse<ListPeopleModel>> GetDetalhesChurrasco(int id)
        {
            string token = SharedServices.SavedToken.Token;

            return await Endpoint.GetDetalhesChurrasco(id, token);
        }
        #endregion

        #region Posts
        public static async Task<ApiResponse<TokenModel>> GetAutentication(string username, string password)
        {
            LoginModel login = new LoginModel()
            {
                Username = username,
                Password = password
            };

            SharedServices.Saveduser = login;

            return await Endpoint.GetAutentication(login);
        }

        public static async Task<ApiResponse<string>> CreateChurras(DataCardsChurras churras)
        {
            string token = SharedServices.SavedToken.Token;

            return await Endpoint.CreateChurras(token, churras);
        }
        #endregion

        #region Delete
        public static async Task<ApiResponse<string>> DeleteChurras(int id)
        {
            string token = SharedServices.SavedToken.Token;

            return await Endpoint.DeleteChurras(id, token);
        }
        #endregion
    }
}