<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ShoppingCart.aspx.cs" Inherits="GarageManager.Pages.ShoppingCart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:Panel ID="pnlShoopingCart" runat="server">


    </asp:Panel>

    <table>
        <tr>
            <td>Total:</td>
            <td><asp:Literal ID="litTotal" runat="server" Text=""></asp:Literal></td>
        </tr>
          <tr>
            <td>Vat:</td>
            <td><asp:Literal ID="LiteralVat" runat="server" Text=""></asp:Literal></td>
        </tr>

          <tr>
            <td>Shipping:</td>
            <td>€ 15</td>
        </tr>

          <tr>
            <td>Total Amount:</td>
            <td><asp:Literal ID="Literal3" runat="server" Text=""></asp:Literal></td>
        </tr>

          <tr>
            <td>Total:</td>
            <td><asp:Literal ID="LiteralTotalAmount" runat="server" Text=""></asp:Literal></td>
        </tr>
        <tr>
            <td>
                <asp:LinkButton Text="Continue Shopping" CssClass="btn btn-info" ID="lnkContinue" PostBackUrl="~/Index.aspx" runat="server"/>
                OR
                <asp:Button ID="btnCheckOut" CssClass="btn btn-success" runat="server" Text="Continue Checkout" PostBackUrl="~/Pages/Success.aspx" />
            </td>
        </tr>
    </table>

</asp:Content>
