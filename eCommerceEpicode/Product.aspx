<%@ Page Title="" Language="C#" MasterPageFile="~/MasteryPages/TemplateBase.Master" AutoEventWireup="true" CodeBehind="Product.aspx.cs" Inherits="eCommerceEpicode.Product" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1 id="productTitle" runat="server"></h1>
    <div id="productPage" runat="server">
        <div id="productImgDiv" runat="server">
            <asp:Image ID="productImg" runat="server" />
        </div>
        <div id="productTxt" runat="server">

        </div>
        <div id="addToCartDiv" runat="server">
            <form id="formQuantita" runat="server">
                <asp:Label ID="lblQuantita" runat="server" Text="Quantità: 1"></asp:Label>
                <asp:DropDownList ID="quantita" runat="server" OnSelectedIndexChanged="quantita_SelectedIndexChanged" AutoPostBack="true"> 
                    <asp:ListItem Value="0" Text="Seleziona..." Selected="True"></asp:ListItem>
                    <asp:ListItem Value="1" Text="1"></asp:ListItem>
                    <asp:ListItem Value="2" Text="2"></asp:ListItem>
                    <asp:ListItem Value="3" Text="3"></asp:ListItem>
                    <asp:ListItem Value="4" Text="4"></asp:ListItem>
                    <asp:ListItem Value="5" Text="5"></asp:ListItem>
                    <asp:ListItem Value="6" Text="6"></asp:ListItem>
                    <asp:ListItem Value="7" Text="7"></asp:ListItem>
                    <asp:ListItem Value="8" Text="8"></asp:ListItem>
                    <asp:ListItem Value="9" Text="9"></asp:ListItem>
                    <asp:ListItem Value="10" Text="10"></asp:ListItem>
                </asp:DropDownList>
                <asp:Button ID="btnAddToCart" runat="server" Text="Aggiungi al carrello" OnClick="btnAddToCart_Click" />
                <asp:Label ID="lblAddedToCart" runat="server" Text="Prodotto aggiunto al carrello!"></asp:Label>
            </form>
        </div>
    </div>
</asp:Content>
