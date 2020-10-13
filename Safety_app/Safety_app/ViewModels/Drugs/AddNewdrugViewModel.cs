using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Safety_app.ViewModels.Drugs
{

   public class AddNewdrugViewModel:BaseViewModel
    {
        public ICommand SaveDrug { get; set; }
        public Models.Drugs drug { get; set; }
        public AddNewdrugViewModel()
        {
            SaveDrug = new Command(OnSaveDrugAsync);
            drug = new Models.Drugs();
            
        }

        private async void OnSaveDrugAsync(object obj)
        {
          await  App.Database.GetDrugOperator().saveAsync(drug);
          var t= await  App.Database.GetDrugOperator().GetAsync();
            await Shell.Current.GoToAsync("..");
        }
    }
}
