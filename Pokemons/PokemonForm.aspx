<%@ Page Title="Alta Pokemon" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PokemonForm.aspx.cs" Inherits="Pokemons.PokemonForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">   
    <div class="row">
        <div class="col-6">
            <div class="mb-3">
                <Label for="txtId" class="form-label">ID</Label>
                <asp:TextBox runat="server" ID="txtId" CssClass="form-control"/>
            </div>
            <div class="mb-3">
                <Label for="txtNombre" class="form-label">Nombre</Label>
                <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control"/>
            </div>
            <div class="mb-3">
                <Label for="txtNumero" class="form-label">Numero</Label>
                <asp:TextBox runat="server" ID="txtNumero" CssClass="form-control"/>
            </div>                                               
            <div class="mb-3">
                <Label for="ddlTipo" class="form-label me-3">Tipo</Label>
                <asp:DropDownList runat="server" ID="ddlTipo" CssClass="form-select pr-3"/>
            </div>
            <div class="mb-3">
                <Label for="ddlDebilidad" class="form-label me-3">Debilidad</Label>
                <asp:DropDownList runat="server" ID="ddlDebilidad" CssClass="form-select pr-3"/>
            </div>
            <div class="mb-3">
                <asp:Button runat="server" ID="btnAgregar"  Text="Agregar" CssClass="btn btn-success me-6" OnClick="btnAgregar_Click"/>
                <asp:HyperLink runat="server" ID="btnCancelar" CssClass="btn btn-danger" NavigateUrl="~/PokemonsLista.aspx" Text="Cancelar"/>
            </div>            
        </div>
        <div class="col-6">
            <div class="mb-3">
                <Label for="txtDescripcion" class="form-label">Descripción</Label>
                <asp:TextBox runat="server" ID="txtDescripcion" textMode="MultiLine" CssClass="form-control"/>
            </div>
            <asp:UpdatePanel runat="server" ID="udpPanel">
                <ContentTemplate>
                    <div class="mb-3">
                        <label for="txtUrlImagen" class="form-label">Url Imagen</label>
                        <asp:TextBox runat="server" ID="txtUrlImagen" CssClass="form-control" OnTextChanged="txtUrlImagen_TextChanged"  
                            AutoPostBack="true"/>                        
                    </div>
                    <asp:Image ImageUrl="https://upload.wikimedia.org/wikipedia/commons/thumb/5/51/Pokebola-pokeball-png-0.png/800px-Pokebola-pokeball-png-0.png"
                        runat="server" ID="imgPokemon" Width="60%" CssClass="ms-lg-5" Height="300px"/>
                </ContentTemplate>
            </asp:UpdatePanel>
            
        </div>
    </div>
</asp:Content>
