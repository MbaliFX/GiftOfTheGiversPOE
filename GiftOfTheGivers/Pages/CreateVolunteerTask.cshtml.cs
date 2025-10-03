using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using GiftOfTheGivers.Models;
using System.Collections.Generic;

public class CreateVolunteerTaskModel : PageModel
{
    [BindProperty]
    public InputModel Input { get; set; }
    public List<string> Volunteers { get; set; }

    public class InputModel
    {
        [Required]
        public string TaskName { get; set; }
        [Required]
        public string TaskDescription { get; set; }
        [Required]
        public string AssignedVolunteer { get; set; }
    }

    public void OnGet()
    {
        Volunteers = VolunteerStore.GetAll().ConvertAll(v => v.Name);
    }

    public IActionResult OnPost()
    {
        Volunteers = VolunteerStore.GetAll().ConvertAll(v => v.Name);
        if (!ModelState.IsValid)
        {
            return Page();
        }
        var task = new VolunteerTask
        {
            TaskName = Input.TaskName,
            TaskDescription = Input.TaskDescription,
            AssignedVolunteer = Input.AssignedVolunteer
        };
        VolunteerTaskStore.AddTask(task);
        return RedirectToPage("/VolunteerDashboard");
    }
}
