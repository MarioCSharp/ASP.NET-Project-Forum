namespace Forum.Test.Services
{
    using Forum.Data.Models;
    using Forum.Models.Post;
    using Forum.Services.Post;
    using Forum.Test.Mocks;
    using System.Linq;
    using Xunit;
    public class PostServiceTest
    {
        [Fact]
        public void CreatePostShouldReturnTrue()
        {
            //Arrange
            using var data = DatabaseMock.Instance;
            data.Users.Add(new MyUser
            {
                Id = "User",
                Email = "a"
            });
            data.SaveChanges();
            var postService = new PostService(data);
            var mdl = new CreatePostFormModel
            {
                Tittle = "a",
                Content = "dsa",
                CategoryId = 3
            };
            //Act
            var result = postService.Create(mdl, "User");
            //Assert
            Assert.True(result);
        }
        [Fact]
        public void CreatePostShouldReturnFalseBecauseTitleIsNull()
        {
            //Arrange
            using var data = DatabaseMock.Instance;
            data.Users.Add(new MyUser
            {
                Id = "User",
                Email = "a"
            });
            data.SaveChanges();
            var postService = new PostService(data);
            var mdl = new CreatePostFormModel
            {
                Tittle = null,
                Content = "dsa",
                CategoryId = 3
            };
            //Act
            var result = postService.Create(mdl, "User");
            //Assert
            Assert.False(result);
        }
        [Fact]
        public void CreatePostShouldReturnFalseBecauseContentIsNull()
        {
            //Arrange
            using var data = DatabaseMock.Instance;
            data.Users.Add(new MyUser
            {
                Id = "User",
                Email = "a"
            });
            data.SaveChanges();
            var postService = new PostService(data);
            var mdl = new CreatePostFormModel
            {
                Tittle = "dasdas",
                Content = null,
                CategoryId = 3
            };
            //Act
            var result = postService.Create(mdl, "User");
            //Assert
            Assert.False(result);
        }
        [Fact]
        public void CreatePostShouldReturnFalseBecauseCategoryIdIsBellowZero()
        {
            //Arrange
            using var data = DatabaseMock.Instance;
            data.Users.Add(new MyUser
            {
                Id = "User",
                Email = "a"
            });
            data.SaveChanges();
            var postService = new PostService(data);
            var mdl = new CreatePostFormModel
            {
                Tittle = "dasdas",
                Content = null,
                CategoryId = -1
            };
            //Act
            var result = postService.Create(mdl, "User");
            //Assert
            Assert.False(result);
        }
        [Fact]
        public void CreatePostShouldReturnFalseBecauseCategoryIdIsZero()
        {
            //Arrange
            using var data = DatabaseMock.Instance;
            data.Users.Add(new MyUser
            {
                Id = "User",
                Email = "a"
            });
            data.SaveChanges();
            var postService = new PostService(data);
            var mdl = new CreatePostFormModel
            {
                Tittle = "dasdas",
                Content = null,
                CategoryId = 0
            };
            //Act
            var result = postService.Create(mdl, "User");
            //Assert
            Assert.False(result);
        }
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
