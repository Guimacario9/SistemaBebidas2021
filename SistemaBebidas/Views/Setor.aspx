<%@ Page Title="" Language="C#" MasterPageFile="~/Template/Site.Master" AutoEventWireup="true" CodeBehind="Setor.aspx.cs" Inherits="SistemaBebidas.Views.Setor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:UpdatePanel runat="server" ID="upCadastro" UpdateMode="Conditional">
        <ContentTemplate>

            <asp:HiddenField runat="server" ID="hfCodigo" />
            <div class="row">
                <div class="col-4 form-group">
                    <asp:Label Text="Nome" ID="lbNome" runat="server" CssClass="form-label" AssociatedControlID="txtNome" />
                    <asp:TextBox runat="server" ID="txtNome" CssClass="form-control" />
                </div>
                
                </div>
                <div class="col-4 form-group">
                    <asp:Label Text="Gerente" ID="lbGerente" runat="server" CssClass="form-label" AssociatedControlID="ddlGerente" />

                    <asp:DropDownList runat="server" ID="ddlGerente"
                        CssClass="form-control"
                        DataValueField="Codigo"
                        DataTextField="Nome">
                    </asp:DropDownList>


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
                        <th>Nome</th>
                        <th>Gerente</th>
                        <th>Ações</th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater runat="server" ID="rpLista"
                        OnItemCommand="rpLista_ItemCommand">
                        <ItemTemplate>
                            <tr>
                                <td><%# Eval("Codigo")%></td>
                                <td><%# Eval("Nome")%></td>
                                <td><%# Eval("NomeGerente")%></td>
                                <td>

                                    <div class="dropdown">
                                        <button class="btn btn-primary dropdown-toggle"
                                            type="button" id="dropdownMenuButton1"
                                            data-bs-toggle="dropdown" aria-expanded="false">
                                            Ações
                                        </button>
                                        <ul class="dropdown-menu" aria-labelledby="dropdownMenuButton1">
                                            <li>

                                                <asp:LinkButton Text="Editar"
                                                    CommandName="Editar"
                                                    CommandArgument='<%#Eval("Codigo")%>'
                                                    runat="server"
                                                    CssClass="dropdown-item" />

                                                <asp:LinkButton Text="Remover"
                                                    CommandName="Remover"
                                                    CommandArgument='<%#Eval("Codigo")%>'
                                                    OnClientClick="return confirm('remover');"
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
