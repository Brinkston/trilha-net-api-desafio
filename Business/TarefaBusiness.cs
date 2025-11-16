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
}
