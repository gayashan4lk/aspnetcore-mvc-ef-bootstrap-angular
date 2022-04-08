using Microsoft.AspNetCore.Mvc;
using SekiroApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SekiroApp.Services;
using SekiroApp.Data;

namespace SekiroApp.Controllers
{
    public class AppController: Controller
    {
        private readonly IMailService _mailService;
        private readonly ISekiroRepository _repository;

        public AppController(IMailService mailService, ISekiroRepository repository)
        {
            _mailService = mailService;
            _repository = repository;
        }

        public IActionResult Index()
        {
            //throw new InvalidProgramException("Shit happens!");
            //var results = _context.Products.ToList();
            return View();
        }

        [HttpGet("contact")]
        public IActionResult Contact()
        {
            //throw new InvalidOperationException("Shit happens!");
            //ViewBag.Title = "Contact Page";
            return View();
        }

        [HttpPost("contact")]
        public IActionResult Contact(ContactViewModel model)
        {
            //ViewBag.Title = "Contact us";
            if (ModelState.IsValid)
            {
                // Send the email
                _mailService.SendMessage("dummy@dummy.com", model.Subject, $"From:{model.Name} - {model.Email}, Message: {model.Message}");
                ViewBag.UserMessage = "Mail Sent";
                ModelState.Clear();
            }
            // dont need "else" because errors are showing on frontend
            return View();
        }

        [HttpGet("about")]
        public IActionResult About()
        {
            //ViewBag.Title = "About Page";
            ViewBag.Message = "This is message from AppController. You are seeing the About page.";

            //This causes error! why??
            // RuntimeBinderException: Cannot apply indexing with [] to an expression of type 'System.Dynamic.DynamicObject'
            /*ViewBag["Title"] = "Title";
            ViewBag["Message"] = "This is message from AppController. You are seeing the About page.";*/

            return View(ViewBag);
        }

        [HttpGet("shop")]
        public IActionResult Shop()
        {
            var results = _repository.GetAllProducts();
            return View(results.ToList());
        }
    }
}
