using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AfterWorkTambayan.Web.Model;
using AfterWorkTambayan.Domain.Entities;
using AfterWorkTambayan.Web.Utilities;
using System.Threading;
using AfterWorkTambayan.Domain.Repository;

namespace AfterWorkTambayan.Web.Controllers
{
    public class RestaurantController : Controller
    {
        private RestaurantRepository _repositoryRestaurant;
        private CategoryRepository _repositoryCategory;

        public RestaurantController()
        {
            _repositoryRestaurant = new RestaurantRepository();
            _repositoryCategory = new CategoryRepository();
        }
        
        //
        // GET: /Restaurant/

        public ActionResult Index()
        {
            //
            //_repository.ClearAll();
            //Restaurant restaurant = new Restaurant();
            //restaurant.Address = "Address 1";
            //restaurant.City = "City 1";
            //restaurant.Currency = "PHP";
            //restaurant.Description = "Description 1";
            //restaurant.IsTest = 1;
            //restaurant.Latitude = null;
            //restaurant.Longitude = null;
            //restaurant.Name = "Name 1";
            //restaurant.OperationHrsFrom = "0700 am";
            //restaurant.OperationHrsTo = "2100 pm";
            //restaurant.RestaurantId = Guid.NewGuid();
            //restaurant.Service = 0.05;
            //restaurant.State = "GU";
            //restaurant.Tax = 0.05;
            //restaurant.ZipCode = "1234";
            //_repository.Add(restaurant);

            //restaurant = new Restaurant();
            //restaurant.Address = "Address 2";
            //restaurant.City = "City 2";
            //restaurant.Currency = "PHP";
            //restaurant.Description = "Description 2";
            //restaurant.IsTest = 2;
            //restaurant.Latitude = null;
            //restaurant.Longitude = null;
            //restaurant.Name = "Name 2";
            //restaurant.OperationHrsFrom = "0700 am";
            //restaurant.OperationHrsTo = "2100 pm";
            //restaurant.RestaurantId = Guid.NewGuid();
            //restaurant.Service = 0.05;
            //restaurant.State = "GU";
            //restaurant.Tax = 0.05;
            //restaurant.ZipCode = "1234";
            //_repository.Add(restaurant);
            //            

            var items = (from r in _repositoryRestaurant.GetRestaurants()
                         orderby r.Name 
                         select new ListRestaurantsViewModel
                         {
                            Id = r.RestaurantId,
                            Name = r.Name
                         }).ToList();            

            return View(items);
        }        

        //
        // GET: /Restaurant/GetMenu

        public ActionResult GetMenu()
         {
            MenuViewModel menuViewModel = new MenuViewModel();
            menuViewModel.Category = new Category();
            menuViewModel.Categories = (from r in _repositoryCategory.GetCategories()
                         orderby r.Name
                         select new Category
                         {
                            CategoryId = r.CategoryId,
                            ImageUrl = r.ImageUrl,
                            Name = r.Name,
                            Description = r.Description
                         }).ToList();

            return PartialView("_MenuPartialView", menuViewModel);
         }

        //
        // POST: /Restaurant/GetMenu

        [HttpPost]
        public ActionResult GetMenu(MenuViewModel menuViewModel)
        {
            if (ModelState.IsValid)
            {
                Category category = new Category();
                category.CategoryId = Guid.NewGuid();
                category.ImageUrl = menuViewModel.Category.ImageUrl;
                category.Name = menuViewModel.Category.Name;
                category.Description = menuViewModel.Category.Description;
                _repositoryCategory.Add(category);                
                return Content("OK");
            }
            else
            {
                return Content(String.Empty);
            }
        }

        //
        // GET: /Restaurant/GetRestaurant

        public ActionResult GetRestaurant(Guid id)
        {
            var restaurant = _repositoryRestaurant.GetRestaurant(id);
            GetRestaurantViewModel restaurantViewModel = new GetRestaurantViewModel();
            if (restaurant != null)
            {
                restaurantViewModel.Restaurant = new Restaurant()
                {
                    RestaurantId = restaurant.RestaurantId,
                    Address = restaurant.Address,
                    City = restaurant.City,
                    Currency = restaurant.Currency,
                    Description = restaurant.Description,
                    IsTest = restaurant.IsTest,
                    Latitude = restaurant.Latitude,
                    Longitude = restaurant.Longitude,
                    Name = restaurant.Name,
                    OperationHrsFrom = restaurant.OperationHrsFrom,
                    OperationHrsTo = restaurant.OperationHrsTo,
                    Service = restaurant.Service,
                    State = restaurant.State,
                    Tax = restaurant.Tax,
                    ZipCode = restaurant.ZipCode
                };
            }
            else
            {
                restaurantViewModel.Restaurant = new Restaurant();
            }            
            var amHrs = restaurantViewModel.Restaurant.OperationHrsFrom;
            var pmHrs = restaurantViewModel.Restaurant.OperationHrsTo;
            restaurantViewModel.AMHrs = amHrs.Substring(amHrs.Length - 2) == "am" ? true : false;
            restaurantViewModel.PMHrs = pmHrs.Substring(pmHrs.Length - 2) == "pm" ? true : false; 
            restaurantViewModel.Restaurant.OperationHrsFrom = restaurantViewModel.Restaurant.OperationHrsFrom.Substring(0, restaurantViewModel.Restaurant.OperationHrsFrom.Length - 3);
            restaurantViewModel.Restaurant.OperationHrsTo = restaurantViewModel.Restaurant.OperationHrsTo.Substring(0, restaurantViewModel.Restaurant.OperationHrsTo.Length - 3);            
            restaurantViewModel.USStates = USStates.StateSelectList;
            restaurantViewModel.Currencies = Currencies.StateSelectList;
            ViewBag.Status = "Get";
            
            return PartialView("_ListRestaurantsPartialView", restaurantViewModel);
        }

