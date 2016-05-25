<%@ Page Language="C#" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Data.SqlClient" %>
<script runat="server">

    protected void Page_Load(object sender, EventArgs e)
    {
       // string connetionString = null;
        SqlConnection conn;
        SqlCommand cmd;
        string sql = null;
        sql = "select * from score";
        conn=SqlUtil.GetConnection("MyScore.mdf");
        try
        {
            cmd = new SqlCommand(sql, conn);
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                Response.Write(rd["sno"] + " ");
                Response.Write(rd["name"] + " ");
                Response.Write(rd["chi"] + " ");
                Response.Write(rd["eng"] + " ");
                Response.Write(rd["math"] + "<br/>");
            }
            rd.Close();
            cmd.Dispose();
            conn.Close();
        }catch (Exception ex) { }
        Response.Write("okay!");
    }
   
</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    </form>
</body>
</html>
