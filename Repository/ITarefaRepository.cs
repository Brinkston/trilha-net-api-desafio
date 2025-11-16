namespace TrilhaApiDesafio.Repository;
using TrilhaApiDesafio.Models;


public interface ITarefaRepository
{
    Tarefa Create(Tarefa tarefa);
    Tarefa Update(Tarefa tarefa);
    Tarefa FindById(int id);
    List<Tarefa> FindAll();
    void Delete(int id);
}
