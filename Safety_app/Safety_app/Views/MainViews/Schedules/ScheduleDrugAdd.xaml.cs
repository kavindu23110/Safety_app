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
    public partial class ScheduleDrugAdd : ContentPage
    {
        public ScheduleDrugAdd()
        {
            InitializeComponent();
            BindingContext = new ViewModels.Schedules.ScheduleDrugAddViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            load();
        }
        private async void load()
        {
        await (this.BindingContext as Safety_app.ViewModels.Schedules.ScheduleDrugAddViewModel).loadPrescriptionDrugsAsync();
        }

        private void Remove_Clicked(object sender, EventArgs e)
        {

        }
    }
}