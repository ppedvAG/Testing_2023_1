namespace TddBank.Tests
{
    public class BankAccountTests
    {
        [Fact]
        public void New_Account_should_have_zero_as_Balance()
        {
            var ba = new BankAccount();

            Assert.Equal(0m, ba.Balance);
        }

        [Fact]
        public void Deposit_should_add_to_Balance()
        {
            var ba = new BankAccount();

            ba.Deposit(3m);
            ba.Deposit(4m);

            Assert.Equal(7m, ba.Balance);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void Deposit_a_negative_or_zero_amount_should_throw_ArgumentException(decimal amount)
        {
            var ba = new BankAccount();

            Assert.Throws<ArgumentException>(() => ba.Deposit(amount));
        }

        [Fact]
        public void Withdraw_should_substract_from_Balance()
        {
            var ba = new BankAccount();
            ba.Deposit(12m);

            ba.Withdraw(4m);
            ba.Withdraw(3m);

            Assert.Equal(5m, ba.Balance);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void Withdraw_a_negative_amount_should_throw_ArgumentException(decimal amount)
        {
            var ba = new BankAccount();

            Assert.Throws<ArgumentException>(() => ba.Withdraw(amount));
        }

        [Fact]
        public void Withdraw_more_than_Balance_should_throw_InvaildOperationEx()
        {
            var ba = new BankAccount();
            ba.Deposit(12m);

            Assert.Throws<InvalidOperationException>(() => ba.Withdraw(13));
        }

    }
}