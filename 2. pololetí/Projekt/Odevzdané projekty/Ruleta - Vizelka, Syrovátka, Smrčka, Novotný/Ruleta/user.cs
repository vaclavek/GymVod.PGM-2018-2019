using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ruleta
{
    [Serializable]
    class User
    {
            public string Login;
            public int PasswordHash;

            public User(string login, string password)
            {
                Login = login;
                PasswordHash = password.GetHashCode();
     
            }
     
    }
}
