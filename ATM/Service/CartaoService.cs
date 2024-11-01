using ATM.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ATM.Service
{
    public class CartaoService : Controller
    {
        private readonly CartaoDbContext _dbContext;

        public CartaoService(CartaoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public CartaoDbContext GetDbContext()
        {
            return _dbContext;
        }

        [HttpPost]
        public async void Add(Cartao model)
        {
            await _dbContext.Cartoes.AddAsync(model);
            await _dbContext.SaveChangesAsync();
        }

        [HttpGet]
        public async Task<Cartao?> Get(int numero, DateOnly data)
        {
            return await _dbContext.Cartoes
                .FirstOrDefaultAsync(c => c.Numero == numero && c.DataValidade == data);
        }

    }
}
