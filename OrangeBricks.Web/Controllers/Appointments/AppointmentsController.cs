using System.Web.Mvc;
using OrangeBricks.Web.Attributes;
using OrangeBricks.Web.Models;
using OrangeBricks.Web.Controllers.Appointments.Builders;

namespace OrangeBricks.Web.Controllers.Appointments
{
    [OrangeBricksAuthorize(Roles = "Seller")]
    public class AppointmentsController : Controller
    {
        private readonly IOrangeBricksContext _context;

        public AppointmentsController(IOrangeBricksContext context)
        {
            _context = context;
        }

        public ActionResult OnProperty(int id)
        {
            var builder = new AppointmentsOnPropertyViewModelBuilder(_context);
            var viewModel = builder.Build(id);

            return View(viewModel);
        }
    }
}