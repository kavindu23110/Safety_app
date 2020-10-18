using Plugin.Media;
using Plugin.Media.Abstractions;
using Safety_app.BOD;
using Safety_app.Helpers;
using System.Windows.Input;
using Xamarin.Forms;

namespace Safety_app.ViewModels.Drugs
{

    public class AddNewdrugViewModel : BaseViewModel
    {
        public ICommand TakeImageCommand { get; set; }
        public ICommand SaveDrug { get; set; }
        public Models.Drugs drug { get; set; }
        public bool isEdit { get; set; }
        public AddNewdrugViewModel()
        {
            TakeImageCommand = new Command(OnTakeImageAsync);
            SaveDrug = new Command(OnSaveDrugAsync);
            drug = new Models.Drugs();

        }

        public void LoadDrugs()
        {
            var cachedDrug = StateManager.GetProperties<Models.Drugs>(KeyValueDefinitions.DrugEdit);
            if (cachedDrug != null)
            {
                isEdit = true;
                drug = cachedDrug;
                StateManager.Remove(KeyValueDefinitions.DrugEdit);
            }
        }

        private async void OnTakeImageAsync(object obj)
        {
            if (!CrossMedia.Current.IsCameraAvailable ||
            !CrossMedia.Current.IsTakePhotoSupported)
            {
                StaticFunctions.DisplayAlert_ProvideInformationAsync("No Camera", "Sorry! No camera available.");
                return;
            }

            var file = await CrossMedia.Current.TakePhotoAsync(new
                Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                Directory = "DrugImage",
                SaveToAlbum = true,
                PhotoSize = PhotoSize.Medium,
            });

            drug.ImageLocation = file.AlbumPath;

        }



        private async void OnSaveDrugAsync(object obj)
        {
            if (isEdit)
            {
                StaticFunctions.ToastMessage_Long("Drug Updated Successfully");
                await App.Database.GetDrugOperator().updateAsync(drug);
            }
            else
            {
                StaticFunctions.ToastMessage_Long("Drug Added Successfully");
                await App.Database.GetDrugOperator().saveAsync(drug);
            }
            await Shell.Current.GoToAsync("..");
        }
    }
}
