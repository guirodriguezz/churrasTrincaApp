using Android.Content;
using churrasTrincaApp.Controls;
using churrasTrincaApp.Droid.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(EntryTrinca), typeof(CustomEntryRenderer))]
namespace churrasTrincaApp.Droid.Controls
{
    public class CustomEntryRenderer : EntryRenderer
    {
        private Context context;
        public CustomEntryRenderer(Context context) : base(context)
        {
            this.context = context;
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                Control.Background = null;
            }

            if (e.NewElement != null)
            {

            }
        }
    }
}