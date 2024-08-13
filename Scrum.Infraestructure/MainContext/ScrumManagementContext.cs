using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scrum.Infraestructure.MainContext
{
    public partial class ScrumManagementContext : DbContext

    {
        public ScrumManagementContext(DbContextOptions<ScrumManagementContext> options)
            : base(options)
        {
        }
    }
}
