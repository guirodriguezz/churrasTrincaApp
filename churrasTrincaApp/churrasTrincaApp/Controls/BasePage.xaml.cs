using System.Runtime.CompilerServices;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace churrasTrincaApp.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BasePage : ContentPage
    {
        public static readonly BindableProperty BodyProperty = BindableProperty.Create(nameof(Body), typeof(View), typeof(BasePage), null);

        public View Body
        {
            get { return (View)GetValue(BodyProperty); }
            set { SetValue(BodyProperty, value); }
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
    }
}