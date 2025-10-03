using Microsoft.AspNetCore.Mvc.RazorPages;
using GiftOfTheGivers.Models;
using System.Collections.Generic;

public class ViewVolunteerTasksModel : PageModel
{
    public List<VolunteerTask> Tasks { get; set; }

    public void OnGet()
    {
        Tasks = VolunteerTaskStore.GetAll();
    }
}
