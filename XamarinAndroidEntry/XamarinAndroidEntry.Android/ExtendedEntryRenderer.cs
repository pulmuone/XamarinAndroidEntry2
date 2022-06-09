using Android.Content;
using Android.Text;
using Android.Views;
using Android.Views.InputMethods;
using Android.Widget;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(XamarinAndroidEntry.ExtendedEntry), typeof(XamarinAndroidEntry.Droid.ExtendedEntryRenderer))]
namespace XamarinAndroidEntry.Droid
{
    /// <summary>
    /// Class ExtendedEntryRenderer.
    /// </summary>
    public class ExtendedEntryRenderer : EntryRenderer, IVirtualKeyboard
    {
        public ExtendedEntryRenderer(Context context) : base(context)
        {
        }

        /// <summary>
        /// Called when [element changed].
        /// </summary>
        /// <param name="e">The e.</param>
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if ((e.OldElement == null) && (Control != null))
            {
                var edittext = (EditText)Control;

                //edittext.SetPadding(0, 0, 0, 0);
                edittext.SetTextIsSelectable(true);
                edittext.SetSelectAllOnFocus(true);
                edittext.ShowSoftInputOnFocus = false; //true: Ű���� ����, false: Ű���� �Ⱥ���

                var view = (ExtendedEntry)Element;

                view.VirtualKeyboardHandler = this;
            }
        }

        public void ShowKeyboard()
        {
            Control.RequestFocus();
            var inputMethodManager = Control.Context.GetSystemService(Context.InputMethodService) as InputMethodManager;
            inputMethodManager.ShowSoftInput(Control, ShowFlags.Implicit);
            //Show Force : ����ڰ� ���������� Ű���带 ǥ���ϵ��� ��û������(��:Ű���� ���� ��ư�� ����) �ý����� Ű���带 ������
            //����� ���� �ǹ��մϴ�. �� ��� �÷��׸� ����Ͽ� Ű���带 ������� ���� ��û�� ���õ˴ϴ�.(���� Ű����� ������ ����)
            //SHOW_IMPLICIT ���� Ű���带 ������ ��� ���� ���� HIDE_IMPLICIT_ONLY /HIDE_NOT_ALWAYS ���� ���ܾ� �Ѵ�.
        }

        public void HideKeyboard()
        {
            Control.RequestFocus();
            var inputMethodManager = Control.Context.GetSystemService(Context.InputMethodService) as InputMethodManager;
            //inputMethodManager.HideSoftInputFromWindow(this.Control.WindowToken, HideSoftInputFlags.None); // this probably needs to be set to ToogleSoftInput, forced.
            inputMethodManager.HideSoftInputFromWindow(this.Control.WindowToken, HideSoftInputFlags.ImplicitOnly);
        }


        /// <summary>
        /// Handles the touch.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="Android.Views.View.TouchEventArgs"/> instance containing the event data.</param>
        //private void HandleTouch(object sender, global::Android.Views.View.TouchEventArgs e)
        //{
        //    var element = this.Element as ExtendedEntry;
        //    switch (e.Event.Action)
        //    {
        //        case MotionEventActions.Down:
        //            downX = e.Event.GetX();
        //            downY = e.Event.GetY();
        //            return;
        //        case MotionEventActions.Up:
        //        case MotionEventActions.Cancel:
        //        case MotionEventActions.Move:
        //            upX = e.Event.GetX();
        //            upY = e.Event.GetY();

        //            var deltaX = downX - upX;
        //            var deltaY = downY - upY;

        //            // swipe horizontal?
        //            if (Math.Abs(deltaX) > Math.Abs(deltaY))
        //            {
        //                if (Math.Abs(deltaX) > MIN_DISTANCE)
        //                {
        //                    // left or right
        //                    if (deltaX < 0) { element.OnRightSwipe(this, EventArgs.Empty); return; }
        //                    if (deltaX > 0) { element.OnLeftSwipe(this, EventArgs.Empty); return; }
        //                }
        //                else
        //                {
        //                    global::Android.Util.Log.Info("ExtendedEntry", "Horizontal Swipe was only " + Math.Abs(deltaX) + " long, need at least " + MIN_DISTANCE);
        //                    return;	// We don't consume the event
        //                }
        //            }
        //            // swipe vertical?
        //            //                    else 
        //            //                    {
        //            //                        if(Math.abs(deltaY) > MIN_DISTANCE){
        //            //                            // top or down
        //            //                            if(deltaY < 0) { this.onDownSwipe(); return true; }
        //            //                            if(deltaY > 0) { this.onUpSwipe(); return true; }
        //            //                        }
        //            //                        else {
        //            //                            Log.i(logTag, "Vertical Swipe was only " + Math.abs(deltaX) + " long, need at least " + MIN_DISTANCE);
        //            //                            return false; // We don't consume the event
        //            //                        }
        //            //                    }

