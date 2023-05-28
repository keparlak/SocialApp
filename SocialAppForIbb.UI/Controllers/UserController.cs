using Microsoft.AspNetCore.Mvc;
using SocialAppForIbb.Ent;
using SocialAppForIbb.UI.Models.ViewModels;
using SocialAppForIbb.Uow;

namespace SocialAppForIbb.UI.Controllers
{
    public class UserController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> List()
        {
            // Örneğin, tüm kullanıcıları getir
            List<User> users = await _unitOfWork.Users.GetAllAsync();

            // User sınıfını UserViewModel ile dönüştür
            List<UserViewModel> viewModels = users.Select(u => new UserViewModel
            {
                Id = u.Id,
                Username = u.Username,
                Role = u.Role,
                CreatedAt = u.CreatedAt,
                IsDeleted = u.IsDeleted,
                DeletedAt = u.DeletedAt,
                FollowersCount = u.Followers != null ? u.Followers.Count() : 0,
                FollowingsCount = u.Followings != null ? u.Followings.Count() : 0,
                PostsCount = u.Posts != null ? u.Posts.Count() : 0
            }).ToList();

            // View'e modeli geçir
            return View(viewModels);
        }

        // Diğer action metodları, kullanıcı ekleme, silme, güncelleme işlemleri için kullanılabilir
    }
}
