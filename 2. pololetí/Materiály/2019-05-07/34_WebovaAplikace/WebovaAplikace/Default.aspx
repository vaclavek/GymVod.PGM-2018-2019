<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebovaAplikace.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        #informace {
            border: 1px solid #00cc00;
            padding: 10px;
            margin: 10px 0;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Ahoj</h1>

            <p id="informace">
                <asp:Literal ID="litInformace" runat="server"></asp:Literal><br />
            </p>

            <asp:MultiView ID="MultiView1" runat="server">
                <asp:View runat="server">
                    
                    <asp:Calendar ID="Calendar1" runat="server" OnSelectionChanged="Calendar1_SelectionChanged"></asp:Calendar>

                    <asp:CheckBox ID="CheckBox1" runat="server" Text="Zaškrtni mě!" 
                        OnCheckedChanged="CheckBox1_CheckedChanged" 
                        AutoPostBack="false" /><br />
            
                    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                        <asp:ListItem Text="Seznam" Value="1"></asp:ListItem>
                        <asp:ListItem Text="Google" Value="2"></asp:ListItem>
                        <asp:ListItem Text="GymVod" Value="3"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
                    <br /><br />
                    <asp:FileUpload ID="FileUpload1" runat="server" />
                    <br /><br />
                    <asp:HyperLink ID="HyperLink1" runat="server" Target="_blank" Visible="false">HyperLink</asp:HyperLink>
                    <br /><br />
            
                    <asp:Button ID="Button2" runat="server" Text="Zobraz obrázek" OnClick="Button2_Click" />
                    <asp:Image ID="Image1" runat="server" Visible="false" />

                    <asp:Button ID="Button3" runat="server" Text="Vpřed" OnClick="Button3_Click" />

                </asp:View>
                <asp:View runat="server">
                    
                    <asp:Literal runat="server" ID="litVysledek"></asp:Literal><br />

                    Username: <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox><br />
                    Password: <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox><br />
                    <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />

                    <asp:Button ID="Button4" runat="server" Text="Zpět" OnClick="Button4_Click" />

                </asp:View>
            </asp:MultiView>


        </div>
    </form>
</body>
</html>
