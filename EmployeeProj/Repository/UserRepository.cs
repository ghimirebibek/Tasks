using Dapper;
using EmployeeProj.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace EmployeeProj.Repository
{
    public class UserRepository
    {
        DBConnection.DBConnection db = new DBConnection.DBConnection();
        public int RegisterUser(string username,string password)
        {
            db.connect();
            try
            {

                db.con.Open();
                DynamicParameters parm = new DynamicParameters();
                parm.Add("@username", username);
                parm.Add("@password", password);
                parm.Add("@key", "encrypt");
                parm.Add("@flag", "Insert");
                var data = db.con.Execute("usp_Userdetails", parm, commandType: CommandType.StoredProcedure);
                return data;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                db.con.Close();
            }
        }

        public UserModel login(string username, string password)
        {
            db.connect();
            try
            {
                db.con.Open();
                DynamicParameters parm = new DynamicParameters();
                parm.Add("@username", username);
                parm.Add("@password", password);
                parm.Add("@flag", "Check");
                var data = SqlMapper.Query<UserModel>(db.con, "usp_Userdetails", parm, commandType: CommandType.StoredProcedure).FirstOrDefault();
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                db.con.Close();
            }
        }
    }
}