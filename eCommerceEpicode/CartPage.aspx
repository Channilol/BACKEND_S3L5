<%@ Page Title="" Language="C#" MasterPageFile="~/MasteryPages/TemplateBase.Master" AutoEventWireup="true" CodeBehind="CartPage.aspx.cs" Inherits="eCommerceEpicode.CartPage" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1 id="cartTitle" runat="server">
        <a href="/Home.aspx">Home</a> > Carrello
    </h1>
    <form id="deleteForm" runat="server">
        <div id="cartPageLeft" runat="server">
            <asp:Repeater ID="cartRepeater" runat="server">
                <ItemTemplate>
                    <div class="cartItem">
                        <div class="cartItemImg">
                            <asp:Image ID="cartItmImg" runat="server" ImageUrl='<%# Eval("Img") %>' />
                        </div>
                        <div class="cartItemTxt">
                            <h2><%# Eval("Nome") %></h2>
                            <h4><%# Eval("Brand") %></h4>
                            <p>Quantità: <%# Eval("Quantità") %>, Prezzo totale: <%# Convert.ToInt32(Eval("Quantità")) * Convert.ToInt32(Eval("Prezzo")) %>€</p>
                            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# "Product.aspx?id=" + Eval("IdProdotto") %>'>Dettagli</asp:HyperLink>
                            <asp:Button ID="btnDelete" runat="server" Text="Rimuovi" CommandArgument='<%# Eval("IdCarrello") %>' onCommand="btnDelete_Command"/>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
        <div class="cartPageRight">
            <asp:Label ID="lblSumPrice" runat="server" Text="0"></asp:Label>
            <asp:Button ID="btnDeleteAll" runat="server" Text="Svuota il carrello" OnClick="btnDeleteAll_Click"/>
            <asp:Label ID="lblDeletedProd" runat="server" Text=""></asp:Label>
        </div>
    </form>
</asp:Content>