using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AarhusWebDevClub.ViewModels;
using Umbraco.Web.Mvc;
using Umbraco.Core.Models;

namespace AarhusWebDevClub.Controllers
{
    public class ContactFormSurfaceController : SurfaceController
    {
        // GET: ContactFormSurface
        public ActionResult Index()
        {
            return PartialView("ContactForm", new ContactForm());
        }
        [HttpPost]
        public ActionResult HandleFormSubmit(ContactForm model)
        {
          

            if (!ModelState.IsValid)
            return CurrentUmbracoPage();
            TempData["success"] = true;

            IContent comment = Services.ContentService.Create(model.Subject, CurrentPage.Id, "comment");
            comment.SetValue("username", model.Name);
            comment.SetValue("email", model.Email);
            comment.SetValue("subject", model.Subject);
            comment.SetValue("message", model.Message);
            Services.ContentService.Save(comment);

            return RedirectToCurrentUmbracoPage();



        }
    }  
}
