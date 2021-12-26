namespace Forum.Test.Services
{
    using Forum.Data.Models;
    using Forum.Models.Category;
    using Forum.Services.Category;
    using Forum.Test.Mocks;
    using System.Linq;
    using Xunit;
    public class CategoryServiceTest
    {
        [Fact]
        public void GetCategoryTest()
        {
            //Arrange
            using var data = DatabaseMock.Instance;
            data.Categories.Add(new Category
            {
                Id = 1,
                Name = "aa",
                ImageURL = "b"
            });
            data.Categories.Add(new Category
            {
                Id = 2,
                Name = "bb",
                ImageURL = "b"
            });
            data.SaveChanges();
            var categoryService = new CategoryService(data);
            //Act
            var result = categoryService.GetCategory(2).Name;
            //Assert
            Assert.Equal("bb", result);
        }
        [Fact]
        public void GetCategoryPostsTest()
        {
            //Arrange
            using var data = DatabaseMock.Instance;
            var category = new Category
            {
                Id = 1,
                Name = "aa",
                ImageURL= "b"
            };
            data.Categories.Add(category);
            data.SaveChanges();
            data.Posts.Add(new Post
            {
                CategoryId = 1,
                Tittle = "a"
            });
            data.Posts.Add(new Post
            {
                CategoryId = 1,
                Tittle = "b"
            });
            data.Posts.Add(new Post
            {
                CategoryId = 2,
                Tittle = "v"
            });
            data.SaveChanges();
            var categoryService = new CategoryService(data);
            //Act
            var result = string.Join(" ", categoryService.GetCategoryPosts(category).Select(x => x.Tittle));
            //Assert
            Assert.Equal("a b", result);
        }
        [Fact]
        public void CreateShouldReturnFalseBecauseNameIsNull()
        {
            //Arrange
            using var data = DatabaseMock.Instance;
            var mdl = new CategoryFormModel
            {
                Name = null,
                ImageUrl = "a"
            };
            var categoryService = new CategoryService(data);
            //Act
            var result = categoryService.Create(mdl);
            //Assert
            Assert.False(result);
        }
        [Fact]
        public void CreateShouldReturnFalseBecauseImageURLIsNull()
        {
            //Arrange
            using var data = DatabaseMock.Instance;
            var mdl = new CategoryFormModel
            {
                Name = "a",
                ImageUrl = null
            };
            var categoryService = new CategoryService(data);
            //Act
            var result = categoryService.Create(mdl);
            //Assert
            Assert.False(result);
        }
        [Fact]
        public void CreateShouldReturnTrue()
        {
            //Arrange
            using var data = DatabaseMock.Instance;
            var mdl = new CategoryFormModel
            {
                Name = "a",
                ImageUrl = "b"
            };
            var categoryService = new CategoryService(data);
            //Act
            var result = categoryService.Create(mdl);
            //Assert
            Assert.True(result);
        }
    }
}
