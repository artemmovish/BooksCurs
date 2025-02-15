using BooksCurs.models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using static System.Reflection.Metadata.BlobBuilder;


namespace BooksCurs.ViewModels
{
    public partial class AuthorViewModel : ObservableObject
    {
        [ObservableProperty]
        ObservableCollection<Author> authors;
        [ObservableProperty]
        ObservableCollection<Author> authorsSort;
        [ObservableProperty]
        string searchText;

        public AuthorViewModel()
        {
            LoadData();
        }

        private async Task LoadData()
        {
            try
            {
                var client = new ApiClient();
                Authors = new ObservableCollection<Author>(await client.GetAllAuthors());

                AuthorsSort = new ObservableCollection<Author>(Authors);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка загрузки данных: {ex.Message}");
            }
        }

        [RelayCommand]
        async Task Search()
        {
            AuthorsSort = new ObservableCollection<Author>(Authors.Where(author => author.lname.StartsWith(SearchText)));
        }

        [RelayCommand]
        async Task MoreInfo(Author author)
        {
            var client = new ApiClient();

            var books = new ObservableCollection<Book>(await client.GetAllBooks());

            books = new ObservableCollection<Book>(books.Where(book => book.author.lname == author.lname));

            await Shell.Current.GoToAsync("//MoreInfoAuthorPage", new Dictionary<string, object>
            {
                    { "Books", books },
                    {"Author", author}
            });
        }
    }
}
