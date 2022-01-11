using Dapper;
using StaparParking.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace StaparParking.Repository
{
    public class ParkingRepository
    {
        public SqlConnection DbCon;
        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["ValetDBConn"].ToString();
            DbCon = new SqlConnection(constr);
        }

        public void AddParkingLog(Parking objParkingLog)
        {
            try
            {
                connection();
                DbCon.Open();
                DbCon.Execute("ParkingLog_AddNew", new {  objParkingLog.CarId, objParkingLog.ValetID},
                    commandType: CommandType.StoredProcedure);
                DbCon.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Parking> GetAllParkings()
        {
            try
            {
                connection();
                DbCon.Open();
                IList<Parking> ParkingList = SqlMapper.Query<Parking>(
                                  DbCon, "Parkings_Get").ToList();
                DbCon.Close();
                return ParkingList.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}