using churrasTrincaApp.Models;
using MvvmHelpers;
using System;

namespace churrasTrincaApp.ViewModels.DetalhesChurras
{
    public class DetalhesChurrasViewModel : BaseViewModel
    {
        #region Variaveis
        private CardsChurrasModel _cardsChurras;
        #endregion

        #region Propriedades
        public CardsChurrasModel CardsChurras
        {
            get => _cardsChurras;
            set
            {
                _cardsChurras = value;
                OnPropertyChanged(nameof(CardsChurras));
            }
        }
        #endregion

        #region Commands
        #endregion

        #region Construtor
        public DetalhesChurrasViewModel()
        {
            
        }
        #endregion

        #region Methods
        public void CarregarDetalhes(CardsChurrasModel cardsChurrasModel)
        {
            CardsChurras = cardsChurrasModel;
        }
        #endregion
    }
}