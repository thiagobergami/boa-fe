﻿using API.Entities;

namespace API.DTO;

public class UnitsDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public Clients TenantClient { get; set; }
    public DateTime TenantStartedAt { get; set; }
    public DateTime TenantFinishedAt { get; set; }
    public List<MaintenanceUnitDTO> Maintenances { get; set; }
    public int? CondominiumId { get; set; }
    public Condominiums Condominium { get; set; }
    public int TenantClientId { get; set; }
}