namespace Forum.Test.Services
{
    using Forum.Data.Models;
    using Forum.Services.Post;
    using Forum.Test.Mocks;
    using Xunit;
    public class PostServiceTest
    {
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
            var postService = new PostService(data, null);
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
            var postService = new PostService(data, null);
            //Act
            var isDeleted = postService.Delete(2);
            //Assert
            Assert.False(isDeleted);
        }
    }
}
