using Ramon_Lopez_AP1_P2.Dal;
using Ramon_Lopez_AP1_P2.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Ramon_Lopez_AP1_P2.Services;

public class EntradasService(IDbContextFactory<Contexto> DbContext)
{
    public async Task<bool> Existe(int EntradaId)
    {
        await using var contexto = await DbContext.CreateDbContextAsync();
        return await contexto.Entradas.AnyAsync(e => e.EntradaId == EntradaId);
    }

    public async Task<bool> Insertar(Entradas entrada)
    {
        await using var contexto = await DbContext.CreateDbContextAsync();
        contexto.Entradas.Add(entrada);

        if (entrada.EntradasDetalle != null)
        {
            foreach (var detalle in entrada.EntradasDetalle)
            {
                detalle.EntradaId = entrada.EntradaId;
                contexto.EntradasDetalle.Add(detalle);
            }
        }
        return await contexto.SaveChangesAsync() > 0;
    }

    public async Task<bool> Modificar(Entradas entrada)
    {
        await using var contexto = await DbContext.CreateDbContextAsync();

        contexto.Entradas.Update(entrada);

        if (entrada.EntradasDetalle != null)
        {
            foreach (var detalle in entrada.EntradasDetalle)
            {
                var detalleExistente = await contexto.EntradasDetalle
                    .FirstOrDefaultAsync(d => d.EntradasDetalleId == detalle.EntradasDetalleId && d.EntradaId == entrada.EntradaId);

                if (detalleExistente != null)
                {
                    detalleExistente.ProductoId = detalle.ProductoId;
                    detalleExistente.Cantidad = detalle.Cantidad;
                    detalleExistente.Productos = detalle.Productos;

                    contexto.EntradasDetalle.Update(detalleExistente);
                }
                else
                {
                    detalle.EntradaId = entrada.EntradaId;
                    contexto.EntradasDetalle.Add(detalle);
                }
            }
        }

        return await contexto.SaveChangesAsync() > 0;
    }

    public async Task<bool> Guardar(Entradas entrada)
    {
        if (!await Existe(entrada.EntradaId))
        {
            return await Insertar(entrada);
        }
        else
        {
            return await Modificar(entrada);
        }
    }

    public async Task<Entradas?> Buscar(int EntradaId)
    {
        await using var contexto = await DbContext.CreateDbContextAsync();
        return await contexto.Entradas
            .Include(e => e.EntradasDetalle)
                .ThenInclude(d => d.Productos)
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.EntradaId == EntradaId);
    }

    public async Task<bool> Eliminar(int EntradaId)
    {
        await using var contexto = await DbContext.CreateDbContextAsync();
        return await contexto.Entradas
            .Where(e => e.EntradaId == EntradaId)
            .ExecuteDeleteAsync() > 0;
    }

    public async Task<List<Entradas>> Listar(Expression<Func<Entradas, bool>> criterio)
    {
        await using var contexto = await DbContext.CreateDbContextAsync();
        return await contexto.Entradas
            .Include(e => e.EntradasDetalle)
                .ThenInclude(d => d.Productos)
            .Where(criterio)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<List<Productos>> ListarProductos()
    {
        await using var contexto = await DbContext.CreateDbContextAsync();
        return await contexto.Productos
            .AsNoTracking()
            .ToListAsync();
    }
}