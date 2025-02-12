using BooksCurs.models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace BooksCurs.ViewModels.Auth
{
    partial class AuthViewModel : ObservableObject
    {
        [ObservableProperty]
        string login;
        [ObservableProperty]
        string password;

        public AuthViewModel()
        {

        }

        [RelayCommand]
        async Task Login()
        {
            var user = new User()
            {
                login = login,
                password = password
            };

            var client = new ApiClient();

            await client.AuthorizeUser(user);

            await Shell.Current.GoToAsync("..");
        }
    }
}
