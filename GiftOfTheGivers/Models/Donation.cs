using System;

namespace GiftOfTheGivers.Models
{
    public class Donation
    {
        public int Id { get; set; }
        public string DonorName { get; set; }
        public string ResourceDetails { get; set; }
        public int Quantity { get; set; }
        public DateTime DonationDate { get; set; }
        public string Status { get; set; }
        public string Contact { get; set; }
        public string PickupLocation { get; set; }
    }
}
