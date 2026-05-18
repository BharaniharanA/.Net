<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Banking.aspx.cs" Inherits="DemoApp1.Banking" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
    body {
        font-family: Arial;
        background-color: #f4f6f8;
    }
    .container {
        width: 1114px;
        margin: 30px auto;
        background: white;
        padding: 25px;
        border-radius: 10px;
        box-shadow: 0px 0px 10px #ccc;
        height: 1333px;
    }
    table {
    }
    td {
        padding: 8px;
    }
    .error {
        color: red;
    }
    .success {
        color: green;
        font-weight: bold;
    }
    .btn {
        padding: 8px 18px;
        background-color: #0078d7;
        color: white;
        border: none;
        border-radius: 5px;
    }
        .auto-style1 {
            height: 31px;
        }
        .auto-style2 {
        }
        .auto-style3 {
            height: 31px;
            width: 594px;
        }
        .auto-style4 {
            width: 594px;
            height: 38px;
        }
        .auto-style5 {
            height: 38px;
        }
        .auto-style6 {
            height: 72px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" enctype="multipart/form-data">
        <div class="container">
            <h2>Banking Registration</h2>
        
        <table style="width:100%;">
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="lblName" runat="server" Text="Full Name"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtName" CssClass="error" Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="lblEmail" runat="server" Text="Email"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtEmail" runat="server" TextMode="Email"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail" CssClass="error" Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="refEmail" runat="server" ControlToValidate="txtEmail" CssClass="error" Display="Dynamic" ErrorMessage="Enter valid Email" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="lblPhone" runat="server" Text="Phone Number"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtPhone" runat="server" TextMode="Phone"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvPhone" runat="server" ControlToValidate="txtPhone" CssClass="error" Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="refPhone" runat="server" ControlToValidate="txtPhone" CssClass="error" Display="Dynamic" ErrorMessage="Enter 10 digit mobile number" ValidationExpression="^[0-9]{10}$"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style6">
                    <asp:Label ID="lblAddress" runat="server" Text="Address"></asp:Label>
                </td>
                <td class="auto-style6">
                    <asp:TextBox ID="txtAddress" runat="server" TextMode="MultiLine"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvAddress" runat="server" ControlToValidate="txtAddress" CssClass="error" Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">
                    <asp:Label ID="lblDob" runat="server" Text="Date of Birth"></asp:Label>
                </td>
                <td class="auto-style1">
                    <asp:TextBox ID="txtDob" runat="server"  TextMode="Date"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvDob" runat="server" ControlToValidate="txtDob" CssClass="error" Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator>
                    <asp:CustomValidator ID="cvDob" runat="server" ControlToValidate="txtDob" CssClass="error" Display="Dynamic" ErrorMessage="Age should be above 18 years" OnServerValidate="cvDob_ServerValidate"></asp:CustomValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">
                    <asp:Label ID="lblAcctype" runat="server" Text="Account Type"></asp:Label>
                </td>
                <td class="auto-style1">
                    <asp:DropDownList ID="ddlAccType" runat="server" AutoPostBack="True">
                        <asp:ListItem>-- Select Account Type</asp:ListItem>
                        <asp:ListItem Value="Saving">Saving</asp:ListItem>
                        <asp:ListItem Value="Credit">Credit</asp:ListItem>
                        <asp:ListItem Value="Salary">Salary</asp:ListItem>
                    </asp:DropDownList>
                    <asp:CustomValidator ID="cvAcctype" runat="server" ControlToValidate="ddlAccType" CssClass="error" Display="Dynamic" ErrorMessage="Select Account Type" OnServerValidate="cvAcctype_ServerValidate"></asp:CustomValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="lblAadhar" runat="server" Text="Aadhar Number"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtAadhar" runat="server" TextMode="Number"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvAadhar" runat="server" ControlToValidate="txtAadhar" CssClass="error" Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revAadhar" runat="server" ControlToValidate="txtAadhar" CssClass="error" Display="Dynamic" ErrorMessage="Enter Valid Aadhar number" ValidationExpression="^[0-9]{12}$"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="lblAadharup" runat="server" Text="Upload Aadhar Document"></asp:Label>
                </td>
                <td>
                    <asp:FileUpload ID="FuAadhar" runat="server" />
                    <asp:CustomValidator ID="cvFuaadhar" runat="server" CssClass="error" Display="Dynamic" ErrorMessage="upload image/pdf file" OnServerValidate="cvFuaadhar_ServerValidate"></asp:CustomValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">
                    <asp:Label ID="lblPan" runat="server" Text="Pan Number"></asp:Label>
                </td>
                <td class="auto-style1">
                    <asp:TextBox ID="txtPan" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvPan" runat="server" ControlToValidate="txtPan" CssClass="error" Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revPan" runat="server" ControlToValidate="txtPan" CssClass="error" Display="Dynamic" ErrorMessage="Enter Valid Pan Id" ValidationExpression="^[A-Za-z]{5}[0-9]{4}[A-Za-z]{1}$"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="lblPanup" runat="server" Text="Upload Pan Document"></asp:Label>
                </td>
                <td>
                    <asp:FileUpload ID="FuPan" runat="server" />
                    <asp:CustomValidator ID="cvFuPan" runat="server" CssClass="error" Display="Dynamic" ErrorMessage="upload image/pdf file" OnServerValidate="cvFuPan_ServerValidate"></asp:CustomValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:CheckBox ID="chkAgree" runat="server" Text="I Agree to the terms and conditions" />
                    <asp:CustomValidator ID="cvAgree" runat="server" CssClass="error" Display="Dynamic" ErrorMessage="*" OnServerValidate="cvAgree_ServerValidate"></asp:CustomValidator>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style4">
                    <asp:Button ID="btnRegister" runat="server" Text="Register" CssClass="btn" OnClick="btnRegister_Click" />
                </td>
                <td class="auto-style5">
                    <asp:Label ID="lblMessage" runat="server"></asp:Label>
                    <br />
                    <asp:Label ID="lblAccno" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style2" colspan="2">
                    &nbsp;</td>
            </tr>
        </table>
            <asp:GridView ID="gvAccounts" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" >
                <EditRowStyle BackColor="#2461BF" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#EFF3FB" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                <SortedDescendingHeaderStyle BackColor="#4870BE" />
            </asp:GridView>
            </div>
    </form>
</body>
</html>
