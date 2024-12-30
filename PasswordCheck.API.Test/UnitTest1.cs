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
            Assert.Equal(strength, 1);

        }

        [Fact]
        public void WeakAplhabeticLowerCasePasswordTest()
        {
            PasswordStrengthChecker passwordStrengthChecker = new PasswordStrengthChecker();
            string password = "abc";
            int strength = passwordStrengthChecker.PasswordStrength(password);
            Assert.Equal(strength, 1);
        }

        [Fact]
        public void WeakAplhabeticUpperCasePasswordTest()
        {
            PasswordStrengthChecker passwordStrengthChecker = new PasswordStrengthChecker();
            string password = "ABC";
            int strength = passwordStrengthChecker.PasswordStrength(password);
            Assert.Equal(strength, 1);
        }

        [Fact]
        public void MediumPasswordTest()
        {
            PasswordStrengthChecker passwordStrengthChecker = new PasswordStrengthChecker();
            string password = "ABC123abc";
            int strength = passwordStrengthChecker.PasswordStrength(password);
            Assert.Equal(strength, 3);
        }


        [Fact]
        public void MediumHighPasswordTest()
        {
            PasswordStrengthChecker passwordStrengthChecker = new PasswordStrengthChecker();
            string password = "ABC123abc@";
            int strength = passwordStrengthChecker.PasswordStrength(password);
            Assert.Equal(strength, 4);
        }

        [Fact]
        public void StrongPasswordTest()
        {
            PasswordStrengthChecker passwordStrengthChecker = new PasswordStrengthChecker();
            string password = "ABC123abc@#!$%#b";
            int strength = passwordStrengthChecker.PasswordStrength(password);
            Assert.Equal(strength, 5);
        }

        [Fact]
        public void EmptyPassword()
        {
            PasswordStrengthChecker passwordStrengthChecker = new PasswordStrengthChecker();
            string password = string.Empty;
            Assert.Equal(passwordStrengthChecker.PasswordStrength(password), 0);
        }
    }
}