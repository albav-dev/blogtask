﻿using Blog.Data;
using Blog.Data.FileManager;
using Blog.Data.Repository;
using Blog.Models;
using Blog.Models.CategoryData;
using Blog.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Controllers
{
    [Authorize(Roles = "Admin")]
    public class PanelController : Controller
    {
        private IRepository _repo;
        private IFileManager _fileManager;
        private readonly AppDbContext _context;

        public PanelController(IRepository repo, IFileManager fileManager, AppDbContext context)
        {
            _repo = repo;
            _fileManager = fileManager;
            _context = context;
        }

        public IActionResult Index()
        {
            var posts = _repo.GetAllPosts();
            return View(posts);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            List<CategoryData> cat = new List<CategoryData>();
            cat = (from product in _context.CategoriesData select product).ToList();
            ViewBag.CategoriesList = cat;

            if (id == null)
                return View(new PostViewModel());
            else
            {
                var post = _repo.GetPost((int)id);
                return View(new PostViewModel
                {
                    Id = post.Id,
                    Title = post.Title,
                    Body = post.Body,
                    CurrentImage = post.Image,
                    Description = post.Description,
                    Tags = post.Tags,
                    Category = post.Category,
                });
            }

        }

        [HttpPost]
        public async Task<IActionResult> Edit(PostViewModel vm)
        {
            var post = new Post
            {
                Id = vm.Id,
                Title = vm.Title,
                Body = vm.Body,
                Description = vm.Description,
                Tags = vm.Tags,
                Category = vm.Category,
            };

            if (vm.Image == null)
                post.Image = vm.CurrentImage;
            else
            {
                if (!string.IsNullOrEmpty(vm.CurrentImage))
                    _fileManager.RemoveImage(vm.CurrentImage);

                post.Image = await _fileManager.SaveImage(vm.Image);
            }

            if (post.Id > 0)
                _repo.UpdatePost(post);
            else
                _repo.AddPost(post);

            if (await _repo.SaveChangesAsync())
                return RedirectToAction("Index", "Panel");
            else
                return View(post);
        }

        public async Task<IActionResult> Remove(int id)
        {
            _repo.RemovePost(id);
            await _repo.SaveChangesAsync();
            return RedirectToAction("Index", "Panel");
        }
    }
}
