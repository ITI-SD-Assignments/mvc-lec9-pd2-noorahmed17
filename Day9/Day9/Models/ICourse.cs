namespace Day8.Models
{
    public interface ICourse
    {
        public IEnumerable<Course> GetAll();
        public Course GetById(int id);
        public void Add(Course course);
        public void Update(Course course);
        public void Delete(int id);
    }
}
