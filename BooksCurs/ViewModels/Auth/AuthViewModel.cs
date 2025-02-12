using BooksCurs.models;
using BooksCurs.Views;
using BooksCurs.Views.Auth;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace BooksCurs.ViewModels.Auth
{
    partial class AuthViewModel : ObservableObject
    {
        [ObservableProperty]
        string login = "artemka";
        [ObservableProperty]
        string password = "12345678";

        public AuthViewModel()
        {

        }

        [RelayCommand]
        async Task Logins()
        {
            var user = new User()
            {
                login = Login,
                password = password
            };

            var client = new ApiClient();

            await client.AuthorizeUser(user);
            
            Application.Current.MainPage = new AppShell();
        }

        [RelayCommand]
        async Task ToRegister()
        {
            await Shell.Current.GoToAsync(nameof(RegPage));
        }
    }
}
