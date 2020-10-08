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
    }
}
