<%@ Page Title="Alta de Auto" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AutoForm.aspx.cs" Inherits="Pokemons.AutoForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">
        <div class="col-6">
            <div class="mb-3">
                <Label for="txtId" class="form-label">ID</Label>
                <asp:TextBox runat="server" ID="txtId" CssClass="form-control"/>
            </div>
            <div class="mb-3">
                <Label for="txtModelo" class="form-label">Modelo</Label>
                <asp:TextBox runat="server" ID="txtModelo" CssClass="form-control"/>
            </div>
            <div class="mb-3">
                <Label for="txtDescripcion" class="form-label">Descripcion</Label>
                <asp:TextBox runat="server" ID="txtDescripcion" textMode="MultiLine" CssClass="form-control"/>
            </div>
             <div class="mb-3">
                <Label for="txtFecha" class="form-label">Fecha</Label>
                <asp:TextBox runat="server" TextMode="Date" ID="txtFecha" CssClass="form-control"/>
            </div>
            <div class="mb-3">
                <Label for="ddlColores" class="form-label me-3">Color</Label>
                <asp:DropDownList runat="server" ID="ddlColores" CssClass="form-select btn btn-secondary w-auto pr-3"/>
            </div>
            <div class="mb-3">
                <Label for="cbxUsado" class="form-label me-3">Usado</Label>
                <asp:CheckBox runat="server" ID="cbxUsado" CssClass=""/>
            </div>

            <div class="mb-3">
                <Label for="rbnImportado" class="form-label me-3">Importado</Label>
                <asp:RadioButton runat="server" ID="rbnImportado" GroupName="Importado" CssClass="" />

                <Label for="rbnNacional" class="form-label me-3">Nacional </Label>
                <asp:RadioButton runat="server" Checked="true" ID="rbnNacional" CssClass="" GroupName="Importado" />
            </div
            <div class="mb-3">
                <asp:Button runat="server" ID="btnAgregar"  Text="Agregar" CssClass="btn btn-success me-6" OnClick="btnAgregar_Click"/>
                <asp:HyperLink runat="server" ID="btnCancelar" CssClass="btn btn-danger" NavigateUrl="~/Default.aspx" Text="Cancelar"/>
            </div>

        </div>
    </div>
</asp:Content>
