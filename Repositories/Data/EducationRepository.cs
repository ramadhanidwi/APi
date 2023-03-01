using APi.Context;
using APi.Models;

namespace APi.Repositories.Data
{
    public class EducationRepository : GeneralRepository<int, Education>
    {
        private readonly MyContext context;

        public EducationRepository(MyContext context) : base(context)
        {
            this.context = context;
        }
    }
}
