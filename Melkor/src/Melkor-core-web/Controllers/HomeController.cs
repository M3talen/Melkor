﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Melkor_core_builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Melkor_core_gitzipper;
using Melkor_core_web.Models;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Design.Internal;
using BuildItem = Melkor_core_web.Models.BuildItem;
using Microsoft.AspNetCore.Authorization;

namespace Melkor_core_web.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly IHostingEnvironment _environment;
        private readonly UserManager<ApplicationUser> _userManager;

        public HomeController(IHostingEnvironment environment, UserManager<ApplicationUser> userManager)
        {
            this._environment = environment;
            this._userManager = userManager;
        }

        public IActionResult Index()
        {

            return View();
        }

        [Authorize]
        public async Task<IActionResult> About()
        {
            string downloadLocation = @"D:\home\Melkor\";
            string[] urls = new[] { "https://github.com/fspigel/RAUPJC-DZ2/", "https://github.com/ZvonimirKucis/2-domaca-zadaca" };

            ApplicationUser currentUser = await _userManager.GetUserAsync(HttpContext.User);

            GitZipper.CleanUp(downloadLocation);
            foreach (var url in urls)
            {
                GitZipper zip = new GitZipper(url, currentUser.GetHashCode().ToString());

                zip.GitDownload(downloadLocation);
                zip.GitUnzip();
            }
            ViewData["Message"] = downloadLocation; 

            return View();
        }

        [Authorize]
        public IActionResult Contact()
        {
            List<BuildItem> str = new List<BuildItem>();
            string target = @"D:\home\Melkor\";
            if (!Directory.Exists(target)) throw new DirectoryNotFoundException();
            Builder builder = new Builder(target);
            string[] strin = builder.FindProjectFile(target);
            foreach (var dir in strin)
            {
                str.Add(item: new BuildItem(dir, builder.Build3(dir) + ""));
            }

            ViewData["Message"] = "Build";

            return View(str);
        }

        public IActionResult Error()
        {
            return View();
        }

    }
}
