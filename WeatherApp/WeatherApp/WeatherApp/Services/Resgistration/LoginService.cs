using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WeatherApp.DataBase;
using WeatherApp.DataBase.Sqlite;

namespace WeatherApp.Services.Resgistration
{
    public class LoginService
    {
        public ServiceResult<UserInfo> Login(string userName,string password)
        {
            //todo server authentication for now data bae only
            var userlist = DataManagerRepository.Instanace.GetUsersList();
            var selectedUser = userlist?.Where(U => U.UserName == userName).FirstOrDefault();
            if(selectedUser!=null && string.Equals(selectedUser.Password,password))
            {
                return new ServiceResult<UserInfo>(true, "", selectedUser);
            }
            else
            {
                return new ServiceResult<UserInfo>(false,Localization.Translations.Label_InvalidCredentials);
            }
        }
    }
}
