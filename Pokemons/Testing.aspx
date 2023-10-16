<%@ Page Title="Login" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Testing.aspx.cs" Inherits="Pokemons.Testing" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="Testing.css" rel="stylesheet"/>
    <section>
        <asp:Label ID="lblTitulo" runat="server" Text="Login" CssClass="Titulo"/>
        <asp:Label ID="lblEdad" runat="server" Text="Nombre"/>
        <asp:TextBox ID="txtNombre" runat="server" CssClass="Campo"></asp:TextBox>
        <asp:Label ID="lblNombre" runat="server" Text="Edad" />
        <asp:TextBox ID="txtEdad" runat="server" CssClass="Campo" ></asp:TextBox>
        <asp:Button runat="server" ID="btn_login" Text="Ingresar" CssClass="btn btn-success" OnClick="Btn_login_Click"/>
    </section>

   

</asp:Content>
