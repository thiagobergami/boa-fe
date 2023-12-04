using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace API.Entities;

public class Condominiums
{   
    public Condominiums()
    {
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
    }
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    [JsonIgnore]
    public List<Units> Units {get; set;}

    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt {get; set;}
}
