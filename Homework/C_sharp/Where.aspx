<%@ Page Language="C#" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Data.SqlClient" %>
<script runat="server">
    string result = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        // string connetionString = null;
        string sno = Request["sno"];
        SqlConnection conn;
        SqlCommand cmd;
        string WhereString = null;
        WhereString = "select * from score where sno='" + sno + "'";
        conn = SqlUtil.GetConnection("MyScore.mdf");
        bool flag = false;
        try
        {
            cmd = new SqlCommand(WhereString, conn);
            cmd.ExecuteNonQuery();
            SqlDataReader rd = cmd.ExecuteReader();

            while (rd.Read())
            {
                flag = true;
                /*
                Response.Write(rd["sno"] + " ");
                Response.Write(rd["name"] + " ");
                Response.Write(rd["chi"] + " ");
                Response.Write(rd["eng"] + " ");
                Response.Write(rd["math"] + "<br/>");
                */
                result = "<table><tr><th>學號</th><th>姓名</th><th>國文</th><th>英文</th><th>數學</th></tr><tr align = center ><td>" + rd["sno"] + "</td><td>" + rd["name"] + "</td><td>" + rd["chi"] + "</td><td>" + rd["eng"] + "</td><td>" + rd["math"] + "</td></tr></table>";
            }
            rd.Close();
            cmd.Dispose();
            conn.Close();
        }
        catch (Exception ex) { }
        //Response.Write("okay!");
        if (flag == false)
        {
            result = "查無此人";
            //Response.Write("查無此人");
        }
    }
</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" type="text/css" href="index.css" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <%Response.Write(result);%>
    </div>
    </form>
</body>
</html>
