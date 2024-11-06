using ChariTov.DataBaseContext;
using ChariTov.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ChariTov.Services
{
    public interface IContributionService
    {
        Task AddContributionAsync(Contribution contribution);
        Task<Contribution> GetContributionById(int id);
        Task<bool> RemoveContributionAsync(Contribution contribution);
        Task<bool> RemoveContributionAsync(int id);
        Task<bool> UpdateContributionPaymentStatusAsync(int id, bool status);

        Task<IEnumerable<Contribution>> GetAllContributionsByType(int TypeId);

        Task<IEnumerable<Contribution>> GetAllContributionsByStatus(bool status);
    }

    public class ContributionService : IContributionService
    {
        private readonly AppDbContext _context;

        public ContributionService(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddContributionAsync(Contribution contribution)
        {
            await _context.Contributions.AddAsync(contribution);
        }

        public async Task<IEnumerable<Contribution>> GetAllContributionsByStatus(bool status) 
            => await _context.Contributions.Where(c => c.IsPaid == status).ToListAsync();

        public async Task<IEnumerable<Contribution>> GetAllContributionsByType(int TypeId)
            => await _context.Contributions.Where(c => c.ContributionType.Id == TypeId).ToListAsync();

        public async Task<Contribution> GetContributionById(int id) 
            => await _context.Contributions.FindAsync(id);

        public async Task<bool> RemoveContributionAsync(Contribution contribution)
        {
            if (contribution == null)
            {
                return false;
            }

            _context.Contributions.Remove(contribution);
            _context.SaveChanges();

            return true;
        }

        public async Task<bool> RemoveContributionAsync(int id)
        {

            var contribution = await _context.Contributions.FindAsync(id);

            if (contribution == null)
            {
                return false;
            }

            _context.Contributions.Remove(contribution);
            _context.SaveChanges();

            return true;
        }

        public async Task<bool> UpdateContributionPaymentStatusAsync(int id, bool status)
        {
            var contribution = await _context.Contributions.FindAsync(id);

            if (contribution == null)
            {
                return false;
            }

            contribution.IsPaid = status;

            _context.SaveChanges();

            return true;
        }
    }
}
