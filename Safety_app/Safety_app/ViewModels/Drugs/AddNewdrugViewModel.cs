using Plugin.Media;
using Plugin.Media.Abstractions;
using Plugin.Permissions;
using Safety_app.Helpers;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Safety_app.ViewModels.Drugs
{

    public class AddNewdrugViewModel : BaseViewModel
    {
        public ICommand TakeImageCommand { get; set; }
        public ICommand SaveDrug { get; set; }
        public Models.Drugs drug { get; set; }
        public AddNewdrugViewModel()
        {
            TakeImageCommand = new Command(OnTakeImageAsync);
            SaveDrug = new Command(OnSaveDrugAsync);
            drug = new Models.Drugs();

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
            await App.Database.GetDrugOperator().saveAsync(drug);
            await Shell.Current.GoToAsync("..");
        }
    }
}
