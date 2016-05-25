using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// SqlUtil 的摘要描述
/// </summary>
public class SqlUtil
{
    public static SqlConnection GetConnection(string db)
    {
        //APP_Data MyComp.mdf MyComp_log.ldf
        string constr = @"Data Source=.\SQLEXPRESS;AttachDbFileName=|DataDirectory|" + db + ";Integrated Security=True;User Instance=True";
        SqlConnection conn = new SqlConnection(constr);
        conn.Open();
        return conn;
        /*
        有問題裡面這個要刪掉
        C:\Documents and Settings\<UserName>\Local Settings\Application Data\Microsoft\Microsoft SQL Server Data\SQLEXPRESS
        */
    }
}