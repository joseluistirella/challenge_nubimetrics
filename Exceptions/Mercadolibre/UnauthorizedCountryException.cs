using System;

namespace Service.Exceptions
{
    public class CountryUnauthorizedException: Exception
    {
        public CountryUnauthorizedException():base()
        {
        }
        
        public CountryUnauthorizedException(string message):base(message)
        {
        }
        
        

    }
}
