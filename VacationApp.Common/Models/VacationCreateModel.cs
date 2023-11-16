using System.ComponentModel.DataAnnotations;

namespace VacationApp.Common.Models;

public class VacationCreateModel
{
    [Required]
    public DateTime DateFrom { get; set; }
    [Required]
    public DateTime DateTo { get; set; }
    [Required]
    public string Reason { get; set; }
}