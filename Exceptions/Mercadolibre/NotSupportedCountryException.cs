using System;

namespace Service.Exceptions
{
    public class CountryNotSupportedException: Exception
    {
        public CountryNotSupportedException():base()
        {
        }
        
        public CountryNotSupportedException(string message):base(message)
        {
        }
        
        

    }
}
