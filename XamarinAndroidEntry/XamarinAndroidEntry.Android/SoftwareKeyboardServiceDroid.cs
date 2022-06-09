using System;
using Xamarin.Essentials;

[assembly: Xamarin.Forms.Dependency(typeof(XamarinAndroidEntry.Droid.SoftwareKeyboardService))]
namespace XamarinAndroidEntry.Droid
{
    public class SoftwareKeyboardService : ISoftwareKeyboardService
    {
        public virtual event EventHandler<SoftwareKeyboardEventArgs> KeyboardHeightChanged;

        private readonly Android.App.Activity activity;
        private readonly GlobalLayoutListener globalLayoutListener;

        public bool IsKeyboardVisible => globalLayoutListener.IsKeyboardVisible;

        //public SoftwareKeyboardService(Android.App.Activity activity)
        public SoftwareKeyboardService()
        {
            //this.activity = activity;
            this.activity = Xamarin.Essentials.Platform.CurrentActivity;
            globalLayoutListener = new GlobalLayoutListener(activity, this);
            this.activity.Window.DecorView.ViewTreeObserver.AddOnGlobalLayoutListener(this.globalLayoutListener);
        }

        internal void InvokeKeyboardHeightChanged(SoftwareKeyboardEventArgs args)
        {
            var handler = KeyboardHeightChanged;
            handler?.Invoke(this, args);
        }
    }
}
