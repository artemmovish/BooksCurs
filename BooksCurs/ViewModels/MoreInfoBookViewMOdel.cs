using BooksCurs.models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace BooksCurs.ViewModels
{
    public partial class MoreInfoBookViewMOdel : ObservableObject, IQueryAttributable
    {
        [ObservableProperty]
        Book book_;

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            Book_ = query["Book"] as Book;
        }

        [RelayCommand]
        async Task GoBack()
        {
            await Shell.Current.GoToAsync("///BooksPage");
        }
    }
}