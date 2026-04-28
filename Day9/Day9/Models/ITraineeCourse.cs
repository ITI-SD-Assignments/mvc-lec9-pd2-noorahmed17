namespace Day8.Models 
{
    public interface ITraineeCourse
    {
        public void Add(TraineeCourse tc);
        public void Delete(int traineeId, int courseId);
        public IEnumerable<TraineeCourse> GetAll();
        public TraineeCourse GetById(int traineeId, int courseId);
        public void Update(TraineeCourse tc);
    }
}