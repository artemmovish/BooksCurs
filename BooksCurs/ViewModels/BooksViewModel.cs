using BooksCurs.models;
using BooksCurs.Views.Auth;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace BooksCurs.ViewModels
{
    partial class BooksViewModel : ObservableObject
    {
        [ObservableProperty]
        ObservableCollection<Book> books;
        [ObservableProperty]
        ObservableCollection<Book> booksSort;
        [ObservableProperty]
        ObservableCollection<string> genres;

        [ObservableProperty]
        string searchText = "";

        public BooksViewModel()
        {
            LoadData();
        }

        private async Task LoadData()
        {
            try
            {
                Genres = new ObservableCollection<string>();
                var client = new ApiClient();
                Books = new ObservableCollection<Book>(await client.GetAllBooks());
                BooksSort = new ObservableCollection<Book>(Books);

                var uniqueGenres = new HashSet<string>();

                foreach (var item in Books)
                {
                    uniqueGenres.Add(item.genre.style);
                }

                Genres = new ObservableCollection<string>(uniqueGenres.ToList());

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка загрузки данных: {ex.Message}");
            }
        }

        [RelayCommand]
        async Task Search()
        {
            BooksSort = new ObservableCollection<Book>(Books.Where(book => book.title.StartsWith(SearchText)));
        }

        [RelayCommand]
        async Task MoreInfo(Book book)
        {
            if (book != null)
            {
                await Shell.Current.GoToAsync($"//MoreInfoBook", new Dictionary<string, object>
                {
                    { "Book", book }
                });
            }
        }

        [RelayCommand]
        async Task Filtred(string str)
        {
            await Search();
            BooksSort = new ObservableCollection<Book>(BooksSort.Where(b => b.genre.style == str));
        }
    }
}
