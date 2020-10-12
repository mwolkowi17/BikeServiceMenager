using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BikeServiceMenager.Data;
using BikeServiceMenager.Models;
using Microsoft.AspNetCore.Mvc;

namespace BikeServiceMenager.Controllers
{
    public class ClientController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ClientController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var clients = _context.Clients.ToList();

            var clientsToDisplay = new BikeServiceViewModel()
            {
                ClientList = clients
            };

            return View(clientsToDisplay);
        }

        public IActionResult DeleteClient(int id)
        {
            var clientToDelete = _context.Clients
                                 .Where(n => n.ClientId == id)
                                 .FirstOrDefault();
            try{
                _context.Clients.Remove(clientToDelete);
            }
            catch
            {
                Console.WriteLine("Delte Error");
            }

            
            return RedirectToAction (nameof(Index));
        }
    }
}
