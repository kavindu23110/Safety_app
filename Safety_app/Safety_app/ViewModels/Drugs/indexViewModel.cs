using Safety_app.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Safety_app.ViewModels.Drugs
{
   public class indexViewModel:BaseViewModel
    {
        public ICommand addnewDrug { get; }
        public List<Models.Drugs> lstDrugs { get; set; }
        //public List<Models.Drugs> lstSelectedDrugs { get; set; }
        public indexViewModel()
        {
            addnewDrug = new Command(AddNewDrugAsync);
               lstDrugs = new List<Models.Drugs>();
           
        }

        private async void AddNewDrugAsync(object obj)
        {
         await   AppShell.Current.GoToAsync($"{nameof(Views.MainViews.Drugs.AddNewDrug)}");
        }
    }
}
