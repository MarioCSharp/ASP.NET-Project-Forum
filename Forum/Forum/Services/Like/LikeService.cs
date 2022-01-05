namespace Forum.Services.Like
{
    using Forum.Data;
    using Data.Models;
    using System.Linq;

    public class LikeService : ILikeService
    {
        private readonly ApplicationDbContext data;
        public LikeService(ApplicationDbContext data)
        {
            this.data = data;
        }
        public void Like(int Id, string userId)
        {
            if (data.Likes.Any(x => x.PostId == Id && x.UserID == userId))
            {
                return;
            }
            Like like = new Like
            {
                UserID = userId,
                PostId = Id
            };
            data.Likes.Add(like);
            data.SaveChanges();
        }
    }
}
