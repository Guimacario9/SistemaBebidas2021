using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaBebidas.Views
{
    public partial class Compra : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                CarregarLista();
            }

        }

        private void CarregarLista()
        {
            try
            {

                BebidaController ctr = new BebidaController();
                List<Modelo.Bebida> lista = ctr.BuscarTodos();

                rpLista.DataSource = lista;
                rpLista.DataBind();

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

                Modelo.Bebida v = new Modelo.Bebida();

                if (string.IsNullOrEmpty(hfCodigo.Value))
                    v.Codigo = 0;
                else
                    v.Codigo = int.Parse(hfCodigo.Value);



                hfCodigo.Value = v.Codigo.ToString();
                txtCliente.Text = v.CodPessoa.ToString();
                txtCidade.Text = v.Cidade;
                txtProduto.Text = v.Produto;
                txtValor.Text = v.Valor;
                v.CodPessoa = int.Parse(txtCliente.Text);
                v.Cidade = txtCidade.Text;
                v.Produto = txtProduto.Text;
                v.Valor = txtValor.Text;



                BebidaController ctr = new BebidaController();
                ctr.Salvar(v);

                CarregarLista();
                Limpar();

                ScriptManager.RegisterClientScriptBlock(
                    Page,
                    typeof(Page),
                    "AlertaSucesso",
                    "alert('Salvo com sucesso!')",
                    true
                   );

                upLista.Update();

            }
            catch (Exception)
            {
                throw;
            }
        }

        private void Limpar()
        {
            try
            {
                hfCodigo.Value = string.Empty;
                txtCliente.Text = string.Empty;
                txtCidade.Text = string.Empty;
                txtProduto.Text = string.Empty;
                txtValor.Text = string.Empty;
                
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

                BebidaController ctr = new BebidaController();

                Modelo.Bebida v = ctr.BuscarPorCodigo(codigo);

                hfCodigo.Value = v.Codigo.ToString();
                txtCliente.Text = v.CodPessoa.ToString();
                txtCidade.Text = v.Cidade;
                txtProduto.Text = v.Produto;
                txtValor.Text = v.Valor;
                

                upCadastro.Update();

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
                BebidaController ctr = new BebidaController();
                ctr.Remover(codigo);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}