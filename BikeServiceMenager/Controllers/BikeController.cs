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

        public IActionResult AddingBikeForm()
        {
            return View();
        }
        public IActionResult AddBike(string ownername, string ownersurname, string bikebrand, string bikemodel, string productionyear)
        {

            var newclient = new Client()
            {
                Name = ownername,
                Surname = ownersurname,
                YearOfBecameClient=DateTime.Today
            };

            var newbike = new Bike()
            {
                Brand = bikebrand,
                Model = bikemodel,
                YearOfProduction = productionyear,
                Owner = newclient

            };

            if (!_context.Clients.Contains(newclient))
            {
                try
                {
                    _context.Clients.Add(newclient);
                    _context.SaveChanges();
                }
                catch 
                {
                    throw;
                }
            }
           

            try
            {
                _context.Bikes.Add(newbike);
                _context.SaveChanges();
            }
            catch
            {
                throw;
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult DeleteBike (int id)
        {
            var bikeToDelete = _context.Bikes
                             .Where(n => n.BikeId == id)
                             .FirstOrDefault();
            try 
            {
                _context.Bikes.Remove(bikeToDelete);
                _context.SaveChanges();
            }
            catch
            {

            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult BikeServiceHistory(int id)
        {
            var bikeServiceHistory = _context.ServiceHistories
                                   .Where(n => n.ServiceOrderHistory.ServiceOrderId == id)
                                   .ToList();
            var bikeServiceHistoryToDisplay = new BikeServiceViewModel()
            {
                ServiceHistoryList = bikeServiceHistory
            };

            return View (bikeServiceHistoryToDisplay);
        }
    }
}
