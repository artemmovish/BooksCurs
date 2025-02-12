using BooksCurs.models;
using BooksCurs.Views.Auth;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksCurs.ViewModels
{
    partial class BooksViewModel : ObservableObject
    {
        [ObservableProperty]
        ObservableCollection<Book> books;


        public BooksViewModel()
        {
            LoadData();
        }


        private async Task LoadData()
        {
            try
            {
                var client = new ApiClient();
                Books = new ObservableCollection<Book>(await client.GetAllBooks());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка загрузки данных: {ex.Message}");
            }
        }
    }
}
