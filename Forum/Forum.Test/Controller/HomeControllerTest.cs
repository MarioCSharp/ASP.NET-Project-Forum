namespace Forum.Test.Controller
{
    using Forum.Controllers;
    using Forum.Data.Models;
    using MyTested.AspNetCore.Mvc;
    using System.Linq;
    using Xunit;
    
    public class HomeControllerTest
    {
        [Fact]
        public void IndexShouldReturnView()
        => MyController<HomeController>
            .Instance(controller => controller
            .WithData(Enumerable.Range(0, 10).Select(i => new Category { })))
            .Calling(c => c.Index())
            .ShouldReturn()
            .View();
        [Fact]
        public void ErrorShouldReturnView()
        => MyController<HomeController>
            .Instance()
            .Calling(c => c.Error())
            .ShouldReturn()
            .View();
    }
}
