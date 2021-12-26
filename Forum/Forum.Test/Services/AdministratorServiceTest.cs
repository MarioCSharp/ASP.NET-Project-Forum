namespace Forum.Test.Services
{
    using Forum.Data.Models;
    using Forum.Models.Category;
    using Forum.Services.Administrator;
    using Forum.Test.Mocks;
    using Xunit;
    public class AdministratorServiceTest
    {
        [Fact]
        public void DeleteCategoryShouldReturnFalse()
        {
            //Arrange
            using var data = DatabaseMock.Instance;
            data.Categories.Add(new Category
            {
                Id = 1,
                Name = "a"
            });
            data.SaveChanges();
            var administratorService = new AdministratorService(data);
            //Act
            var deleted = administratorService.DeleteCategory(2);
            //
            Assert.False(deleted);
        }
        [Fact]
        public void DeleteCategoryShouldReturnTrue()
        {
            //Arrange
            using var data = DatabaseMock.Instance;
            data.Categories.Add(new Category
            {
                Id = 1,
                Name = "a"
            });
            data.SaveChanges();
            var administratorService = new AdministratorService(data);
            //Act
            var deleted = administratorService.DeleteCategory(1);
            //
            Assert.True(deleted);
        }
        [Fact]
        public void DeleteCommentShouldReturnFalseBecauseTheIdIsBellowZero()
        {
            //Arrange
            using var data = DatabaseMock.Instance;
            data.Comments.Add(new Comment
            {
                Id = 1,
                Content = "das"
            });
            data.SaveChanges();
            var administratorService = new AdministratorService(data);
            //Act
            var deleted = administratorService.DeleteComment(-1);
            //Assert
            Assert.False(deleted);
        }
        [Fact]
        public void DeleteCommentShouldReturnFalseBecauseCommentDontExistInTheDatabase()
        {
            //Arrange
            using var data = DatabaseMock.Instance;
            data.Comments.Add(new Comment
            {
                Id = 1,
                Content = "das"
            });
            data.SaveChanges();
            var administratorService = new AdministratorService(data);
            //Act
            var deleted = administratorService.DeleteComment(2);
            //Assert
            Assert.False(deleted);
        }
        [Fact]
        public void DeleteCommentShouldReturnTrue()
        {
            //Arrange
            using var data = DatabaseMock.Instance;
            data.Comments.Add(new Comment
            {
                Id = 1,
                Content = "das"
            });
            data.SaveChanges();
            var administratorService = new AdministratorService(data);
            //Act
            var deleted = administratorService.DeleteComment(1);
            //Assert
            Assert.True(deleted);
        }
        [Fact]
        public void DeletePostShouldReturnFalse()
        {
            //Arrange
            using var data = DatabaseMock.Instance;
            data.Posts.Add(new Post
            {
                Id = 1,
                Content = "das"
            });
            data.SaveChanges();
            var administratorService = new AdministratorService(data);
            //Act
            var result = administratorService.DeletePost(2);
            //Assert
            Assert.False(result);
        }
        [Fact]
        public void DeletePostShouldReturnTrue()
        {
            //Arrange
            using var data = DatabaseMock.Instance;
            data.Posts.Add(new Post
            {
                Id = 1,
                Content = "das"
            });
            data.SaveChanges();
            var administratorService = new AdministratorService(data);
            //Act
            var result = administratorService.DeletePost(1);
            //Assert
            Assert.True(result);
        }
        [Fact]
        public void EditCategoryShouldReturnFalse()
        {
            //Arrange
            using var data = DatabaseMock.Instance;
            data.Categories.Add(new Category
            {
                Id = 1,
                Name = "das"
            });
            data.SaveChanges();
            var administratorService = new AdministratorService(data);
            //Act
            var result = administratorService.EditCategory(2, new EditCategoryFormModel());
            //Assert
            Assert.False(result);
        }
        [Fact]
        public void EditCategoryShouldReturnTrue()
        {
            //Arrange
            using var data = DatabaseMock.Instance;
            data.Categories.Add(new Category
            {
                Id = 1,
                Name = "das"
            });
            data.SaveChanges();
            var administratorService = new AdministratorService(data);
            //Act
            var result = administratorService.EditCategory(1, new EditCategoryFormModel());
            //Assert
            Assert.True(result);
        }
        [Fact]
        public void EditCategoryTest()
        {
            //Arrange
            using var data = DatabaseMock.Instance;
            var category = new Category
            {
                Id = 1,
                Name = "das"
            };
            data.Categories.Add(category);
            data.SaveChanges();
            var administratorService = new AdministratorService(data);
            var mdl = new EditCategoryFormModel
            {
                Name = "a",
                ImageURL = "dasdas"
            };
            //Act
            administratorService.EditCategory(1, mdl);
            //Assert
            Assert.Equal("a", category.Name);
        }
    }
}
