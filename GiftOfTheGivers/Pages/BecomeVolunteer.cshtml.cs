using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

public class BecomeVolunteerModel : PageModel
{
    [BindProperty]
    public InputModel Input { get; set; }
    public string SuccessMessage { get; set; }

    public class InputModel
    {
        [Required]
        public string Skills { get; set; }
        [Required]
        public string Availability { get; set; }
    }

    public void OnGet() { }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }
        SuccessMessage = "You have joined as a volunteer!";
        // TODO: Save volunteer info
        return RedirectToPage("/VolunteerDashboard");
    }
}
