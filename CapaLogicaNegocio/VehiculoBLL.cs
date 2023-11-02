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
    public class VehiculoBLL
    {   
        public DataTable SelectAll()
        {
            VehiculoDAL vehiculoDAL = new VehiculoDAL();
            DataTable tableVehiculo = vehiculoDAL.Selectall();
            return tableVehiculo;
        }
        public int Insert(VehiculoEL vehiculo)
        {
            VehiculoDAL vehiculoDAL = new VehiculoDAL();
            int resultado = vehiculoDAL.Insert(vehiculo);
            return resultado;
        }
        public int Update(VehiculoEL vehiculo)
        {
            VehiculoDAL vehiculoDAL = new VehiculoDAL();
            int resultado = vehiculoDAL.Update(vehiculo);
            return resultado;
        }
        public int Delete(VehiculoEL vehiculo)
        {
            VehiculoDAL vehiculoDAL = new VehiculoDAL();
            int resultado = vehiculoDAL.Delete(vehiculo);
            return resultado;
        }
    }
}
