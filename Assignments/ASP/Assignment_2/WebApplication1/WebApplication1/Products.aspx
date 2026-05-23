<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="WebApplication1.Products" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
        <style>
body {
    background: #f4f6f8;
    margin-top: 50px;
}

#btnCheck {
    padding: 10px 15px;
    margin: 5px;
    border: none;
    background: #007bff;
    color: white;
    border-radius: 5px;
    cursor: pointer;
}

#btnCheck:hover {
        background: #0056b3;
}

    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblHead" runat="server" Font-Size="X-Large" Text="Product Details"></asp:Label>
            <br />
            <br />
            <asp:DropDownList ID="ddlProducts" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlProducts_SelectedIndexChanged">
                <asp:ListItem>-- Select Product --</asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />
            <asp:Image ID="imgProducts" runat="server" Height="250px" Width="250px" />
            <br />
            <br />
            <asp:Button ID="btnCheck" runat="server" Text="Price" OnClick="btnCheck_Click" />
            <br />
            <br />
            <asp:Label ID="lblPrice" runat="server" ForeColor="#33CC33"></asp:Label>
        </div>
    </form>
</body>
</html>
