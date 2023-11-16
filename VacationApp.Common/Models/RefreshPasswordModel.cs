using System.ComponentModel.DataAnnotations;

namespace VacationApp.Common.Models;

public class RefreshPasswordModel
{
    [Required]
    public string Id { get; set; }
    [Required]
    public string Password { get; set; }
}