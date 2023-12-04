namespace API.DTO;

public class CondominiumDTO
{
    public int Id { get; set; }

    public string Name { get; set; }

    public List<CondominumUnitDTO> Units { get; set; }
}
