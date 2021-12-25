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
            if (categoryToDelete != null)
            {
                return false;
            }
            data.Categories.Remove(categoryToDelete);
            data.SaveChanges();
            return true;
        }
    }
}
