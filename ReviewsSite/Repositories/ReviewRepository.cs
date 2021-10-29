using ReviewsSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReviewsSite.Repositories
{
    public class ReviewRepository : IRepository<Review>
    {
        public VideoGameContext db;
        
        public ReviewRepository(VideoGameContext db)
        {
            this.db = db;
        }
        
        public void Create(Review obj)
        {
            db.Reviews.Add(obj);
            db.SaveChanges();
        }

        public void Delete(Review obj)
        {
            db.Reviews.Remove(obj);
            db.SaveChanges();
        }

        public Review GetByID(int id)
        {
            return db.Reviews.Where(r => r.Id == id).FirstOrDefault();
        }

        public IEnumerable<Review> GetByGameID(int gameid)
        {
            return db.Reviews.Where(r => r.VideoGameId == gameid);
        }
        public IEnumerable<Review> GetAll()
        {
            return db.Reviews.OrderBy(r => r.VideoGame.Name).ToList();
        }

        public String GetVideoGameName(int videoGameId)
        {
            return db.VideoGames.Where(r => r.Id == videoGameId).FirstOrDefault().Name;
        }

        public void Update(Review obj)
        {
            db.Reviews.Update(obj);
            db.SaveChanges();
        }
        public List<VideoGame> PopulateVideoGameList()
        {
            return db.VideoGames.ToList();
        }
    }
}
