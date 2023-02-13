using DotNet_Project9.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using DotNet_Project9.Models;

namespace DotNet_Project9.Controllers
{
    public class RegisterController : Controller
    {
        private readonly ApplicationDbContext _context;
        public RegisterController()
        {
            _context= new ApplicationDbContext();
        }
        // GET: Register
        public ActionResult Index()
        {
            var userList= _context.Registers.Include(c => c.City).Include(c => c.City.State).Include(c => c.City.State.Country).ToList();
            return View(userList);
        }
        public ViewResult Create()
        {
            ViewBag.CountryList = _context.Countries.ToList();
            ViewBag.StateList = _context.States.ToList();
            ViewBag.CityList = _context.Cities.ToList();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Register register)
        {
            if (register == null)
                return HttpNotFound();

            if (!ModelState.IsValid)
            {
                ViewBag.CountryList = _context.Countries.ToList();
                ViewBag.StateList = _context.States.ToList();
                ViewBag.CityList = _context.Cities.ToList();
                return View(register);

            }
            _context.Registers.Add(register);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public ActionResult Edit(int id)
        {
            //var userInDb = _context.Registers.Find(id);
            var userInDb = _context.Registers.Include(c => c.City).Include(s => s.City.State).Include(c => c.City.State.Country).FirstOrDefault(r => r.Id == id);
            if (userInDb == null) return HttpNotFound();

            ViewBag.CountryList = _context.Countries.ToList();
            ViewBag.StateList = _context.States.ToList();
            ViewBag.CityList = _context.Cities.ToList();
            userInDb.CountryId = userInDb.City.State.Country.Id;
            userInDb.StateId = userInDb.City.State.Id;
            return View(userInDb);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Register register)
        {
            if (register == null) return HttpNotFound();
            var userFromDb = _context.Registers.Find(register.Id);
            if (userFromDb == null) return HttpNotFound();
            if (!ModelState.IsValid)
            {
                ViewBag.CountryList = _context.Countries.ToList();
                ViewBag.StateList = _context.States.ToList();
                ViewBag.CityList = _context.Cities.ToList();
                return View(register);

            }
            userFromDb.Name = register.Name;
            userFromDb.Address = register.Address;
            userFromDb.Email = register.Email;
            userFromDb.CityId = register.CityId;
            userFromDb.Subscribe = register.Subscribe;
            userFromDb.Gender = register.Gender;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public ActionResult Details(int id)
        {
            var userInDb = _context.Registers.Include(c => c.City).Include(s => s.City.State).Include(c => c.City.State.Country).FirstOrDefault(r => r.Id == id);
            if (userInDb == null) return HttpNotFound();
            return View(userInDb);
        }
        public ActionResult Delete(int id)
        {
            var userInDb = _context.Registers.Find(id);
            if (userInDb == null) return HttpNotFound();
            _context.Registers.Remove(userInDb);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        #region APIs
        private List<State> GetStates(int countryId)
        {
            return _context.States.Where(s => s.CountryId == countryId).ToList();
        }
        private List<City> GetCities(int stateId)
        {
            return _context.Cities.Where(c => c.StateId == stateId).ToList();
        }
        public ActionResult LoadStateByCountryId(int countryId)
        {
            var stateList = GetStates(countryId);
            var stateListData = stateList.Select(s1 => new SelectListItem()
            {
                Text = s1.Name,
                Value = s1.Id.ToString()
            });
            return Json(stateListData, JsonRequestBehavior.AllowGet);
        }
        public ActionResult LoadCityByStateId(int stateId)
        {
            var cityList = GetCities(stateId);
            var cityListData = cityList.Select(c1 => new SelectListItem()
            {
                Text = c1.Name,
                Value = c1.Id.ToString()
            });
            return Json(cityListData, JsonRequestBehavior.AllowGet);
        }

        #endregion
    }
}