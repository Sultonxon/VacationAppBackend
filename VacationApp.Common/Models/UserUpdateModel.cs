using System.ComponentModel.DataAnnotations;

namespace VacationApp.Common.Models;

public class UserUpdateModel
{
    [Required]
    public string Id { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    public string UserName { get; set; }
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
}