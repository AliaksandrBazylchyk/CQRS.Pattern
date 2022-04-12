namespace CQRS.Pattern.Models.Requests
{
    public class CreatePersonRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public uint Age { get; set; }
    }
}