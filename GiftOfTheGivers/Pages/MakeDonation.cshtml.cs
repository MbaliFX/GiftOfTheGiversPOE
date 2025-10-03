using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using GiftOfTheGivers.Models;
using System;

public class MakeDonationModel : PageModel
{
    [BindProperty]
    public InputModel Input { get; set; }
    public string SuccessMessage { get; set; }

    public class InputModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string ContactNumber { get; set; }
        [Required]
        public string ResourceType { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1.")]
        public int Quantity { get; set; }
        public string AdditionalInfo { get; set; }
        [Required]
        public string PickupAddress { get; set; }
    }

    public void OnGet() { }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }
        var donation = new Donation
        {
            DonorName = Input.Name,
            ResourceDetails = Input.ResourceType + (string.IsNullOrWhiteSpace(Input.AdditionalInfo) ? "" : $" ({Input.AdditionalInfo})"),
            Quantity = Input.Quantity,
            DonationDate = DateTime.Now,
            Status = "Pending",
            Contact = Input.ContactNumber,
            PickupLocation = Input.PickupAddress
        };
        DonationStore.AddDonation(donation);
        SuccessMessage = "Donation submitted successfully!";
        return RedirectToPage("/ViewDonations");
    }
}
