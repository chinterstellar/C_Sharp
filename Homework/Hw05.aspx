<%@ Page Language="C#" %>

<!DOCTYPE html>

<script runat="server">
    string str2 = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        string str = Request["arr"];

        string[] arr = str.Split(',');
        str = "";
        for(int i = 0; i <arr.GetUpperBound(0); i++)
        {
            str += arr[i] + " , ";
        }
        str += arr[arr.GetUpperBound(0)];
        str2 += "輸入 "+str+"<br/>";

        str2 += "輸出 ";
        for(int i = arr.GetLength(0)-1; i >0; i--)
        {
            str2 += arr[i] + " , ";
        }
        str2 += arr[0];
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
        <%
            Response.Write(str2); 
        %>
    </div>
    </form>
</body>
</html>
