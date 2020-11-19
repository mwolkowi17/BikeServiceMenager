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

        public IActionResult AddOrderFormDisplay()
        {
            return View();
        }

        public IActionResult AddOrder(int bikeid, string additionalinfo, int serviceactionid1, int serviceactionid2, int serviceactionid3, int serviceactionid4, int serviceactionid5)
        {
            var bikeToService = _context.Bikes
                                .Where(n => n.BikeId == bikeid)
                                .Include(n => n.Owner)
                                .FirstOrDefault();

            var bikeToServiceOwner = bikeToService.Owner;

            var serviceAction1 = _context.ServiceActions
                                 .Where(n => n.ServiceActionId == serviceactionid1)
                                 .FirstOrDefault();

            var serviceAction2 = _context.ServiceActions
                                 .Where(n => n.ServiceActionId == serviceactionid2)
                                 .FirstOrDefault();

            var serviceAction3 = _context.ServiceActions
                                 .Where(n => n.ServiceActionId == serviceactionid3)
                                 .FirstOrDefault();

            var serviceAction4 = _context.ServiceActions
                                 .Where(n => n.ServiceActionId == serviceactionid4)
                                 .FirstOrDefault();

            var serviceAction5 = _context.ServiceActions
                                 .Where(n => n.ServiceActionId == serviceactionid5)
                                 .FirstOrDefault();

            var newServiceOrder = new ServiceOrder()
            {
                BikeToService = bikeToService,
                BikeToServiceOwner = bikeToServiceOwner,
                DateOfOrderOpen = DateTime.Now.Date,
                ActionToDo1 = serviceAction1,
                ActionToDo2 = serviceAction2,
                ActionToDo3 = serviceAction3,
                ActionToDo4 = serviceAction4,
                ActionToDo5 = serviceAction5,
                AditionalNotes = additionalinfo
            };

            _context.ServiceOrders.Add(newServiceOrder);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult GetOrderDetails(int id)
        {
            var OrderToDisplay = _context.ServiceOrders
                                 .Where(n => n.ServiceOrderId == id)
                                 .Include(n=>n.BikeToService)
                                 .Include(n=>n.BikeToServiceOwner)
                                 .Include(n=>n.ActionToDo1)
                                 .Include(n=>n.ActionToDo2)
                                 .Include(n=>n.ActionToDo3)
                                 .Include(n=>n.ActionToDo4)
                                 .Include(n=>n.ActionToDo5)
                                 .FirstOrDefault();

            return View(OrderToDisplay);
        }
    }
}
