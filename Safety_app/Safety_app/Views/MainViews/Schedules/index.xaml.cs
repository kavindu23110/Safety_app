
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Safety_app.Views.MainViews.Schedules
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class index : ContentPage
    {
        public index()
        {
            InitializeComponent();
            BindingContext = new Safety_app.ViewModels.Schedules.indexViewmodel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            load();
        }
        private async void load()
        {
            await (this.BindingContext as Safety_app.ViewModels.Schedules.indexViewmodel).LoadSchedulesAsync();
        }
    }
}