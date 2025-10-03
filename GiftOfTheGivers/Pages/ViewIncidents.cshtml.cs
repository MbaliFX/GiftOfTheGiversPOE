using Microsoft.AspNetCore.Mvc.RazorPages;
using GiftOfTheGivers.Models;
using System.Collections.Generic;

public class ViewIncidentsModel : PageModel
{
    public List<Incident> Incidents { get; set; }

    public void OnGet()
    {
        Incidents = IncidentStore.GetAll();
    }
}
