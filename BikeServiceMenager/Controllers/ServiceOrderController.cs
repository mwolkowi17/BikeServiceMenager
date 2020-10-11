using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BikeServiceMenager.Data;
using BikeServiceMenager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BikeServiceMenager.Controllers
{
    public class ServiceOrderController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ServiceOrderController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var orders = _context.ServiceOrders
                         .Include(n=>n.BikeToService)
                         .Include(n=>n.BikeToServiceOwner)
                         .ToList();

            var ordersToDisplay = new BikeServiceViewModel()
            {
                ServiceOrderList = orders
            };
            return View(ordersToDisplay);
        }
    }
}
