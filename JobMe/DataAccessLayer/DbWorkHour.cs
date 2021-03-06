﻿using ModelLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DbWorkHour : IDataAccess<WorkHours>
    {
        //Is an instance of DBConnection
        private string ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        /// <summary>
        /// Is a method that creates a WorkHours object in the databse with the varibles....
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Create(WorkHours obj)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Is a method that deletes a WorkHours Object from the database by its Id
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns a WorkHours Object from the database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public WorkHours Get(int id)
        {
            WorkHours workHours = new WorkHours();
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM WorkHours WHERE Id = @Id";
                    cmd.Parameters.AddWithValue("Id", id);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        workHours.Id = (int)reader["Id"];
                        workHours.Type = (string)reader["Type"];
                    }
                    return workHours;
                }
            }
        }

        /// <summary>
        /// Returns a list of all JobCategories from the database
        /// </summary>
        /// <returns></returns>
        public List<WorkHours> GetAll()
        {
            List<WorkHours> workHoursList = new List<WorkHours>();
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using(SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM WorkHours";
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        WorkHours workHours = new WorkHours
                        {
                            Id = (int)reader["Id"],
                            Type = (string)reader["Type"]
                        };
                        workHoursList.Add(workHours);
                    }
                }
            }
            return workHoursList;
        }

        /// <summary>
        /// Is a method that Updates the WorkHours Object in the database
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Update(WorkHours obj)
        {
            throw new NotImplementedException();
        }
    }
}
