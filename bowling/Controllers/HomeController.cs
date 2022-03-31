using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using bowling.Models;

namespace bowling.Controllers
{
    public class HomeController : Controller
    {
        private BowlingDbContext _context { get; set; }

        public HomeController(BowlingDbContext temp)
        {
            _context = temp;
        }

        public IActionResult Index()
        {
            var blah = _context.Bowlers.ToList();

            return View(blah);
        }

        [HttpGet]
        public IActionResult Add()
        {
            var x = new Bowler();


            return View("Add", x);
        }

        [HttpPost]
        public IActionResult Add(Bowler b)
        {
            if (ModelState.IsValid)
            {

                _context.Add(b);
                _context.SaveChanges();


                return RedirectToAction("Index");
            }

            else
            {
                return View();
            }

        }

        [HttpGet]
        public IActionResult Edit(int bowlerid)
        {

            var x = _context.Bowlers.Single(x => x.BowlerID == bowlerid);



            return View("Edit", x);
        }

        [HttpPost]
        public IActionResult Edit(Bowler b, int bowlerid)
        {
            if (ModelState.IsValid)
            {

                _context.Update(b);

                _context.SaveChanges();



                return RedirectToAction("Index");

            }


            else
            {
                return View();
            }


        }

        [HttpGet]
        public IActionResult Delete(int bowlerid)
        {
            Bowler bowler = _context.Bowlers.Single(x => x.BowlerID == bowlerid);
            _context.Bowlers.Remove(bowler);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
