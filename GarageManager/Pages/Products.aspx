<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="GarageManager.Pages.Products" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class=" table-responsive">
        <tr>
            <td rowspan="4">
                <asp:image runat="server"  id="imageProduct" CssClass="detailsImage"></asp:image>
            </td>
            <td>
               <h2>
                    <asp:label runat="server" id="lblTitle" ></asp:label>
                   <hr />
               </h2>
            </td>
        </tr>
        <tr>
            <td>
                <asp:label runat="server"  id="lblDescription" CssClass="destailsDescription"></asp:label>
            </td>
            <td>
                <asp:label runat="server" id="lblPrice" CssClass="detailPrice" ></asp:label>

                <br />

            Quantity :
            <asp:dropdownlist runat="server" id="ddlAmount"></asp:dropdownlist>
                <br />
                <asp:Button ID="btnAdd" runat="server" CssClass="button" OnClick="btnAdd_Click" Text="Add Product" />
                <br />
            <asp:label runat="server" id="lblResult" ></asp:label>
                </td>
        </tr>
        <tr>
            <td>
                Product Number: <asp:label runat="server" id="lblItemNumber"  text="Label"></asp:label>
            </td>

        </tr>
        <tr>
            <td>
                <asp:label id="label1" runat="server" text="Available" CssClass="productPrice"></asp:label>
            </td>

        </tr>
    </table>
</asp:Content>
