using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using GSMC20240906.Models.EN;

namespace GSMC20240906.Models.DAL
{
    public class GSMCCRMContext : DbContext
    {
        public GSMCCRMContext(DbContextOptions<GSMCCRMContext> options) : base(options) { }

        public DbSet<ProductGSMC> ProductsGSMC { get; set; }
    }
}
