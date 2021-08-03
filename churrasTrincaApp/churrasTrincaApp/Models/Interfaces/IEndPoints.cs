using Refit;
using System.Threading.Tasks;

namespace churrasTrincaApp.Models.Interfaces
{
    public interface IEndPoints
    {
        #region Gets
        [Get("/bbq")]
        [Headers("Authorization: Bearer")]
        Task<ApiResponse<CardsChurrasModel>> GetChurrascos([Header("Authorization")] string authorization);

        [Get("/bbq/participants/{id}")]
        [Headers("Authorization: Bearer")]
        Task<ApiResponse<ListPeopleModel>> GetDetalhesChurrasco(int id, [Header("Authorization")] string authorization);
        #endregion

        #region Posts
        [Post("/bbq/auth")]
        Task<ApiResponse<TokenModel>> GetAutentication([Body] LoginModel login);

        [Post("/bbq")]
        [Headers("Authorization: Bearer")]
        Task<ApiResponse<string>> CreateChurras([Header("Authorization")] string authorization, [Body] DataCardsChurras churras);
        #endregion

        #region Patch e Put 
        #endregion

        #region Delete
        [Delete("/bbq/{id}")]
        [Headers("Authorization: Bearer")]
        Task<ApiResponse<string>> DeleteChurras(int id, [Header("Authorization")] string authorization);
        #endregion
    }
}
