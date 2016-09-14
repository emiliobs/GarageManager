<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="GarageManager.Pages.Account.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Literal ID="LiteralStatus" runat="server"></asp:Literal>
<br />
<br />
User Name:<br />
<asp:TextBox ID="txtUserName" runat="server" CssClass="inputs"></asp:TextBox>
<br />
<br />
Password:<br />
&nbsp;<asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
<br />
<br />
<asp:Button ID="btnLogIn" runat="server" CssClass="btn btn-success" OnClick="btnLogIn_Click" Text="Log In.!" />
<br />
</asp:Content>
