namespace PasswordCheck.API.Models
{
    public class PasswordResponse
    {

        public int StrengthRate { get; set; }
        public string StrengthMessage
        {

            get
            {
                if (this.StrengthRate <= 1)
                {
                    return "Password is very weak";
                }
                else if (this.StrengthRate > 1 && this.StrengthRate <= 2)
                {
                    return "Password is weak";
                }
                else if (this.StrengthRate > 2 && this.StrengthRate <= 3)
                {
                    return "Password is normal";
                }
                else if (this.StrengthRate > 3 && this.StrengthRate <= 4)
                {
                    return "Password is strong";
                }
                else
                {
                    return "Password is very strong";
                }
            }
        }


    }
}
