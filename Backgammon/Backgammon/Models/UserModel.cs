namespace Backgammon.Models
{
    public abstract class UserModel
    {
        protected enum SaveMeState
        {
            WantSave,
            DontWantSave
        }
        protected SaveMeState currentState = SaveMeState.DontWantSave;  
        public bool IsRegistered => !string.IsNullOrWhiteSpace(Name) && !string.IsNullOrWhiteSpace(Password) && !string.IsNullOrWhiteSpace(Email) && !string.IsNullOrWhiteSpace(Phone);
        public string Name { get; set; } = string.Empty;
        public string Instagram { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public abstract void Login();
        public abstract void SignUp();
        public abstract void UpdateSaveMe();
    }
}
