using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogicaNegocio
{
    public  class ServicioBLL
    {
        public DataTable SelectAll()
        {
            ServiciosDAL  serviciosDAL = new ServiciosDAL();
            DataTable tableServicios =  serviciosDAL.Selectall();
            return tableServicios;
        }
        public int Insert(ServiciosEL servicios)
        {
            ServiciosDAL  serviciosDAL = new ServiciosDAL();
            int resultado =  serviciosDAL.Insert(servicios);
            return resultado;
        }
        public int Update(ServiciosEL servicios)
        {
            ServiciosDAL  serviciosDAL = new ServiciosDAL();
            int resultado =  serviciosDAL.Update(servicios);
            return resultado;
        }
        public int Delete(ServiciosEL servicios)
        {
            ServiciosDAL  serviciosDAL = new ServiciosDAL();
            int resultado =  serviciosDAL.Delete(servicios);
            return resultado;
        }
    }
}
