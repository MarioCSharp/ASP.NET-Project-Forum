namespace Forum.Models.Administrator
{
    public class UsersViewModel
    {
        public int Count { get; set; }
        public string UserName { get; set; }
        public string NormalizedUserName { get; set; }
        public string Email { get; set; }
        public string NormalizedEmail { get; set; }
        public string PasswordHash { get; set; }
        public string FullName { get; set; }
    }
}
