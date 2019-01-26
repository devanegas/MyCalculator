using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MvvmCross.Platforms.Android.Views;
using MyCalculator.ViewModels;

namespace MyCalculator.Droid.Views
{
    [Activity(Label = "MyCalculator", MainLauncher = true)]
    public class SquareRootView : MvxActivity<SquareRootViewModel>
    {

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.MyCalculatorView);
            Button button = FindViewById<Button>(Resource.Id.button);

            button.Click += (o, e) => {
                Toast.MakeText(this, "Beep Boop", ToastLength.Short).Show();
            };
        }


    }


}