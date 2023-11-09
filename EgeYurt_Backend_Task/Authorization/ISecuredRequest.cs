namespace EgeYurt_Backend_Task.Authorization
{
    public interface ISecuredRequest
    {
        public string[] Roles { get; }
    }
}
