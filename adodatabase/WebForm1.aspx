<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="adodatabase.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #form1 {
            font-weight: 700;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>

        </div>
        <asp:Label ID="Label1" runat="server" Text="Enter the Id"></asp:Label>
        <p>
            <asp:TextBox ID="TextBox1" runat="server" ></asp:TextBox>
            &nbsp;
        </p>
        <asp:Label ID="Label2" runat="server" Text="Enter the Name:"></asp:Label>
        <p>
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        </p>
        <asp:Label ID="Label3" runat="server" Text="Enter the Address:"></asp:Label>
        <p>
            <asp:TextBox ID="TextBox3" runat="server" TextMode="MultiLine"></asp:TextBox>
        </p>
        <p>
            <asp:Label ID="Label4" runat="server" Text="Select the field to Update:"></asp:Label>
        </p>
        <p style="font-weight: 700">
        <asp:DropDownList ID="DropDownList1" runat="server">
            <asp:ListItem>Name</asp:ListItem>
            <asp:ListItem>Address</asp:ListItem>
        </asp:DropDownList>
        </p>
        <br />
        <p>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Insert" />
&nbsp;
            <asp:Button ID="Button2" runat="server" Text="Update" OnClick="Button2_Click" />
&nbsp;&nbsp;
            <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Delete" />
&nbsp;&nbsp;
            <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Retrieve" />
        </p>
        <br /><asp:GridView ID="GridView1" runat="server">
        </asp:GridView>
    </form>
</body>
</html>
