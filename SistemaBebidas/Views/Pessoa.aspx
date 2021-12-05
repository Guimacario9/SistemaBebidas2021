<%@ Page Title="" Language="C#" MasterPageFile="~/Template/Site.Master" AutoEventWireup="true" CodeBehind="Pessoa.aspx.cs" Inherits="SistemaBebidas.Views.Pessoa" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <asp:UpdatePanel runat="server" ID="UpCadastro" UpdateMode="Conditional">
        <ContentTemplate>

            <asp:HiddenField ID="hfCodigo" runat="server" />
            <div class="row">
                <div class="col-4 form-group">
                    <asp:Label Text="Nome" ID="lbNome" runat="server" CssClass="form-label" AssociatedControlID="txtNome" />
                    <asp:TextBox runat="server" ID="txtNome" CssClass="form-control" />
                </div>

                <div class="col-4 form-group">
                    <asp:Label Text="Endereco" ID="lbEndereco" runat="server" CssClass="form-label" AssociatedControlID="txtEndereco" />
                    <asp:TextBox runat="server" ID="txtEndereco" CssClass="form-control" />
                </div>

                <div class="col-4 form-group">
                    <asp:Label Text="Telefone" ID="lbTelefone" runat="server" CssClass="form-label" AssociatedControlID="txtTelefone" />
                    <asp:TextBox runat="server" ID="txtTelefone" CssClass="form-control" />
                </div>
                 <div class="col-4 form-group">
                    <asp:Label Text="Telefone" ID="lblCpf" runat="server" CssClass="form-label" AssociatedControlID="txtCpf" />
                    <asp:TextBox runat="server" ID="txtCpf" CssClass="form-control" />
                </div>

            </div>
            <br />
            <div class="row">
                <div class="col-4 form-group">
                    <br />
                    <asp:CheckBox Text="É Funcionario?" ID="chkFuncionario"
                        runat="server" 
                        OnCheckedChanged="chkFuncionario_CheckedChanged"
                        AutoPostBack="true"
                        />
                </div>

                <asp:Panel runat="server" ID="pnlSetor" Visible="false"
                    CssClass="col-4">
                    <asp:Label Text="Setor" runat="server" />
                    <asp:DropDownList runat="server" ID="ddlSetor"
                        CssClass="form-control"
                        DataTextField="Nome" DataValueField="Codigo">
                    </asp:DropDownList>
                </asp:Panel>


                <div class="col-4 form-group">
                    <br />  
                    <asp:Button Text="Salvar" ID="btnSalvar" OnClick="btnSalvar_Click" runat="server" CssClass="btn btn-success" />
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
                        <th>Endereco</th>
                        <th>Telefone</th>
                        <th>CPF</th>
                        <th>Setor</th>
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
                                <td><%# Eval("Endereco")%></td>
                                <td><%# Eval("Telefone")%></td>
                                <td><%# Eval("CPF")%></td>
                                <td><%# Eval("NomeSetor")%></td>
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

