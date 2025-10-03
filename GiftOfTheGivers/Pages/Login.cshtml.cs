using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;
using System.Threading.Tasks;

public class LoginModel : PageModel
{
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly UserManager<IdentityUser> _userManager;

    public LoginModel(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
    {
        _signInManager = signInManager;
        _userManager = userManager;
    }

    [BindProperty]
    public InputModel Input { get; set; }
    public string ErrorMessage { get; set; }

    public class InputModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }

    public void OnGet()
    {
        // Display login page
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (string.IsNullOrWhiteSpace(Input?.Email) || string.IsNullOrWhiteSpace(Input?.Password))
        {
            ErrorMessage = "Email and password are required.";
            return Page();
        }
        var result = await _signInManager.PasswordSignInAsync(Input.Email, Input.Password, Input.RememberMe, lockoutOnFailure: false);
        if (result.Succeeded)
        {
            var user = await _userManager.FindByEmailAsync(Input.Email);
            var claims = await _userManager.GetClaimsAsync(user);
            var accountType = claims.FirstOrDefault(c => c.Type == "AccountType")?.Value;
            if (accountType == "General user")
                return RedirectToPage("/Dashboard");
            if (accountType == "Volunteer")
                return RedirectToPage("/VolunteerDashboard");
            return RedirectToPage("/Index");
        }
        ErrorMessage = "Invalid login attempt.";
        return Page();
    }
}
