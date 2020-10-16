using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Safety_app.Helpers
{
  public static  class StaticFunctions
    {
        public static async System.Threading.Tasks.Task<bool> DisplayAlert_DeleteAsync() {
            return await Application.Current.MainPage.DisplayAlert("Reminder", "This Action Will Delete Item Permanently", "OK", "cancel");
        }
    }
}
