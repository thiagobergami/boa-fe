namespace API.DTO;

public class MaintenanceUnitDTO
{
    public int Id { get; set; }
    public string ProblemDescription { get; set; }
    public bool IsSolved { get; set; }
    public DateTime UpdatedAt { get; set; }
    public DateTime CreatedAt { get; set; }
}
