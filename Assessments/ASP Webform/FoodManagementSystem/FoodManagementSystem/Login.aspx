<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="FoodManagementSystem.Login" %>
<!DOCTYPE html>
<html>
<head>
    <title>Login</title>
    <style>
        .form-box { width:300px;margin:100px auto;padding:20px;border:1px solid #ccc;border-radius:10px;}
        input { width:100%;padding:8px;margin:5px 0;}
        .btn { background:#28a745;color:white;border:none;padding:10px;}
        .error { color:red;}
    </style>
</head>
<body>
    <form runat="server">
        <div class="form-box">
            <h3>Admin Login</h3>

            <asp:TextBox ID="txtUser" runat="server" placeholder="Username" />
            <asp:TextBox ID="txtPass" runat="server" TextMode="Password" placeholder="Password" />

            <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="btn" OnClick="btnLogin_Click" />

            <asp:Label ID="lblMsg" runat="server" CssClass="error"></asp:Label>
        </div>
    </form>
</body>
</html>
