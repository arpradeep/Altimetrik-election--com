using Altimetrik_election__com.Models;
using Microsoft.AspNetCore.Mvc;

namespace Altimetrik_election__com.Controllers
{
    public class PartyNameController : Controller
    {
        public PartyNameData PartyNameDatas = new PartyNameData();
        private readonly ILogger<PartyNameController> _logger;
        public MPSeatsData mPSeatsData = new MPSeatsData();
        public PartyNameController(ILogger<PartyNameController> logger)
        {
            _logger = logger;
        }

        public ActionResult Index()
        {
            return View(PartyNameDatas.ElectionpartyList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(PartyNameModel PartyNameModels)
        {

            string status = PartyNameDatas.ElectionpartyInserts(PartyNameModels);
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
