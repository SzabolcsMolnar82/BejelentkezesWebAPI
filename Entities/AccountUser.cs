using Microsoft.AspNetCore.Identity;

namespace BejelentkezesWebAPI.Entities
{

    public class AccountUser : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public byte[]? Photo {  get; set; }
    }
}
