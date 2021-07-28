using churrasTrincaApp.Models.Enums;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace churrasTrincaApp.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExibirIcone : Label
    {
        #region propertities
        public static readonly BindableProperty IconeProperty = BindableProperty.Create(propertyName: "Icons",
                                                         returnType: typeof(Icons),
                                                         declaringType: typeof(ExibirIcone),
                                                         defaultValue: Icons.Default,
                                                         defaultBindingMode: BindingMode.TwoWay,
                                                         propertyChanged: IconePropertyChanged);

        public static readonly BindableProperty HintColorProperty = BindableProperty.Create(
             propertyName: "HintColor",
             returnType: typeof(Color),
             declaringType: typeof(ExibirIcone),
             defaultValue: Color.DarkGray,
             defaultBindingMode: BindingMode.TwoWay,
             propertyChanged: HintColorPropertyChanged);

        public static readonly BindableProperty CurvedCornerRadiusProperty =
            BindableProperty.Create<ExibirIcone, double>(w => w.CurvedCornerRadius, default(double));

        public static readonly BindableProperty CurvedBackgroundColorProperty =
            BindableProperty.Create<ExibirIcone, Color>(w => w.CurvedBackgroundColor, default(Color));
        #endregion
        public Icons Icone
        {
            get { return (Icons)GetValue(IconeProperty); }
            set { SetValue(IconeProperty, value); }
        }
        public ExibirIcone()
        {
            InitializeComponent();
            this.Text = "F";
        }

        private static void IconePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (Label)bindable;
            control.Text = ((Icons)newValue).ToStringValue();
        }

        public Color HintColor
        {
            get { return (Color)base.GetValue(HintColorProperty); }
            set { base.SetValue(HintColorProperty, value); }
        }

        static void HintColorPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ((ExibirIcone)bindable).TextColor = (Color)newValue;
        }

        public double CurvedCornerRadius
        {
            get { return (double)GetValue(CurvedCornerRadiusProperty); }
            set { SetValue(CurvedCornerRadiusProperty, value); }
        }

        public Color CurvedBackgroundColor
        {
            get { return (Color)GetValue(CurvedBackgroundColorProperty); }
            set { SetValue(CurvedBackgroundColorProperty, value); }
        }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);
            if (nameof(FontAttributes) == propertyName)
            {
                this.FontAttributes = FontAttributes.None;
            }
        }
    }
}