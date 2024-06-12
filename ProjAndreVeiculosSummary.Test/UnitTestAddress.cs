using Microsoft.EntityFrameworkCore;
using Models;
using MongoDB.Driver;
using ProjAndreVeiculosSummary.Controllers;
using ProjAndreVeiculosSummary.Data;

namespace ProjAndreVeiculosSummary.Test
{
    public class UnitTestAddress
    {
        private DbContextOptions<ProjAndreVeiculosSummaryContext> options;

        private void InitializeDataBase()
        {
            options = new DbContextOptionsBuilder<ProjAndreVeiculosSummaryContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
            using(var context = new ProjAndreVeiculosSummaryContext(options))
            {
                context.Address.Add(new Models.Address { Id = 1, Cep = "00000-000", Description = "Teste 1" });
                context.Address.Add(new Models.Address { Id = 2, Cep = "00000-001", Description = "Teste 2" });
                context.Address.Add(new Models.Address { Id = 3, Cep = "00000-002", Description = "Teste 3" });
                context.SaveChanges();
            }
        }
        [Fact]
        public void TestGetAll()
        {
            InitializeDataBase();
            using (var context = new ProjAndreVeiculosSummaryContext(options))
            {
                AddressesController addressesController = new AddressesController(context);
                IEnumerable<Address> addresses = addressesController.GetAddress().Result.Value;
                Assert.Equal(3, addresses.Count());
            }
        }
        [Fact]
        public void TestGetById()
                    {
            InitializeDataBase();
            using (var context = new ProjAndreVeiculosSummaryContext(options))
            {
                AddressesController addressesController = new AddressesController(context);
                Address address = addressesController.GetAddress(1).Result.Value;
                Assert.Equal(1, address.Id);
            }
        }
        [Fact]
        public void TestCreate()
        {
            InitializeDataBase();

            using (var context = new ProjAndreVeiculosSummaryContext(options))
            {
                AddressesController addressesController = new AddressesController(context);
                Address address = new Address { Id = 4, Cep = "00000-003", Description = "Teste 4" };
                var add = addressesController.PostAddress(address).Result.Value;
                Assert.Equal(4, add.Id);
            }
        }
    }
}