using Microsoft.AspNetCore.Mvc.RazorPages;
using GiftOfTheGivers.Models;
using System.Collections.Generic;

public class ViewVolunteersModel : PageModel
{
    public List<Volunteer> Volunteers { get; set; }

    public void OnGet()
    {
        Volunteers = VolunteerStore.GetAll();
    }
}
