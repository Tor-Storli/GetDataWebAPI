using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace GetDataWebAPI.Security
{
    public class SecurityData
    {
        // ConfigurationManager.ConnectionStrings["dbConn"].ToString();
        public string VerifyUser(string userID, string password, string connectionstring)
        {

            // string connectionstring =  Configuration.GetConnectionString("dbConn");

            string sSQL = @"DEMO.DEMO_SECURITY_PKG.VERIFY_USER";

            OracleConnection Conn = new OracleConnection(connectionstring);

            // Conn.Open();
            // string xmlStr = string.Empty;

            // Set the query to run against the connection
            OracleCommand cmd = new OracleCommand(sSQL, Conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            ////Create the return Varchar2
            OracleParameter parmReturn =
            cmd.Parameters.Add("result", OracleDbType.Clob, ParameterDirection.ReturnValue);

            //Create the return sys Refcursor
            //OracleParameter parmReturn =
            //cmd.Parameters.Add("result", OracleDbType.Varchar2, ParameterDirection.ReturnValue);

            //Create Parameter Collection
            OracleParameter parm1 =
            cmd.Parameters.Add("V_USERID_IN", OracleDbType.Varchar2, ParameterDirection.Input);
            parm1.Value = userID;

            OracleParameter parm2 =
            cmd.Parameters.Add("V_PASSWORD_IN", OracleDbType.Varchar2, ParameterDirection.Input);
            parm2.Value = password;

            try
            {
                Conn.Open();

                cmd.ExecuteNonQuery();

                //string returnvalue = ((Oracle.ManagedDataAccess.Types.OracleString)parmReturn.Value).Value;
                string returnvalue = ((Oracle.ManagedDataAccess.Types.OracleClob)parmReturn.Value).Value.ToString();

                return returnvalue;

               

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                Conn.Close();
                if (Conn != null) { Conn.Dispose(); }
                if (cmd != null) { cmd.Dispose(); }
            }


        }

        public string EncryptData(string userID, string user_key, string text2encrypt, string connectionstring)
        {

            // string connectionstring =  Configuration.GetConnectionString("dbConn");

            string sSQL = @"DEMO.DEMO_SECURITY_PKG.ENCRYPT_DATA";

            OracleConnection Conn = new OracleConnection(connectionstring);

            // Conn.Open();
            // string xmlStr = string.Empty;

            // Set the query to run against the connection
            OracleCommand cmd = new OracleCommand(sSQL, Conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            //Create the return Clob
            OracleParameter parmReturn =
            cmd.Parameters.Add("result", OracleDbType.Clob, ParameterDirection.ReturnValue);

            //Create Parameter Collection
            OracleParameter parm1 =
            cmd.Parameters.Add("V_USERID_IN", OracleDbType.Varchar2, ParameterDirection.Input);
            parm1.Value = userID;

            OracleParameter parm2 =
            cmd.Parameters.Add("V_USER_KEY_IN", OracleDbType.Varchar2, ParameterDirection.Input);
            parm2.Value = user_key;

            OracleParameter parm3 =
            cmd.Parameters.Add("V_TEXT_2_ENCRYPT_IN", OracleDbType.Varchar2, ParameterDirection.Input);
            parm3.Value = text2encrypt;

            try
            {
                Conn.Open();

                cmd.ExecuteNonQuery();

                string returnvalue = ((Oracle.ManagedDataAccess.Types.OracleClob)parmReturn.Value).Value.ToString();

                return returnvalue;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                Conn.Close();
                if (Conn != null) { Conn.Dispose(); }
                if (cmd != null) { cmd.Dispose(); }
            }


        }

        public string DecryptData(string userID, string user_key, string connectionstring)
        {

            // string connectionstring =  Configuration.GetConnectionString("dbConn");

            string sSQL = @"DEMO.DEMO_SECURITY_PKG.DECRYPT_DATA";

            OracleConnection Conn = new OracleConnection(connectionstring);

            // Set the query to run against the connection
            OracleCommand cmd = new OracleCommand(sSQL, Conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            //Create the return sys Refcursor
            OracleParameter parmReturn =
            cmd.Parameters.Add("result", OracleDbType.Clob, ParameterDirection.ReturnValue);

            //Create Parameter Collection
            OracleParameter parm1 =
            cmd.Parameters.Add("V_USERID_IN", OracleDbType.Varchar2, ParameterDirection.Input);
            parm1.Value = userID;

            OracleParameter parm2 =
            cmd.Parameters.Add("V_USER_KEY_IN", OracleDbType.Varchar2, ParameterDirection.Input);
            parm2.Value = user_key;

            try
            {
                Conn.Open();

                cmd.ExecuteNonQuery();

                string returnvalue = ((Oracle.ManagedDataAccess.Types.OracleClob)parmReturn.Value).Value.ToString();

                return returnvalue;


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                Conn.Close();
                if (Conn != null) { Conn.Dispose(); }
                if (cmd != null) { cmd.Dispose(); }
            }


        }

        public string Create_Update_User(string userID, string password, string connectionstring)
        {

            // string connectionstring =  Configuration.GetConnectionString("dbConn");

            string sSQL = @"DEMO.DEMO_SECURITY_PKG.CREATE_UPDATE_USER";

            OracleConnection Conn = new OracleConnection(connectionstring);


            // Set the query to run against the connection
            OracleCommand cmd = new OracleCommand(sSQL, Conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            //Create the return sys Refcursor
            OracleParameter parmReturn =
            cmd.Parameters.Add("result", OracleDbType.Clob, ParameterDirection.ReturnValue);

            //Create Parameter Collection
            OracleParameter parm1 =
            cmd.Parameters.Add("V_USERID_IN", OracleDbType.Varchar2, ParameterDirection.Input);
            parm1.Value = userID;

            OracleParameter parm2 =
            cmd.Parameters.Add("V_PASSWORD_IN", OracleDbType.Varchar2, ParameterDirection.Input);
            parm2.Value = password;

            try
            {
                Conn.Open();

                cmd.ExecuteNonQuery();

                string returnvalue = ((Oracle.ManagedDataAccess.Types.OracleClob)parmReturn.Value).Value.ToString();

                return returnvalue;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                Conn.Close();
                if (Conn != null) { Conn.Dispose(); }
                if (cmd != null) { cmd.Dispose(); }
            }


        }
    }
}