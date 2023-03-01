using APi.Context;
using APi.Models;

namespace APi.Repositories.Data
{
    public class EmployeeRepository : GeneralRepository<string, Employee>
    {
        private readonly MyContext context;

        public EmployeeRepository(MyContext context) : base(context)
        {
            this.context = context;
        }
    }
}
