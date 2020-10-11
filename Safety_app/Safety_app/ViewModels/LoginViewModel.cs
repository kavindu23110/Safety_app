using FluentValidation;
using Safety_app.Models;
using Safety_app.Views;
using Xamarin.Forms;

namespace Safety_app.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public Command LoginCommand { get; }
        public User user{get;set;}
        private readonly IValidator _validator;
        public LoginViewModel()
        {
            LoginCommand = new Command(OnLoginClicked);
         
            user = new User();
        }

        private async void OnLoginClicked(object obj)
        {
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
            await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");
        }
    }
}
