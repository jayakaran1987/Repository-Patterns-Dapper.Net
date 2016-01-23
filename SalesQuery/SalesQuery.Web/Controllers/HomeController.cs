using SalesQuery.Data.Interface;
using SalesQuery.Data.Repository;
using SalesQuery.Model.Entity;
using SalesQuery.Web.Models;
using SalesQuery.Web.Service;
using SalesQuery.Web.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SalesQuery.Web.Controllers
{
    public class HomeController : BaseController
    {
        private ILookupInterface lookupService;
        private IUserRepository userRepository;
        private IPricingQueryRepository pricingOueryRepository;
        private INotificationService notificationService;
        public HomeController()
        {
            // Replace this with IoC 
            // Can Use TinyIoc, Unity, Ninject, Autofac etc
            lookupService = new LookupService();
            userRepository = new UserRepository();
            pricingOueryRepository = new PricingQueryRepository();
            notificationService = new NotificationService();
        }
        public ActionResult Index()
        {
            PopulateLookupList();         
            return View(new PricingQueryViewModel());
        }

        [HttpPost]
        public ActionResult Index(PricingQueryViewModel model)
        {
            //------------Logic---------------------//
            /// if the user is already registered then the system will not add this user again 
            /// but if he already enquired about the same product again but we are adding the pricing query again because of diffrent date
            /// In this existing user changed his address or phone, I just update new details.
            /// 

            // Since not having heavy logic service layer, I didnot try separate the service to service layer.
            // Also used some service for lookup and notification 

            // I didnot added server side validations since we are using in client side
            // If we want to do server side validation then we can use DataAnotations validators in view model
            //if (ModelState.IsValid)
            //{
            //    // Ensure the model state is valid or not
            //}
            // Or we can use FluentValidation for model validations
            //https://fluentvalidation.codeplex.com/
            //-----------------------------------------------

            try
            {
                PopulateLookupList();

                // Check the user is already registerd in the database using email
                var user = userRepository.GetAll().Where(con => con.Email == model.Email).FirstOrDefault();

                if (user != null)
                {
                    //user already exists, update his details in case of address changes and phone number
                    userRepository.Update(UpdateExistingUser(user, model));

                    foreach (var productId in model.SelectedProductIds)
                    {
                        //Add new pricing query for this exixting user with enquiry date.
                        pricingOueryRepository.Add(new PricingQuery() { Id = Guid.NewGuid(), ProductId = productId, UserId = user.Id, EnquiryDate = DateTime.Today, IsReplied = false });
                        //Send Email to sales team
                        notificationService.SendEmailToSalesTeam(user.LastName + "is interested in product");
                        TempData["Message"] = "Thank you for your interest. Sales Team will contact you soon";
                    }
                }
                else
                {
                    // Create new user and add pricing query
                    var newUser = MapToUser(model);
                    var userId = newUser.Id;
                    userRepository.Add(newUser);

                    foreach (var productId in model.SelectedProductIds)
                    {
                        pricingOueryRepository.Add(new PricingQuery() { Id = Guid.NewGuid(), ProductId = productId, UserId = userId, EnquiryDate = DateTime.Today, IsReplied = false});
                    }

                    //Send Email to sales team
                    notificationService.SendEmailToSalesTeam(newUser.LastName + "is interested in product");
                    TempData["Message"] = "Thank you for your interest. Sales Team will contact you soon";
                }
            }
            catch (Exception)
            {
                 // Log your exception message here
                 // Pass the log message to developer
                 // Can use log4net etc
                TempData["Message"] = "Something went wrong. Please try again later";
            }
            ModelState.Clear();
            return View(new PricingQueryViewModel());
        }

        // private methods

        private User UpdateExistingUser(User user, PricingQueryViewModel model)
        {
            if (model.FirstName != "") user.FirstName = model.FirstName;
            if (model.LastName != "") user.LastName = model.LastName;
            if (model.AddressLine1 != "") user.AddressLine1 = model.AddressLine1;
            if (model.City != "") user.City = model.City;
            if (model.PostCode != "") user.PostCode = model.PostCode;
            if (model.Country != "") user.Country = model.Country;
            if (model.Phone != "") user.Phone = model.Phone;

            return user;
        }

        private User MapToUser(PricingQueryViewModel model)
        {
            // We can use Automapper to Map View Model to Model && Model to ViewModel
            // For this assignment, I did not use AutoMapper cosidering time
            return new User()
            {
                Id = Guid.NewGuid(),
                FirstName = model.FirstName,
                LastName = model.LastName,
                AddressLine1 = model.AddressLine1,
                City = model.City,
                Country = model.Country,
                Email = model.Email,
                Phone = model.Phone,
                PostCode = model.PostCode
            };
        }


        private void PopulateLookupList()
        {
            var productList = lookupService.GetProductLookups();
            ViewData["ProductList"] = productList;

            //I did not added country lookup 
            //Just Hardbinding some country
        }
     
    }
}