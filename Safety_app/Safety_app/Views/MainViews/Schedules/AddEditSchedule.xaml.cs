
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Safety_app.Views.MainViews.Schedules
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddEditSchedule : ContentPage
    {
        public AddEditSchedule()
        {
            InitializeComponent();
            BindingContext = new Safety_app.ViewModels.Schedules.AddEditScheduleViewModel();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            load();
        }
        private void load()
        {
            (this.BindingContext as Safety_app.ViewModels.Schedules.AddEditScheduleViewModel).LoadSchedulesAsync();
        }
    }
}