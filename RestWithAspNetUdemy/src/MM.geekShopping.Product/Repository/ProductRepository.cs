using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MM.geekShopping.Product.WebApi.Data.ValueObjects;
using MM.geekShopping.Product.WebApi.Repository;
using MM.GeekShopping.Product.WebApi.Model.Context;
using product = MM.GeekShopping.Model.Product.WebApi.Model;

namespace MM.GeekShopping.Product.WebApi.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly BdMySqlContext _context;
        private IMapper _mapper;

        public ProductRepository(BdMySqlContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductVO>> FindAll()
        {
            List<product.Product> products = await _context.Products.ToListAsync();
            return _mapper.Map<List<ProductVO>>(products);
        }

        public async Task<ProductVO> FindById(long id)
        {
            product.Product product =
                await _context.Products.Where(p => p.Id == id)
                .FirstOrDefaultAsync();
            return _mapper.Map<ProductVO>(product);
        }

        public async Task<ProductVO> Create(ProductVO vo)
        {
            product.Product product = _mapper.Map<product.Product>(vo);
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return _mapper.Map<ProductVO>(product);
        }
        public async Task<ProductVO> Update(ProductVO vo)
        {
            product.Product product = _mapper.Map<product.Product>(vo);
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
            return _mapper.Map<ProductVO>(product);
        }

        public async Task<bool> Delete(long id)
        {
            try
            {
                product.Product product =
                await _context.Products.Where(p => p.Id == id)
                    .FirstOrDefaultAsync();
                if (product == null) return false;
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
