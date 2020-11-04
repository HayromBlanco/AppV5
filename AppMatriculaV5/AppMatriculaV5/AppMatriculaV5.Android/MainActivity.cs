using System;
using Android;
using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Gms.Common;
using Firebase.Messaging;
using Firebase.Iid;
using Android.Util;

namespace AppMatriculaV5.Droid
{
    [Activity(Label = "AppMatriculaV5", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {

        //static readonly string TAG = "MainActivity";

        //internal static readonly string CHANNEL_ID = "my_notification_channel";
        //internal static readonly int NOTIFICATION_ID = 100;

        //TextView msgText;

        //public bool IsPlayServicesAvailable()
        //{
        //    int resultCode = GoogleApiAvailability.Instance.IsGooglePlayServicesAvailable(this);
        //    if (resultCode != ConnectionResult.Success)
        //    {
        //        if (GoogleApiAvailability.Instance.IsUserResolvableError(resultCode))
        //            msgText.Text = GoogleApiAvailability.Instance.GetErrorString(resultCode);
        //        else
        //        {
        //            msgText.Text = "This device is not supported";
        //            Finish();
        //        }
        //        return false;
        //    }
        //    else
        //    {
        //        msgText.Text = "Google Play Services is available.";
        //        return true;
        //    }
        //}

        //void CreateNotificationChannel()
        //{
        //    if (Build.VERSION.SdkInt < BuildVersionCodes.O)
        //    {
        //        // Notification channels are new in API 26 (and not a part of the
        //        // support library). There is no need to create a notification
        //        // channel on older versions of Android.
        //        return;
        //    }

        //    var channel = new NotificationChannel(CHANNEL_ID,
        //                                          "FCM Notifications",
        //                                          NotificationImportance.Default)
        //    {

        //        Description = "Firebase Cloud Messages appear in this channel"
        //    };

        //    var notificationManager = (NotificationManager)GetSystemService(Android.Content.Context.NotificationService);
        //    notificationManager.CreateNotificationChannel(channel);
        //}
        //protected override void OnCreate(Bundle savedInstanceState)
        //{
        //    base.OnCreate(savedInstanceState);
        //    SetContentView(Resource.Layout.Main);
        //    msgText = FindViewById<TextView>(Resource.Id.msgText);

        //    IsPlayServicesAvailable();

        //    CreateNotificationChannel();

        //    TabLayoutResource = Resource.Layout.Tabbar;
        //    ToolbarResource = Resource.Layout.Toolbar;

        //    base.OnCreate(savedInstanceState);

        //    Xamarin.Essentials.Platform.Init(this, savedInstanceState);
        //    global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
        //    LoadApplication(new App());
        //}
        //public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        //{
        //    Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

        //    base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        //}

        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}