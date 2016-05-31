<%@ Page Language="C#" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Data.SqlClient" %>
<!DOCTYPE html>

<script runat="server">
    string str="";
    protected void Page_Load(object sender, EventArgs e)
    {
        string name = Request["name"];
        string age = Request["age"];
        string address = Request["address"];
        string salary = Request["salary"];
        SqlConnection conn;
        SqlCommand cmd;
        string InsertString = null;
        InsertString="insert into SalaryDB values('"+name+"',"+age+",'"+address+"',"+salary+")";
        conn = SqlUtil.GetConnection("MyComp.mdf");
        int flag = 0;
        try
        {
            cmd = new SqlCommand(InsertString, conn);
            flag=cmd.ExecuteNonQuery();
            cmd.Dispose();
            conn.Close();
        }
        catch (Exception ex){ }
        if (flag!=0)
        {
            //Response.Write("新增成功");
            str = "新增成功";
        }
        else
        {
            //Response.Write("新增失敗");
            str = "新增失敗";
        }


        /*
        Response.Write(name + "<br/>");
        Response.Write(age + "<br/>");
        Response.Write(address + "<br/>");
        Response.Write(salary + "<br/>");
        */

    }
</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" type="text/css" href="index.css" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table>
            <tr>
                <th><a href="Hw08_Create.html">新增資料</a></th>
                <th><a href="Hw08_Read.aspx">讀取資料</a></th>
                <th><a href="Hw08_Update.html">更新資料</a></th>
                <th><a href="Hw08_Delete.html">刪除資料</a></th>
            </tr>
       </table>
        <br/>
        <%=str %>
    </div>
    </form>
</body>
</html>
