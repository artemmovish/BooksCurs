using BooksCurs.models;
using BooksCurs.Views;
using BooksCurs.Views.Auth;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksCurs.ViewModels.Auth
{
    partial class RegViewModel : ObservableObject
    {
        [ObservableProperty]
        string name;
        [ObservableProperty]
        string password;
        [ObservableProperty]
        string lname;
        [ObservableProperty]
        string fname;
        [ObservableProperty]
        string login;

        [RelayCommand]
        async Task Register()
        {
            var user = new User
            {
                name = name,
                password = password,
                lname = lname,
                login = login,
                fname = fname
            };

            var client = new ApiClient();
            await client.RegisterUser(user);
            await Shell.Current.GoToAsync("../..");
        }

        [RelayCommand]
        async Task ToLogin()
        {
            await Shell.Current.GoToAsync(nameof(AuthPage));
        }
    }
}
