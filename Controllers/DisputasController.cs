using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RpgApi.Data;
using RpgApi.Models;

namespace RpgApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DisputasController : ControllerBase
    {
        private readonly DataContext _context;

        public DisputasController(DataContext context)
        {
            _context = context;
        }

        [HttpPost("Arma")]
        public async Task<IActionResult> AtaqueComArmaAsync(Disputa d)
        {
            try
            {
                Personagem? atacante = await _context.TB_PERSONAGENS
                    .Include(p => p.Arma)
                    .FirstOrDefaultAsync(p => p.Id == d.AtacanteId);

                Personagem? oponente = await _context.TB_PERSONAGENS
                    .FirstOrDefaultAsync(p => p.Id == d.OponenteId);

                if (atacante == null || oponente == null)
                    return BadRequest("Personagem não encontrado.");

                if (atacante.Arma == null)
                    return BadRequest("O atacante não possui arma.");

                Random random = new Random();

                int dano = atacante.Arma.Dano + random.Next(atacante.Forca);

                dano -= random.Next(oponente.Defesa);

                if (dano > 0)
                {
                    oponente.PontosVida -= dano;

                    if (oponente.PontosVida <= 0)
                    {
                        d.Narracao = $"{oponente.Nome} foi derrotado.";
                    }
                }
                else
                {
                    d.Narracao = $"{oponente.Nome} defendeu o ataque.";
                }

                _context.TB_PERSONAGENS.Update(oponente);

                StringBuilder dados = new StringBuilder();

                dados.AppendFormat("Atacante: {0}. ", atacante.Nome);
                dados.AppendFormat("Oponente: {0}. ", oponente.Nome);
                dados.AppendFormat("Pontos de vida do atacante: {0}. ", atacante.PontosVida);
                dados.AppendFormat("Pontos de vida do oponente: {0}. ", oponente.PontosVida);
                dados.AppendFormat("Arma utilizada: {0}. ", atacante.Arma.Nome);
                dados.AppendFormat("Dano: {0}. ", dano);

                d.Narracao += dados.ToString();
                d.DataDisputa = DateTime.Now;

                _context.TB_DISPUTAS.Add(d);

                await _context.SaveChangesAsync();

                return Ok(d);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = $"Erro ao processar a disputa: {ex.Message}" });
            }
        }

        [HttpPost("Habilidade")]
        public async Task<IActionResult> AtaqueComHabilidadeAsync(Disputa d)
        {
            try
            {
                Personagem? atacante = await _context.TB_PERSONAGENS
                    .FirstOrDefaultAsync(p => p.Id == d.AtacanteId);

                Personagem? oponente = await _context.TB_PERSONAGENS
                    .FirstOrDefaultAsync(p => p.Id == d.OponenteId);

                if (atacante == null || oponente == null)
                    return BadRequest("Personagem não encontrado.");

                PersonagemHabilidade? ph = await _context.TB_PERSONAGENS_HABILIDADES
                    .Include(ph => ph.Habilidade)
                    .FirstOrDefaultAsync(ph =>
                        ph.PersonagemId == d.AtacanteId &&
                        ph.HabilidadeId == d.HabilidadeId);

                if (ph == null)
                {
                    d.Narracao = $"{atacante.Nome} não possui essa habilidade.";
                }
                else
                {
                    Random random = new Random();

                    int dano = ph.Habilidade.Dano +
                        random.Next(atacante.Inteligencia);

                    dano -= random.Next(oponente.Defesa);

                    if (dano > 0)
                    {
                        oponente.PontosVida -= dano;

                        if (oponente.PontosVida <= 0)
                        {
                            d.Narracao = $"{oponente.Nome} foi derrotado.";
                        }
                    }
                    else
                    {
                        d.Narracao = $"{oponente.Nome} defendeu o ataque.";
                    }

                    _context.TB_PERSONAGENS.Update(oponente);

                    StringBuilder dados = new StringBuilder();

                    dados.AppendFormat("Atacante: {0}. ", atacante.Nome);
                    dados.AppendFormat("Oponente: {0}. ", oponente.Nome);
                    dados.AppendFormat("Pontos de vida do atacante: {0}. ", atacante.PontosVida);
                    dados.AppendFormat("Pontos de vida do oponente: {0}. ", oponente.PontosVida);
                    dados.AppendFormat("Habilidade utilizada: {0}. ", ph.Habilidade.Nome);
                    dados.AppendFormat("Dano: {0}. ", dano);

                    d.Narracao += dados.ToString();
                }

                d.DataDisputa = DateTime.Now;

                _context.TB_DISPUTAS.Add(d);

                await _context.SaveChangesAsync();

                return Ok(d);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = $"Erro ao processar a disputa: {ex.Message}" });
            }
        }
    }
}