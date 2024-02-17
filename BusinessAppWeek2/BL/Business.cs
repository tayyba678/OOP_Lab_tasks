using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business1User
{
    class SignUp
    {
        public SignUp(string sname, string spassword, string srole)
        {
            name = sname;
            password = spassword;
            role = srole;

        }
        public SignUp()
        {

        }
        public SignUp(string sname, string spassword)
        {
            name = sname;
            password = spassword;
        }
        public string name;
        public string password;
        public string role;
        public bool IsAdmin()
        {
            if(role=="Manager"||role=="manager")
            {
                return true;
            }
            return false;
        }
    }
}




