using CommonLib.Interfaces;
using CommonLib.Models;
using System;
using System.Data;
using System.Data.SqlClient;

namespace CommonLib.Implementations
{
    public class RoleImpl : BaseImpl, IRole
    {
        public int Delete(Role t)
        {
            string query = @"UPDATE [dbo].[Role]
                               SET [LastUpdate] = CURRENT_TIMESTAMP
                               ,[Status] = 0
                            WHERE [IdRole]=@IdRole";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@IdRole", t.IdRole);
            try
            {
                return ExecuteBasicCommand(command);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Role GetRole(byte id)
        {
            Role role = null;
            string query = @"SELECT [IdRole]
                                ,[Name]
                                ,[Description]
                                ,[RegisterDate]
                                ,ISNULL (LastUpdate,CURRENT_TIMESTAMP)
                                ,[Status]
                            FROM [dbo].[Role]
                            WHERE [IdRole]=@IdRole";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@IdRole", id);
            SqlDataReader reader = null;
            try
            {
                reader = ExecuteDataReaderCommand(command);
                while (reader.Read())
                {
                    if (reader.IsDBNull(5))
                    {
                        var n = "2000/05/05 15:00:15 PM";
                        string dateString = reader[4].ToString();
                        role = new Role(
                            int.Parse(reader[0].ToString()),
                            reader[1].ToString(),
                            reader[2].ToString(),
                            DateTime.Parse(reader[3].ToString()),
                            DateTime.Parse(n, System.Globalization.CultureInfo.InvariantCulture),
                            reader[5].ToString()
                            );
                    }
                    else
                    {
                        role = new Role(
                            int.Parse(reader[0].ToString()),
                            reader[1].ToString(),
                            reader[2].ToString(),
                            DateTime.Parse(reader[3].ToString()),
                            DateTime.Parse(reader[4].ToString()),
                            reader[5].ToString()
                            );
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                command.Connection.Close();
                reader.Close();
            }
            return role;
        }

        public int Insert(Role t)
        {
            string query = @"INSERT INTO [dbo].[Role]
                                   ([Name]
                                   ,[Description])
                             VALUES
                                   (@name
                                   ,@description)";

            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@name", t.Name);
            command.Parameters.AddWithValue("@description", t.Description);
            try
            {
                return ExecuteBasicCommand(command);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public DataTable Select()
        {
            string query = @"SELECT [IdRole]
                                   ,[Name] as Name
                                   ,[Description] as Description
                                   ,[RegisterDate] as RegisterDate
                               FROM [dbo].[Role]
                               WHERE [Status]=1";
            SqlCommand command = CreateBasicCommand(query);
            try
            {
                return ExecuteDataTableCommand(command);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public int Update(Role t)
        {
            string query = @"UPDATE [dbo].[Role]
                              SET [Name] = @Name
                                 ,[Description] = @Description
                                 ,[LastUpdate] = CURRENT_TIMESTAMP
                            WHERE [IdRole]=@IdRole";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@IdRole", t.IdRole);
            command.Parameters.AddWithValue("@Name", t.Name);
            command.Parameters.AddWithValue("@Description", t.Description);
            try
            {
                return ExecuteBasicCommand(command);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
