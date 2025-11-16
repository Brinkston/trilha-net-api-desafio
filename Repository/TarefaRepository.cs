using Microsoft.EntityFrameworkCore;
using TrilhaApiDesafio.Context;
using TrilhaApiDesafio.Models;

namespace TrilhaApiDesafio.Repository;

public class TarefaRepository : ITarefaRepository
{
    private readonly OrganizadorContext _context;
    private readonly DbSet<Tarefa> _dataset;

    public TarefaRepository(OrganizadorContext context)
    {
        _context = context;
        _dataset = _context.Tarefas; // DbSet vindo do contexto
    }

    public Tarefa Create(Tarefa tarefa)
    {
        _dataset.Add(tarefa);
        _context.SaveChanges();
        return tarefa;
    }

    public void Delete(int id)
    {
        var tarefa = _dataset.FirstOrDefault(t => t.Id == id);
        if (tarefa == null) return;

        _dataset.Remove(tarefa);
        _context.SaveChanges();
    }

    public List<Tarefa> FindAll()
    {
        try
        {
            return _dataset.ToList();
        }
        catch
        {
            return null;
        }
    }

    public Tarefa FindById(int id)
    {
        return _dataset.FirstOrDefault(t => t.Id == id);
    }

    public Tarefa Update(Tarefa tarefa)
    {
        var existing = _dataset.FirstOrDefault(t => t.Id == tarefa.Id);

        if (existing == null) return null;

        _context.Entry(existing).CurrentValues.SetValues(tarefa);
        _context.SaveChanges();

        return tarefa;
    }
}
