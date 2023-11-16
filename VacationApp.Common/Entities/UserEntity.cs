using Microsoft.AspNetCore.Identity;

namespace VacationApp.Common.Entities;

public class UserEntity : IdentityUser
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
}
