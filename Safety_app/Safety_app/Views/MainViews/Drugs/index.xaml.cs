using Safety_app.ViewModels.Drugs;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Safety_app.Views.MainViews.Drugs
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class index : ContentPage
    {
        public index()
        {
            InitializeComponent();
            BindingContext = new Safety_app.ViewModels.Drugs.indexViewModel();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            load();
        }

        private async void load()
        {
            await (this.BindingContext as indexViewModel).LoadDrugsAsync();
        }


    }
}