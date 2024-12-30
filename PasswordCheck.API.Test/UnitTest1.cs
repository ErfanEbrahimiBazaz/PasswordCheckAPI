using PasswordCheck.API.Services;

namespace PasswordCheck.API.Test
{
    public class PasswordStrengthCheckerTest
    {

        [Fact]
        public void WeakNumericPasswordTest()
        {
            // Arrange
            PasswordStrengthChecker passwordStrengthChecker = new PasswordStrengthChecker();
            string password = "123";
            // Act

            int strength = passwordStrengthChecker.PasswordStrength(password);
            // Assert
            // expected, actual
            Assert.Equal(1, strength);

        }

        [Fact]
        public void WeakAplhabeticLowerCasePasswordTest()
        {
            PasswordStrengthChecker passwordStrengthChecker = new PasswordStrengthChecker();
            string password = "abc";
            int strength = passwordStrengthChecker.PasswordStrength(password);
            Assert.Equal(1, strength);
        }

        [Fact]
        public void WeakAplhabeticUpperCasePasswordTest()
        {
            PasswordStrengthChecker passwordStrengthChecker = new PasswordStrengthChecker();
            string password = "ABC";
            int strength = passwordStrengthChecker.PasswordStrength(password);
            Assert.Equal(1, strength);
        }

        [Fact]
        public void MediumPasswordTest()
        {
            PasswordStrengthChecker passwordStrengthChecker = new PasswordStrengthChecker();
            string password = "ABC123abc";
            int strength = passwordStrengthChecker.PasswordStrength(password);
            Assert.Equal(3, strength);
        }


        [Fact]
        public void MediumHighPasswordTest()
        {
            PasswordStrengthChecker passwordStrengthChecker = new PasswordStrengthChecker();
            string password = "ABC123abc@";
            int strength = passwordStrengthChecker.PasswordStrength(password);
            Assert.Equal(4, strength);
        }

        [Fact]
        public void StrongPasswordTest()
        {
            PasswordStrengthChecker passwordStrengthChecker = new PasswordStrengthChecker();
            string password = "ABC123abc@#!$%#b";
            int strength = passwordStrengthChecker.PasswordStrength(password);
            Assert.Equal(5, strength);
        }

        [Fact]
        public void EmptyPassword()
        {
            PasswordStrengthChecker passwordStrengthChecker = new PasswordStrengthChecker();
            string password = string.Empty;
            int strength = passwordStrengthChecker.PasswordStrength(password);
            Assert.Equal(0, strength);
        }
    }
}