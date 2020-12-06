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
                
                DateToBeReady = DateTime.Now.AddDays(1),
                ActionToDo1 = serviceAction1,
                ActionToDo2 = serviceAction2,
                ActionToDo3 = serviceAction3,
                ActionToDo4 = serviceAction4,
                ActionToDo5 = serviceAction5,
                AditionalNotes = additionalinfo
            };

            var noAction = _context.ServiceActions
                          .Where(n => n.ServiceActionId == 4)
                          .FirstOrDefault();
            if (newServiceOrder.ActionToDo2 == null)
            {
                newServiceOrder.ActionToDo2 = noAction;
            }
            if (newServiceOrder.ActionToDo3 == null)
            {
                newServiceOrder.ActionToDo3 = noAction;
            }
            if (newServiceOrder.ActionToDo4 == null)
            {
                newServiceOrder.ActionToDo4 = noAction;
            }
            if (newServiceOrder.ActionToDo5 == null)
            {
                newServiceOrder.ActionToDo5 = noAction;
            }
            if ((newServiceOrder.ActionToDo1.ManHour + newServiceOrder.ActionToDo2.ManHour + newServiceOrder.ActionToDo3.ManHour + newServiceOrder.ActionToDo4.ManHour + newServiceOrder.ActionToDo5.ManHour) > 8)
            {
                newServiceOrder.DateToBeReady = DateTime.Now.AddDays(2);
            }
            else
            {
                newServiceOrder.DateToBeReady = DateTime.Now.AddDays(1);
            }

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

            var noAction = _context.ServiceActions
                          .Where(n => n.ServiceActionId == 4)
                          .FirstOrDefault();
            if (OrderToDisplay.ActionToDo2 == null)
            {
                OrderToDisplay.ActionToDo2 = noAction;
            }
            if (OrderToDisplay.ActionToDo3 == null)
            {
                OrderToDisplay.ActionToDo3 = noAction;
            }
            if (OrderToDisplay.ActionToDo4 == null)
            {
                OrderToDisplay.ActionToDo4 = noAction;
            }
            if (OrderToDisplay.ActionToDo5 == null)
            {
                OrderToDisplay.ActionToDo5 = noAction;
            }

            var TotalAmountToPay = (OrderToDisplay.ActionToDo1.Price + OrderToDisplay.ActionToDo2.Price + OrderToDisplay.ActionToDo3.Price + OrderToDisplay.ActionToDo4.Price + OrderToDisplay.ActionToDo5.Price);

            ViewBag.TotalAmountToDisplay = TotalAmountToPay;

            return View(OrderToDisplay);
        }

        public IActionResult DeleteServiceOrder (int id)
        {
            var ServiceOrderToDelete = _context.ServiceOrders
                                       .Where(n => n.ServiceOrderId == id)
                                       .FirstOrDefault();
            try
            {
                _context.ServiceOrders.Remove(ServiceOrderToDelete);
                _context.SaveChanges();
            }
            catch
            {
                throw;
            }

            
            return RedirectToAction(nameof(Index));
        }

        public IActionResult FindBike(string ownersurname)
        {
            var BikesToDisplaybyOwner = _context.Bikes
                                 .Include(n => n.Owner)
                                 .Where(n => n.Owner.Surname == ownersurname)
                                 .ToList();

            var bikesToDislplay = new BikeServiceViewModel()
            {
                BikeList = BikesToDisplaybyOwner
            };
            return View(bikesToDislplay);
        }
    }
}
