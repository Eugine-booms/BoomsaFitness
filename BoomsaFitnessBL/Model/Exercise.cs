using System;

namespace BoomsaFitnessBL.Model
{
    [Serializable]
    public class Exercise
    {
        public DateTime Start { get; }
        public DateTime Finish { get; }
        public User User { get; }
        public Activity Activity { get; }

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