namespace Forum.Models.Administrator
{
    public class UsersViewModel
    {
        public string Id { get; init; }
        public string UserName { get; init; }
        public string NormalizedUserName { get; init; }
        public string Email { get; init; }
        public string NormalizedEmail { get; init; }
        public string PasswordHash { get; init; }
        public string FullName { get; init; }
    }
}
