<%@ Page Title="Lista Pokemons " Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PokemonsLista.aspx.cs" Inherits="Pokemons.PokemonsLista" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main class="d-flex justify-content-center">
        <section clas="row">
            <div class="col-9 mb-3">
                <asp:GridView runat="server" ID="dgvPokemonsLista" DataKeyNames="Id" CssClass="table table-dark col-9" 
                    AutoGenerateColumns="false" 
                    OnSelectedIndexChanged="dgvPokemonsLista_SelectedIndexChanged" Width="860px">                   
                   <columns>
                        <asp:boundfield  headertext="Numero" datafield="Numero"/>
                        <asp:boundfield  headertext="Nombre" datafield="Nombre"/>
                        <asp:BoundField HeaderText="Tipo" DataField="Tipo.Descripcion" />
                        <asp:BoundField HeaderText="Tipo" DataField="Debilidad.Descripcion"/>
                        <asp:commandfield headertext="acción" showselectbutton="true" SelectText='<i class="bi bi-pencil-fill"></i>' ItemStyle-ForeColor="#0099ff"/> 
                    </columns>
                </asp:GridView>
            </div>
            <div class="mb-3">
                <asp:HyperLink runat="server" ID="btnAgregar" NavigateUrl="~/PokemonForm.aspx" CssClass="btn btn-primary" Text="Agregar Pokemon"/>
            </div>
        </section>
    </main>
</asp:Content>