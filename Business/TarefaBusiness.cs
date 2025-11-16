using TrilhaApiDesafio.Models;
using TrilhaApiDesafio.Repository;

namespace TrilhaApiDesafio.Business;

public class TarefaBusiness : ITarefaBusiness
{

    private readonly ITarefaRepository _tarefaRepository;


    public TarefaBusiness(ITarefaRepository tarefaRepository)
    {
        _tarefaRepository = tarefaRepository;
    }

    public List<Tarefa> FindAll()
    {
        return _tarefaRepository.FindAll();
    }

    public Tarefa FindById(int id)
    {
        return _tarefaRepository.FindById(id);
    }

    public List<Tarefa> FindByTitulo(string titulo)
    {
        return _tarefaRepository.FindByTitulo(titulo);
    }

    public List<Tarefa> FindByData(DateTime data)
    {
        return _tarefaRepository.FindByData(data);
    }

    public List<Tarefa> FindByStatus(EnumStatusTarefa status)
    {
        return _tarefaRepository.FindByStatus(status);
    }

    public Tarefa Create(Tarefa tarefa)
    {
        return _tarefaRepository.Create(tarefa);
    }

    public Tarefa Update(int id, Tarefa tarefa)
    {
        return _tarefaRepository.Update(id, tarefa);
    }

    public void Delete(int id)
    {
        _tarefaRepository.Delete(id);
    }
}
