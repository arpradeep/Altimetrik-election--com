using Altimetrik_election__com.Models;
using Microsoft.AspNetCore.Mvc;

namespace Altimetrik_election__com.Controllers
{
    public class VotingsystemController : Controller
    {
        public Votingsystemdata PartyNameDatas = new Votingsystemdata();
        private readonly ILogger<VotingsystemController> _logger;
        public MPSeatsData mPSeatsData = new MPSeatsData();
        public VotingsystemController(ILogger<VotingsystemController> logger)
        {
            _logger = logger;
        }
        public ActionResult Index()
        {
            return View(PartyNameDatas.VotingsystempList());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(VotingsystemModel VotersModels)
        {

            string status = PartyNameDatas.VotingsystemInserts(VotersModels);
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
