using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class StudentsRepository : GenericRepository<Students>, IStudentsRepository
    {
        public StudentsRepository( ApplicationDbContext context) : base(context)
        {
        }
    }
}
