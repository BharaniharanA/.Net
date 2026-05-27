<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="MenuList.aspx.cs" Inherits="FoodManagementSystem.MenuList" UnobtrusiveValidationMode="None" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView ID="gvMenu" runat="server" AutoGenerateColumns="False"
    DataKeyNames="MenuId" OnRowDeleting="gvMenu_RowDeleting">

    <Columns>
        <asp:BoundField DataField="MenuId" HeaderText="ID"/>
        <asp:BoundField DataField="ItemName" HeaderText="Name"/>
        <asp:BoundField DataField="Category" HeaderText="Category"/>
        <asp:BoundField DataField="FoodType" HeaderText="Type"/>
        <asp:BoundField DataField="Price" HeaderText="Price"/>
        <asp:BoundField DataField="AvailableQuantity" HeaderText="Qty"/>
        <asp:CheckBoxField DataField="IsAvailable" HeaderText="Available"/>

        <asp:HyperLinkField Text="View"
         DataNavigateUrlFields="MenuId"
         DataNavigateUrlFormatString="MenuDetails.aspx?MenuId={0}" />

        <asp:HyperLinkField Text="Edit"
         DataNavigateUrlFields="MenuId"
         DataNavigateUrlFormatString="AddEditMenu.aspx?MenuId={0}" />

        <asp:CommandField ShowDeleteButton="True"/>
    </Columns>
</asp:GridView>

</asp:Content>
