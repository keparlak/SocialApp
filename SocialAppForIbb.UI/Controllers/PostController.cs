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
            List<Post> posts = await _unitOfWork.Posts.GetAllAsync();

            List<PostViewModel> viewModels = posts.Select(p => new PostViewModel
            {
                Id = p.Id,
                Title = p.Title,
                Body = p.Body,
                Status = p.Status,
                UserId = p.UserId,
                CreatedAt = p.CreatedAt,
                IsDeleted = p.IsDeleted,
                DeletedAt = p.DeletedAt
            }).ToList();

            return View(viewModels);
        }

        public IActionResult Create()
        {
            PostViewModel model = new PostViewModel
            {
                PageTitle = "Create Post",
                BtnClass = "btn-success",
                BtnText = "Save"
            };

            return View("Crud", model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(PostViewModel model)
        {
            if (ModelState.IsValid)
            {
                Post newPost = new Post
                {
                    Title = model.Title,
                    Body = model.Body,
                    Status = model.Status,
                    UserId = model.UserId,
                    CreatedAt = DateTime.Now,
                    IsDeleted = false
                };

                await _unitOfWork.Posts.AddAsync(newPost);
                await _unitOfWork.SaveChangesAsync();

                return RedirectToAction("List");
            }

            model.PageTitle = "Create Post";
            model.BtnClass = "btn-success";
            model.BtnText = "Save";

            return View("Crud", model);
        }

        public async Task<IActionResult> Edit(int id)
        {
            Post post = await _unitOfWork.Posts.GetByIdAsync(id);

            if (post != null)
            {
                PostViewModel model = new PostViewModel
                {
                    Id = post.Id,
                    Title = post.Title,
                    Body = post.Body,
                    Status = post.Status,
                    UserId = post.UserId,
                    CreatedAt = post.CreatedAt,
                    IsDeleted = post.IsDeleted,
                    DeletedAt = post.DeletedAt,
                    PageTitle = "Edit Post",
                    BtnClass = "btn-primary",
                    BtnText = "Update"
                };

                return View("Crud", model);
            }

            return RedirectToAction("List");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(PostViewModel model)
        {
            if (ModelState.IsValid)
            {
                Post existingPost = await _unitOfWork.Posts.GetByIdAsync(model.Id);

                if (existingPost != null)
                {
                    existingPost.Title = model.Title;
                    existingPost.Body = model.Body;
                    existingPost.Status = model.Status;
                    existingPost.UserId = model.UserId;
                    existingPost.IsDeleted = model.IsDeleted;
                    existingPost.DeletedAt = model.DeletedAt;

                    await _unitOfWork.Posts.UpdateAsync(existingPost);
                    await _unitOfWork.SaveChangesAsync();

                    return RedirectToAction("List");
                }
            }

            model.PageTitle = "Edit Post";
            model.BtnClass = "btn-primary";
            model.BtnText = "Update";

            return View("Crud", model);
        }

        public async Task<IActionResult> Delete(int id)
        {
            Post post = await _unitOfWork.Posts.GetByIdAsync(id);

            if (post != null)
            {
                await _unitOfWork.Posts.DeleteAsync(post);
                await _unitOfWork.SaveChangesAsync();
            }

            return RedirectToAction("List");
        }
    }
}
