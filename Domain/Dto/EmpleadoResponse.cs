using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dto
{
    public class EmpleadoResponse
    {

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string Direccion { get; set; }

        public string Ciudad { get; set; }

        public int? FkPuesto { get; set; }
        public int? FkDepartamento { get; set; }
    }
}
