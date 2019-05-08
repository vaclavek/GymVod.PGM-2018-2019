<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Kalkulacka.aspx.cs" Inherits="WebKalkulacka.Kalkulacka" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>Webová kalkulačka</h1>

        <p>
            <asp:TextBox ID="txtPrvniCislo" runat="server"></asp:TextBox><br />
            <asp:TextBox ID="txtDruheCislo" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:Button ID="btnPlus" runat="server" Text="+" OnClick="btnPlus_Click" />
            <asp:Button ID="btnMinus" runat="server" Text="-" OnClick="btnMinus_Click" />
            <asp:Button ID="btnKrat" runat="server" Text="×" OnClick="btnKrat_Click" />
            <asp:Button ID="btnDeleno" runat="server" Text="÷" OnClick="btnDeleno_Click" />
        </p>

        <p>
            Výsledek je: <asp:Literal ID="litVysledek" runat="server"></asp:Literal>
        </p>
    </div>
    </form>
</body>
</html>
