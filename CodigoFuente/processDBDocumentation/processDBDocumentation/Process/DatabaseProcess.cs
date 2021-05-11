using processDBDocumentation.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace processDBDocumentation.Process
{
    public class DatabaseProcess
    {
        SqlConnection connection;
        bool tableHasADescription;

        public void ProcessDatabase(string connectionString, List<Table> tablesToProcess)
        {
            try
            {
                using (connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    foreach(Table t in tablesToProcess)
                    {
                        this.tableHasADescription = this.CheckIfTableHasDescription(t.Name);

                        this.DocumentTable(t.Name, t.Description);

                        foreach(Column c in t.Columns)
                        {
                            this.DocumentColumn(t.Name, c.Name, c.Description);
                        }
                    }

                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nERROR: Error estableciendo una conexión con la base de datos.");

                Console.WriteLine(ex.Message);

                throw ex;
            }
        }

        private bool CheckIfTableHasDescription(string tableName)
        {
            string command = string.Format("SELECT 1 FROM SYS.EXTENDED_PROPERTIES WHERE [major_id] = OBJECT_ID('{0}') AND [name] = N'MS_Description' AND [minor_id] = 0", tableName);

            using (SqlCommand cmd = new SqlCommand(command, connection))
            {
                cmd.CommandType = CommandType.Text;

                object exists = cmd.ExecuteScalar();

                if (exists != null)
                {
                    return true;
                }
            }

            return false;
        }

        private void DocumentColumn(string tableName, string columnName, string description)
        {
            string command = null;

            if (this.tableHasADescription)
            {
                command = string.Format("sys.sp_updateextendedproperty @name=N'MS_Description', @value=N'{0}' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'{1}', @level2type=N'COLUMN',@level2name=N'{2}'",
                    description, tableName, columnName);
            }
            else
            {
                command = string.Format("sys.sp_addextendedproperty @name=N'MS_Description', @value=N'{0}' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'{1}', @level2type=N'COLUMN',@level2name=N'{2}'",
                    description, tableName, columnName);
            }

            using (SqlCommand cmd = new SqlCommand(command, connection))
            {
                cmd.CommandType = CommandType.Text;

                cmd.ExecuteNonQuery();
            }
        }

        private void DocumentTable(string tableName, string description)
        {
            string command = null;

            if (this.tableHasADescription)
            {
                command = string.Format("sys.sp_updateextendedproperty @name=N'MS_Description', @value=N'{0}' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'{1}'",
                    description, tableName);
            }
            else
            {
                command = string.Format("sys.sp_addextendedproperty @name=N'MS_Description', @value=N'{0}' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'{1}'",
                    description, tableName);
            }

            using (SqlCommand cmd = new SqlCommand(command, connection))
            {
                cmd.CommandType = CommandType.Text;

                cmd.ExecuteNonQuery();
            }
        }
    }
}