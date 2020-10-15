using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Safety_app.Views.MainViews.Schedules
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PrescriptionSchedule : ContentPage
    {
        public PrescriptionSchedule()
        {
            InitializeComponent();
            BindingContext = new Safety_app.ViewModels.Schedules.PrescriptionScheduleViewmodel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            load();
        }
        private async void load()
        {
            await (this.BindingContext as Safety_app.ViewModels.Schedules.PrescriptionScheduleViewmodel).LoadSchedulesAsync();
        }
    }
}