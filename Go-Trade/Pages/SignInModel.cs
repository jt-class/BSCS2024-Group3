 
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


        [RelayCommand]
        private async Task SignIn()
        {
            await _client.SignInWithEmailAndPasswordAsync(Email, Password);


        }
        [RelayCommand]
        private async Task NavigateToSignUp()
        {
            await Shell.Current.GoToAsync("//SignUp");
        }
    }
}
