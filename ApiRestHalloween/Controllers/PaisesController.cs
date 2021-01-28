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

    }
}
