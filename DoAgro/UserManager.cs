using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Firebase.Auth;

namespace DoAgro
{
    class UserManager
    {
        public string WebAPIkey = "AIzaSyAORmGx7StS_KVkahljSogKIIvCAbEO26c";
        FirebaseAuthProvider authProvider;
        
        public UserManager()
        {
            authProvider = new FirebaseAuthProvider(new FirebaseConfig(WebAPIkey));
        }

        public async Task<bool> Autentificare(string email, string username, string parola)
        {
            var token = await authProvider.CreateUserWithEmailAndPasswordAsync(email, parola, username);
            if (!string.IsNullOrEmpty(token.FirebaseToken))
            {
                return true;
            }
            return false;
        }
        /*
        public async Task<bool> Logare(string email, string parola)
        {
            var token = await authProvider.SignInWithEmailAndPasswordAsync(email, parola);
            if (!string.IsNullOrEmpty(token.FirebaseToken))
            {
                return token.FirebaseToken;
            }
            return "Nu a reusit logarea";
        }
        */

        public async Task<bool>SchimbareParola(string email)
        {
            await authProvider.SendPasswordResetEmailAsync(email);
            return true;
        }
    }
}
