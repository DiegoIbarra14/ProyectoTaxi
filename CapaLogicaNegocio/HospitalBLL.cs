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
    public class HospitalBLL
    {
        public DataTable SelectAll()
        {
            HospitalDAL hospitalDAL = new HospitalDAL();
            DataTable tableHospital = hospitalDAL.Selectall();
            return tableHospital;
        }
        public int Insert(HospitalEL hospital)
        {
            HospitalDAL hospitalDAL = new HospitalDAL();
            int resultado = hospitalDAL.Insert(hospital);
            return resultado;
        }
        public int Update(HospitalEL hospital)
        {
            HospitalDAL hospitalDAL = new HospitalDAL();
            int resultado = hospitalDAL.Update(hospital);
            return resultado;
        }
        public int Delete(HospitalEL hospital)
        {
            HospitalDAL hospitalDAL = new HospitalDAL();
            int resultado = hospitalDAL.Delete(hospital);
            return resultado;
        }
    }
}
