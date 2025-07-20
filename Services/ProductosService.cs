using Microsoft.EntityFrameworkCore;
using Ramon_Lopez_AP1_P2.Dal;
using Ramon_Lopez_AP1_P2.Models;
using System.Linq.Expressions;

namespace Ramon_Lopez_AP1_P2.Services;

public class ProductosService(IDbContextFactory<Contexto> DbContext)
{
    public async Task<bool> Existe(int productoId)
    {
        await using var contexto = await DbContext.CreateDbContextAsync();
        return await contexto.Productos.
            AnyAsync(p => p.ProductoId == productoId);
    }

    public async Task<bool> Insertar(Productos producto)
    {
        await using var contexto = await DbContext.CreateDbContextAsync();
        contexto.Productos.Add(producto);
        return await contexto.SaveChangesAsync() > 0;
    }

    public async Task<bool> Modificar(Productos producto)
    {
        await using var contexto = await DbContext.CreateDbContextAsync();
        contexto.Productos.Update(producto);
        return await contexto.SaveChangesAsync() > 0;
    }

    public async Task<bool> Guardar(Productos producto)
    {
        if (await Existe(producto.ProductoId))
            return await Modificar(producto);
        else
            return await Insertar(producto);
    }

    public async Task<Productos?> Buscar(int productoId)
    {
        await using var contexto = await DbContext.CreateDbContextAsync();
        return await contexto.Productos
            .FindAsync(productoId);
    }

    public async Task<bool> Eliminar(int productoId)
    {
        await using var contexto = await DbContext.CreateDbContextAsync();
        return await contexto.Productos
            .AsNoTracking()
            .Where(p => p.ProductoId == productoId)
            .ExecuteDeleteAsync() > 0;
    }

    public async Task<List<Productos>> Listar(Expression<Func<Productos, bool>> criterio)
    {
        await using var contexto = await DbContext.CreateDbContextAsync();
        return await contexto.Productos
            .Where(criterio)
            .AsNoTracking()
            .ToListAsync();
    }
}
