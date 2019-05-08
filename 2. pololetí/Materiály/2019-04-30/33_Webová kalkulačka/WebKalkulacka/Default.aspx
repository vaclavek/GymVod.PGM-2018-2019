<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebKalkulacka.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>Ahoj světe!</h1>

        <p>
            Kliknul jsi už:
            <asp:Literal ID="Literal1" runat="server" Text="0"></asp:Literal>x<br />
            <asp:Button ID="Button1" runat="server" Text="Klikni na mě!" OnClick="Button1_Click" />
        </p>
        <p>
            <a href="Kalkulacka.aspx">Jdi na kalkulačku</a>
        </p>
    </div>
    </form>
</body>
</html>
