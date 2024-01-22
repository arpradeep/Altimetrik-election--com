using Altimetrik_election__com.Models;
using Microsoft.AspNetCore.Mvc;

namespace Altimetrik_election__com.Controllers
{
    public class VoterController : Controller
    {
        public VotersData PartyNameDatas = new VotersData();
        private readonly ILogger<VoterController> _logger;
        public MPSeatsData mPSeatsData = new MPSeatsData();
        public VoterController(ILogger<VoterController> logger)
        {
            _logger = logger;
        }
        public ActionResult Index()
        {
            return View(PartyNameDatas.VotersList());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(VotersModel VotersModels)
        {

            string status = PartyNameDatas.VotersInserts(VotersModels);
            ViewBag.Status = status;
            if (status == "")
            {
                ViewBag.Status = status;
            }
            else
            {

                return RedirectToAction("Index", "Voter", new { area = "" });
            }

            return View();
        }
    }
}
