namespace Forum.Services.Administrator
{
    using Forum.Data;
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
    }
}
