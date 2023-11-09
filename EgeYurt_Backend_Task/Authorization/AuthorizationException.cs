namespace EgeYurt_Backend_Task.Authorization
{
    public class AuthorizationException:Exception
    {
        public AuthorizationException(string message):base(message) 
        { }
    }
}
