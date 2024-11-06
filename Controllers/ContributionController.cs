using ChariTov.Services;
using Microsoft.AspNetCore.Mvc;

namespace ChariTov.Controllers
{
    public class ContributionController : ControllerBase
    {
        private readonly IContributionService _contributionService;
        public ContributionController(IContributionService contributionService) 
        {
            _contributionService = contributionService;
        }
    }
}
