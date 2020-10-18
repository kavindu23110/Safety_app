
using Android.App;
using Android.Widget;
using Safety_app.DependancyServices;
using Safety_app.Droid.DependancyServices;

[assembly: Xamarin.Forms.Dependency(typeof(MessageAndroid))]
namespace Safety_app.Droid.DependancyServices
{

    public class MessageAndroid : IMessage
    {
        public void LongAlert(string message)
        {
            Toast.MakeText(Application.Context, message, ToastLength.Long).Show();
        }

        public void ShortAlert(string message)
        {
            Toast.MakeText(Application.Context, message, ToastLength.Short).Show();
        }
    }
}