using System.ComponentModel.DataAnnotations;

namespace VacationApp.Common.Models;

public class VacationRejectModel
{
    [Required]
    public string Id { get; set; }
    [Required]
    public string Comment { get; set; }
}