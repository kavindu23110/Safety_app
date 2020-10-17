
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Safety_app.Views.MainViews.Schedules
{
    [XamlCompilation(XamlCompilationOptions.Skip)]
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