namespace PasswordCheck.API.Models
{
    public class PasswordBreachResponse
    {
        // password checker Request
        public int NumberOfBreaches { get; set; }
        public bool IsBreached
        {
            get
            { 
                if(this.NumberOfBreaches > 0)
                {
                    return true;
                }
                return false;
            }
        }
    }
}
