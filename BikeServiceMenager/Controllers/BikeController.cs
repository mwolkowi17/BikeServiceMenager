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
    public class BikeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BikeController( ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var bikes = _context.Bikes
                                .Include(n => n.Owner)
                                .ToList();

            var bikesToDislplay = new BikeServiceViewModel()
            {
                BikeList = bikes
            };
            return View(bikesToDislplay);
        }
    }
}
