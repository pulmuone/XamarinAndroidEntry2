using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace XamarinAndroidEntry
{
    public partial class App : Xamarin.Forms.Application
    {
        //public App(ISoftwareKeyboardService softwarekeyboardservice)
        public App()
        {
            InitializeComponent();

            //MainPage = new NavigationPage(new MainPage(softwarekeyboardservice));
            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
            //App.Current.On<Android>().UseWindowSoftInputModeAdjust(WindowSoftInputModeAdjust.Resize);
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
