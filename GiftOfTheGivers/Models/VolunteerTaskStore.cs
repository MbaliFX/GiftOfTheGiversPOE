using System.Collections.Generic;
using System.Linq;

namespace GiftOfTheGivers.Models
{
    public static class VolunteerTaskStore
    {
        private static List<VolunteerTask> _tasks = new List<VolunteerTask>();
        private static int _nextId = 1;

        public static List<VolunteerTask> GetAll() => _tasks;

        public static void AddTask(VolunteerTask task)
        {
            task.Id = _nextId++;
            _tasks.Add(task);
        }
    }
}
