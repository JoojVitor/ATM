using ATM.Models;
using ATM.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ATM.Controllers
{
    public class SaqueService : Controller
    {
        private readonly SaqueDbContext _dbContext;
        private readonly CartaoService _cartaoService;
        private readonly ContaService _contaService;

        public SaqueService(SaqueDbContext dbContext, CartaoService cartaoService, ContaService contaService)
        {
            _dbContext = dbContext;
            _cartaoService = cartaoService;
            _contaService = contaService;
        }

        [HttpPost]
        public async Task<IActionResult> Add(Saque model)
        {
            Cartao? cartao = ValidarCartao(model.Cartao).Result;

            if (cartao == null)
            {
                return RedirectToAction("CartaoError", "Home");
            }

            Conta? conta = ValidarSenha(cartao.CodConta).Result;

            if (conta != null && conta.Senha == model.Conta.Senha)
            {
                return RedirectToAction("SenhaError", "Home");
            }

            Saque saque = new()
            {
                Cartao = cartao,
                Conta = conta
            };

            await _dbContext.Saques.AddAsync(saque);
            await _dbContext.SaveChangesAsync();

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public Task<Cartao?> ValidarCartao(Cartao model)
        {
            return _cartaoService.Get(model.Numero, model.DataValidade);
        }

        [HttpGet]
        public Task<Conta?> ValidarSenha(int codConta)
        {
            return _contaService.Get(codConta);
        }
    }
}
