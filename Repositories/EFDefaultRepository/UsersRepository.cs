using System.Linq;
using CriminalCode.API.Models;
using CriminalCode.API.Repositories.EFDefaultRepository;
using System.Threading.Tasks;

namespace CriminalCode.API.Repositories
{
    public class UsersRepository : EfDefaultRepository<User, CriminalCodeContext>
    {
        private readonly CriminalCodeContext context;
        public UsersRepository(CriminalCodeContext context) : base(context)
        {
            this.context = context;
        }

        public User loginUser(User user)
        {
            return context.Users
                        .Where(u => u.UserName == user.UserName &&
                                    u.Password == user.Password)
                        .FirstOrDefault<User>();
        }

        public User findUserByUserName(string userName) {
            return context.Users
                        .Where(u => u.UserName == userName)
                        .FirstOrDefault<User>();
        }
    }
}