namespace TrilhaApiDesafio.Repository;
using TrilhaApiDesafio.Models;


public interface ITarefaRepository
{
    Tarefa Create(Tarefa tarefa);
    Tarefa Update(int id, Tarefa tarefa);
    Tarefa FindById(int id);
    List<Tarefa> FindAll();
    List<Tarefa> FindByTitulo(string titulo);
    List<Tarefa> FindByData(DateTime data);
    List<Tarefa> FindByStatus(EnumStatusTarefa status);
    void Delete(int id);
}
