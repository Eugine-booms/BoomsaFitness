using BoomsaFitnessBL.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BoomsaFitnessBL.Controller
{
    public class ExerciseController :ControllerBase
    {
        private readonly User user;
        public List<Exercise> Exercises { get; }
        public List<Activity> Activitys { get;  }

        public ExerciseController(User user)
        {
            this.LoadFile += LoadingFile;
            this.SaveFile+=SavingFile;
            this.user = user ?? throw new ArgumentNullException(nameof(user));
            Exercises = GetAllExercises();
            Activitys = GetActivity();
        }

        private List<Activity> GetActivity()
        {
           return Load<Activity>();          
        }

        private List<Exercise> GetAllExercises()
        {
            return Load <Exercise>() ?? new List<Exercise>();
        }
        private void Save()
        {
            base.Save(Exercises);
            base.Save(Activitys);
        }
        public void Add(Exercise exercise) => Add(exercise.Activity, exercise.Start, exercise.Finish);
        public void Add(Activity activity, DateTime start, DateTime finish)
        {

            var act = Activitys.SingleOrDefault(a => a.Name == activity.Name);
            if (act==null)
            {
                var exercises = new Exercise(start, finish, user, activity);
                Activitys.Add(activity);
                Exercises.Add(exercises);
            }
            else
            {
                var exercises = new Exercise(start, finish, user, act);
                Exercises.Add(exercises);
            }
            Save();
        }
    }
}
