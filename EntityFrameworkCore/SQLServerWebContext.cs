using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class SQLServerWebContext : WebContext<SQLServerWebContext>
    {
        public SQLServerWebContext(DbContextOptions<SQLServerWebContext> options) : base(options) { }
    }
}