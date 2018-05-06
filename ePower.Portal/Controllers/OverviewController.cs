using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using ePower.Data;
using ePower.Identity.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using ePower.Data.Repositories;
using ePower.Portal.ViewModels;

namespace ePower.Portal.Controllers
{
    public class OverviewController : Controller
    {
        private IOrganizationInformationRepository organizationInformationRepository;

        public OverviewController()
        {
            this.organizationInformationRepository = new OrganizationInformationRepository(new PortalDbContext());
        }

        public OverviewController(IOrganizationInformationRepository organizationInformationRepository)
        {
            this.organizationInformationRepository = organizationInformationRepository;
        }

        // GET: Overview
        public ActionResult Index()
        {
            ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());

            var viewModel = new OverviewViewModel()
            {
                Organizations = organizationInformationRepository.GetOrganizationInformationByUserId(Guid.Parse(user.Id)),
                User = user,
            };

            return View(viewModel);
        }
    }
}