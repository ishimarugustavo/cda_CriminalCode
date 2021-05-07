using System.Linq;
using CriminalCode.API.Models;
using CriminalCode.API.Repositories.EFDefaultRepository;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CriminalCode.API.Repositories
{
    public class UsersRepository : EfDefaultRepository<User, CriminalCodeContext>
    {
        private readonly CriminalCodeContext context;
        public UsersRepository(CriminalCodeContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<User> loginUser(User user)
        {
            return await context.Users
                        .Where(u => u.UserName == user.UserName &&
                                    u.Password == user.Password)
                        .SingleAsync();
        }

        public async Task<User> findUserByUserName(string userName) {
            return await context.Users
                        .Where(u => u.UserName == userName)
                        .SingleAsync();
        }
    }
}