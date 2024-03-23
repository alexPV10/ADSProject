using ADSProject.Interfaces;
using ADSProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace ADSProject.Controllers
{
    [Route("api/carreras/")]
    public class CarreraController : ControllerBase
    {
        private readonly ICarrera carrera;
        private const string COD_EXITO = "0000";
        private const string COD_ERROR = "1111";
        private string respuesta;
        private string msjUsuario;
        private string msjTecnico;

        public CarreraController(ICarrera carrera)
        {
            this.carrera = carrera;
        }


        [HttpPost("agregarCarrera")]
        public ActionResult<string> AgregarCarrera([FromBody] Carrera carrera)
        {
            try
            {
                int contador = this.carrera.AgregarCarrera(carrera);

                if(contador > 0)
                {
                    respuesta = COD_EXITO;
                    msjUsuario = "Registro agregado";
                    msjTecnico = respuesta + " || " + msjUsuario;
                }
                else
                {
                    respuesta = COD_ERROR;
                    msjUsuario = "Ha ocurrido un error *-*";
                    msjTecnico = respuesta + " || " + msjUsuario;
                }

                return Ok( new {respuesta, msjUsuario, msjTecnico});

            }
            catch (Exception)
            {
                throw;
            }
        }


        [HttpPost("actualizarCarrera/{id}")]
        public ActionResult<string> ActualizarCarrera(int id, [FromBody] Carrera carrera)
        {
            try
            {
                int contador = this.carrera.ActualizarCarrera(id, carrera);

                if (contador > 0)
                {
                    respuesta = COD_EXITO;
                    msjUsuario = "Actualizacion hecha";
                    msjTecnico = respuesta + " || " + msjUsuario;
                }
                else
                {
                    respuesta = COD_ERROR;
                    msjUsuario = "Ha ocurrido un error al actualizar *-*";
                    msjTecnico = respuesta + " || " + msjUsuario;
                }

                return Ok(new { respuesta, msjUsuario, msjTecnico });

            }
            catch (Exception)
            {
                throw;
            }
        }


        [HttpDelete("eliminarCarrera/{id}")]
        public ActionResult<string> EliminarCarrera(int id)
        {
            try
            {
                bool eliminado = this.carrera.EliminarCarrera(id);

                if (eliminado)
                {
                    respuesta = COD_EXITO;
                    msjUsuario = "Registro eliminado";
                    msjTecnico = respuesta + " || " + msjUsuario;
                }
                else
                {
                    respuesta = COD_ERROR;
                    msjUsuario = "Ha ocurrido un error *-*";
                    msjTecnico = respuesta + " || " + msjUsuario;
                }

                return Ok(new { respuesta, msjUsuario, msjTecnico });

            }
            catch (Exception)
            {
                throw;
            }
        }


        [HttpGet("obtenerCarreraPorID/{id}")]
        public ActionResult<Carrera> OptenerCarreraPorID(int id)
        {
            try
            {
                Carrera carrera = this.carrera.ObtenerCarreraPorID(id);

                if (carrera != null)
                {
                    return Ok(carrera);
                }
                else
                {
                    respuesta = COD_ERROR;
                    msjUsuario = "No se han encontrado datos *-*";
                    msjTecnico = respuesta + " || " + msjUsuario;
                }

                return NotFound(new { respuesta, msjUsuario, msjTecnico });

            }
            catch (Exception)
            {
                throw;
            }
        }


        [HttpGet("obtenerCarreras")]
        public ActionResult<List<Carrera>> ObtenerCarrera()
        {
            try
            {
                List<Carrera> lstCarrera = this.carrera.ObtenerTodosLasCarreras();

                return Ok(lstCarrera);

            }
            catch (Exception)
            {
                throw;
            }
        }


    }
}
