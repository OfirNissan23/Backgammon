using Backgammon.ModelsLogic;
using System.Windows.Input;
using Backgammon.Models;
using Backgammon.Views;
namespace Backgammon.ViewModels
{
    public class SignUpPageVM : ObservableObject
    {
        public readonly User user = new();
        public ICommand SignUpCommand { get; }
        public ICommand IsPasswordCommand { get; }
        public ICommand SaveMeCommand => new Command(UpdateSaveMe);
        public ICommand NavigateToLoginComand { get; }
        public string Name
        {
            get => user.Name;
            set
            {
                if (user.Name != value)
                {
                    user.Name = value;
                    (SignUpCommand as Command)?.ChangeCanExecute();
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
                    (SignUpCommand as Command)?.ChangeCanExecute();
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
                    (SignUpCommand as Command)?.ChangeCanExecute();
                }
            }
        }
        public string Address
        {
            get => user.Address;
            set
            {
                if (user.Address != value)
                {
                    user.Address = value;
                    (SignUpCommand as Command)?.ChangeCanExecute();
                }
            }
        }
        public string Instagram
        {
            get => user.Instagram;
            set
            {
                if (user.Instagram != value)
                {
                    user.Instagram = value;
                    (SignUpCommand as Command)?.ChangeCanExecute();
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
                    (SignUpCommand as Command)?.ChangeCanExecute();
                }
            }
        }
        public bool IsBusy { get; set; } = false;
        public bool IsPassword { get; set; } = true;
        public bool SaveMe { get; set; } = false;
        public SignUpPageVM()
        {
            IsPasswordCommand = new Command(UpdateIsPassword);
            SignUpCommand = new Command(async () => await SignUp(), CanSignUp);
            NavigateToLoginComand = new Command(async () =>
            {
                await Application.Current!.MainPage!.Navigation.PushAsync(new LoginPage());
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
        public async Task SignUp()
        {
            user.SignUp();
            IsBusy = true;
            OnPropertyChanged(nameof(IsBusy));
            await Task.Delay(3000);
            IsBusy = false;
            OnPropertyChanged(nameof(IsBusy));
            await Application.Current!.MainPage!.Navigation.PushAsync(new MainPage());
        }
        private bool CanSignUp()
        {
            return !string.IsNullOrWhiteSpace(Name) && !string.IsNullOrWhiteSpace(Password) && !string.IsNullOrWhiteSpace(Email) && !string.IsNullOrWhiteSpace(Phone) && !string.IsNullOrWhiteSpace(Instagram) && !string.IsNullOrWhiteSpace(Address);
        }
    }
}
