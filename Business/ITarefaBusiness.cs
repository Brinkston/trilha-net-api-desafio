using TrilhaApiDesafio.Models;

namespace TrilhaApiDesafio.Business;

public interface ITarefaBusiness
{
    List<Tarefa> FindAll();
    Tarefa FindById(int id);
    List<Tarefa> FindByTitulo(string titulo);
    List<Tarefa> FindByData(DateTime data);
    List<Tarefa> FindByStatus(EnumStatusTarefa status);
    Tarefa Create(Tarefa tarefa);
    Tarefa Update(int id, Tarefa tarefa);
    void Delete(int id);
}
