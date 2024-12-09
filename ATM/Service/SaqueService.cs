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
        public async Task<IActionResult> ValidarSaque(Saque model)
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

            if (conta != null && conta.Saldo < model.Valor)
            {
                return RedirectToAction("SaldoError", "Home");
            }

            if (conta != null && conta.LimiteDiaSaque <  model.Valor)
            {
                return RedirectToAction("LimiteError", "Home");
            }

            Saque saque = new()
            {
                Cartao = cartao,
                Conta = conta,
                Valor = model.Valor
            };

            Add(saque);

            AtualizaSaldoConta(conta.Codigo, saque.Valor);

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public void AtualizaSaldoConta(int codConta, float valor)
        {
            _contaService.AtualizaSaldo(codConta, valor);
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

        [HttpPost]
        public async void Add(Saque saque)
        {
            await _dbContext.Cartoes.AddAsync(saque.Cartao);
            await _dbContext.Contas.AddAsync(saque.Conta);
            await _dbContext.Saques.AddAsync(saque);
            await _dbContext.SaveChangesAsync();
        }

        [HttpGet]
        public IActionResult GetSaques()
        {
            var saques = _dbContext.Saques
                .Include(s => s.Conta)
                .Include(s => s.Cartao)
                .ToList();
            return View(saques);
        }
    }
}
