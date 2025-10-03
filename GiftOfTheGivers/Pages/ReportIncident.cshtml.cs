
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using GiftOfTheGivers.Services;
using GiftOfTheGivers.Models;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;

public class ReportIncidentModel : PageModel
{
    private readonly FirestoreService _firestoreService;

    [BindProperty]
    public Incident Incident { get; set; }
    public List<Incident> Incidents { get; set; }

    public ReportIncidentModel(FirestoreService firestoreService)
    {
        _firestoreService = firestoreService;
    }

    public async Task OnGetAsync()
    {
        Incidents = await _firestoreService.GetIncidentsAsync();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
            return Page();

        await _firestoreService.AddIncidentAsync(Incident);
        return RedirectToPage();
    }
}