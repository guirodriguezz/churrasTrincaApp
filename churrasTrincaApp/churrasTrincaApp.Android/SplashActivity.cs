using Android.App;
using Android.Content.PM;
using Android.OS;

namespace churrasTrincaApp.Droid
{
    [Activity(Label = "Churras Trinca", Icon = "@mipmap/icon", Theme = "@style/MainTheme.Splash", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize)]
    public class SplashActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            StartActivity(typeof(MainActivity));
            Finish();

            //Disable activity slide-in animation
            OverridePendingTransition(0, 0);
        }
    }
}