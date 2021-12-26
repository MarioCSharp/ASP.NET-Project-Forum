namespace Forum.Test.Services
{
    using Forum.Data.Models;
    using Forum.Services.Post;
    using Forum.Test.Mocks;
    using System.Linq;
    using Xunit;
    public class PostServiceTest
    {
        [Fact]
        public void GetCategoriresTest()
        {
            //Arrange
            using var data = DatabaseMock.Instance;
            data.Categories.Add(new Category
            {
                Name = "aa",
                ImageURL = "b"
            });
            data.Categories.Add(new Category
            {
                Name = "bb",
                ImageURL = "b"
            });
            data.SaveChanges();
            var postService = new PostService(data);
            //Act
            string result = string.Join(" ", postService.GetCategories().Select(x => x.Name));
            //Assert
            Assert.Equal("bb aa", result);
        }
        [Fact]
        public void DeleteShouldReturnTrue()
        {
            //Arrange
            using var data = DatabaseMock.Instance;
            data.Posts.Add(new Post
            {
                Id = 1,
                Tittle = "a",
                Content = "b"
            });
            var postService = new PostService(data);
            //Act
            var isDeleted = postService.Delete(1);
            //Assert
            Assert.True(isDeleted);
        }
        [Fact]
        public void DeleteShouldReturnFalse()
        {
            //Arrange
            using var data = DatabaseMock.Instance;
            data.Posts.Add(new Post
            {
                Id = 1,
                Tittle = "a",
                Content = "b"
            });
            var postService = new PostService(data);
            //Act
            var isDeleted = postService.Delete(2);
            //Assert
            Assert.False(isDeleted);
        }
    }
}
