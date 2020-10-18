using Safety_app.Helpers;
using Safety_app.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace Safety_app.ViewModels.Notification
{
    public class DrugConflictViewModel
    {
        public System.Windows.Input.ICommand closeCommand { get; }
        public ObservableCollection<Models.Notification> lstNotification { get; set; }

        public DrugConflictViewModel(List<DrugSchedulePrescription> currentdrugwithothers)
        {
            closeCommand = new Command(Onclose);
            LoadNotificationDetails(currentdrugwithothers);
        }

        private async void Onclose(object obj)
        {
            await App.Current.MainPage.Navigation.PopModalAsync(true);
        }

        private async void LoadNotificationDetails(List<DrugSchedulePrescription> currentdrugwithothers)
        {
            lstNotification = new ObservableCollection<Models.Notification>();
            foreach (var item in currentdrugwithothers)
            {
                Models.Notification notification = new Models.Notification();
                var prescription = await App.Database.GetPrescriptionOperator().GetSelectedAsync(p => p.Id == item.PrescriptionId && p.IsActive == 1);
                var drug = await App.Database.GetDrugOperator().GetSelectedAsync(p => p.Id == item.DrugId && p.IsActive == 1);

                notification.Drugs = drug;
                notification.DrugSchedulePrescription = item;
                notification.Prescription = prescription;
                lstNotification.Add(notification);
            }

        }
    }
}
