using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using System.Net;
using TaskManager.Domain;
using TaskManager.Domain.Dtos;
using TaskManager.Service.Services.Interfaces;

namespace TaskManager.Controllers
{
    public class TaskController : BaseApiController
    {
        private readonly ITaskService _taskServicio;
        private ApiResponse _response;
        public TaskController(ITaskService taskServicio)
        {
            _taskServicio = taskServicio;
            _response = new ApiResponse();
        }
        [HttpGet("{Id:int}")]
        public async Task<IActionResult> Get(int Id)
        {
            try
            {
                _response.Resultado = await _taskServicio.GetTask(Id);
                _response.IsExitoso = true;
                _response.StatusCode = HttpStatusCode.Created;

            }
            catch (Exception ex)
            {
                _response.IsExitoso = false;
                _response.Mensaje = ex.Message;
                _response.StatusCode = HttpStatusCode.BadRequest;
            }
            return Ok(_response);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                _response.Resultado = await _taskServicio.GetTaskAll();
                _response.IsExitoso = true;
                _response.StatusCode = HttpStatusCode.Created;

            }
            catch (Exception ex)
            {
                _response.IsExitoso = false;
                _response.Mensaje = ex.Message;
                _response.StatusCode = HttpStatusCode.BadRequest;
            }
            return Ok(_response);
        }
        [HttpDelete("{Id:int}")]
        public async Task<IActionResult> Delete(int Id)
        {
            try
            {
                await _taskServicio.RemoverTask(Id);
                _response.IsExitoso = true;
                _response.StatusCode = HttpStatusCode.Created;

            }
            catch (Exception ex)
            {
                _response.IsExitoso = false;
                _response.Mensaje = ex.Message;
                _response.StatusCode = HttpStatusCode.BadRequest;
            }
            return Ok(_response);
        }
        [HttpPost]
        public async Task<IActionResult> Crear(DtoTask modeloDto)
        {
            try
            {
                await _taskServicio.AddTask(modeloDto);
                _response.IsExitoso = true;
                _response.StatusCode = HttpStatusCode.Created;

            }
            catch (Exception ex)
            {
                _response.IsExitoso = false;
                _response.Mensaje = ex.Message;
                _response.StatusCode = HttpStatusCode.BadRequest;
            }
            return Ok(_response);
        }
        [HttpPut]
        public async Task<IActionResult> Update(DtoTask modeloDto)
        {
            try
            {
                await _taskServicio.UpdatTask(modeloDto);
                _response.IsExitoso = true;
                _response.StatusCode = HttpStatusCode.Created;

            }
            catch (Exception ex)
            {
                _response.IsExitoso = false;
                _response.Mensaje = ex.Message;
                _response.StatusCode = HttpStatusCode.BadRequest;
            }
            return Ok(_response);
        }
    }
}
