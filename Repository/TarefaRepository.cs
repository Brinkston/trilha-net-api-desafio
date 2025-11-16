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

    public Tarefa Update(int id, Tarefa tarefa)
    {
        var existing = _dataset.FirstOrDefault(t => t.Id == id);

        if (existing == null) return null;

        existing.Titulo = tarefa.Titulo;
        existing.Descricao = tarefa.Descricao;
        existing.Data = tarefa.Data;
        existing.Status = tarefa.Status;

        _context.SaveChanges();

        return existing;
    }

    public List<Tarefa> FindByTitulo(string titulo)
    {
        return _dataset.Where(t => t.Titulo.Contains(titulo)).ToList();
    }

    public List<Tarefa> FindByData(DateTime data)
    {
        return _dataset.Where(t => t.Data.Date == data.Date).ToList();
    }

    public List<Tarefa> FindByStatus(EnumStatusTarefa status)
    {
        return _dataset.Where(t => t.Status == status).ToList();
    }
}
