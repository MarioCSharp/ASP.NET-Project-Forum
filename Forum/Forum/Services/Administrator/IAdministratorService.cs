namespace Forum.Services.Administrator
{
    public interface IAdministratorService
    {
        bool DeleteCategory(int Id);
        bool DeleteComment(int Id);
    }
}
