using Day8.RepoServices;
using Microsoft.EntityFrameworkCore;

namespace Day8.Models
{
    public class CourseRepo : ICourse
    {
        public _DbContext Context { get; }
        public CourseRepo(_DbContext context)
        {
            Context = context;
        }

        public void Add(Course course)
        {
            if (course != null)
            {
                Context.Courses.Add(course);
                Context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var course = Context.Courses.Find(id);
            if (course != null)
            {
                Context.Courses.Remove(course);
                Context.SaveChanges();
            }
        }

        public IEnumerable<Course> GetAll()
        {
            return Context.Courses.ToList();
        }

        public Course GetById(int id)
        {
            return Context.Courses.Find(id);
        }

        public void Update(Course course)
        {
            if (course != null)
            {
                Context.Courses.Update(course);
                Context.SaveChanges();
            }
        }
    }
}