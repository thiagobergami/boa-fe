// <copyright file="ClientServiceTests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using API.Data;
using API.Entities;
using API.Services;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace API.UnitTests.Services;
public class ClientServiceTests
{
    [Fact]
    public async Task ListAllClients_ReturnListOfClients()
    {
        // Arrange
        var clientsData = new List<Clients>
        {
            new Clients { Id = 1, Name = "Thiago", Age = 20, Email = "thiago@t.com" },
            new Clients { Id = 2, Name = "Guedes", Age = 20, Email = "guedes@t.com" },
        }.AsQueryable();

        var options = new DbContextOptionsBuilder<DataContext>()
            .UseInMemoryDatabase(databaseName: "InMemoryDatabase")
            .Options;

        using (var context = new DataContext(options))
        {
            context.Clients.AddRange(clientsData);
            context.SaveChanges();
        }

        using (var context = new DataContext(options))
        {
            var clientService = new ClientService(context);

            // Act
            var result = await clientService.ListAllClients();

            // Assert
            Assert.NotNull(result.Value);
            Assert.IsType<List<Clients>>(result.Value);
            Assert.Equal(3, result.Value.Count());
        }
    }

    [Fact]
    public async Task CreateClient_ReturnCreatedClient()
    {
        // Arrange
        var client = new Clients { Id = 3, Name = "Thiago", Age = 20, Email = "thiago@t.com" };
        var options = new DbContextOptionsBuilder<DataContext>()
            .UseInMemoryDatabase(databaseName: "InMemoryDatabase")
            .Options;

        using (var context = new DataContext(options))
        {
            var clientService = new ClientService(context);

            // Act
            var result = await clientService.CreateClient(client);

            // Assert
            Assert.Equal(1, result);
        }
    }
}
