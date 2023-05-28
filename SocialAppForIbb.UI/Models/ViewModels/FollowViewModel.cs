namespace SocialAppForIbb.UI.Models.ViewModels
{
    public class FollowViewModel : BaseCRUD
    {
        public int FollowingUserId { get; set; }
        public int FollowedUserId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
