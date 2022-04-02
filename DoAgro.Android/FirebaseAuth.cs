using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Firebase;
using Microsoft.AspNetCore.Authentication;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace DoAgro.Droid
{
    class FirebaseAuth : IAuthenticationService
    {
        public FirebaseAuth()
        {
            
        }
        public Task<AuthenticateResult> AuthenticateAsync(HttpContext context, string scheme)
        {
            throw new NotImplementedException();
        }

        public Task ChallengeAsync(HttpContext context, string scheme, AuthenticationProperties properties)
        {
            throw new NotImplementedException();
        }

        public Task ForbidAsync(HttpContext context, string scheme, AuthenticationProperties properties)
        {
            throw new NotImplementedException();
        }

        public Task SignInAsync(HttpContext context, string scheme, ClaimsPrincipal principal, AuthenticationProperties properties)
        {
            throw new NotImplementedException();
        }

        public Task SignOutAsync(HttpContext context, string scheme, AuthenticationProperties properties)
        {
            throw new NotImplementedException();
        }
        /*public async Task <string> LogIn(string email, string password)
        {
            var auth
        }
        */
    }
}