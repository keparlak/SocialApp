using Microsoft.AspNetCore.Mvc;
using SocialAppForIbb.Ent;
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

        public async Task<IActionResult> Index()
        {
            // Örneğin, tüm gönderileri getir
            List<Post> posts = await _unitOfWork.Posts.GetAllAsync();

            // View'e modeli geçir
            return View(posts);
        }

        // Diğer action metodları, gönderi ekleme, silme, güncelleme işlemleri için kullanılabilir
    }
}
