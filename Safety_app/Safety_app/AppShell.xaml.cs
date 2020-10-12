using System;
using System.Collections.Generic;
using Safety_app.ViewModels;
using Safety_app.Views;
using Safety_app.Views.MainViews.Prescriptions;
using Safety_app.Views.MainViews.Schedules;
using Xamarin.Forms;

namespace Safety_app
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
            Routing.RegisterRoute(nameof(AddEditPrescription), typeof(AddEditPrescription));
            Routing.RegisterRoute(nameof(AddEditSchedule), typeof(AddEditSchedule));
            Routing.RegisterRoute(nameof(Views.MainViews.Drugs.AddNewDrug), typeof(Views.MainViews.Drugs.AddNewDrug));
            Routing.RegisterRoute(nameof(Safety_app.Views.MainViews.Drugs.index), typeof(Safety_app.Views.MainViews.Drugs.index));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
