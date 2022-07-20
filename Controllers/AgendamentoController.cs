using Consultorio.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Consultorio.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AgendamentoController : ControllerBase
    {
        public List<Agendamento> Agendamentos = new();

        public AgendamentoController()
        {
            Agendamentos.Add(new Agendamento
            {
                Id = 1,
                NomePaciente = "Mario Leston Rey",
                Horario = new DateTime(2022, 07, 20)
            });
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Agendamentos);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            Agendamento agendamento = Agendamentos.FirstOrDefault(x => x.Id == id);

            if (agendamento is null)
                return BadRequest("Agendamento não encontrado!");

            return Ok(agendamento);
        }
    }
}
