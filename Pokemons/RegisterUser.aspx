<%@ Page Title="Registro de Usuario" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegisterUser.aspx.cs" Inherits="Pokemons.RegisterUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="lblTitulo" runat="server" Text="Registro de usuario" CssClass="row d-block text-success text-center display-2 text-md mb-sm-5"/>

    <Main class="row">
        <div class="col">
            
            <asp:Label ID="lblEmail" runat="server" Text="Nuevo email" CssClass="mb-2"/>
            <asp:TextBox ID="txtEmail" runat="server" CssClass=" d-block mb-3 form-control border border-success"></asp:TextBox>
            <Label ID="lblPassword" class="mb-2">Nueva contraseña</Label>
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="  d-block mb-3 form-control border border-success"/>
            <Label ID="lblConfirmPassword" class="mb-2">Confirmar contraseña</Label>
            <asp:TextBox ID="TextBox1" runat="server" TextMode="Password" CssClass="d-block mb-3 form-control border border-success"/>
            <asp:Label runat="server" Text="" ID="lblValidacion" CssClass=""/>
            <div class="d-flex justify-content-center">
                <asp:Button runat="server" ID="btnRegistrar" Text="Registrarse" CssClass="btn btn-success px-sm-5 mt-4" OnClick="btnRegistrar_Click"/>

            </div>
        </div>
        <div class="col">
            <img src="Resources/Register_logo.png" width="500" class="mt-5"/>
        </div>
    </Main>

</asp:Content>
