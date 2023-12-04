namespace API.DTO;

public class UpdateTenantInfoDTO
{
    public int TenantClientId { get; set; }
    public string TenantStartedAt { get; set; }
    public string TenantFinishedAt { get; set; }
}
