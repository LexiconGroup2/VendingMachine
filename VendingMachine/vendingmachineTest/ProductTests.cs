using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.VendingMachine;

namespace vendingmachineTest
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


        //[Fact]
        //public void Drink_Use_ShouldOutputCorrectMessage()
        //{
        //    // Arrange
        //    var drink = new Drink("Cola", 20, 250);
        //    var expectedOutput = $"You drink the {drink.Name}. Refreshing!";
        //    using (var sw = new System.IO.StringWriter())
        //    {
        //        Console.SetOut(sw);

        //        // Act
        //        drink.Use();

        //        // Assert
        //        Assert.Equal(expectedOutput, sw.ToString().Trim());
        //    }
        //}

        //[Fact]
        //public void Snack_Examine_ShouldReturnCorrectDetails()
        //{
        //    // Arrange
        //    var snack = new Snack("Chips", 20, 200);

        //    // Act
        //    var details = snack.Examine();

        //    // Assert
        //    Assert.Equal($"ID: {snack.Id}, Product: {snack.Name}, Price: {snack.Price:C}, Calories: {snack.Calories}", details);
        //}

        //[Fact]
        //public void Snack_Use_ShouldOutputCorrectMessage()
        //{
        //    // Arrange
        //    var snack = new Snack("Chips", 20, 200);
        //    var expectedOutput = $"You eat the {snack.Name}. Tasty!";
        //    using (var sw = new System.IO.StringWriter())
        //    {
        //        Console.SetOut(sw);

        //        // Act
        //        snack.Use();

        //        // Assert
        //        Assert.Equal(expectedOutput, sw.ToString().Trim());
        //    }
        //}

        //[Fact]
        //public void Toy_Examine_ShouldReturnCorrectDetails()
        //{
        //    // Arrange
        //    var toy = new Toy("Action Figure", 50 , "Plastic");

        //    // Act
        //    var details = toy.Examine();

        //    // Assert
        //    Assert.Equal($"ID: {toy.Id}, Product: {toy.Name}, Price: {toy.Price:C}, Material: {toy.Material}", details);
        //}

        //[Fact]
        //public void Toy_Use_ShouldOutputCorrectMessage()
        //{
        //    // Arrange
        //    var toy = new Toy("Action Figure", 50, "Plastic");
        //    var expectedOutput = $"You play with the {toy.Name}. Fun!";
        //    using (var sw = new System.IO.StringWriter())
        //    {
        //        Console.SetOut(sw);

        //        // Act
        //        toy.Use();

        //        // Assert
        //        Assert.Equal(expectedOutput, sw.ToString().Trim());
        //    }
        //}

    }
}
