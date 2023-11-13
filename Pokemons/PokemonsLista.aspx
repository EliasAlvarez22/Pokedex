<%@ Page Title="Lista Pokemons " Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PokemonsLista.aspx.cs" Inherits="Pokemons.PokemonsLista" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main>               
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <div class="mt-md-4 mb-4">
                    <label> Filtros</label>
                    <asp:TextBox runat="server" ID="txtFiltro" placeholder="Nombre,numero.."  AutoPostBack="true" CssClass="form-control d-inline-block" OnTextChanged="txtFiltro_TextChanged" Width="300px"/>                            
                    <label>Filtro avanzado</label>
                    <asp:CheckBox runat="server" ID="cbxFiltroAvanzado" AutoPostBack="true" CssClass="ms-lg-2 "/>
                </div>
                <%if (cbxFiltroAvanzado.Checked)
                  {
                %>
                    <section class="row border border-2 border-primary-subtle rounded-4 p-4 mb-4">
                        <div class="col">
                            <label>Campo</label>
                            <asp:DropDownList runat="server" ID="ddlCampos" CssClass="form-control" Width="300px" AutoPostBack="true" OnSelectedIndexChanged="ddlCampos_SelectedIndexChanged">
                                <asp:ListItem Text="Seleccione"/>                                
                                <asp:ListItem Text="Número"/>
                                <asp:ListItem Text="Nombre"/>
                                <asp:ListItem Text="Tipo Elemento"/>
                            </asp:DropDownList>
                        </div>
                        <div class="col">
                            <label>Criterio</label>
                            <asp:DropDownList runat="server" ID="ddlCriterio" CssClass="form-control" Width="300px" >
                            </asp:DropDownList>
                        </div>     
                        <div class="col">
                            <label>Filtro</label>
                            <asp:TextBox runat="server" ID="txtFiltroAvanzado" CssClass="form-control  d-inline-block " Width="300px" />
                        </div>  
                        <div class="col"> 
                            <asp:Button Text="Buscar" runat="server" ID="btnBuscar" OnClick="btnBuscar_Click" CssClass="btn btn-primary mt-4"/>
                        </div>


                    </section>
                <%}%>
            </ContentTemplate>
        </asp:UpdatePanel>
       
        <asp:UpdatePanel runat="server" >
            <ContentTemplate>               
                <section class=" d-flex flex-column align-items-lg-center">
                 <%
                     if (!dgvPokemonsLista.Visible)
                     {
                %>
                        <label class="text-center mb-3 fw-bold fs-2">No hay resultados!</label>        
                <%
                    }
                    else
                    {
                %>
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
                    <%
                    }
                    %>
                    
            <asp:HyperLink runat="server" ID="btnAgregar" NavigateUrl="~/PokemonForm.aspx" CssClass="btn btn-primary mb-3" Text="Agregar Pokemon"/>            
        </section>
            </ContentTemplate>
        </asp:UpdatePanel>
        
    </main>
</asp:Content>