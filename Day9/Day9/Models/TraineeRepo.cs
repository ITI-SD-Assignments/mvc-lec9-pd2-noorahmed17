using Day8.RepoServices;
using Microsoft.EntityFrameworkCore;

namespace Day8.Models
{
    public class TraineeRepo : ITrainee
    {
        public _DbContext Context { get; }
        public TraineeRepo(_DbContext context)
        {
            Context = context;
        }

        public void Add(Trainee trainee)
        {
            if (trainee != null)
            {
                Context.Trainees.Add(trainee);
                Context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var trainee = Context.Trainees.Find(id);
            if (trainee != null)
            {
                Context.Trainees.Remove(trainee);
                Context.SaveChanges();
            }
        }

        public IEnumerable<Trainee> GetAll()
        {
            return Context.Trainees.Include(t => t.Trk).ToList();
        }

        public Trainee GetById(int id)
        {
            return Context.Trainees.Include(t => t.Trk).FirstOrDefault(t => t.ID == id);
        }

        public void Update(Trainee trainee)
        {
            if (trainee != null)
            {
                Context.Trainees.Update(trainee);
                Context.SaveChanges();
            }
        }
    }
}