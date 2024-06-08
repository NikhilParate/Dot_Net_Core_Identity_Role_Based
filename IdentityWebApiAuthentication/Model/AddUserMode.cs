namespace IdentityWebApiAuthentication.Model
{
    public class AddUserMode
    {
        public string? UserEmail { get; set; }
        public string[]? Roles { get; set; }
    }
}
