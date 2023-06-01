using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EmployeeProj.Models;
using Dapper;
using System.Net.Http.Headers;
using System.Data;
using System.Web.UI.WebControls.WebParts;

namespace EmployeeProj.Repository
{
    public class EmployeeRepository
    {
        DBConnection.DBConnection db = new DBConnection.DBConnection();
        public List<EmployeeModel> GetList()
        {
            db.connect();
            try
            {
                db.con.Open();
                DynamicParameters parm = new DynamicParameters();
                parm.Add("@flag", "GetList");
                var dataList = SqlMapper.Query<EmployeeModel>(db.con,"EmployeeProc",parm, commandType: CommandType.StoredProcedure).ToList();
                return dataList;
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

        public EmployeeModel GetEmpById(int empId)
        {
            db.connect();
            try
            {
                db.con.Open();
                DynamicParameters parm = new DynamicParameters();
                parm.Add("@employeeId", empId);
                parm.Add("@flag", "GetById");
                var data = SqlMapper.Query<EmployeeModel>(db.con, "EmployeeProc", parm, commandType: CommandType.StoredProcedure).FirstOrDefault();
                return data;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                db.con.Close();
            }
        }

        public void InsertEmp(EmployeeModel emp)
        {
            db.connect();
            try
            {
                db.con.Open();
                DynamicParameters parm = new DynamicParameters();
                parm.Add("@firstName", emp.firstName);
                parm.Add("@middleName", emp.middleName);
                parm.Add("@lastName", emp.lastName);
                parm.Add("@monthlySalary", emp.monthlySalary);
                parm.Add("@flag", "Insert");
                db.con.Execute("EmployeeProc", parm, commandType: CommandType.StoredProcedure);
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

        public void UpdateEmp(EmployeeModel emp)
        {
            db.connect();
            try
            {
                db.con.Open();
                DynamicParameters parm = new DynamicParameters();
                parm.Add("@employeeId", emp.employeeId);
                parm.Add("@firstName", emp.firstName);
                parm.Add("@middleName", emp.middleName);
                parm.Add("@lastName", emp.lastName);
                parm.Add("@monthlySalary", emp.monthlySalary);
                parm.Add("@flag", "Update");
                db.con.Execute("EmployeeProc", parm, commandType: CommandType.StoredProcedure);
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

        public void DeleteEmp(int empId) 
        {
            db.connect();
            try
            {
                db.con.Open();
                DynamicParameters parm = new DynamicParameters();
                parm.Add("@employeeId", empId);
                parm.Add("@flag", "Delete");
                db.con.Execute("EmployeeProc", parm, commandType: CommandType.StoredProcedure);
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