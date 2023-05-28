namespace SocialAppForIbb.UI.Models.ViewModels
{
    public class PostViewModel : BaseCRUD
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public int UserId { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedAt { get; set; }

        // Additional properties for UI purposes
        public string Username { get; set; }
    }

}
