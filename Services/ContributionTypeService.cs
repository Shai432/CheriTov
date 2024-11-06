using ChariTov.DataBaseContext;
using ChariTov.Models;
using Microsoft.EntityFrameworkCore;

namespace ChariTov.Services
{
    public interface IContributionTypeService
    {
        Task AddContributionType(ContributionType contributionType);
        Task<bool> RemoveContributionType(int id);
        Task<ContributionType> GetContributionTypeById(int id);
        Task<ContributionType> GetContributionTypeByName(string name);
    }
    public class ContributionTypeService : IContributionTypeService
    {
        private readonly AppDbContext _context;
        public ContributionTypeService(AppDbContext context) 
        { 
            _context = context;
        }
        public async Task AddContributionType(ContributionType contributionType)
        {

            await _context.ContributionTypes.AddAsync(contributionType);
            await _context.SaveChangesAsync();
        }

        public async Task<ContributionType> GetContributionTypeById(int id) => await _context.ContributionTypes.FindAsync(id);

        public async Task<ContributionType> GetContributionTypeByName(string name) => await _context.ContributionTypes?.SingleOrDefaultAsync(c => c.Name == name);

        public async Task<bool> RemoveContributionType(int id)
        {
            var contributionType = await _context.ContributionTypes.FindAsync(id);
            if (contributionType == null)
            {
                return false;
            }
            _context.ContributionTypes.Remove(contributionType);
            _context.SaveChanges();

            return true;
        }
    }
}
