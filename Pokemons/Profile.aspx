<%@ Page Title="Mi perfil" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="Pokemons.Profile" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">    
    <h1>Mí Perfil</h1>
    <div class="row">
        <section class="col-3 me-lg-5" >
            <asp:Label Text="Email" runat="server" />
            <asp:TextBox ID="txtEmail" runat="server" cssClass="mb-3 form-control"/> 

            <asp:Label Text="Nombre" runat="server" />
            <asp:TextBox ID="txtNombre" runat="server" cssClass="mb-3 form-control"/> 

            <asp:Label Text="Edad" runat="server"/>
            <asp:TextBox ID="txtEdad" runat="server" cssClass="mb-3 form-control"/>

            <asp:Button runat="server" Text="Guardar Datos" CssClass="btn btn-primary"/>
        </section>
        <div class="col-4">
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <input type="file" name="txtImagen" runat="server" ID="txtImagen" class="form-control mb-3" onchange="txtImagen_onchange"/>
                    <asp:Image ImageUrl="https://static.vecteezy.com/system/resources/previews/004/141/669/non_2x/no-photo-or-blank-image-icon-loading-images-or-missing-image-mark-image-not-available-or-image-coming-soon-sign-simple-nature-silhouette-in-frame-isolated-illustration-vector.jpg" ID="imgPerfil" CssClass="img-fluid" runat="server" />
                </ContentTemplate>
            </asp:UpdatePanel>
       </div>    
     </div>

</asp:Content>
