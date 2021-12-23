namespace Forum.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using System.ComponentModel.DataAnnotations;

    using static GlobalConstants.User;
    public class MyUser : IdentityUser
    {
        [MaxLength(MaxUserFullNameLength)]
        public string FullName { get; set; }
    }
}
