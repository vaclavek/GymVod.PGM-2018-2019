using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ruleta
{
    [Serializable]
    class Users : List<User>
    {
        public bool SignIn(string login, string password)
        {
  
            var user = this.FirstOrDefault(u => u.Login == login);
            if (user == null) throw new Exception("Uzivatel se zadanym jmenem neexistuje");

      
            if (user.PasswordHash != password.GetHashCode()) throw new Exception("Spatne heslo");

            return true;
        }

        public void SignupNewUser(string login, string password)
        {
       
            if (this.Any(u => u.Login == login))
                throw new Exception("Uzivatel se stejnym jmenem jiz existuje");

            Add(new User(login, password));
        }
    }
}
