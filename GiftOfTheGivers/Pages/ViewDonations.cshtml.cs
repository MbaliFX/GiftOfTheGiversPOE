using Microsoft.AspNetCore.Mvc.RazorPages;
using GiftOfTheGivers.Models;
using System.Collections.Generic;

public class ViewDonationsModel : PageModel
{
    public List<Donation> Donations { get; set; }

    public void OnGet()
    {
        Donations = DonationStore.GetAll();
    }
}
