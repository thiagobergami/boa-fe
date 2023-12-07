// <copyright file="Properties.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities;

public class Properties
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    public int UnitId { get; set; }

    public virtual Units Unit { get; set; }

    public int ClientId { get; set; }

    public virtual Clients Client { get; set; }
}
