using APi.Context;
using APi.Models;

namespace APi.Repositories.Data
{
    public class AccountRoleRepository : GeneralRepository<int, AccountRole>
    {
        private readonly MyContext context;

        public AccountRoleRepository(MyContext context) : base(context)
        {
            this.context = context;
        }
    }
}
