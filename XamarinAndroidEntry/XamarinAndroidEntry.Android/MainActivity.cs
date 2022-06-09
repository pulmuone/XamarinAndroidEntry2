
using Android.App;
using Android.Content.PM;
using Android.OS;
using AndroidX.AppCompat.App;

namespace XamarinAndroidEntry.Droid
{
    [Activity(Label = "XamarinAndroidEntry", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            AppCompatDelegate.DefaultNightMode = AppCompatDelegate.ModeNightNo;
            this.Window.AddFlags(Android.Views.WindowManagerFlags.KeepScreenOn);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

            // if you need to size the screen yourself, register this service to get notified when 
            // the keyboard appears or disappears and get the current keyboard height along with it.
            // It also has a property if the keyboard is currently visible
            //var softwarekeyboardservice = new SoftwareKeyboardService(this);

            // in your app you would probably Resolve this through some sort of IOC container
            //LoadApplication(new App(softwarekeyboardservice));
            LoadApplication(new App());
        }
    }
}