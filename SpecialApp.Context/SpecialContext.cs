using Microsoft.EntityFrameworkCore;
using System;

namespace SpecialApp.Context
{
    public class SpecialContext : DbContext
    {
        public SpecialContext(DbContextOptions options) : base(options)
        {

        }
    }
}
