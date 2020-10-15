using Safety_app.ViewModels.Prescriptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Safety_app.Views.MainViews.Prescriptions
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class index : ContentPage
    {
        public index()
        {
            InitializeComponent();
            BindingContext = new Safety_app.ViewModels.Prescriptions.indexViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            load();
        }
        private async void load()
        {
            await (this.BindingContext as Safety_app.ViewModels.Prescriptions.indexViewModel).OnAppearing();
        }

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {

        }
    }
}