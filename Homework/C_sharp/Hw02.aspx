<%@ Page Language="C#" %>

<!DOCTYPE html>

<script runat="server">

    protected void Page_Load(object sender, EventArgs e)
    {
        Double num1 = Convert.ToDouble(Request["num1"]);
        Double num2 = Convert.ToDouble(Request["num2"]);
        string str = "";
        if (num1 > num2) str = "大於";
        else if (num1 < num2) str = "小於";
        else str = "等於";
        Response.Write(num1 +" "+ str +" " + num2);
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
    
    </div>
    </form>
</body>
</html>
