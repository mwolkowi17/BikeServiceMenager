using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BikeServiceMenager.Data;
using BikeServiceMenager.Models;
using Microsoft.AspNetCore.Mvc;

namespace BikeServiceMenager.Controllers

{ public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;
        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ServiceActionList()
        {
        var serviceActions = _context.ServiceActions
                                    .ToList();
        var serviceAsctionToDisplay = new BikeServiceViewModel()
        {
            ServiceActionList = serviceActions
        };
            return View(serviceAsctionToDisplay);
        }
    }
}
