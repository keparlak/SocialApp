namespace SocialAppForIbb.UI.Models.ViewModels
{
    public class UserViewModel : BaseCRUD
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Role { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedAt { get; set; }

        // Additional properties for UI purposes
        public int FollowersCount { get; set; }
        public int FollowingsCount { get; set; }
        public int PostsCount { get; set; }
    }
}
