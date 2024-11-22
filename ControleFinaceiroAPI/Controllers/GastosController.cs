using ControleFinaceiroAPI.Data;
using ControleFinaceiroAPI.DTOs;
using ControleFinaceiroAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleFinaceiroAPI.Controllers;

using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class GastosController : ControllerBase
{
    private readonly AppDbContext _context;

    public GastosController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet("{mesId}")]
    public async Task<IActionResult> GetGastos(int mesId)
    {
        var gastos = await _context.Gastos
            .Where(g => g.MesId == mesId)
            .ToListAsync();

        return Ok(gastos);
    }

    [HttpPost]
    public async Task<IActionResult> AddGasto([FromBody] GastoDto gastoDto)
    {
        var gasto = new Gasto
        {
            Descricao = gastoDto.Descricao,
            Valor = gastoDto.Valor,
            MesId = gastoDto.MesId
        };

        _context.Gastos.Add(gasto);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetGastos), new { mesId = gasto.MesId }, gasto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateGasto(int id, [FromBody] GastoDto gastoDto)
    {
        var gasto = await _context.Gastos.FindAsync(id);
        if (gasto == null)
        {
            return NotFound();
        }

        gasto.Descricao = gastoDto.Descricao;
        gasto.Valor = gastoDto.Valor;
        gasto.MesId = gastoDto.MesId;

        _context.Gastos.Update(gasto);
        await _context.SaveChangesAsync();

        return NoContent(); 
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteGasto(int id)
    {
        var gasto = await _context.Gastos.FindAsync(id);
        if (gasto == null)
        {
            return NotFound();
        }

        _context.Gastos.Remove(gasto);
        await _context.SaveChangesAsync();

        return NoContent(); 
    }
}
