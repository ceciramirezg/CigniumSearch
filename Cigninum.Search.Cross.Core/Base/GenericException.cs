using System;

namespace Cigninum.Search.Cross.Core.Base
{
    public abstract class GenericException<T> : System.Exception
         where T : class
    {  
        protected GenericException(string message, System.Exception e)
            : base(message, e)
        {           
            Console.WriteLine(message, e);           
        }
      
        protected GenericException(System.Exception e)
            : base("Error : " + typeof(T).Name + " , see more detail.(view innerException)", e)
        {
            Console.WriteLine("Error : " + typeof(T).Name + " , see more detail.(view innerException)", e);
        }
        
        protected GenericException(string message)
            : base(message)
        {
            Console.WriteLine(message);
        }
    }
}
