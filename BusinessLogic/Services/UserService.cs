using DataAccess.Data;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Services
{
    public class UserService
    {
         RegistrationContext registrationContext=new RegistrationContext();
         UserDeatails urserDeatails=new UserDeatails();
        
        
       
        public void GetDetails(UserDeatails urserDeatails)
        {
            registrationContext.Add(urserDeatails);
            registrationContext.SaveChanges();

        }
        public bool GetByFilter(string Email)
        {
            int id = registrationContext.UserDeatails.Where(x => x.Email == Email).Select(i => i.Id).FirstOrDefault();
            if (id==0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool UserExists(string Email,string Password)
        {
            int loginId = registrationContext.UserDeatails.Where(x => x.Email == Email && x.Password == Password).Select(i=>i.Id).FirstOrDefault();
            if(loginId==0)
            {
                return false;
            }
            return true;
            
        }


    }
}
