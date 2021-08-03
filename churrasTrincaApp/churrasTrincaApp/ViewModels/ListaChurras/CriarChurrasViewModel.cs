using Acr.UserDialogs;
using churrasTrincaApp.Models;
using churrasTrincaApp.Services;
using churrasTrincaApp.Views.ListaChurras;
using MvvmHelpers;
using Refit;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace churrasTrincaApp.ViewModels.ListaChurras
{
    public class CriarChurrasViewModel : BaseViewModel
    {
        #region Variaveis
        private string _titulo;
        private string _descricao;
        private string _nomePessoa;
        private bool _confirmado;
        private string _valorPessoa;
        private double _valorTotal;
        private DateTime _dataChurras;
        private bool _btnAtivado;
        private string _textoBtn;
        private bool _addChurrasVisible;
        private bool _addPessoasVisible;
        private DataCardsChurras _cardsChurras;
        private ObservableCollection<DataListPeople> _listPeoples;
        #endregion

        #region Propriedades
        public DataCardsChurras CardsChurras
        {
            get => _cardsChurras;
            set
            {
                _cardsChurras = value;
                OnPropertyChanged(nameof(CardsChurras));
            }
        }

        public ObservableCollection<DataListPeople> ListPeoples
        {
            get => _listPeoples;
            set
            {
                _listPeoples = value;
                OnPropertyChanged(nameof(ListPeoples));
            }
        }

        public string Titulo
        {
            get => _titulo;
            set
            {
                _titulo = value;

                BtnAtivado = !string.IsNullOrEmpty(Titulo) && !string.IsNullOrEmpty(Descricao);

                OnPropertyChanged(nameof(Titulo));
            }
        }

        public string Descricao
        {
            get => _descricao;
            set
            {
                BtnAtivado = !string.IsNullOrEmpty(Titulo) && !string.IsNullOrEmpty(Descricao);

                _descricao = value;
                OnPropertyChanged(nameof(Descricao));
            }
        }

        public DateTime DataChurras
        {
            get => _dataChurras;
            set
            {
                _dataChurras = value;
                OnPropertyChanged(nameof(DataChurras));
            }
        }

        public string NomePessoa
        {
            get => _nomePessoa;
            set
            {
                _nomePessoa = value;
                OnPropertyChanged(nameof(NomePessoa));
            }
        }

        public bool Confirmado
        {
            get => _confirmado;
            set
            {
                _confirmado = value;
                OnPropertyChanged(nameof(Confirmado));
            }
        }

        public string ValorPessoa
        {
            get => _valorPessoa;
            set
            {
                _valorPessoa = value;
                OnPropertyChanged(nameof(ValorPessoa));
            }
        }

        public double ValorTotal
        {
            get => _valorTotal;
            set
            {
                _valorTotal = value;
                OnPropertyChanged(nameof(ValorTotal));
            }
        }

        public bool BtnAtivado
        {
            get => _btnAtivado;
            set
            {
                _btnAtivado = value;
                OnPropertyChanged(nameof(BtnAtivado));
            }
        }

        public string TextoBtn
        {
            get => _textoBtn;
            set
            {
                _textoBtn = value;
                OnPropertyChanged(nameof(TextoBtn));
            }
        }

        public bool AddChurrasVisible
        {
            get => _addChurrasVisible;
            set
            {
                _addChurrasVisible = value;
                OnPropertyChanged(nameof(AddChurrasVisible));
            }
        }

        public bool AddPessoasVisible
        {
            get => _addPessoasVisible;
            set
            {
                _addPessoasVisible = value;
                OnPropertyChanged(nameof(AddPessoasVisible));
            }
        }
        #endregion

        #region Commands
        public ICommand AvancarCommand { get; set; }
        public ICommand AdicionarPessoaCommand { get; set; }
        public ICommand VoltarCommand { get; set; }
        #endregion

        #region Construtor
        public CriarChurrasViewModel()
        {
            AddChurrasVisible = true;
            AddPessoasVisible = false;
            TextoBtn = "Continuar";
            Confirmado = true;
            BtnAtivado = false;
            DataChurras = DateTime.Now;
            ValorTotal = 0.00;

            ListPeoples = new ObservableCollection<DataListPeople>();

            AvancarCommand = new Command(async () => await Avancar());
            AdicionarPessoaCommand = new Command(async () => await AdicionarPessoa());
            VoltarCommand = new Command(async () => await Voltar());
        }
        #endregion

        #region Methods
        public async Task Avancar()
        {
            if (AddChurrasVisible)
            {
                AddChurrasVisible = false;
                AddPessoasVisible = true;
                BtnAtivado = false;
                TextoBtn = "Finalizar";
            }
            else
            {
                try
                {
                    UserDialogs.Instance.ShowLoading("Aguarde....");

                    CardsChurras = new DataCardsChurras
                    {
                        Title = Titulo,
                        Description = Descricao,
                        Date = DataChurras,
                        value_per_person = ValorTotal,
                        Participants = ListPeoples
                    };

                    ApiResponse<string> response = await BaseServices.CreateChurras(CardsChurras);

                    if (response.IsSuccessStatusCode)
                    {
                        await UserDialogs.Instance.AlertAsync("Seu churras foi adicionado com sucesso", "Parabéns", "Ok");

                        await Application.Current.MainPage.Navigation.PopModalAsync();
                        Application.Current.MainPage = new NavigationPage(new ListaChurrasPage());
                    }
                    else
                    {
                        await UserDialogs.Instance.AlertAsync("Não foi possível adicionar seu churrasco no momento, tente novamente mais tarde", "Desculpe", "Ok");
                    }
                }
                catch (Exception ex)
                {
                    Exception error = ex;
                    await UserDialogs.Instance.AlertAsync("Ocorreu um erro ao processar a sua solicitação.", "ATENÇÃO", "Ok");
                }
                finally
                {
                    UserDialogs.Instance.HideLoading();
                }
            }
        }

        private async Task AdicionarPessoa()
        {
            if (string.IsNullOrEmpty(NomePessoa))
            {
                await UserDialogs.Instance.AlertAsync("É necessário adicionar um nome", "ATENÇÃO", "Ok");
            }
            else if (ValorPessoa == "0,00")
            {
                await UserDialogs.Instance.AlertAsync("O valor por pessoa não pode ser zero", "ATENÇÃO", "Ok");
            }
            else
            {
                double valorConvertido = Convert.ToDouble(ValorPessoa);
                ValorTotal += valorConvertido;

                DataListPeople participant = new DataListPeople()
                {
                    Name = NomePessoa,
                    Confirmed = Confirmado,
                    value_paid = valorConvertido
                };

                ListPeoples.Add(participant);

                BtnAtivado = true;

                NomePessoa = string.Empty;
                Confirmado = false;
                ValorPessoa = string.Empty;
            }
        }

        public async Task Voltar()
        {
            await Application.Current.MainPage.Navigation.PopModalAsync();
        }
        #endregion
    }
}