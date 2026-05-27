<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddEditMenu.aspx.cs" Inherits="FoodManagementSystem.AddEditMenu" UnobtrusiveValidationMode="None" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Item:
            <asp:TextBox ID="txtName" runat="server" />
            <asp:RequiredFieldValidator ControlToValidate="txtName" ErrorMessage="Required" runat="server" />

            <br />

            Category:
            <asp:TextBox ID="txtCategory" runat="server" />
            <asp:RegularExpressionValidator ControlToValidate="txtCategory"
                ValidationExpression="^[a-zA-Z ]+$" ErrorMessage="Only text" runat="server" />

            <br />

            Food Type:
            <asp:DropDownList ID="ddlType" runat="server">
                <asp:ListItem>Veg</asp:ListItem>
                <asp:ListItem>Non-Veg</asp:ListItem>
            </asp:DropDownList>

            <br />

            Price:
            <asp:TextBox ID="txtPrice" runat="server" />
            <asp:RangeValidator ControlToValidate="txtPrice" MinimumValue="1" MaximumValue="1000"
                Type="Double" ErrorMessage="Invalid Price" runat="server" />

            <br />

            Qty:
            <asp:TextBox ID="txtQty" runat="server" />
            <asp:CompareValidator ControlToValidate="txtQty"
                Type="Integer" Operator="DataTypeCheck" ErrorMessage="Numbers only" runat="server" />

            <br />

            Available:
            <asp:CheckBox ID="chkAvailable" runat="server" />

            <asp:ValidationSummary runat="server" />

            <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
        </div>
    </form>
</body>
</html>
