using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using GymApp.Droid;
using GymApp.Custom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(MyEntry), typeof(CustomEntry))]

namespace GymApp.Droid
{
    class CustomEntry : EntryRenderer
    {
        public CustomEntry(Context context) : base(context)
        {

        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                Control.SetBackgroundColor(Android.Graphics.Color.Transparent);
            }
        }
    }
}