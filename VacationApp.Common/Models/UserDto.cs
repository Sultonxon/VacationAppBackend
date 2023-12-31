using VacationApp.Common.Entities;

namespace VacationApp.Common.Models;

public class UserDto
{
    public string Id { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    
    public UserDto(){}

    public UserDto(UserEntity entity)
    {
        Id = entity.Id;
        UserName = entity.UserName;
        Email = entity.Email;
        FirstName = entity.FirstName;
        LastName = entity.LastName;
    }
}