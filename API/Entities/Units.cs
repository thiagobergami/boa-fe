using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace API.Entities;

public class Units
{   
    public Units()
    {
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
    }
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public string Adress { get; set; }

    [JsonIgnore]
    public int? TenantClientId { get; set; }

    [JsonIgnore]    
    public DateTime TenantStartedAt { get; set; }

    [JsonIgnore]
    public DateTime TenantFinishedAt { get; set; }    

    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [JsonIgnore]
    public int? CondominiumId { get; set; }

    [JsonIgnore]
    public Condominiums Condominium { get; set; }    

    [JsonIgnore]
    public Clients TenantClient { get; set; }

    [JsonIgnore]
    public List<Maintenances> Maintenances { get; set; }
    [JsonIgnore]
    public ICollection<Properties> Properties { get; set; }
}
