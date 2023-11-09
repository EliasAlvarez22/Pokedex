<%@ Page Title="Pokedex Web" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Pokemons._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main class="">
        <h1>Pokedex Web</h1>
        <div class="row row-cols-1 row-cols-md-3 g-4">
            
        <%--<% foreach (Dominio.Pokemon poke in ListaPokemons)
            {
        %>        
                <div class="col d-flex " >
                    <div class="card" style="width:340px">
                        <img src="<%: poke.UrlImagen %>" class="card-img-top " alt="<%:poke.Nombre %>"  style="height:250px" >
                        <div class="card-body" style="" >
                            <h5 class="card-title"><%: poke.Nombre %></h5>
                            <p class="card-text" style="height:40px"><%: poke.Descripcion %></p>
                            <a href="DetallesPokemon.aspx?id=<%: poke.Id %>" class="btn btn-primary">Ver detalles</a>                           
                        </div>
                    </div>
                </div>
        <%} %>--%>
           <asp:Repeater runat="server" ID="RptPokemons" OnItemDataBound="RptPokemons_ItemDataBound">
               <ItemTemplate>
                   <div class="col d-flex " >
                    <div class="card" style="width:340px">
                        <asp:Image ID="imgPokemon" runat="server" ImageUrl='<%#Eval("UrlImagen") %>' CssClass="card-img-top " alt='<%#Eval("Nombre") %>'  style="height:250px"  />
                        <div class="card-body" style="" >
                            <h5 class="card-title"><%#Eval("Nombre") %></h5>
                            <p class="card-text" style="height:40px"><%#Eval("Descripcion") %></p>
                            <a href="DetallesPokemon.aspx?id=<%#Eval("Id") %>" class="btn btn-primary">Ver detalles</a >
                            <asp:Button runat="server" ID="btnEliminar" Text="Eliminar" CommandArgument='<%#Eval("Id") %>' OnClick="btnEliminar_Click" CommandName="IdPokemon" CssClass="btn btn-danger" />
                        </div>
                    </div>
                </div>
               </ItemTemplate>
           </asp:Repeater>
        </div>
    </main>
</asp:Content>
