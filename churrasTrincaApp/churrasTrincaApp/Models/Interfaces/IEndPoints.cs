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
        #endregion

        #region Posts
        [Post("/bbq/auth")]
        Task<ApiResponse<TokenModel>> GetAutentication([Body] string serialized);
        #endregion

        #region Patch e Put 
        #endregion

        #region Delete
        #endregion
    }
}
