using System;
using System.Collections.Generic;

namespace BoomsaFitnessBL.Model
{
    [Serializable]
    public class Exercise
    {
        public DateTime Start { get; set; }
        public DateTime Finish { get; set; }
        public User User { get; set; }
        public Activity Activity { get; set; }

        ////////For Entity
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ActivityId { get; set; }
        public Exercise()
        {
        }

        ////////For Entity

        public Exercise (DateTime start, DateTime finish, User user, Activity activity)
        {
            if (activity is null)
            {
                throw new ArgumentNullException(nameof(activity));
            }

            Start = start;
            Finish = finish;
            User = user ?? throw new ArgumentNullException(nameof(user));
            Activity = activity;
        }

       

        public override string ToString()
        {
            return $"{Activity} дата {Start.ToShortDateString()} начало {Start.ToShortTimeString()} - конец {Finish.ToShortTimeString()}";
        }
    }
}