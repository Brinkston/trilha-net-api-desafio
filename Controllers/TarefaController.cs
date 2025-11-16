using Microsoft.AspNetCore.Mvc;
using TrilhaApiDesafio.Business;
using TrilhaApiDesafio.Context;
using TrilhaApiDesafio.Models;

namespace TrilhaApiDesafio.Controllers;

[ApiController]
[Route("[controller]")]
public class TarefaController : ControllerBase
{
    private readonly ITarefaBusiness _business;

    public TarefaController(ITarefaBusiness business)
    {
        _business = business;
    }

    [HttpGet("{id}")]
    public IActionResult ObterPorId(int id)
    {
        // TODO: Buscar o Id no banco utilizando o EF
        // TODO: Validar o tipo de retorno. Se não encontrar a tarefa, retornar NotFound,
        // caso contrário retornar OK com a tarefa encontrada
        return Ok();
    }

    [HttpGet("ObterTodos")]
    [ProducesResponseType(typeof(List<Tarefa>),200)]
    public IActionResult ObterTodos()
    {
        var tarefas = _business.FindAll();
        // TODO: Buscar todas as tarefas no banco utilizando o EF
        return Ok(tarefas);
    }

    [HttpGet("ObterPorTitulo")]
    public IActionResult ObterPorTitulo(string titulo)
    {
        // TODO: Buscar  as tarefas no banco utilizando o EF, que contenha o titulo recebido por parâmetro
        // Dica: Usar como exemplo o endpoint ObterPorData
        return Ok();
    }

    [HttpGet("ObterPorData")]
    public IActionResult ObterPorData(DateTime data)
    {
        //var tarefa = _context.Tarefas.Where(x => x.Data.Date == data.Date);
        return Ok();
    }

    [HttpGet("ObterPorStatus")]
    public IActionResult ObterPorStatus(EnumStatusTarefa status)
    {
        // TODO: Buscar  as tarefas no banco utilizando o EF, que contenha o status recebido por parâmetro
        // Dica: Usar como exemplo o endpoint ObterPorData
        //var tarefa = _context.Tarefas.Where(x => x.Status == status);
        return Ok();
    }

    [HttpPost]
    public IActionResult Criar(Tarefa tarefa)
    {
        if (tarefa.Data == DateTime.MinValue)
            return BadRequest(new { Erro = "A data da tarefa não pode ser vazia" });

        // TODO: Adicionar a tarefa recebida no EF e salvar as mudanças (save changes)
        return CreatedAtAction(nameof(ObterPorId), new { id = tarefa.Id }, tarefa);
    }

    [HttpPut("{id}")]
    public IActionResult Atualizar(int id, Tarefa tarefa)
    {
        //var tarefaBanco = _context.Tarefas.Find(id);

        // if (tarefaBanco == null)
        //     return NotFound();

        // if (tarefa.Data == DateTime.MinValue)
        //     return BadRequest(new { Erro = "A data da tarefa não pode ser vazia" });

        // TODO: Atualizar as informações da variável tarefaBanco com a tarefa recebida via parâmetro
        // TODO: Atualizar a variável tarefaBanco no EF e salvar as mudanças (save changes)
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Deletar(int id)
    {
        // var tarefaBanco = _context.Tarefas.Find(id);

        // if (tarefaBanco == null)
        //     return NotFound();

        // TODO: Remover a tarefa encontrada através do EF e salvar as mudanças (save changes)
        return NoContent();
    }
}
