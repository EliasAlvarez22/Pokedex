<%@ Page Title="Lista Pokemons " Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PokemonsLista.aspx.cs" Inherits="Pokemons.PokemonsLista" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main>               
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <div class="row mb-3">
                    <label> Filtros</label>
                    <asp:TextBox runat="server" ID="txtFiltro" AutoPostBack="true" CssClass="form-control" OnTextChanged="txtFiltro_TextChanged" Width="300px"/>                            
                    <asp:CheckBox runat="server" ID="cbxFiltroAvanzado" AutoPostBack="true" OnCheckedChanged="cbxFiltroAvanzado_CheckedChanged" CssClass="" Width="10px"/>
                    <label>Filtro avanzado</label>
                </div>

                <div class=" col-3">
                    <asp:DropDownList runat="server" ID="ddlCampos" CssClass="form-control">
                        <asp:ListItem Text="Número" Selected="True"/>
                        <asp:ListItem Text="Nombre"/>
                        <asp:ListItem Text="Tipo Elemento"/>
                    </asp:DropDownList>
                    
                </div>                           
            </ContentTemplate>
        </asp:UpdatePanel>
       
        <asp:UpdatePanel runat="server" >
            <ContentTemplate>
                <section class=" d-flex flex-column align-items-lg-center">
            <div class="col-9 mb-3">
                <asp:GridView runat="server" ID="dgvPokemonsLista" DataKeyNames="Id" CssClass="table table-dark col-9" 
                    AutoGenerateColumns="false" OnSelectedIndexChanged="dgvPokemonsLista_SelectedIndexChanged" Width="860px"
                    OnPageIndexChanging="dgvPokemonsLista_PageIndexChanging" AllowPaging="true"
                    PageSize="7">                   
                   <columns>
                        <asp:boundfield  headertext="Numero" datafield="Numero"/>
                        <asp:boundfield  headertext="Nombre" datafield="Nombre"/>
                        <asp:BoundField HeaderText="Tipo" DataField="Tipo.Descripcion" />
                        <asp:BoundField HeaderText="Debilidad" DataField="Debilidad.Descripcion"/>
                        <asp:commandfield headertext="Acción" showselectbutton="true" SelectText='<i class="bi bi-pencil-fill"></i>' ItemStyle-ForeColor="#0099ff"/> 
                    </columns>
                </asp:GridView>
            </div>    
            <asp:HyperLink runat="server" ID="btnAgregar" NavigateUrl="~/PokemonForm.aspx" CssClass="btn btn-primary mb-3" Text="Agregar Pokemon"/>
            
        </section>
            </ContentTemplate>
        </asp:UpdatePanel>
        
    </main>
</asp:Content>