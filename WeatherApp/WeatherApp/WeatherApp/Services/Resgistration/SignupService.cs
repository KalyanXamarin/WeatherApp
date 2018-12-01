using System;
using System.Collections.Generic;
using System.Text;
using WeatherApp.DataBase;
using WeatherApp.DataBase.Sqlite;

namespace WeatherApp.Services.Resgistration
{
    public class SignUpService
    {
        public ServiceResult<UserInfo> StoreUserInfo(UserInfo userInfo)
        {
            //todo server register for now data bae only
            if (DataManagerRepository.Instanace.RegisterUser(userInfo))
            {
                return new ServiceResult<UserInfo>(true, "", userInfo);
            }
            else
            {
                return new ServiceResult<UserInfo>(false, "Error occured while storing the account");
            }
        }
    }
}
