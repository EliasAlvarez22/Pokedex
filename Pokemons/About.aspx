<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="Pokemons.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link href="About.css" rel="stylesheet" />
    
<%        
    lblTituloLogin.Text = Nombre == null ? "Dirigase a Login" : "Bienvenido " + Nombre;
    if(Nombre != null)    
        lblTituloLogin.NavigateUrl = "";
    
%>    
    <asp:HyperLink ID="lblTituloLogin" NavigateUrl="~/Testing.aspx" runat="server" CssClass="Titulo"/>
<%
    if (Nombre != null)
    {
%>    
    <asp:Label ID="lblDatos" runat="server" cssClass="Datos" Text="Tus datos: "/>

    <asp:Label ID="lblNombre" runat="server" cssClass="" Text="Nombre:"/>
    
    <asp:Label ID="lblEdad" runat="server" cssClass="" Text="Edad: "/>
<%
    }
%>
</asp:Content>
