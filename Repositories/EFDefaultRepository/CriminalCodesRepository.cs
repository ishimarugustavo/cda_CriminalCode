using CriminalCode.API.Models;
using CriminalCode.API.Repositories.EFDefaultRepository;

namespace CriminalCode.API.Repositories
{
    public class CriminalCodesRepository : EfDefaultRepository<CriminalCodes, CriminalCodeContext>
    {
        public CriminalCodesRepository(CriminalCodeContext context) : base(context)
        {
            
        }
    }
}