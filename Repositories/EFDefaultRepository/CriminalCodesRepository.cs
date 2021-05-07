using System;
using System.Linq;
using System.Collections.Generic;
using CriminalCode.API.Models;
using CriminalCode.API.Repositories.EFDefaultRepository;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CriminalCode.API.Repositories
{
    public class CriminalCodesRepository : EfDefaultRepository<CriminalCodes, CriminalCodeContext>
    {
        private readonly CriminalCodeContext context;
        public CriminalCodesRepository(CriminalCodeContext context) : base(context)
        {
            this.context = context;   
        }

        public async Task<CriminalCodes> AddCriminalCode(CriminalCodes entity) {
            var status = await context.Set<Status>().FindAsync(entity.Status.Id);
            if (status != null) {
                entity.Status = status;
                entity.CreateDate = DateTime.Now;
                entity.UpdateDate = DateTime.Now;
            }
            context.Set<CriminalCodes>().Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public override async Task<CriminalCodes> Get(int id) {
           return await context.CriminalCodes.Where(c => c.Id == id).Include(s => s.Status).SingleAsync();
        }

        public override async Task<List<CriminalCodes>> GetAll() {
            return await context.CriminalCodes.Include(s => s.Status).ToListAsync();
        }
    }
}