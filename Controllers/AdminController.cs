using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ChariTov.DataModels;
using ChariTov.Models;
using ChariTov.Services;


[ApiController]
[Authorize(Roles = nameof(Role.Admin))]
[Route("api/[controller]")]
public class AdminController(IContributionService contributionService, IContributionTypeService contributionTypeService) : ControllerBase
{
    private readonly IContributionService _contributionService = contributionService;
    private readonly IContributionTypeService _contributionTypeService = contributionTypeService;

    [HttpPost("add-contribution")]
    public async Task<IActionResult> AddConribution([FromBody] Contribution model)
    {
        // Logic for adding a restaurant
        return Ok("Restaurant added successfully.");
    }

    [HttpPut("update-contribution")]  
    public async Task<IActionResult> UpdateConribution([FromBody] Contribution model)
    {
        // Logic for adding a restaurant
        return Ok("Restaurant added successfully.");
    }

    [HttpPost("add-contribution-type")]
    public async Task<IActionResult> AddContributionType([FromBody] ContributionTypeDto contributionType)
    {
        var _contributionType = await _contributionTypeService.GetContributionTypeByName(contributionType.Name);
        if (_contributionType != null)
        {
            return Ok(new {message ="Contribution type already exists", ContributionType = contributionType });
        }

        await _contributionTypeService.AddContributionType(contributionType);
        return CreatedAtAction();
    }

    [HttpGet("get-unpaid-contributions")]
    public async Task<IActionResult> GetAllUnpaidContributions()
    {
        var unpaidContributions = await _contributionService.GetAllContributionsByStatus(false);
        if (!unpaidContributions.Any())
        {
            return NotFound();
        }

        return Ok(unpaidContributions);
    }


}