using PasswordCheck.API.Models;

namespace PasswordCheck.API.Services
{
    // Interface
    // Add service to the end of interface name. IPasswordStrengthCheckerService
    public interface IPasswordStrengthChecker
    {
        public bool HasNumber(string pwd);
        public bool Haslower(string pwd);
        public bool HasUpper(string pwd);
        public bool HasEspecialCharacter(string pwd);
        public bool IsLongerThanM(string pwd);

        //PatternBuilder detection 

        public int PasswordStrength(string pwd);

    }

    public class PasswordStrengthChecker : IPasswordStrengthChecker
    {
   
        private const int NumberOfCharacters = 10;
        public bool HasEspecialCharacter(string pwd)
        {
            bool res = pwd.Any(c => ! char.IsLetterOrDigit(c));
            return res;
        }

        public bool Haslower(string pwd)
        {
            bool res = pwd.Any(c => char.IsLower(c));
            return res;
        }

        public bool HasNumber(string pwd)
        {
            bool res = pwd.Any(c => char.IsDigit(c));
            return res;
        }

        public bool HasUpper(string pwd)
        {
            bool res = pwd.Any(c => char.IsUpper(c));
            return res;
        }


        public bool IsLongerThanM(string pwd)
        {
            bool res = pwd.Length > NumberOfCharacters;
            return res;
        }

        public int PasswordStrength(string pwd)
        {
            int res = 0;

            if ( this.Haslower(pwd)){
                res ++;
            }

            if (HasUpper(pwd))
            {
                res++;
            }

            if (this.HasNumber(pwd))
            {
                res++;
            }

            if (HasEspecialCharacter(pwd))
            {
                res++;
            }

            if (IsLongerThanM(pwd))
            {
                res++;
            }

            return res; 
        }

    }
}
