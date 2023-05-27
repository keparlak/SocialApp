using Microsoft.AspNetCore.Mvc;
using SocialAppForIbb.Ent;
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

        public async Task<IActionResult> Index()
        {
            // Örneğin, tüm kullanıcıları getir
            List<User> users = await _unitOfWork.Users.GetAllAsync();

            // View'e modeli geçir
            return View(users);
        }

        // Diğer action metodları, kullanıcı ekleme, silme, güncelleme işlemleri için kullanılabilir
    }
}
