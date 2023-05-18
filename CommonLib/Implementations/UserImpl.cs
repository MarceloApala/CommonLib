using CommonLib.Interfaces;
using CommonLib.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CommonLib.Implementations
{
    public class UserImpl : BaseImpl, IUser
    {
        public int Delete(User t)
        {
            throw new NotImplementedException();
        }

        public User GetUser(byte id)
        {
            throw new NotImplementedException();
        }

        public int Insert(User t)
        {
            string query = @"INSERT INTO [dbo].[Users]
                                  ([Name]
                                  ,[LastName]
                                  ,[Dni]
                                  ,[Address]
                                  ,[PhoneNumber]
                                  ,[UserName]
                                  ,[Password]
                                  ,[Email]
                                  ,[Status]
                                  ,[IdRole])
                            VALUES
                                  (@Name
                                  ,@LastName
                                  ,@Dni
                                  ,@Address
                                  ,@PhoneNumber
                                  ,@UserName
                                  ,@Password
                                  ,@Email
                                  ,@IdRole)";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@Name",t.Name);
            command.Parameters.AddWithValue("@LastName",t.LastName);
            command.Parameters.AddWithValue("@Dni", t.Dni);
            command.Parameters.AddWithValue("@Address",t.Address);
            command.Parameters.AddWithValue("@PhoneNumber",t.PhoneNumber);
            command.Parameters.AddWithValue("@UserName",t.UserName);
            command.Parameters.AddWithValue("@Password",t.Password);
            command.Parameters.AddWithValue("@Email",t.Email);
            command.Parameters.AddWithValue("@IdRole",t.IdRole);
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
            string query = @"SELECT U.IdUser
                        	  ,U.Name
                              ,U.LastName
                              ,U.Dni
                              ,U.Address
                              ,U.PhoneNumber
                              ,U.UserName
                              ,U.Email
                              ,U.RegisterDate
                              ,R.Name as Role
                          FROM Users U
                          INNER JOIN [Role] R ON R.IdRole=U.IdRole
                          WHERE U.Status=1";
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

        public int Update(User t)
        {
            throw new NotImplementedException();
        }
    }
}
