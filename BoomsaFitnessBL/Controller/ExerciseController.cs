using BoomsaFitnessBL.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BoomsaFitnessBL.Controller
{
    public class ExerciseController :ControllerBase
    {
        private const string EXERCISES_FILE_NAME = "exercises.dat";
        private const string ACTIVITY_FILE_NAME = "activity.dat";
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
           return Load<List<Activity>>(ACTIVITY_FILE_NAME) ?? new List<Activity>();          
        }

        private List<Exercise> GetAllExercises()
        {
            return Load <List<Exercise>>(EXERCISES_FILE_NAME) ?? new List<Exercise>();
        }
        private void Save()
        {
            base.Save(EXERCISES_FILE_NAME, Exercises);
            base.Save(ACTIVITY_FILE_NAME, Activitys);
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
