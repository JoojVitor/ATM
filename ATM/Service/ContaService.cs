﻿using ATM.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ATM.Service
{
    public class ContaService : Controller
    {
        private readonly ContaDbContext _dbContext;

        public ContaService(ContaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async void AtualizaSaldo(int codigo, float valor)
        {
            var conta = Get(codigo);

            if (conta != null)
            {
                conta.Result.Saldo -= valor;
                _dbContext.Update(conta);
                await _dbContext.SaveChangesAsync();
            }
        }

        public ContaDbContext GetDbContext()
        {
            return _dbContext;
        }

        [HttpPost]
        public async void Add(Conta model)
        {
            await _dbContext.AddAsync(model);
            await _dbContext.SaveChangesAsync();
        }

        [HttpGet]
        public async Task<Conta?> Get(int codigo)
        {
            return await _dbContext.Contas
                .FirstOrDefaultAsync(c => c.Codigo == codigo);
        }
    }
}
