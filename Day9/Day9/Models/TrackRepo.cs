using Day8.RepoServices;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Day8.Models
{
    public class TrackRepo : ITrack
    {
        public _DbContext Context { get; }
        public TrackRepo(_DbContext context)
        {
            Context = context;
        }
        public void Add(Track track)
        {
            if(track != null)
            {
                Context.Tracks.Add(track);
                Context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var track = Context.Tracks.Find(id);
            if (track != null)
            {
                Context.Tracks.Remove(track);
                Context.SaveChanges();
            }
        }

        public IEnumerable<Track> GetAll()
        {
            return Context.Tracks.Include(t => t.Trainees).ToList();
        }

        public Track GetById(int id)
        {
            return Context.Tracks.Include(t => t.Trainees).FirstOrDefault(t => t.ID == id);
        }

        public void Update(Track track)
        {
            if(track != null)
            {
                Context.Tracks.Update(track);
                Context.SaveChanges();
            }
        }
    }
}
