using Backgammon.Models;
using Backgammon.ModelsLogic;
using Backgammon.Views;
using System.Windows.Input;
namespace Backgammon.ViewModels
{
    public class LoginPageVM : ObservableObject
    {
        public readonly User user = new();
        public ICommand LoginCommand { get; }
        public ICommand IsPasswordCommand { get; }
        public ICommand SaveMeCommand => new Command(UpdateSaveMe);
        public ICommand NavigateToSignUpCommand { get; }
        public string Name
        { 
            get => user.Name; 
            set
            {
                if(user.Name != value)
                {
                    user.Name = value;
                    (LoginCommand as Command)?.ChangeCanExecute();
                }
            }
        } 
        public string Password 
        {
            get => user.Password;
            set
            {
                if (user.Password != value)
                {
                    user.Password = value;
                    (LoginCommand as Command)?.ChangeCanExecute();
                }
            }
        } 
        public string Email 
        {
            get => user.Email;
            set
            {
                if (user.Email != value)
                {
                    user.Email = value;
                    (LoginCommand as Command)?.ChangeCanExecute();
                }
            }
        }
        public string Phone
        {
            get => user.Phone;
            set
            {
                if (user.Phone != value)
                {
                    user.Phone = value;
                    (LoginCommand as Command)?.ChangeCanExecute();
                }
            }
        }
        public bool IsBusy { get; set; } = false;
        public bool IsPassword { get; set; } = true;
        public bool SaveMe { get; set; } = false;
        public LoginPageVM()
        {
            IsPasswordCommand = new Command(UpdateIsPassword);
            LoginCommand = new Command(async () => await Login(), CanLogin);
            NavigateToSignUpCommand = new Command(async () =>
            {
                await Application.Current!.MainPage!.Navigation.PushAsync(new SignUpPage());
            });
        }
        public void UpdateIsPassword()
        {
            IsPassword = !IsPassword;
            OnPropertyChanged(nameof(IsPassword));
        }
        public void UpdateSaveMe()
        {
            SaveMe = !SaveMe;
            user.UpdateSaveMe();
            OnPropertyChanged(nameof(SaveMe));
        }
        public async Task Login()
        {
            user.Login();
            IsBusy = true;
            OnPropertyChanged(nameof(IsBusy));
            await Task.Delay(3000);
            IsBusy = false;
            OnPropertyChanged(nameof(IsBusy));
            await Application.Current!.MainPage!.Navigation.PushAsync(new MainPage());
        }
        private bool CanLogin()
        {
            return !string.IsNullOrWhiteSpace(Name) && !string.IsNullOrWhiteSpace(Password) && !string.IsNullOrWhiteSpace(Email) && !string.IsNullOrWhiteSpace(Phone);
        }
    }
}
