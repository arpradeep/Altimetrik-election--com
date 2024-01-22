using Microsoft.AspNetCore.Mvc;
using Altimetrik_election__com.Models;
namespace Altimetrik_election__com.Controllers
{

    public class MPSeatsController : Controller
    {
        private readonly ILogger<MPSeatsController> _logger;
        public MPSeatsData mPSeatsData = new MPSeatsData();
        public MPSeatsController(ILogger<MPSeatsController> logger)
        {
            _logger = logger;
        }

        public ActionResult Index()
        {

            return View(mPSeatsData.ElectionRegistrationuserMPList());
        }

       
        public ActionResult Create()
        {
            MPSeatsModel mPSeatsModel = new MPSeatsModel();
            mPSeatsModel.statelist = mPSeatsData.ElectionRegistrationuserstate();
            return View(mPSeatsModel);
        }
        [HttpPost]
        public ActionResult Create(MPSeatsModel MPSeatsModel)
        {

            string status = mPSeatsData.MpSeatInserts(MPSeatsModel);
            ViewBag.Status = status;
            if (status == "")
            {
                ViewBag.Status = status;
            }
            else
            {

                return RedirectToAction("Index", "MPSeats", new { area = "" });
            }

            return View();
        }
        public ActionResult Edit(int id)
        {

            return View(mPSeatsData.ElectionRegistrationuserMPfind(id));
        }
        [HttpPost]
        public ActionResult Edit(MPSeatsModel MPSeatsModel)
        {

            string status = mPSeatsData.MpSeatUpdate(MPSeatsModel);
            ViewBag.Status = status;
            if (status == "")
            {
                ViewBag.Status = status;
            }
            else
            {

                return RedirectToAction("Index", "MPSeats", new { area = "" });
            }

            return View();
        }
    }
}
