using System;
using System.Collections.Generic;

namespace GiftOfTheGivers.Models
{
    public static class VolunteerStore
    {
        private static List<Volunteer> _volunteers = new List<Volunteer>();
        private static int _nextId = 1;

        public static List<Volunteer> GetAll() => _volunteers;

        public static void AddVolunteer(Volunteer v)
        {
            v.Id = _nextId++;
            v.JoinDate = DateTime.Now;
            _volunteers.Add(v);
        }
    }
}