        //            return;
        //    }
        //}

        /// <summary>
        /// Handles the <see cref="E:ElementPropertyChanged" /> event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.ComponentModel.PropertyChangedEventArgs"/> instance containing the event data.</param>
        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            //var view = (ExtendedEntry)Element;

            //if (e.PropertyName == ExtendedEntry.FontProperty.PropertyName)
            //{
            //    SetFont(view);
            //}

            //if (e.PropertyName == ExtendedEntry.XAlignProperty.PropertyName)
            //{
            //    SetTextAlignment(view);
            //}

            //if (e.PropertyName == ExtendedEntry.YAlignProperty.PropertyName)
            //{
            //    SetTextAlignment(view);
            //}
            ////if (e.PropertyName == ExtendedEntry.HasBorderProperty.PropertyName)
            ////    SetBorder(view);
            //if (e.PropertyName == ExtendedEntry.TextColorProperty.PropertyName)
            //{
            //    SetTextColor(view);
            //}

            //if (e.PropertyName == ExtendedEntry.PlaceholderTextColorProperty.PropertyName)
            //{
            //    SetPlaceholderTextColor(view);
            //}

            //if (e.PropertyName == ExtendedEntry.MaxLengthProperty.PropertyName)
            //{
            //    SetMaxLength(view);
            //}
        }

        /// <summary>
        /// Sets the border.
        /// </summary>
        /// <param name="view">The view.</param>
        //private void SetBorder(ExtendedEntry view)
        //{
        //    //NotCurrentlySupported: HasBorder property not supported on Android
        //}

        /// <summary>
        /// Sets the Text alignment.
        /// </summary>
        /// <param name="view">The view.</param>
        private void SetTextAlignment(ExtendedEntry view)
        {
            var gravity = GravityFlags.NoGravity;

            switch (view.XAlign)
            {
                case Xamarin.Forms.TextAlignment.Center:
                    gravity |= GravityFlags.CenterHorizontal;
                    break;
                case Xamarin.Forms.TextAlignment.End:
                    gravity |= GravityFlags.End;
                    break;
                case Xamarin.Forms.TextAlignment.Start:
                    gravity |= GravityFlags.Start;
                    break;
            }

            switch (view.YAlign)
            {
                case Xamarin.Forms.TextAlignment.Center:
                    gravity |= GravityFlags.CenterVertical;
                    break;
                case Xamarin.Forms.TextAlignment.End:
                    gravity |= GravityFlags.Bottom;
                    break;
                case Xamarin.Forms.TextAlignment.Start:
                    gravity |= GravityFlags.Top;
                    break;
            }
            Control.Gravity = gravity;
        }

        /// <summary>
        /// Sets the font.
        /// </summary>
        /// <param name="view">The view.</param>
        private void SetFont(ExtendedEntry view)
        {
            if (view.Font != Font.Default)
            {
                Control.TextSize = view.Font.ToScaledPixel();
                Control.Typeface = view.Font.ToTypeface();
            }
        }

        /// <summary>
        /// Sets the color of the placeholder text.
        /// </summary>
        /// <param name="view">The view.</param>
        private void SetPlaceholderTextColor(ExtendedEntry view)
        {
            if (view.PlaceholderTextColor != Xamarin.Forms.Color.Default)
            {
                Control.SetHintTextColor(view.PlaceholderTextColor.ToAndroid());
            }
        }


        /// <summary>
        /// Sets the color of the  text.
        /// </summary>
        /// <param name="view">The view.</param>
        private void SetTextColor(ExtendedEntry view)
        {
            if (view.TextColor != Xamarin.Forms.Color.Default)
            {
                Control.SetTextColor(view.TextColor.ToAndroid());
            }
        }
        /// <summary>
        /// Sets the MaxLength characteres.
        /// </summary>
        /// <param name="view">The view.</param>
        private void SetMaxLength(ExtendedEntry view)
        {
            Control.SetFilters(new IInputFilter[] { new global::Android.Text.InputFilterLengthFilter(view.MaxLength) });
        }
    }
}
