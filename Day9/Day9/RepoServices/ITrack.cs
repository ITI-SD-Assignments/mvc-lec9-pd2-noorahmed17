namespace Day8.RepoServices
{
    public interface ITrack
    {
        public IEnumerable<Track> GetAll();
        public Track GetById(int id);
        public void Add(Track track);
        public void Update(Track track);
        public void Delete(int id);
    }
}
