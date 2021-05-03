using CriminalCode.API.Models;
using CriminalCode.API.Repositories.EFDefaultRepository;

namespace CriminalCode.API.Repositories
{
    public class StatusRepository : EfDefaultRepository<Status, CriminalCodeContext>
    {
        public StatusRepository(CriminalCodeContext context) : base(context)
        {

        }
    }
}