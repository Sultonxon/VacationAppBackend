namespace VacationApp.Common.Entities;

public class VacationEntity
{
    public string Id { get; set; }
    public DateTime DateFrom { get; set; }
    public DateTime DateTo { get; set; }
    public string? Comment { get; set; }
    public string? Reason { get; set; }
    public string VacationStatusId { get; set; }
    public VacationStatus Status { get; set; }
    public string UserId { get; set; }
    public UserEntity User { get; set; }
}
