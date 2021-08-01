using churrasTrincaApp.Models;
using churrasTrincaApp.Models.Interfaces;
using Newtonsoft.Json;
using Refit;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace churrasTrincaApp.Services
{
    public static class BaseServices
    {
        private static string BaseUrl => "https://trinca-api.herokuapp.com";
        private static IEndPoints Endpoint => RestService.For<IEndPoints>(BaseUrl);

        #region Gets
        public static async Task<ApiResponse<CardsChurrasModel>> GetChurrascos(string username, string password)
        {
            LoginModel login = new LoginModel()
            {
                Username = username,
                Password = password
            };

            string serialized = JsonConvert.SerializeObject(login);

            return await Endpoint.GetChurrascos(serialized); ;
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

            string serialized = JsonConvert.SerializeObject(login);

            return await Endpoint.GetAutentication(serialized); ;
        }
        #endregion

        public static ObservableCollection<DataCardsChurras> CardsChurras()
        {
            ObservableCollection<DataCardsChurras> cardsChurras = new ObservableCollection<DataCardsChurras>()
            {
                new DataCardsChurras
                {
                    Id = 1,
                    Date = DateTimeOffset.Now,
                    Title = "Aniversário do Gui",
                    Description = "",
                    ValuePerPerson = 50.0
                },

                new DataCardsChurras
                {
                    Id = 2,
                    Date = DateTimeOffset.Now,
                    Title = "Final de Ano",
                    Description = "",
                    ValuePerPerson = 200.0
                },

               new DataCardsChurras
               {
                    Id = 3,
                    Date = DateTimeOffset.Now,
                    Title = "Sem motivo",
                    Description = "",
                    ValuePerPerson = 30.0
               },

               new DataCardsChurras
               {
                    Id = 4,
                    Date = DateTimeOffset.Now,
                    Title = "Sem motivo",
                    Description = "",
                    ValuePerPerson = 30.0
               },
            };

            return cardsChurras;
        }

        public static ObservableCollection<ListPeopleModel> ListPeople()
        {
            ObservableCollection<ListPeopleModel> listPeople = new ObservableCollection<ListPeopleModel>()
            {
                new ListPeopleModel
                {
                    Nome = "Guilherme",
                    ValorPessoa = 250
                },

                new ListPeopleModel
                {
                    Nome = "Maria",
                    ValorPessoa = 150
                },

                new ListPeopleModel
                {
                    Nome = "João",
                    ValorPessoa = 50
                },

                new ListPeopleModel
                {
                    Nome = "Pedro",
                    ValorPessoa = 255
                },

                new ListPeopleModel
                {
                    Nome = "Fernando",
                    ValorPessoa = 15
                },

                new ListPeopleModel
                {
                    Nome = "Carla",
                    ValorPessoa = 35
                },

                new ListPeopleModel
                {
                    Nome = "Flavia",
                    ValorPessoa = 555
                }
            };

            return listPeople;
        }
    }

}
