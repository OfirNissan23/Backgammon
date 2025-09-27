using Backgammon.ModelsLogic;
using Backgammon.Views;
namespace Backgammon
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            User user = new();
            Page page = user.IsRegistered ? new LoginPage() : new SignUpPage();
            MainPage = new NavigationPage(page); 
        }
    }
}
