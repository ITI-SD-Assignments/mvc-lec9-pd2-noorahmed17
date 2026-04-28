using Day8.RepoServices;
using Microsoft.EntityFrameworkCore;

namespace Day8.Models
{
    public class TraineeCourseRepo : ITraineeCourse
    {
        public _DbContext Context { get; }
        public TraineeCourseRepo(_DbContext context)
        {
            Context = context;
        }

        public void Add(TraineeCourse tc)
        {
            if (tc != null)
            {
                Context.TraineeCourses.Add(tc);
                Context.SaveChanges();
            }
        }

        public void Delete(int traineeId, int courseId)
        {
            var tc = Context.TraineeCourses.Find(traineeId, courseId);
            if (tc != null)
            {
                Context.TraineeCourses.Remove(tc);
                Context.SaveChanges();
            }
        }

        public IEnumerable<TraineeCourse> GetAll()
        {
            return Context.TraineeCourses
                .Include(tc => tc.Trainee)
                .Include(tc => tc.Course)
                .ToList();
        }

        public TraineeCourse GetById(int traineeId, int courseId)
        {
            return Context.TraineeCourses.Include(tc => tc.Trainee).Include(tc => tc.Course).FirstOrDefault(tc => tc.TraineeID == traineeId && tc.CourseID == courseId);
        }

        public void Update(TraineeCourse tc)
        {
            if (tc != null)
            {
                Context.TraineeCourses.Update(tc);
                Context.SaveChanges();
            }
        }
    }
}