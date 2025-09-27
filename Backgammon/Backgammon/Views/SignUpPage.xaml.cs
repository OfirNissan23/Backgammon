using Backgammon.ViewModels;
namespace Backgammon.Views;
public partial class SignUpPage : ContentPage
{
	public SignUpPage()
	{
		InitializeComponent();
        BindingContext = new SignUpPageVM();
    }
}