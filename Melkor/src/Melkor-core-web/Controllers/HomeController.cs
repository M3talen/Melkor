﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
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
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;

namespace Melkor_core_web.Controllers
{
    

    public class HomeController : Controller
    {
        private readonly string _location;
        private readonly IHostingEnvironment _environment;
        private readonly UserManager<ApplicationUser> _userManager;

        public HomeController(IHostingEnvironment environment, UserManager<ApplicationUser> userManager, IConfigurationRoot configuration)
        {
            this._environment = environment;
            this._userManager = userManager;
            this._location = configuration.GetSection("Environment")["Storage"];
        }

        public IActionResult Index()
        {

            return View();
        }

        [Authorize]
        public async Task<IActionResult> GitDownload()
        {
            string downloadLocation = _location;
            string[] urls = new[] { "https://github.com/fspigel/RAUPJC-DZ2/", "https://github.com/ZvonimirKucis/2-domaca-zadaca" };

            ApplicationUser currentUser = await _userManager.GetUserAsync(HttpContext.User);

            GitZipper.CleanUp(downloadLocation);
            
            foreach (var url in urls)
            {
                GitZipper zip = new GitZipper(url, Guid.Parse(currentUser.Id).ToString());
                
                zip.GitDownload(downloadLocation);
                zip.GitUnzip();
            }
            ViewData["Message"] = downloadLocation; 

            return View();
        }

        [Authorize]
        public IActionResult Build()
        {
            string target = _location;
            if (!Directory.Exists(target)) throw new DirectoryNotFoundException();
            Builder builder = new Builder(target);

            var resultBuildItems = builder.Build();
            
            ViewData["Message"] = "Build";

            return View(resultBuildItems);
        }

        public IActionResult Error()
        {
            return View();
        }

    }
}
