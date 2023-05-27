using Microsoft.AspNetCore.Mvc;
using SocialAppForIbb.Ent;
using SocialAppForIbb.Uow;

namespace SocialAppForIbb.UI.Controllers
{
    public class FollowController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public FollowController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index()
        {
            // Örneğin, tüm takip edilenleri getir
            List<Follow> follows = await _unitOfWork.Follows.GetAllAsync();

            // View'e modeli geçir
            return View(follows);
        }

        // Diğer action metodları, takip ekleme, silme, güncelleme işlemleri için kullanılabilir
    }
}
