<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Pokemons._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main class="d-flex justify-content-center">
        <section clas="row">
            <div class="col-8 mb-3">
                <asp:GridView runat="server" ID="dgvAutos" DataKeyNames="Id"  OnSelectedIndexChanged="dgvAutos_SelectedIndexChanged" CssClass="table table-dark col-6" AutoGenerateColumns="false">
                    <Columns>
                        <asp:BoundField  HeaderText="Modelo" DataField="Modelo"/>
                        <asp:BoundField  HeaderText="Color" DataField="Color"/>
                        <asp:CheckBoxField HeaderText="Usado" DataField="Usado"/>
                        <asp:CheckBoxField HeaderText="Importado" DataField="Importado"/>
                        <asp:CommandField HeaderText="Acción" SelectText="Seleccionar" ShowSelectButton="true"/>
                    </Columns>
                </asp:GridView>
            </div>
            <div class="mb-3">
                <asp:HyperLink runat="server" ID="btnAgregar" NavigateUrl="~/AutoForm.aspx" CssClass="btn btn-primary" Text="Agregar Auto" />

            </div>
        </section>

    </main>

</asp:Content>
