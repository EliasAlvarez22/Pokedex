<%@ Page Title="Login" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Pokemons.Testing" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <Main class="d-flex flex-column align-items-center">
        <asp:Label ID="lblTitulo" runat="server" Text="Login" CssClass="  d-block text-success text-center display-2 text-md mb-4"/>
        <asp:Label ID="lblEdad" runat="server" Text="Email" CssClass="mb-2"/>
        <asp:TextBox ID="txtEmail" runat="server" CssClass=" w-50 d-block mb-3 form-control border border-success"></asp:TextBox>
        <asp:Label ID="lblNombre" runat="server" Text="Password" cssClass="mb-2"/>
        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass=" w-50 d-block mb-3 form-control border border-success"/>
        <asp:Button runat="server" ID="btn_login" Text="Ingresar" CssClass="btn btn-success" OnClick="Btn_login_Click"/>
    </Main>

<%--   100% en body creo, 100 % en el form, quiero un heigh dinamico en el main 500 px al menos.. 
    y luego un menos margin top para que quede menos  y un justifity content center--%>

</asp:Content>
