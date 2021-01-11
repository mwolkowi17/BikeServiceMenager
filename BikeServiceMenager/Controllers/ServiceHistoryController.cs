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
    public class ServiceHistoryController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ServiceHistoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var historyOrders = _context.ServiceHistories
                                        .ToList();
            var historyOrdersToDisplay = new BikeServiceViewModel
            {
                ServiceHistoryList = historyOrders
            };
            return View(historyOrdersToDisplay);
        }
    }
}
