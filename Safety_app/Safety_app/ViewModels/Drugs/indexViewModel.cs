using Safety_app.BOD;
using Safety_app.Helpers;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace Safety_app.ViewModels.Drugs
{

    public class indexViewModel : BaseViewModel
    {


        public ICommand addnewDrug { get; }
        public ICommand RemoveDrugsFromListCommand { get; }
        public ICommand DrugEditCommand { get; }

        public ICommand AddSelectedDrug { get; }
        public ICommand SaveDrugs { get; }

        public ObservableCollection<Models.Drugs> lstDrugs { get; set; }

        public ObservableCollection<Models.Drugs> lstSelectedDrugs { get; set; }


        public indexViewModel()
        {

            addnewDrug = new Command(OnAddNewDrugAsync);
            AddSelectedDrug = new Command(OnAddSelectedDrug);
            SaveDrugs = new Command(OnSaveDrugs);
            RemoveDrugsFromListCommand = new Command(OnRemoveDrugsFromListCommand);
            DrugEditCommand = new Command(OnDrugEditAsync);

            lstDrugs = new ObservableCollection<Models.Drugs>();
            lstSelectedDrugs = new ObservableCollection<Models.Drugs>();

        }

        private async void OnDrugEditAsync(object obj)
        {
            StateManager.StoreProperties<Models.Drugs>(KeyValueDefinitions.DrugEdit, obj);
            await AppShell.Current.GoToAsync($"{nameof(Views.MainViews.Drugs.AddNewDrug)}");
        }

        private void OnRemoveDrugsFromListCommand(object obj)
        {
            if (obj != null)
            {
                lstDrugs.Add((Models.Drugs)obj);
                lstSelectedDrugs.Remove((Models.Drugs)obj);
            }
        }

        private void OnSaveDrugs(object obj)
        {
            StateManager.StoreProperties<ObservableCollection<Models.Drugs>>(KeyValueDefinitions.lstselecteddrugs, lstSelectedDrugs);
            AppShell.Current.GoToAsync("..");
        }

        private void OnAddSelectedDrug(object obj)
        {
            if (obj != null)
            {
                lstSelectedDrugs.Add((Models.Drugs)obj);
                lstDrugs.Remove((Models.Drugs)obj);
            }
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
