namespace Forum.Services.Administrator
{
    using Forum.Models.Category;
    public interface IAdministratorService
    {
        bool DeleteCategory(int Id);
        bool DeleteComment(int Id);
        bool DeletePost(int Id);
        bool EditCategory(int Id, EditCategoryFormModel edit);
        bool DeleteUser(string Id);
    }
}
