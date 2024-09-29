 
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Firebase.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 

namespace Go_Trade.Pages
{
    public partial class SignInModel : ObservableObject
    {
        private readonly FirebaseAuthClient _client;

        [ObservableProperty]
        private string _email;
        [ObservableProperty]
        private string _password;
        public SignInModel(FirebaseAuthClient client)
        {
            _client = client;
        }

        [RelayCommand]
        private async Task SignIn()
        {
            try
            { 
                await _client.SignInWithEmailAndPasswordAsync(Email, Password);

                
                await Shell.Current.GoToAsync("//HomePage");
            }
            catch (Exception ex)
            {
                
                Console.WriteLine($"Sign-in failed: {ex.Message}");
                
            }

        }
        [RelayCommand]
        private async Task NavigateToSignUp()
        {
            await Shell.Current.GoToAsync("//SignUp");
        }
    }
}
