using APi.Context;
using APi.Models;

namespace APi.Repositories.Data
{
    public class RoleRepository : GeneralRepository<int, Role>
    {
        private readonly MyContext context;

        public RoleRepository(MyContext context) : base(context)
        {
            this.context = context;
        }
    }
}
