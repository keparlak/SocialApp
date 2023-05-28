using Microsoft.AspNetCore.Mvc;
using SocialAppForIbb.Ent;
using SocialAppForIbb.UI.Models.ViewModels;
using SocialAppForIbb.Uow;

namespace SocialAppForIbb.UI.Controllers
{
    public class PostController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public PostController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> List()
        {
            // Örneğin, tüm gönderileri getir
            List<Post> posts = await _unitOfWork.Posts.GetAllAsync();

            // User sınıfını UserViewModel ile dönüştür
            List<PostViewModel> viewModels = posts.Select(u => new PostViewModel
            {
                Id = u.Id,
                Title = u.Title,
                Body = u.Body,
                Status = u.Status,
                UserId = u.UserId,
                CreatedAt = u.CreatedAt,
                IsDeleted = u.IsDeleted,
                DeletedAt = u.DeletedAt,
            }).ToList();

            // View'e modeli geçir
            return View(viewModels);
        }

        // Diğer action metodları, gönderi ekleme, silme, güncelleme işlemleri için kullanılabilir
    }
}
