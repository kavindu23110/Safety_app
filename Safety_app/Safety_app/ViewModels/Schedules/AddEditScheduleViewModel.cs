using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Safety_app.ViewModels.Schedules
{
    public class AddEditScheduleViewModel : BaseViewModel
    {
   
        public ICommand SaveSchedule { get; }
        public Models.Shedule Shedule { get; set; }
        public AddEditScheduleViewModel()
        {
         
            SaveSchedule = new Command(OnSaveScheduleAsync);
            Shedule = new Models.Shedule();
        }

        private async void OnSaveScheduleAsync(object obj)
        {
            
            await App.Database.GetScheduleOperator().saveAsync(Shedule);
           await Shell.Current.GoToAsync("..");
        }



    }
}
