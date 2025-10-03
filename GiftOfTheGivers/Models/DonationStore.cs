using System.Collections.Generic;
using System.Linq;

namespace GiftOfTheGivers.Models
{
    public static class DonationStore
    {
        private static List<Donation> _donations = new List<Donation>();
        private static int _nextId = 1;

        public static List<Donation> GetAll() => _donations;

        public static void AddDonation(Donation donation)
        {
            donation.Id = _nextId++;
            _donations.Add(donation);
        }
    }
}
