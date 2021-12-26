namespace Forum.Services.Administrator
{
    using Forum.Data;
    using Forum.Models.Category;
    using System.Linq;
    public class AdministratorService : IAdministratorService
    {
        private readonly ApplicationDbContext data;
        public AdministratorService(ApplicationDbContext data)
        {
            this.data = data;
        }
        public bool DeleteCategory(int Id)
        {
            var categoryToDelete = data.Categories.Find(Id);
            if (categoryToDelete == null)
            {
                return false;
            }
            data.Categories.Remove(categoryToDelete);
            data.SaveChanges();
            return true;
        }
        public bool DeleteComment(int Id)
        {
            if (Id <= 0)
            {
                return false;
            }
            var commentToDelete = data.Comments.Find(Id);
            if (commentToDelete == null)
            {
                return false;
            }
            data.Comments.Remove(commentToDelete);
            data.SaveChanges();
            return true;
        }
        public bool DeletePost(int Id)
        {
            var post = data.Posts.FirstOrDefault(x => x.Id == Id);
            if (post == null)
            {
                return false;
            }
            data.Posts.Remove(post);
            data.SaveChanges();
            return true;
        }
        public bool EditCategory(int Id, EditCategoryFormModel edit)
        {
            var category = data.Categories.Find(Id);
            if (category == null)
            {
                return false;
            }
            category.Name = edit.Name;
            category.ImageURL = edit.ImageURL;
            data.SaveChanges();
            return true;
        }
        public bool DeleteUser(string Id)
        {
            var user = data.Users.Find(Id);
            if (user == null)
            {
                return false;
            }
            data.Users.Remove(user);
            data.SaveChanges();
            return true;
        }
    }
}
