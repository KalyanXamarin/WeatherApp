using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherApp.Services
{
    public class ServiceResult<T>
    {
        public bool IsSucess { get; set; }
        public string ErrorMessage { get; set; }
        public T Result { get; set; }
        public ServiceResult(bool isSucess,string errorMessage,T result)
        {
            IsSucess = isSucess;
            ErrorMessage = errorMessage;
            Result = result;
        }
        public ServiceResult(bool isSucess, string errorMessage)
        {
            IsSucess = isSucess;
            ErrorMessage = errorMessage;
        }
    }
}
