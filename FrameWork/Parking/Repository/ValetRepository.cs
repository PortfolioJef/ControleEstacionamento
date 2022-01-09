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
    public class ValetRepository
    {
        public SqlConnection DbCon;
        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["ValetDBConn"].ToString();
            DbCon = new SqlConnection(constr);
        }

        public void AddValet(Models.Valet objValet)
        {
            //try
            //{

            connection();
            DbCon.Open();
            DbCon.Execute("Valet_AddNew", new { Name = objValet.Name, NumberId = objValet.NumberId, BirthDate = objValet.BirthDate }, commandType: CommandType.StoredProcedure);
            DbCon.Close();
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
        }

        public Models.Valet GetValetById(int Id)
        {
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@CarId", Id);
                connection();
                DbCon.Open();
                Valet Valet = SqlMapper.Query<Valet>(
                                  DbCon, "Valet_GetById", param).FirstOrDefault();
                DbCon.Close();
                return Valet;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Models.Valet> GetAllValet()
        {
            try
            {
                connection();
                DbCon.Open();
                IList<Valet> ValetList = SqlMapper.Query<Valet>(
                                  DbCon, "Valets_Get").ToList();
                DbCon.Close();
                return ValetList.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateValet(Models.Valet objUpdate)
        {
            try
            {
                connection();
                DbCon.Open();
                DbCon.Execute("Valet_UpdateDetails", objUpdate, commandType: CommandType.StoredProcedure);
                DbCon.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool DeleteValet(int Id)
        {
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@ValetId", Id);
                connection();
                DbCon.Open();
                DbCon.Execute("Valet_DeleteById", param, commandType: CommandType.StoredProcedure);
                DbCon.Close();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}