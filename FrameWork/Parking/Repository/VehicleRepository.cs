using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using StaparParking.Models;

namespace StaparParking.Repository
{
    public class VehicleRepository
    {
        public SqlConnection DbCon;
        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["ValetDBConn"].ToString();
            DbCon = new SqlConnection(constr);
        }
        public void AddVehicle(Vehicle objVehicle)
        {
            try
            {
                connection();
                DbCon.Open();
                DbCon.Execute("Vehicle_AddNew", new { objVehicle.Model, objVehicle.Brand, objVehicle.Identification }, commandType: CommandType.StoredProcedure);
                DbCon.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Vehicle GetVehicleById(int Id)
        {
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@VehicleId", Id);
                connection();
                DbCon.Open();
                Vehicle Vehicle = SqlMapper.Query<Vehicle>(
                                  DbCon, "Vehicles_Get",  new { VehicleId = Id }).FirstOrDefault();
                DbCon.Close();
                return Vehicle;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Vehicle> GetAllVehicles()
        {
            try
            {
                connection();
                DbCon.Open();
                IList<Vehicle> VehicleList = SqlMapper.Query<Vehicle>(
                                  DbCon, "Vehicles_Get").ToList();
                DbCon.Close();
                return VehicleList.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateVehicle(Vehicle objVehicle)
        {
            try
            {
                connection();
                DbCon.Open();
                DbCon.Execute("Vehicle_UpdateDetails", new { VehicleId = objVehicle.Id, Model = objVehicle.Model, Brand = objVehicle.Brand, Identification = objVehicle.Identification }, commandType: CommandType.StoredProcedure);
                DbCon.Close();
            }
            catch (Exception)
            {
                throw;
            }

        }
        public bool DeleteVehicle(int Id)
        {
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@VehicleId", Id);
                connection();
                DbCon.Open();
                DbCon.Execute("Vehicle_DeleteById", param, commandType: CommandType.StoredProcedure);
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