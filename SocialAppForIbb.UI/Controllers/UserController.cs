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
            List<User> users = await _unitOfWork.Users.GetAllAsync();

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
                PostsCount = u.Posts != null ? u.Posts.Count() : 0,
                PageTitle = "User List",
                BtnClass = "btn-primary",
                BtnText = "Create User"
            }).ToList();

            return View(viewModels);
        }

        public IActionResult Create()
        {
            UserViewModel model = new UserViewModel
            {
                PageTitle = "Create User",
                BtnClass = "btn-success",
                BtnText = "Save"
            };

            return View("Crud", model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                User newUser = new User
                {
                    Username = model.Username,
                    Role = model.Role,
                    CreatedAt = DateTime.Now,
                    IsDeleted = false
                };

                await _unitOfWork.Users.AddAsync(newUser);
                await _unitOfWork.SaveChangesAsync();

                return RedirectToAction("List");
            }

            model.PageTitle = "Create User";
            model.BtnClass = "btn-success";
            model.BtnText = "Save";

            return View("Crud", model);
        }

        public async Task<IActionResult> Edit(int id)
        {
            User user = await _unitOfWork.Users.GetByIdAsync(id);

            if (user != null)
            {
                UserViewModel model = new UserViewModel
                {
                    Id = user.Id,
                    Username = user.Username,
                    Role = user.Role,
                    CreatedAt = user.CreatedAt,
                    IsDeleted = user.IsDeleted,
                    DeletedAt = user.DeletedAt,
                    FollowersCount = user.Followers != null ? user.Followers.Count() : 0,
                    FollowingsCount = user.Followings != null ? user.Followings.Count() : 0,
                    PostsCount = user.Posts != null ? user.Posts.Count() : 0,
                    PageTitle = "Edit User",
                    BtnClass = "btn-primary",
                    BtnText = "Update"
                };

                return View("Crud", model);
            }

            return RedirectToAction("List");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                User existingUser = await _unitOfWork.Users.GetByIdAsync(model.Id);

                if (existingUser != null)
                {
                    existingUser.Username = model.Username;
                    existingUser.Role = model.Role;
                    existingUser.IsDeleted = model.IsDeleted;
                    existingUser.DeletedAt = model.DeletedAt;

                    await _unitOfWork.Users.UpdateAsync(existingUser);
                    await _unitOfWork.SaveChangesAsync();

                    return RedirectToAction("List");
                }
            }

            model.PageTitle = "Edit User";
            model.BtnClass = "btn-primary";
            model.BtnText = "Update";

            return View("Crud", model);
        }

        public async Task<IActionResult> Delete(int id)
        {
            User user = await _unitOfWork.Users.GetByIdAsync(id);

            if (user != null)
            {
                await _unitOfWork.Users.DeleteAsync(user);
                await _unitOfWork.SaveChangesAsync();
            }

            return RedirectToAction("List");
        }
    }
}
