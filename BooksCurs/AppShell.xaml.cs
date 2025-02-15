using BooksCurs.Views;
using BooksCurs.Views.Auth;

namespace BooksCurs
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(AuthPage), typeof(AuthPage));
            Routing.RegisterRoute(nameof(RegPage), typeof(RegPage));
            Routing.RegisterRoute(nameof(BooksPage), typeof(BooksPage));
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new AuthShell();
        }
    }
}
