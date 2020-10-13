using Safety_app.Data.DatabaseOperation;
using Safety_app.ViewModels.Drugs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
         await   (this.BindingContext as indexViewModel).LoadDrugsAsync();
        }


    }
}