        //
        // POST: /Restaurant/GetRestaurant

        [HttpPost]
        public ActionResult GetRestaurant(GetRestaurantViewModel restaurantViewModel)
        {
            if (ModelState.IsValid)
            {
                _repositoryRestaurant.Delete(restaurantViewModel.Restaurant.RestaurantId);
                Restaurant restaurant = new Restaurant();
                restaurant.Address = restaurantViewModel.Restaurant.Address;
                restaurant.City = restaurantViewModel.Restaurant.City;
                restaurant.Currency = restaurantViewModel.Restaurant.Currency;
                restaurant.Description = restaurantViewModel.Restaurant.Description;
                restaurant.IsTest = restaurantViewModel.Restaurant.IsTest;
                restaurant.Latitude = restaurantViewModel.Restaurant.Latitude;
                restaurant.Longitude = restaurantViewModel.Restaurant.Longitude;
                restaurant.Name = restaurantViewModel.Restaurant.Name;
                restaurant.OperationHrsFrom = restaurantViewModel.Restaurant.OperationHrsFrom;
                restaurant.OperationHrsTo = restaurantViewModel.Restaurant.OperationHrsTo;
                restaurant.RestaurantId = Guid.NewGuid();
                restaurant.Service = restaurantViewModel.Restaurant.Service;
                restaurant.State = restaurantViewModel.Restaurant.State;
                restaurant.Tax = restaurantViewModel.Restaurant.Tax;
                restaurant.ZipCode = restaurantViewModel.Restaurant.ZipCode;
                _repositoryRestaurant.Add(restaurant);                

                return Content("OK");
            }
            else
            {
                ModelState.AddModelError("", "Please fix error(s) first in order to continue.");
                restaurantViewModel.USStates = USStates.StateSelectList;
                restaurantViewModel.Currencies = Currencies.StateSelectList;
                ViewBag.Status = "Get";
                return PartialView("_GetRestaurantPartialView", restaurantViewModel);
            }
        }

        //
        // GET: /Add Restaurant/

        public ActionResult AddRestaurant()
        {
            GetRestaurantViewModel restaurantViewModel = new GetRestaurantViewModel();
            restaurantViewModel.Restaurant = new Restaurant();
            restaurantViewModel.USStates = USStates.StateSelectList;
            restaurantViewModel.Currencies = Currencies.StateSelectList;
            ViewBag.Status = "Add";
            return PartialView("_AddRestaurantPartialView", restaurantViewModel);
        }

        //
        // POST: /Add Restaurant/

        [HttpPost]
        public ActionResult AddRestaurant(GetRestaurantViewModel restaurantViewModel)
        {           
            if (ModelState.IsValid)
            {
                Restaurant restaurant = new Restaurant();
                restaurant.Address = restaurantViewModel.Restaurant.Address;
                restaurant.City = restaurantViewModel.Restaurant.City;
                restaurant.Currency = restaurantViewModel.Restaurant.Currency;
                restaurant.Description = restaurantViewModel.Restaurant.Description;
                restaurant.IsTest = restaurantViewModel.Restaurant.IsTest;
                restaurant.Latitude = restaurantViewModel.Restaurant.Latitude;
                restaurant.Longitude = restaurantViewModel.Restaurant.Longitude;
                restaurant.Name = restaurantViewModel.Restaurant.Name;
                restaurant.OperationHrsFrom = restaurantViewModel.Restaurant.OperationHrsFrom;
                restaurant.OperationHrsTo = restaurantViewModel.Restaurant.OperationHrsTo;
                restaurant.RestaurantId = Guid.NewGuid();
                restaurant.Service = restaurantViewModel.Restaurant.Service;
                restaurant.State = restaurantViewModel.Restaurant.State;
                restaurant.Tax = restaurantViewModel.Restaurant.Tax;
                restaurant.ZipCode = restaurantViewModel.Restaurant.ZipCode;
                _repositoryRestaurant.Add(restaurant);

                //return RedirectToAction("Index");            

                return Content("OK");
            }
            else
            {
                ModelState.AddModelError("", "Please fix error(s) first in order to continue.");
                restaurantViewModel.USStates = USStates.StateSelectList;
                restaurantViewModel.Currencies = Currencies.StateSelectList;
                ViewBag.Status = "Add";
                return PartialView("_AddRestaurantPartialView", restaurantViewModel);
            }
        }

        // -------------------------------------------------------------------------------------------------------------------------

        //
        // GET: /Restaurant/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Restaurant/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Restaurant/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Restaurant/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Restaurant/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Restaurant/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Restaurant/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
