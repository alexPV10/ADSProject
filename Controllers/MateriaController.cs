using ADSProject.Interfaces;
using ADSProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace ADSProject.Controllers
{
    [Route("api/materias/")]
    public class MateriaController : Controller
    {
        private readonly IMateria materia;
        private const string COD_EXITO = "0000";
        private const string COD_ERROR = "1111";
        private string respuesta;
        private string msjUsuario;
        private string msjTecnico;

        public MateriaController(IMateria materia)
        {
            this.materia = materia;
        }


        [HttpPost("agregarMateria")]
        public ActionResult<string> AgregarMateria([FromBody] Materia materia)
        {
            try
            {
                int contador = this.materia.AgregarMateria(materia);

                if (contador > 0)
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

                return Ok(new { respuesta, msjUsuario, msjTecnico });

            }
            catch (Exception)
            {
                throw;
            }
        }


        [HttpPut("actualizarMateria/{idMateria}")]
        public ActionResult<string> ActualizarMateria(int idMateria, [FromBody] Materia materia)
        {
            try
            {
                int contador = this.materia.ActualizarMateria(idMateria, materia);

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


        [HttpDelete("eliminarMateria/{idMateria}")]
        public ActionResult<string> EliminarMateria(int idMateria)
        {
            try
            {
                bool eliminado = this.materia.EliminarMateria(idMateria);

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


        [HttpGet("obtenerMateriasPorID/{idMateria}")]
        public ActionResult<Materia> OptenerMateriasPorID(int idMateria)
        {
            try
            {
                Materia materia = this.materia.ObtenerMateriasPorID(idMateria);

                if (materia != null)
                {
                    return Ok(materia);
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


        [HttpGet("obtenerMaterias")]
        public ActionResult<List<Materia>> ObtenerMateria()
        {
            try
            {
                List<Materia> lstMateria = this.materia.ObtenerTodasLasMaterias();

                return Ok(lstMateria);

            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
