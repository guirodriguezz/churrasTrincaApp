using System.Runtime.CompilerServices;
using churrasTrincaApp.Services;
using churrasTrincaApp.Views.Login;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace churrasTrincaApp.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BasePage : ContentPage
    {
        public static readonly BindableProperty BodyProperty = BindableProperty.Create(nameof(Body), typeof(View), typeof(BasePage), null);
        public static readonly BindableProperty TemVoltarProperty = BindableProperty.Create(nameof(TemVoltar), typeof(bool), typeof(BasePage), true);

        public View Body
        {
            get { return (View)GetValue(BodyProperty); }
            set => SetValue(BodyProperty, value);
        }

        public bool TemVoltar
        {
            get { return (bool)GetValue(TemVoltarProperty); }
            set => SetValue(TemVoltarProperty, value);
        }

        public BasePage()
        {
            InitializeComponent();
        }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            if (propertyName == nameof(Body))
            {
                pageContent.Children.Add(Body);
            }
        }

        void TapGestureRecognizer_Tapped(System.Object sender, System.EventArgs e)
        {
            SharedServices.RemoveUser();
            Application.Current.MainPage = new NavigationPage(new LoginPage());
        }
    }
}