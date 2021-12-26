namespace Forum.Models.Administrator
{
    using Forum.Data.Models;
    using System.Collections.Generic;
    public class AllUsersQuery
    {
        public IEnumerable<MyUser> Users { get; set; }
    }
}
