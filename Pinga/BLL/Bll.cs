using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Bll
    {
        public Classes.ClsLogin login = null;
        public Classes.ClsTipoContinente tipoContinente = null;
        public Classes.ClsContinente continente = null;
        public Classes.ClsPais pais = null;
        public Classes.ClsEstado estado = null;
        public Classes.ClsCidade cidade = null;
        public Classes.ClsBairro bairro = null;
        public Classes.ClsEndereco endereco = null;
        public Classes.ClsTipoComplemento tipoComplemento = null;
        public Classes.ClsTipoCusto tipoCusto = null;
        public Classes.ClsTipoLitragem tipoLitragem = null;
        public Classes.ClsTipoLogradouro tipoLogradouro = null;
        public Classes.ClsTipoTelefone tipoTelefone = null;
        public Classes.ClsCliente cliente = null;
        public Classes.ClsCusto custo = null;
        public Classes.ClsEmail email = null;
        public Classes.ClsEmailDominio emailDominio = null;
        public Classes.ClsEmailLocalidade emailLocalidade = null;
        public Classes.ClsEntrada entrada = null;
        public Classes.ClsEstoque estoque = null;
        public Classes.ClsFase fase = null;
        public Classes.ClsFormaPagamento formaPagamento = null;
        public Classes.ClsFornecedor fornecedor = null;
        public Classes.ClsInformacoesCliente informacoeCliente = null;
        public Classes.ClsItensSaida itensSaida = null;
        public Classes.ClsOperadora operadora = null;
        public Classes.ClsParceiro parceiro = null;
        public Classes.ClsParcelamento parcelamento = null;
        public Classes.ClsProduto produto = null;
        public Classes.ClsProdutoQuantidade produtoQuantidade = null;
        public Classes.ClsSaida saida = null;
        public Classes.ClsTelefone telefone = null;

        public Bll(string classe)
        {
            if(!string.IsNullOrEmpty(classe))
            {
                switch (classe)
                {
                    case "Login":
                        login = new Classes.ClsLogin();
                        break;

                    case "Tipo_Continente":
                        tipoContinente = new Classes.ClsTipoContinente();
                        break;

                    case "Continente":
                        continente = new Classes.ClsContinente();
                        break;

                    case "Pais":
                        pais = new Classes.ClsPais();
                        break;

                    case "Estado":
                        estado = new Classes.ClsEstado();
                        break;

                    case "Cidade":
                        cidade = new Classes.ClsCidade();
                        break;

                    case "Bairro":
                        bairro = new Classes.ClsBairro();
                        break;

                    case "Endereco":
                        endereco = new Classes.ClsEndereco();
                        break;

                    case "Tipo_Logradouro":
                        tipoLogradouro = new Classes.ClsTipoLogradouro();
                        break;

                    case "Tipo_Complemento":
                        tipoComplemento = new Classes.ClsTipoComplemento();
                        break;

                    case "Tipo_Telefone":
                        tipoTelefone = new Classes.ClsTipoTelefone();
                        break;

                    case "Operadora":
                        operadora = new Classes.ClsOperadora();
                        break;

                    case "Telefone":
                        telefone = new Classes.ClsTelefone();
                        break;

                    case "Tipo_Litragem":
                        tipoLitragem = new Classes.ClsTipoLitragem();
                        break;

                    case "Tipo_Custo":
                        tipoCusto = new Classes.ClsTipoCusto();
                        break;

                    case "Custo":
                        custo = new Classes.ClsCusto();
                        break;

                    case "Parcelamento":
                        parcelamento = new Classes.ClsParcelamento();
                        break;

                    case "Entrada":
                        entrada = new Classes.ClsEntrada();
                        break;

                    case "Fornecedor":
                        fornecedor = new Classes.ClsFornecedor();
                        break;

                    case "Fase":
                        fase = new Classes.ClsFase();
                        break;

                    case "Forma_Pagamento":
                        formaPagamento = new Classes.ClsFormaPagamento();
                        break;

                    case "Email_Localidade":
                        emailLocalidade = new Classes.ClsEmailLocalidade();
                        break;

                    case "Email_Dominio":
                        emailDominio = new Classes.ClsEmailDominio();
                        break;

                    case "Email":
                        email = new Classes.ClsEmail();
                        break;

                    case "Cliente":
                        cliente = new Classes.ClsCliente();
                        break;

                    case "Informacoes_Cliente":
                        informacoeCliente = new Classes.ClsInformacoesCliente();
                        break;

                    case "Produto_Quantidade":
                        produtoQuantidade = new Classes.ClsProdutoQuantidade();
                        break;

                    case "Produto":
                        produto = new Classes.ClsProduto();
                        break;

                    case "Parceiro":
                        parceiro = new Classes.ClsParceiro();
                        break;

                    case "Saida":
                        saida = new Classes.ClsSaida();
                        break;

                    case "Itens_Saida":
                        itensSaida = new Classes.ClsItensSaida();
                        break;

                    case "Estoque":
                        estoque = new Classes.ClsEstoque();
                        break;
                }
            }
            else
            {
                throw new ArgumentNullException("O argumento deve ser informado.");
            }
        }
    }
}
