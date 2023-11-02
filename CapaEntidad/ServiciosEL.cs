using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class ServiciosEL
    {
        public int Id { get; set; }
        public DateTime FechaServicio { get; set; }
        public int  IdHospital {  get; set; }
        public string Dni { get; set; }
    }
}
