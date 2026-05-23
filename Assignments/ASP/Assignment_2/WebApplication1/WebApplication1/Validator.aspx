<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Validator.aspx.cs" Inherits="WebApplication1.Validator" %>

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
            <asp:Label ID="lblHeading" runat="server" Text="Insert your details:" Font-Size="Larger"></asp:Label>
            <br />
            <br />
            <asp:Label ID="lblName" runat="server" Text="Name:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtName" runat="server" Width="230px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtName" Display="Dynamic" ErrorMessage="Name" ForeColor="#CC0000">*</asp:RequiredFieldValidator>
            <br />
            <br />
            <asp:Label ID="lblFamname" runat="server" Text="Family Name:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtFamname" runat="server" Width="230px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvFamname" runat="server" ControlToValidate="txtFamname" ErrorMessage="Family Name" ForeColor="#CC0000">*</asp:RequiredFieldValidator>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:CompareValidator ID="covFamname" runat="server" ControlToCompare="txtName" ControlToValidate="txtFamname" Display="Dynamic" ErrorMessage="Differs from name" ForeColor="#CC0000" Operator="NotEqual"></asp:CompareValidator>
            <br />
            <br />
            <asp:Label ID="lblAddress" runat="server" Text="Address:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtAddress" runat="server" TextMode="MultiLine" Width="230px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvAddress" runat="server" ControlToValidate="txtAddress" Display="Dynamic" ErrorMessage="Address" ForeColor="#CC0000">*</asp:RequiredFieldValidator>
            
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:RegularExpressionValidator ID="revAddress" runat="server" ControlToValidate="txtAddress" Display="Dynamic" ErrorMessage="Address" ForeColor="#CC0000" ValidationExpression="^.{2,}$">At least 2 chars</asp:RegularExpressionValidator>
            
            <br />
            <br />
            <asp:Label ID="lblCity" runat="server" Text="City:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtCity" runat="server" Width="230px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvCity" runat="server" ControlToValidate="txtCity" Display="Dynamic" ErrorMessage="City" ForeColor="#CC0000">*</asp:RequiredFieldValidator>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:RegularExpressionValidator ID="revCity" runat="server" ControlToValidate="txtCity" Display="Dynamic" ErrorMessage="City" ForeColor="#CC0000" ValidationExpression="^.{2,}$">At least 2 chars</asp:RegularExpressionValidator>
            <br />
            <br />
            <asp:Label ID="lblZipcode" runat="server" Text="Zipcode:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtZipcode" runat="server" Width="230px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvZipcode" runat="server" ControlToValidate="txtZipcode" Display="Dynamic" ErrorMessage="Zip" ForeColor="#CC0000">*</asp:RequiredFieldValidator>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:RegularExpressionValidator ID="revZipcode" runat="server" ControlToValidate="txtZipcode" Display="Dynamic" ErrorMessage="Zip" ForeColor="#CC0000" ValidationExpression="^[0-9]{6}$">(XXXXXX)</asp:RegularExpressionValidator>
            <br />
            <br />
            <asp:Label ID="lblPhone" runat="server" Text="Phone:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtPhone" runat="server" Width="230px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvPhone" runat="server" ControlToValidate="txtPhone" Display="Dynamic" ErrorMessage="Phone" ForeColor="#CC0000">*</asp:RequiredFieldValidator>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:RegularExpressionValidator ID="revPhone" runat="server" ControlToValidate="txtPhone" Display="Dynamic" ErrorMessage="Phone" ForeColor="#CC0000" ValidationExpression="^\d{2,3}-\d{7}$">(XX-XXXXXXX) or (XXX-XXXXXXX)</asp:RegularExpressionValidator>
            <br />
            <br />
            <asp:Label ID="lblEmail" runat="server" Text="E-mail:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtEmail" runat="server" TextMode="Email" Width="230px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail" Display="Dynamic" ErrorMessage="Email" ForeColor="#CC0000">*</asp:RequiredFieldValidator>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail" Display="Dynamic" ErrorMessage="Email" Font-Underline="True" ForeColor="#CC0000" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">example@example.com</asp:RegularExpressionValidator>
            <br />
            <br />
            <asp:Button ID="btnCheck" runat="server" OnClick="btnCheck_Click" Text="Check" />
            <br />
            <br />
            <asp:Label ID="lblMessage" runat="server"></asp:Label>
            <br />
            <asp:ValidationSummary ID="vsError" runat="server" ForeColor="#CC0000" HeaderText="Validation Sum" ShowMessageBox="True" />
            <br />
        </div>
    </form>
</body>
</html>
