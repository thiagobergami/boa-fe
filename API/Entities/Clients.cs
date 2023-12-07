// <copyright file="Clients.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace API.Entities;

public class Clients
{
    public Clients()
    {
        this.CreatedAt = DateTime.UtcNow;
        this.UpdatedAt = DateTime.UtcNow;
    }

    public int Id { get; set; }

    [Required]
    public required string Name { get; set; }

    [Required]
    public required int Age { get; set; }

    public required string Email { get; set; }

    [JsonIgnore]
    public List<Units> RentUnits { get; set; }

    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [JsonIgnore]
    public ICollection<Properties> Properties { get; set; }
}
