
using Android.App;
using Android.OS;

namespace Taxi.Prism.Droid
{
    [Activity(
        Label = "TaxiApp",
        Theme = "@style/Theme.Splash", 
        Icon = "@mipmap/ic_launcher",
        MainLauncher = true,
        NoHistory = true)]
    public class SplashActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            System.Threading.Thread.Sleep(1800);
            StartActivity(typeof(MainActivity));
        }
    }
}