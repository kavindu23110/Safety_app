using Safety_app.Views.MainViews.Prescriptions;
using Safety_app.Views.MainViews.Schedules;
using System;
using Xamarin.Forms;

namespace Safety_app
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(AddEditPrescription), typeof(AddEditPrescription));

            Routing.RegisterRoute(nameof(Views.MainViews.Drugs.AddNewDrug), typeof(Views.MainViews.Drugs.AddNewDrug));
            Routing.RegisterRoute(nameof(Views.MainViews.Drugs.index), typeof(Views.MainViews.Drugs.index));

            Routing.RegisterRoute(nameof(AddEditSchedule), typeof(AddEditSchedule));
            Routing.RegisterRoute(nameof(ScheduleDrugAdd), typeof(ScheduleDrugAdd));
            Routing.RegisterRoute(nameof(PrescriptionSchedule), typeof(PrescriptionSchedule));
            Routing.RegisterRoute("Scheduleindex", typeof(Views.MainViews.Schedules.index));

        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
