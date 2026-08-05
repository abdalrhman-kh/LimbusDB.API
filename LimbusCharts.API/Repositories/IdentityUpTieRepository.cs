using LimbusCharts.API.Data;
using LimbusCharts.API.Models.Domain;
using LimbusCharts.API.Repositories.IRepository;
using Microsoft.EntityFrameworkCore;

namespace LimbusCharts.API.Repositories
{
    public class IdentityUpTieRepository: IIdentityUptieRepository
    {
        private readonly DataDbContext context;

        public IdentityUpTieRepository(DataDbContext context)
        {
            this.context = context;
        }
        public async Task<IdentityUpTie> CreateAsync(IdentityUpTie identityUpTie)
        {
            var upTie = await context.UpTie.FirstOrDefaultAsync(x => x.UpTieId == identityUpTie.UpTieId);

            if(upTie !=  null)
                identityUpTie.UpTie = upTie;

            await context.AddAsync(identityUpTie);
            await context.SaveChangesAsync();
            return identityUpTie;
        }

        public async Task<IdentityUpTie?> DeleteAsync(IdentityUpTie identityUpTie)
        {
            context.Remove(identityUpTie);
            await context.SaveChangesAsync();
            return identityUpTie;
        }

        public async Task<List<IdentityUpTie>> GetAllAsync()
        {
            return await context.IdentityUpTie.ToListAsync();
        }

        public async Task<IdentityUpTie?> GetByIdAsync(Guid id)
        {
            return await context.IdentityUpTie.FirstOrDefaultAsync(x => x.IdentityUpTieId == id);
        }

        public async Task<IdentityUpTie?> UpdateAsync(Guid id, IdentityUpTie identityUpTie)
        {
            var oldIdentityUpTie = await GetByIdAsync(id);

            if (oldIdentityUpTie == null)
                return null;

            var uptie = await context.UpTie.FirstOrDefaultAsync(x => x.UpTieId == identityUpTie.UpTieId);

            if (uptie != null)
                oldIdentityUpTie.UpTie = uptie;

            oldIdentityUpTie.MinSpeed = identityUpTie.MinSpeed;
            oldIdentityUpTie.MaxSpeed = identityUpTie.MaxSpeed;

            await context.SaveChangesAsync();
            return oldIdentityUpTie;
        }
    }
}
