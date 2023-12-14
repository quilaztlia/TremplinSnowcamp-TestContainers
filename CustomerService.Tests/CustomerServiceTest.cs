using System.Reflection;
using System.Runtime.Intrinsics.Arm;
using CustomerService;
using Testcontainers.PostgreSql;

namespace Customers.Tests;

public sealed class CustomerServiceTest
{    
  //"postgres:15-alpine"
    [Fact]
    public void ShouldFindTwoCustomersAfterCreateTwoCustomers() {
      //Arrange

      //Act Insert 3 Customers :     
      //Act: Get Customers are found                  

      //Assert: 
    }
}