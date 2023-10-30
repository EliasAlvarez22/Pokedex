<%@ Page Title="Mi perfil" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="Pokemons.Profile" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">    
    <h1>Mí Perfil</h1>
    <asp:Label ID="lblDatos" runat="server" cssClass="d-block mb-3" Text="Tus datos: "/>
    <asp:Label ID="lblEmail" runat="server" cssClass="d-block mb-3" Text="Email:"/> 

    <asp:Label ID="lblName" runat="server" cssClass="d-block mb-3" Text="Nombre:"/> 
    <asp:Label ID="lblOld" runat="server" cssClass="d-block mb-3" Text="Edad: "/>

</asp:Content>
