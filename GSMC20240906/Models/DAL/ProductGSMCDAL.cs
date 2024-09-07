using GSMC20240906.Models.EN;
using Microsoft.EntityFrameworkCore;

namespace GSMC20240906.Models.DAL
{
    public class ProductGSMCDAL
    {
        readonly GSMCCRMContext _context;

        public ProductGSMCDAL(GSMCCRMContext context)
        {
            _context = context;
        }

        public async Task<int> Create(ProductGSMC product)
        {
            _context.Add(product);
            return await _context.SaveChangesAsync();
        }

        public async Task<ProductGSMC> GetById(int id)
        {
            var product = await _context.ProductsGSMC.FirstOrDefaultAsync(p => p.Id == id);
            return product != null ? product : new ProductGSMC();
        }

        public async Task<int> Edit(ProductGSMC product)
        {
            int result = 0;
            var productUpdate = await GetById(product.Id);
            if (productUpdate.Id != 0)
            {
                
                productUpdate.NombreGSMC = product.NombreGSMC;
                productUpdate.DescripcionGSMC = product.DescripcionGSMC;
                productUpdate.PrecioGSMC = product.PrecioGSMC;
                result = await _context.SaveChangesAsync();
            }
            return result;
        }

        public async Task<int> Delete(int id)
        {
            int result = 0;
            var productDelete = await GetById(id);
            if (productDelete.Id > 0)
            {
                _context.ProductsGSMC.Remove(productDelete);
                result = await _context.SaveChangesAsync();
            }
            return result;
        }

        private IQueryable<ProductGSMC> Query(ProductGSMC product)
        {
            var query = _context.ProductsGSMC.AsQueryable();

            if (!string.IsNullOrWhiteSpace(product.NombreGSMC))
            {
                var searchTerm = product.NombreGSMC.ToLower();
                query = query.Where(p => p.NombreGSMC.ToLower().Contains(searchTerm));
            }

            return query;
        }

        public async Task<int> CountSearch(ProductGSMC product)
        {
            return await Query(product).CountAsync();
        }

        public async Task<List<ProductGSMC>> Search(ProductGSMC product, int take = 10, int skip = 0)
        {
            take = take > 10 ? 10 : take;
            var query = Query(product);
            query = query.OrderByDescending(p => p.Id).Skip(skip).Take(take);
            return await query.ToListAsync();
        }
    }
}
