using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities;

public class Clients
{
    public int Id { get; set; }
    
    [Required]
    public required string Name {get; set;}
    [Required]
    public required int Age {get; set;}

    public required string Email {get;set;}

    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt {get; set;}

}
