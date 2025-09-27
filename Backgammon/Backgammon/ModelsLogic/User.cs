using Backgammon.Models;
namespace Backgammon.ModelsLogic
{
    public class User : UserModel
    {
        public override void Login()
        {
            if (currentState == SaveMeState.WantSave)
            {
                Preferences.Set(Keys.NameKey, Name);
                Preferences.Set(Keys.PasswordKey, Password);
                Preferences.Set(Keys.EmailKey, Email);
                Preferences.Set(Keys.PhoneKey, Phone);
            }
            else
            {
                Preferences.Set(Keys.NameKey, string.Empty);
                Preferences.Set(Keys.PasswordKey, string.Empty);
                Preferences.Set(Keys.EmailKey, string.Empty);
                Preferences.Set(Keys.PhoneKey, string.Empty);
                Preferences.Set(Keys.InstagramKey, string.Empty);
                Preferences.Set(Keys.AddressKey, string.Empty);
            }
        }
        public override void SignUp()
        {
            if (currentState == SaveMeState.WantSave)
            {
                Preferences.Set(Keys.InstagramKey, Instagram);
                Preferences.Set(Keys.AddressKey, Address);
            }
             Login();
        }
        public override void UpdateSaveMe()
        {
            if (currentState == SaveMeState.DontWantSave)
                currentState = SaveMeState.WantSave;
            else
                currentState = SaveMeState.DontWantSave;
        }
        public User()
        {
            Name = Preferences.Get(Keys.NameKey, string.Empty);
            Password = Preferences.Get(Keys.PasswordKey, string.Empty);
            Email = Preferences.Get(Keys.EmailKey, string.Empty);
            Phone = Preferences.Get(Keys.PhoneKey, string.Empty);
            Instagram = Preferences.Get(Keys.InstagramKey, string.Empty);
            Address = Preferences.Get(Keys.AddressKey, string.Empty);
        }
    }
}
