using churrasTrincaApp.Models;
using System;
using System.Collections.ObjectModel;

namespace churrasTrincaApp.Services
{
    public static class BaseServices
    {
        //private static string BaseUrl => "https://tyrenergia.com.br/api";
        //private static IEndPoints Endpoint => RestService.For<IEndPoints>(BaseUrl);

        public static ObservableCollection<CardsChurrasModel> CardsChurras()
        {
            ObservableCollection<CardsChurrasModel> cardsChurras = new ObservableCollection<CardsChurrasModel>()
            {
                new CardsChurrasModel
                {
                    DateChurras = DateTime.Now,
                    Descricao = "Niver do Gui",
                    Quantidade = 15,
                    Valor = 280
                },

                new CardsChurrasModel
                {
                    DateChurras = DateTime.Now,
                    Descricao = "Final de Ano",
                    Quantidade = 28,
                    Valor = 400
                },

                new CardsChurrasModel
                {
                    DateChurras = DateTime.Now,
                    Descricao = "Sem motivo",
                    Quantidade = 12,
                    Valor = 140
                }
            };

            return cardsChurras;
        }
    }

}
