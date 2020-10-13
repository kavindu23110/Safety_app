using PropertyChanged;
using Safety_app.BOD;
using Safety_app.Helpers;
using Safety_app.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Safety_app.ViewModels.Drugs
{

    public class indexViewModel : BaseViewModel
    {


        public ICommand addnewDrug { get; }
       
        public ICommand AddSelectedDrug { get; }
        public ICommand SaveDrugs { get; }

        public ObservableCollection<Models.Drugs> lstDrugs { get; set; }

        public ObservableCollection<Models.Drugs> lstSelectedDrugs {get; set;}


        public indexViewModel()
        {

            addnewDrug = new Command(OnAddNewDrugAsync);
            AddSelectedDrug = new Command(OnAddSelectedDrug);
            SaveDrugs = new Command(OnSaveDrugs);

            lstDrugs = new ObservableCollection<Models.Drugs>();
            lstSelectedDrugs = new ObservableCollection<Models.Drugs>();

        }

        private void OnSaveDrugs(object obj)
        {
            
            StateManager.StoreProperties<ObservableCollection<Models.Drugs>>(KeyValueDefinitions.lstselecteddrugs, lstSelectedDrugs);
            AppShell.Current.GoToAsync("..");
        }

        private void OnAddSelectedDrug(object obj)
        {
            lstSelectedDrugs.Add((Models.Drugs)obj);
            lstDrugs.Remove((Models.Drugs)obj);
        }


        public async System.Threading.Tasks.Task LoadDrugsAsync()
        {
            var drugs = await App.Database.GetDrugOperator().GetAsync();
            lstDrugs = new ObservableCollection<Models.Drugs>(drugs);
        }

        private async void OnAddNewDrugAsync(object obj)
        {
            await AppShell.Current.GoToAsync($"{nameof(Views.MainViews.Drugs.AddNewDrug)}");
        }


    }
}
