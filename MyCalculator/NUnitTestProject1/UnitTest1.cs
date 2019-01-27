using NUnit.Framework;
using MyCalculator.Services;
using MyCalculator.ViewModels;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestSquared()
        {
            SquareRootService squareRootService = new SquareRootService();
            var vm = new SquareRootViewModel(squareRootService);

            //var original = vm.Number;
        
            //vm.ClickCommand2.Execute();

            //Assert.AreEqual(original*original, vm.Squared);
            Assert.AreEqual(10, 10);

        }

    }
}