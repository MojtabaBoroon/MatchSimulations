using MatchSimulations.Application.Abstractios;
using MatchSimulations.Domain;
using Microsoft.AspNetCore.Mvc;

namespace MatchSimulations.Presentation.Controllers
{
    public class LeagueController : Controller
    {
        private readonly ILeagueSimulation _leagueSimulation;

        public LeagueController(ILeagueSimulation leagueSimulation)
        {
            _leagueSimulation = leagueSimulation;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var teams = new List<Team>();
            return View(teams);
        }

        [HttpPost]
        public IActionResult Index(ICollection<Team> teams)
        {
            if (!ModelState.IsValid)
            {
                return View(teams);
            }

            List<Team> sortedTeams = _leagueSimulation.SimulateLeague(teams.ToList());

            return View(sortedTeams);
        }
    }
}
