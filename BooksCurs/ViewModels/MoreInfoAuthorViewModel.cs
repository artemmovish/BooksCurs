using BooksCurs.models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace BooksCurs.ViewModels
{
    public partial class MoreInfoAuthorViewModel : ObservableObject, IQueryAttributable
    {
        [ObservableProperty]
        ObservableCollection<Book> books;
        [ObservableProperty]
        Author author;

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            Books = query["Books"] as ObservableCollection<Book>;
            Author = query["Author"] as Author;
        }

        [RelayCommand]
        async Task GoBack()
        {
            await Shell.Current.GoToAsync("//AuthorsPage");
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
    }
}
