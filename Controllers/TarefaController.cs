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
    [ProducesResponseType(typeof(Tarefa), 200)]
    [ProducesResponseType(404)]
    public IActionResult ObterPorId(int id)
    {
        var tarefa = _business.FindById(id);
        if (tarefa == null)
            return NotFound();
        
        return Ok(tarefa);
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
    [ProducesResponseType(typeof(List<Tarefa>), 200)]
    public IActionResult ObterPorTitulo(string titulo)
    {
        var tarefas = _business.FindByTitulo(titulo);
        return Ok(tarefas);
    }

    [HttpGet("ObterPorData")]
    [ProducesResponseType(typeof(List<Tarefa>), 200)]
    public IActionResult ObterPorData(DateTime data)
    {
        var tarefas = _business.FindByData(data);
        return Ok(tarefas);
    }

    [HttpGet("ObterPorStatus")]
    [ProducesResponseType(typeof(List<Tarefa>), 200)]
    public IActionResult ObterPorStatus(EnumStatusTarefa status)
    {
        var tarefas = _business.FindByStatus(status);
        return Ok(tarefas);
    }

    [HttpPost]
    [ProducesResponseType(typeof(Tarefa), 201)]
    [ProducesResponseType(400)]
    public IActionResult Criar(Tarefa tarefa)
    {
        if (tarefa.Data == DateTime.MinValue)
            return BadRequest(new { Erro = "A data da tarefa não pode ser vazia" });

        var tarefaCriada = _business.Create(tarefa);
        return CreatedAtAction(nameof(ObterPorId), new { id = tarefaCriada.Id }, tarefaCriada);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(typeof(Tarefa), 200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    public IActionResult Atualizar(int id, Tarefa tarefa)
    {
        var tarefaBanco = _business.FindById(id);

        if (tarefaBanco == null)
            return NotFound();

        if (tarefa.Data == DateTime.MinValue)
            return BadRequest(new { Erro = "A data da tarefa não pode ser vazia" });

        var tarefaAtualizada = _business.Update(id, tarefa);
        return Ok(tarefaAtualizada);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public IActionResult Deletar(int id)
    {
        var tarefaBanco = _business.FindById(id);

        if (tarefaBanco == null)
            return NotFound();

        _business.Delete(id);
        return NoContent();
    }
}
