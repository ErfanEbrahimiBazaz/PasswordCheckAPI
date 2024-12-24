using Microsoft.AspNetCore.Mvc;
using PasswordCheck.API.Models;
using PasswordCheck.API.Services;


namespace PasswordCheck.API.Controllers
{
    [ApiController]
    [Route("/api/passwordcheck")]
    public class PasswordCheckController : Controller
    {
        private readonly IPasswordStrengthChecker _passwordStrengthChecker;
        private readonly IPasswordBreachCheckService _passwordBreachCheckService;

        public PasswordCheckController(
            IPasswordStrengthChecker passwordStrengthChecker,
            IPasswordBreachCheckService passwordBreachCheckService)
        {
            this._passwordStrengthChecker = passwordStrengthChecker;
            //this._passwordBreachCheckService = passwordBreachCheckService;
        }

        [HttpPost("echo")]
        public ActionResult<string> Echo([FromBody] PasswordRequest pwd)
        {
            if (string.IsNullOrEmpty(pwd.Password))
            {
                return BadRequest("Password cannot be empty!");
            }

            return Ok(pwd.Password);
        }

        [HttpPost("checkstrength")]
        public ActionResult PasswordStrengthCheck([FromBody] PasswordRequest pwd)
        {
            if (string.IsNullOrEmpty(pwd.Password))
            {
                return BadRequest("Password cannot be empty!");
            }

            PasswordResponse response = new PasswordResponse();
            response.StrengthRate = _passwordStrengthChecker.PasswordStrength(pwd.Password);

            //int passwordStrength = _passwordStrengthChecker.PasswordStrength(pwd.Password); // return API response.
            return Ok(response);
        }

        [HttpGet]
        public ActionResult Passwordbreachedcheck(PasswordRequest pwd)
        {
            if (string.IsNullOrEmpty(pwd.Password))
            {
                return BadRequest("password cannot be empty!");
            }
            PasswordBreachResponse response = new PasswordBreachResponse();
            response = _passwordBreachCheckService.CheckBreach(pwd);

            return Ok(response);
        }

        [HttpPost("sha1")]
        public ActionResult PasswordSha1Calculation([FromBody] PasswordRequest pwd)
        {
            if (string.IsNullOrEmpty(pwd.Password))
            {
                return BadRequest("password cannot be empty!");
            }

            string response = PasswordOperations.CalculateSHA1Hash(pwd.Password);
            return Ok(response);
        }

        [HttpGet("hibp/{range}")]
        public async Task<IActionResult> HIBP(string range)
        {

            if (string.IsNullOrEmpty(range))
            {
                return BadRequest("password cannot be empty!");
            }

            if (range.Length != 5)
            {
                return BadRequest("Only share the first 5 characters of SHA1 of the password hash!");
            }

            string url = $"https://api.pwnedpasswords.com/range/{range}";
            
            HttpClient httpClient = new HttpClient();
            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(url);

                response.EnsureSuccessStatusCode();
                string content = await response.Content.ReadAsStringAsync();


                var result = content
                    .Split('\n')
                    .Select(x => x.ToString().Split(':'))
                    .ToDictionary(x => x[0], x => int.Parse(x[1]))
                    .Sum(x => x.Value);

                //return Content(content);
                return Ok(result);
            }
            catch (HttpRequestException ex)
            {
                return StatusCode(500, $"Error calling the external API: {ex.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error calling the external API: {ex.Message}");
            }
        }

    }
    //PasswordBreachResponse passwordBreachedCheckObject = new PasswordBreachResponse();
}


