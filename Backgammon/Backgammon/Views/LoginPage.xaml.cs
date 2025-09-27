using Backgammon.ViewModels;
namespace Backgammon.Views;
public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
        InitializeComponent();
        BindingContext = new LoginPageVM();
    }
}

