namespace VacationApp.Common.Entities;

public class VacationStatus
{
    public VacationStatus(string name)
    {
        Id = Guid.NewGuid().ToString();
        Name = name;
    }
    
    public string Id { get; set; }
    public string Name { get; set; }
}

