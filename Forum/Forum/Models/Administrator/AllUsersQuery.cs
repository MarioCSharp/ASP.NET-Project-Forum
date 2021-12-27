namespace Forum.Models.Administrator
{
    using System.Collections.Generic;
    public class AllUsersQuery
    {
        public IEnumerable<UsersViewModel> Users { get; set; }
    }
}
