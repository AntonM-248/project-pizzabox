using Xunit;
using PizzaBox.Domain.Models;

namespace PizzaBox.Testing.Tests
{
    public class StoreTests
    {
        [Fact]//makes following method a test
        public void Test_StoreName()
        {
            //arrange: set up test
            var sut = new ChicagoStore();
            //act: carry out test
            var actual = sut.Name;
            //assert: check if result are correct
            Assert.True(actual == "ChicagoStore");
        }
    }
}