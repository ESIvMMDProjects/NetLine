using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace NetLine.Infrastructure.Context
{
    public class NetLineDbContext : IdentityDbContext
    {
        public NetLineDbContext(DbContextOptions<NetLineDbContext> options)
            : base(options)
        {
        }
    }
}
