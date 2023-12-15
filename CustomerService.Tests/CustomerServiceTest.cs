using System.Reflection;
using System.Runtime.Intrinsics.Arm;
using CustomerService;
using Microsoft.VisualStudio.TestPlatform.Common.Utilities;
using Testcontainers.PostgreSql;

namespace Customers.Tests;

public sealed class CustomerServiceTest : IAsyncLifetime
{    
  //"postgres:15-alpine"
  private readonly PostgreSqlContainer _db = new PostgreSqlBuilder()
  .WithImage("postgres:15-alpine")
  .Build();   

    public async Task InitializeAsync()
    {
        await _db.StartAsync();
    }

  public async Task DisposeAsync()
    {
        await _db.DisposeAsync();
    }
    
    [Fact]    
    public void ShouldFindTwoCustomersAfterCreateTwoCustomers() {
      //Arrange     
      var service = new CustomerService(new DbConnectionProvider(_db.GetConnectionString()));

      //Act Insert 3 Customers :  
      service.Create(new Customer(1, "Criteo"));   
      service.Create(new Customer(2, "Snwocap"));
      service.Create(new Customer(3, "CraftsRecords"));

      //Act: Get Customers are found   
      var customers = service.GetCustomers();

      //Assert: 
      Assert.Equal(3, customers.Count());
    }
}