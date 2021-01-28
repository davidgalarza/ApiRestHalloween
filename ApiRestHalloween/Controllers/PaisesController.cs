using ApiRestHalloween.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiRestHalloween.Controllers
{
    public class PaisesController : ApiController
    {

        // Clase de acceso a datos
        private PaisesDAL data;
        public PaisesController()
        {
            // Instanciar el objeto.
            this.data = new PaisesDAL();
        }

        public IEnumerable<Pais> GetPaises()
        {
            return data.GetPaises();
        }

        public int PostPais([FromBody] Pais pais)
        {
            // Llamar a la Capa de Acceso a Datos
            return data.InsertarPais(pais);
        }

        public int PutPais(string id, [FromBody] Pais pais)
        {
            pais.IdPais = id;
            // Llamar a la Capa de Acceso a Datos
            return data.UpdatePais(pais);
        }
        public int DeleteCategory(string id)
        {
            Pais pais = new Pais();
            pais.IdPais = id;
            // Llamar a la Capa de Acceso a Datos
            return data.DeletePais(pais);
        }
    }
}
