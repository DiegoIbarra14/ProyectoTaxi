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
    public  class ChoferBLL
    {
        public DataTable SelectAll()
        {
            ChoferDAL choferDAL = new ChoferDAL();
            DataTable tableChofer = choferDAL.Selectall();
            tableChofer.Columns[0].ColumnName = "DNI";
            tableChofer.Columns[1].ColumnName = "Nombre";
            tableChofer.Columns[2].ColumnName = "Apellido Paterno";
            tableChofer.Columns[3].ColumnName = "Apellido Materno";
            tableChofer.Columns[4].ColumnName = "Fecha Ingreso";
            tableChofer.Columns[5].ColumnName = "Placa de Taxi";
            
            return tableChofer;
        }
        public int Insert(ChoferEL chofer)
        {
            ChoferDAL choferDAL =new ChoferDAL();
            int resultado=choferDAL.Insert(chofer);
            return resultado;
        }
        public int Update (ChoferEL chofer) {
            ChoferDAL choferDAL = new ChoferDAL();
            int resultado = choferDAL.Update(chofer);
            return resultado;
        }
        public int Delete(ChoferEL chofer)
        {
            ChoferDAL choferDAL = new ChoferDAL();
            int resultado = choferDAL.Delete(chofer);
            return resultado;
        }
    }
}
