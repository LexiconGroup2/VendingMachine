using System.Collections.Generic;
using Xunit;
using VendingMachine;

namespace VendingMachineTests
{
    public class VendingMachineControllerTests
    {
        [Fact]
        public void Greeting_ShouldReturnWelcomeMessage()
        {
            // Arrange
            var expected = "Welcome to the vending machine!";

            // Act
            var actual = VendingMachineController.Greeting();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("T")]
        [InlineData("D")]
        [InlineData("S")]
        public void Menu_ShouldReturnSelectedCategory(string category)
        {
            // Act
            var actual = VendingMachineController.Menu(category);

            // Assert
            Assert.Equal(category, actual);
        }

        [Fact]
        public void SubMenu_ShouldReturnSelectedOption()
        {
            // Arrange
            var category = "T";
            var previousChoice = "SomeChoice";
            var productDict = new Dictionary<int, string> { { 1, "Toy" } };
            var selectedCategory = "T";

            // Act
            var actual = VendingMachineController.SubMenu(category, previousChoice, productDict, selectedCategory);

            // Assert
            Assert.Equal(1, actual); // Assuming SubMenu returns 1 in this case
        }

        [Fact]
        public void PurchaseProduct_ShouldNotThrowException()
        {
            // Arrange
            var selectedOption = 1;

            // Act & Assert
            var exception = Record.Exception(() => VendingMachineController.PurchaseProduct(selectedOption));
            Assert.Null(exception);
        }

        [Fact]
        public void InsertCoin_ShouldNotThrowException()
        {
            // Act & Assert
            var exception = Record.Exception(() => VendingMachineController.InsertCoin());
            Assert.Null(exception);
        }

        [Fact]
        public void ViewCart_ShouldNotThrowException()
        {
            // Act & Assert
            var exception = Record.Exception(() => VendingMachineController.ViewCart());
            Assert.Null(exception);
        }

        [Fact]
        public void Checkout_ShouldNotThrowException()
        {
            // Act & Assert
            var exception = Record.Exception(() => VendingMachineController.Checkout());
            Assert.Null(exception);
        }
    }
}