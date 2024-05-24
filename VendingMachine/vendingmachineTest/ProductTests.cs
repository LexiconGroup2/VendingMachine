using Xunit;
using VendingMachine;

namespace VendingmachineTest
{
    public class ProductTests
    {
        [Fact]
        public void Drink_Examine_ShouldReturnCorrectDetails()
        {
            // Arrange
            var drink = new Drink("Pepsi", 20, "Drink", 300, "Classic cola drink");

            // Act
            var details = drink.Examine();

            // Assert
            Assert.Equal($"Drink: Pepsi, Price: 20kr, Milliliters: 300, Description: Classic cola drink", details);
        }

        [Fact]
        public void Drink_Use_ShouldOutputCorrectMessage()
        {
            // Arrange
            var drink = new Drink("Fanta", 18, "Drink", 200, "Fruity orange soda");
            var expectedOutput = $"You drink the {drink.Name}. Refreshing!";
            using (var sw = new System.IO.StringWriter())
            {
                Console.SetOut(sw);

                // Act
                drink.Use();

                // Assert
                Assert.Equal(expectedOutput, sw.ToString().Trim());
            }
        }
        [Fact]
        public void Snack_Examine_ShouldReturnCorrectDetails()
        {
            // Arrange
            var snack = new Snack("Chips", 20, "Snack", 200, "Delicious crispy chips");

            // Act
            var details = snack.Examine();

            // Assert
            Assert.Equal($"Snack: Chips, Price: 20kr, Calories: 200, Description: Delicious crispy chips", details);
        }

        [Fact]
        public void Snack_Use_ShouldOutputCorrectMessage()
        {
            // Arrange
            var snack = new Snack("Chocolate", 25, "Snack", 150, "Creamy milk chocolate bar");
            var expectedOutput = $"You eat the {snack.Name}. Tasty!";
            using (var sw = new System.IO.StringWriter())
            {
                Console.SetOut(sw);

                // Act
                snack.Use();

                // Assert
                Assert.Equal(expectedOutput, sw.ToString().Trim());
            }
        }

        [Fact]
        public void Toy_Examine_ShouldReturnCorrectDetails()
        {
            // Arrange
            var toy = new Toy("Spider man", 50, "Toy", "Plastic", "Cool action figure");

            // Act
            var details = toy.Examine();

            // Assert
            Assert.Equal($"Product: Spider man, Price: 50kr, Material: Plastic, Description: Cool action figure", details);
        }

        [Fact]
        public void Toy_Use_ShouldOutputCorrectMessage()
        {
            // Arrange
            var toy = new Toy("Batman", 100, "Toy", "Plastic", "Dark knight action figure");
            var expectedOutput = $"You play with the {toy.Name}. Fun!";
            using (var sw = new System.IO.StringWriter())
            {
                Console.SetOut(sw);

                // Act
                toy.Use();

                // Assert
                Assert.Equal(expectedOutput, sw.ToString().Trim());
            }
        }

    }
}
