using churrasTrincaApp.Controls;
using churrasTrincaApp.ViewModels.DetalhesChurras;
using Xamarin.Forms.Xaml;

namespace churrasTrincaApp.Views.DetalhesChurras
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetalhesChurrasPage : BasePage
    {
        public DetalhesChurrasPage(DetalhesChurrasViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
}