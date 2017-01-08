<?php 
require_once("GenericTable.class.php");
/**
 * Classe modelo da camada de persistencia - Produto
 * Persistencia com banco de dados
 * Centralizador dos metodos de acesso ao banco de dados
 * @author Davidson Ferreira
 * @editor IHMHR
 */
class Produto extends GenericTable
{
    private $table = "produto";
    private $primary = array("idproduto");
    private $foreign = array("produto","tipo_litragem_idtipo_litragem","produto_quantidade_idproduto_quantidade");
    private $schema = "Pinga";
    private $idproduto;
    private $produto;
    private $tipoLitragemIdtipoLitragem;
    private $litragem;
    private $vendendo;
    private $valorUnitario;
    private $produtoQuantidadeIdprodutoQuantidade;
    private $created;
    private $modified;

    /**
     * Construtor da classe
     */
    function __construct()
    {

    }

    /**
     * Add registro no banco de dados
     * @return 
     */
    public function insert()
    {
        
    }

    /**
     * Update em registro no banco de dados
     * @return 
     */
    public function update()
    {
        
    }

    /**
     * Delete em registro no banco de dados
     * @return
     */
    public function delete()
    {
        
    }

    /**
     * Seleciona registros do banco de dados
     * @return
     */
    public function selectAll()
    {
        $sql = "SELECT idproduto, produto, tipo_litragem_idtipo_litragem, litragem, vendendo, valor_unitario, produto_quantidade_idproduto_quantidade, created, modified
                  FROM " . $this->schema . "." . $this->table;
    }

    /**
     * Retorna o nome da tabela
     * @return string $table
     */
    public function getTable()
    {
        return $this->table;
    }

    /**
     * Retorna o nome do schema
     * @return string $schema
     */
    public function getSchema()
    {
        return $this->schema;
    }

    /**
     * Retorna o nome da(s) primary key
     * @return Array $primary
     */
    public function getPrimary()
    {
        return $this->primary;
    }

    /**
     * Retorna o nome da(s) foreign key
     * @return Array $foreign
     */
    public function getForeign()
    {
        return $this->foreign;
    }

    
    /**
     * @return string $idproduto
     */
    public function getIdproduto() 
    {
	    return $this->idproduto;
    }
        
    /**
     * @param string $idproduto
     */
    public function setIdproduto($idproduto) 
    {
	    $this->idproduto = (string) $idproduto;
    }
        
    /**
     * @return string $produto
     */
    public function getProduto() 
    {
	    return $this->produto;
    }
        
    /**
     * @param string $produto
     */
    public function setProduto($produto) 
    {
	    $this->produto = (string) $produto;
    }
        
    /**
     * @return string $tipoLitragemIdtipoLitragem
     */
    public function getTipoLitragemIdtipoLitragem() 
    {
	    return $this->tipoLitragemIdtipoLitragem;
    }
        
    /**
     * @param string $tipoLitragemIdtipoLitragem
     */
    public function setTipoLitragemIdtipoLitragem($tipoLitragemIdtipoLitragem) 
    {
	    $this->tipoLitragemIdtipoLitragem = (string) $tipoLitragemIdtipoLitragem;
    }
        
    /**
     * @return integer $litragem
     */
    public function getLitragem() 
    {
	    return $this->litragem;
    }
        
    /**
     * @param integer $litragem
     */
    public function setLitragem($litragem) 
    {
	    $this->litragem = (string) $litragem;
    }
        
    /**
     * @return string $vendendo
     */
    public function getVendendo() 
    {
	    return $this->vendendo;
    }
        
    /**
     * @param string $vendendo
     */
    public function setVendendo($vendendo) 
    {
	    $this->vendendo = (string) $vendendo;
    }
        
    /**
     * @return string $valorUnitario
     */
    public function getValorUnitario() 
    {
	    return $this->valorUnitario;
    }
        
    /**
     * @param string $valorUnitario
     */
    public function setValorUnitario($valorUnitario) 
    {
	    $this->valorUnitario = (string) $valorUnitario;
    }
        
    /**
     * @return string $produtoQuantidadeIdprodutoQuantidade
     */
    public function getProdutoQuantidadeIdprodutoQuantidade() 
    {
	    return $this->produtoQuantidadeIdprodutoQuantidade;
    }
        
    /**
     * @param string $produtoQuantidadeIdprodutoQuantidade
     */
    public function setProdutoQuantidadeIdprodutoQuantidade($produtoQuantidadeIdprodutoQuantidade) 
    {
	    $this->produtoQuantidadeIdprodutoQuantidade = (string) $produtoQuantidadeIdprodutoQuantidade;
    }
        
    /**
     * @return string $created
     */
    public function getCreated() 
    {
	    return $this->created;
    }
        
    /**
     * @param string $created
     */
    public function setCreated($created) 
    {
	    $this->created = (string) $created;
    }
        
    /**
     * @return string $modified
     */
    public function getModified() 
    {
	    return $this->modified;
    }
        
    /**
     * @param string $modified
     */
    public function setModified($modified) 
    {
	    $this->modified = (string) $modified;
    }
    
}
?>