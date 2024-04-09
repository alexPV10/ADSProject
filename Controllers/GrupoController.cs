using ADSProject.Interfaces;
using ADSProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace ADSProject.Controllers
{
    [Route("api/grupos/")]
    public class GrupoController : Controller
    {

        private readonly IGrupo grupo;
        private const string COD_EXITO = "0000";
        private const string COD_ERROR = "1111";
        private string respuesta;
        private string msjUsuario;
        private string msjTecnico;

        public GrupoController(IGrupo grupo)
        {
            this.grupo = grupo;
        }


        [HttpPost("agregarGrupo")]
        public ActionResult<string> AgregarGrupo([FromBody] Grupo grupo)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                int contador = this.grupo.AgregarGrupo(grupo);

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


        [HttpPut("actualizarGrupo/{idGrupo}")]
        public ActionResult<string> ActualizarGrupo(int idGrupo, [FromBody] Grupo grupo)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                int contador = this.grupo.ActualizarGrupo(idGrupo, grupo);

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


        [HttpDelete("eliminarGrupo/{idGrupo}")]
        public ActionResult<string> EliminarGrupo(int idGrupo)
        {
            try
            {
                bool eliminado = this.grupo.EliminarGrupo(idGrupo);

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


        [HttpGet("obtenerGruposPorID/{idGrupo}")]
        public ActionResult<Grupo> OptenerGruposPorID(int idGrupo)
        {
            try
            {
                Grupo grupo = this.grupo.ObtenerGruposPorID(idGrupo);

                if (grupo != null)
                {
                    return Ok(grupo);
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


        [HttpGet("obtenerGrupos")]
        public ActionResult<List<Grupo>> ObtenerGrupo()
        {
            try
            {
                List<Grupo> lstGrupo = this.grupo.ObtenerTodosLosGrupos();

                return Ok(lstGrupo);

            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
