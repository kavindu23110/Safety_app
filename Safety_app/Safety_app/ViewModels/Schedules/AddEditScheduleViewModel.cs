using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Safety_app.ViewModels.Schedules
{
    public class AddEditScheduleViewModel : BaseViewModel
    {
        public ICommand addnewSchedule { get; }

        public AddEditScheduleViewModel()
        {
            addnewSchedule = new Command(AddNewschedule);
        }

        private void AddNewschedule(object obj)
        {
            AppShell.Current.GoToAsync($"{nameof(Safety_app.Views.MainViews.Schedules.AddEditSchedule)}");
        }
    }
}
