namespace Forum.Test.Mocks
{
    using Forum.Data;
    using Microsoft.EntityFrameworkCore;
    using System;
    public static class DatabaseMock
    {
        public static ApplicationDbContext Instance
        {
            get
            {
                var dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseInMemoryDatabase(Guid.NewGuid().ToString())
                    .Options;
                return new ApplicationDbContext(dbContextOptions);
            }
        }
    }
}
