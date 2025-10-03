using System;

namespace GiftOfTheGivers.Models
{
    public class Volunteer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Skills { get; set; }
        public string Availability { get; set; }
        public DateTime JoinDate { get; set; }
        public int AssignedTaskCount { get; set; }
    }
}
