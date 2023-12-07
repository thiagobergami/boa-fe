// <copyright file="Maintenances.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace API.Entities;

public class Maintenances
{
    public int Id { get; set; }

    [Required]
    public int UnitID { get; set; }

    [JsonIgnore]
    public Units Unity { get; set; }

    [Required]
    public string ProblemDescription { get; set; }

    public bool IsSolved { get; set; }

    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }
}
