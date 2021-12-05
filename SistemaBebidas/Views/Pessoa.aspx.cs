using Controle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaBebidas.Views
{
    public partial class Pessoa : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CarregarLista();
                CarregaDDLSetor();
            }
        }
        public static string FormatCNPJ(string CNPJ)
        {
            return Convert.ToUInt64(CNPJ).ToString(@"00\.000\.000\/0000\-00");
        }

        /// <summary>
        /// Formatar uma string CPF
        /// </summary>
        /// <param name="CPF">string CPF sem formatacao</param>
        /// <returns>string CPF formatada</returns>
        /// <example>Recebe '99999999999' Devolve '999.999.999-99'</example>

        public static string FormatCPF(string CPF)
        {
            return Convert.ToUInt64(CPF).ToString(@"000\.000\.000\-00");
        }
        /// <summary>
        /// Retira a Formatacao de uma string CNPJ/CPF
        /// </summary>
        /// <param name="Codigo">string Codigo Formatada</param>
        /// <returns>string sem formatacao</returns>
        /// <example>Recebe '99.999.999/9999-99' Devolve '99999999999999'</example>

        public static string SemFormatacao(string Codigo)
        {
            return Codigo.Replace(".", string.Empty).Replace("-", string.Empty).Replace("/", string.Empty);
        }
        private void CarregaDDLSetor()
        {
            try
            {
                ddlSetor.DataSource = new PessoaControle ().BuscarSetores();
                ddlSetor.DataBind();
            }
            catch (Exception er)
            {
                throw;
            }
        }

        private void CarregarLista()
        {
            try
            {
                PessoaControle ctr = new PessoaControle();
                rpLista.DataSource = ctr.BuscarTodos();
                rpLista.DataBind();

                upLista.Update();
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {

                Modelo.Pessoa p = new Modelo.Pessoa();

                p.Codigo = string.IsNullOrEmpty(hfCodigo.Value) ? 0 : int.Parse(hfCodigo.Value);

                p.Nome = txtNome.Text;
                p.Endereco = txtEndereco.Text;
                p.Telefone = txtTelefone.Text;
                p.Cpf.ToString() = txtCpf.Text;

                PessoaControle ctr = new PessoaControle();
                ctr.Salvar(p);

                CarregarLista();


            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void rpLista_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Remover")
                {
                    int codigo = int.Parse(e.CommandArgument.ToString());
                    Remover(codigo);

                    CarregarLista();
                }
                else if (e.CommandName == "Editar")
                {
                    int codigo = int.Parse(e.CommandArgument.ToString());
                    Editar(codigo);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void Editar(int codigo)
        {
            try
            {
                PessoaControle ctr = new PessoaControle();
                Modelo.Pessoa p = ctr.BuscarPorCodigo(codigo);

                txtNome.Text = p.Nome;
                txtCpf.Text = p.Cpf.ToString();
                txtEndereco.Text = p.Endereco;
                txtTelefone.Text = p.Telefone;
                hfCodigo.Value = p.Codigo.ToString();
                 
                UpCadastro.Update();

            }
            catch (Exception)
            {
                throw;
            }
        }

        private void Remover(int codigo)
        {
            try
            {
                PessoaControle ctr = new PessoaControle();
                ctr.Remover(codigo);

                CarregarLista();
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}