using NUnit.Framework;
using MyCalculator.Services;
using MyCalculator.ViewModels;
using MvvmCross.Tests;
using System;

namespace Tests
{
    [TestFixture]
    public class Tests  : MvxIoCSupportingTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestSquared()
        {
            base.Setup();
            var vm = new SquareRootViewModel(new SquareRootService());

            var original = vm.Number;
        
            vm.ClickCommand2.Execute();

            Assert.AreEqual(original*original, vm.Squared);

        }

        [Test]
        public void TestRoot()
        {
            base.Setup();
            var vm = new SquareRootViewModel(new SquareRootService());

            var original = vm.Number;

            vm.ClickCommand.Execute();

            Assert.AreEqual(Math.Sqrt(original), vm.SquareRoot);

        }

        [Test]
        public void TestInvalid()
        {
            base.Setup();
            var vm = new SquareRootViewModel(new SquareRootService());

            vm.Number = -10;

            vm.ClickCommand.Execute();

            Assert.AreEqual(0, vm.Squared);

        }

    }   
}