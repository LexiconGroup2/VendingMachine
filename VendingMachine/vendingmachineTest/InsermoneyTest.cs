using VendingMachine;

namespace vendingmachineTest
{
    public class InsermoneyTest
    {
       
       
        [Fact]
        public void InsertMoney()
        {
            // Arrange
            VendingMachineService vmc = new VendingMachineService();
            int currentBalance = vmc.GetBalance(); // Get the current balance before inserting money
            int amountToAdd = 1000;

            // Act
            vmc.InsertMoney(amountToAdd);

            // Assert
            int expectedBalance = currentBalance + amountToAdd;
            Assert.Equal(expectedBalance, vmc.GetBalance());
        }

    }
}