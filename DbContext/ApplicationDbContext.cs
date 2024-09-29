using BejelentkezesWebAPI.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BejelentkezesWebAPI.DbContext
{
    public class ApplicationDbContext(DbContextOptions options) : IdentityDbContext<AccountUser>(options)
    {
     
    }
}
