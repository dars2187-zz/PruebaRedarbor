﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaRedarbor.Models
{
    public class Database
    {
        public static string sqlDataSource = "Server=(localdb)\\mssqllocaldb;Database=PruebaRedarbor;Trusted_Connection=True;";

        public DataTable GetData(string str)
        {
            DataTable objresutl = new DataTable();
            try
            {
                SqlDataReader myReader;

                using (SqlConnection myCon = new SqlConnection(sqlDataSource))
                {
                    myCon.Open();
                    using (SqlCommand myCommand = new SqlCommand(str, myCon))
                    {
                        myReader = myCommand.ExecuteReader();
                        objresutl.Load(myReader);

                        myReader.Close();
                        myCon.Close();
                    }
                }
            }
            catch (Exception ex)
            {

            }

            return objresutl;

        }
        public int ExecuteData(string str, params IDataParameter[] sqlParams)
        {
            int rows = -1;
            try
            {

                using (SqlConnection conn = new SqlConnection(sqlDataSource))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(str, conn))
                    {
                        if (sqlParams != null)
                        {
                            foreach (IDataParameter para in sqlParams)
                            {
                                cmd.Parameters.Add(para);
                            }
                            rows = cmd.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }


            return rows;


        }
    }
}
