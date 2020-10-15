using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Safety_app.ViewModels.Schedules
{
  public  class Index:BaseViewModel
    {
        public ICommand SelectScheduleCommand { get; set; }
        public ObservableCollection<Models.Shedule> lstSchedules { get; set; }

        public Index()
        {
            SelectScheduleCommand = new Command(OnSelectSchedule);
        }

        private void OnSelectSchedule(object obj)
        {
          
        }

        public async Task LoadSchedulesAsync()
        {
         var lst =await  App.Database.GetScheduleOperator().FindAsync(p => p.IsActive == 1);
            lstSchedules = new ObservableCollection<Models.Shedule>(lst);
        }
    }
}
