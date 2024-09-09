using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Firebase.Auth;
using System;
using System.Threading.Tasks;

namespace Go_Trade.Pages
{
    public partial class SignUpModel : ObservableObject
    {
        private readonly FirebaseAuthClient _client;

        public SignUpModel(FirebaseAuthClient client)
        {
            _client = client;
        }

        [ObservableProperty]
        private string email;

        [ObservableProperty]
        private string password;

        [ObservableProperty]
        private string userName;

        [ObservableProperty]
        private bool isSigningUp;

        [ObservableProperty]
        private string errorMessage;

        [RelayCommand]
        private async Task SignUp()
        {
            if (IsSigningUp) return;

            try
            {
                if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(userName))
                {
                    ErrorMessage = "All fields are required.";
                    return;
                }

                IsSigningUp = true;
                ErrorMessage = string.Empty;

                await _client.CreateUserWithEmailAndPasswordAsync(email, password, userName);
                await Shell.Current.GoToAsync("//SignIn");
            }
            catch (Exception ex)
            {
                ErrorMessage = $"Sign-up failed: {ex.Message}";
            }
            finally
            {
                IsSigningUp = false;
            }
        }

        [RelayCommand]
        private async Task NavigateToSignIn()
        {
            await Shell.Current.GoToAsync("//SignIn");
        }
    }
}
