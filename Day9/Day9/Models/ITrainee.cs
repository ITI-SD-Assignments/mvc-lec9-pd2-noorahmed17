namespace Day8.Models
{
    public interface ITrainee
    {
        public IEnumerable<Trainee> GetAll();
        public Trainee GetById(int id);
        public void Add(Trainee trainee);
        public void Update(Trainee trainee);
        public void Delete(int id);
    }
}
