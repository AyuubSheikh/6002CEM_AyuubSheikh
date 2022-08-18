using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PlanandBuildApp_.Models;
using System.Linq;
using Firebase.Database;
using Firebase.Database.Query;

namespace PlanandBuildApp_.Services
{
    public class UserServiceLogin
    {
        FirebaseClient client;
        public UserServiceLogin()
        {
            client = new FirebaseClient("https://planandbuildapp-72e6e-default-rtdb.firebaseio.com");
        }

        public async Task<bool> IsUserExists_(string uname_)
        {
            var user = (await client.Child("Users").OnceAsync<User>())
                .Where(u => u.Object.Username_ == uname_).FirstOrDefault(); 

            return (user != null);
        }
        public async Task<bool> RegisterUser(string uname_, string pword_)
        {
            if (await IsUserExists_(uname_) == false)
            {
                await client.Child("Users").PostAsync(new User()
                {
                    Username_ = uname_,
                    Password_ = pword_,
                });
                return true;
            }
            else
            {
                return false;
            }
        }
        public async Task<bool> LoginUser(string uname_, string pword_)
        {
            var user = (await client.Child("Users")
                .OnceAsync<User>()).Where(u => u.Object.Username_ == uname_)
                .Where(u => u.Object.Password_ == pword_).FirstOrDefault();

            return (user != null);
        }
    }
}
