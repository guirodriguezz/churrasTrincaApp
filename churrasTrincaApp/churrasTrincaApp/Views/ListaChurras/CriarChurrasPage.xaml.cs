using churrasTrincaApp.Controls;
using Xamarin.Forms.Xaml;

namespace churrasTrincaApp.Views.ListaChurras
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CriarChurrasPage : BasePage
    {
        public CriarChurrasPage()
        {
            InitializeComponent();
        }

        void Titulo_TextChanged(System.Object sender, Xamarin.Forms.TextChangedEventArgs e)
        {
            btnAvancar.IsEnabled = !string.IsNullOrEmpty(titulo.Text) && !string.IsNullOrEmpty(descricao.Text);
        }

        void Descricao_TextChanged(System.Object sender, Xamarin.Forms.TextChangedEventArgs e)
        {
            btnAvancar.IsEnabled = !string.IsNullOrEmpty(titulo.Text) && !string.IsNullOrEmpty(descricao.Text);
        }
    }
}