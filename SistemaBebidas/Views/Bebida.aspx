<%@ Page Title="" Language="C#" MasterPageFile="~/Template/Site.Master" AutoEventWireup="true" CodeBehind="Bebida.aspx.cs" Inherits="SistemaBebidas.Views.Compra" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:UpdatePanel runat="server" ID="upCadastro" UpdateMode="Conditional">
        <ContentTemplate>

            <asp:HiddenField runat="server" ID="hfCodigo" />

            <div class="row">
                <div class="col-4 form-group">
                    <asp:Label Text="Codigo" ID="lbCodigo" runat="server" CssClass="form-label" AssociatedControlID="txtCodigo" />
                    <asp:TextBox runat="server" ID="txtCodigo" CssClass="form-control" />
                </div>
                <div class="col-4 form-group">
                    <asp:Label Text="Cliente" ID="lbCliente" runat="server" CssClass="form-label" AssociatedControlID="txtCliente" />
                    <asp:TextBox runat="server" ID="txtCliente" CssClass="form-control" />
                </div>

                <div class="col-4 form-group">
                    <asp:Label Text="Cidade" ID="lbCidade" runat="server" CssClass="form-label" AssociatedControlID="txtCidade" />
                    <asp:TextBox runat="server" ID="txtCidade" CssClass="form-control" />
                </div>
                <div class="col-4 form-group">
                    <asp:Label Text="Cidade" ID="lbProduto" runat="server" CssClass="form-label" AssociatedControlID="txtProduto" />
                    <asp:TextBox runat="server" ID="txtProduto" CssClass="form-control" />
                </div>
                 <div class="col-4 form-group">
                    <asp:Label Text="Cidade" ID="lbQuantidade" runat="server" CssClass="form-label" AssociatedControlID="txtQuantidade" />
                    <asp:TextBox runat="server" ID="txtQuantidade" CssClass="form-control" />
                </div>
                <div class="col-4 form-group">
                    <asp:Label Text="Cidade" ID="lbValor" runat="server" CssClass="form-label" AssociatedControlID="txtValor" />
                    <asp:TextBox runat="server" ID="txtValor" CssClass="form-control" />
                </div>
                <div class="col-4 form-group">
                    <br />
                    <asp:Button Text="Salvar" runat="server" ID="btnSalvar" OnClick="btnSalvar_Click" CssClass="btn btn-success" />
                </div>
            </div>

        </ContentTemplate>
    </asp:UpdatePanel>






    <hr />

    <asp:UpdatePanel runat="server" ID="upLista" UpdateMode="Conditional">
        <ContentTemplate>
            <table class="table table-striped table-hover">
                <thead>
                    <tr>
                        <th>Codigo</th>
                        <th>Cliente</th>
                        <th>Cidade</th>
                        <th>Produto</th>
                        <th>Quantidade</th>
                        <th>Valor</th>
                        <th>Ações</th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater runat="server" ID="rpLista"
                        OnItemCommand="rpLista_ItemCommand">
                        <ItemTemplate>
                            <tr>
                                                              
                                <td><%# Eval("Codigo")%></td>
                                <td><%# Eval("CLiente")%></td>
                                <td><%# Eval("Cidade")%></td>
                                <td><%# Eval("Produto")%></td>
                                <td><%# Eval("Quantidade")%></td>
                                <td><%# Eval("Valor")%></td>
                                <td>

                                    <div class="dropdown">
                                        <button class="btn btn-primary dropdown-toggle"
                                            type="button" id="dropdownMenuButton1"
                                            data-bs-toggle="dropdown" aria-expanded="false">
                                            Ações
                                        </button>
                                        <ul class="dropdown-menu" aria-labelledby="dropdownMenuButton1">
                                            <li>

                                                <asp:LinkButton Text="Remover"
                                                    CommandName="Remover"
                                                    CommandArgument='<%#Eval("Codigo")%>'
                                                    OnClientClick="return confirm('remover');"
                                                    runat="server"
                                                    CssClass="dropdown-item" />

                                                <asp:LinkButton Text="Editar"
                                                    CommandName="Editar"
                                                    CommandArgument='<%#Eval("Codigo")%>'
                                                    runat="server"
                                                    CssClass="dropdown-item" />

                                            </li>
                                        </ul>
                                    </div>




                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>


</asp:Content>
