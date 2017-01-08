<?php 
require_once("GenericTable.class.php");
/**
 * Classe modelo da camada de persistencia - ProdutoQuantidade
 * Persistencia com banco de dados
 * Centralizador dos metodos de acesso ao banco de dados
 * @author Davidson Ferreira
 * @editor IHMHR
 */
class ProdutoQuantidade extends GenericTable
{
    private $table = "produto_quantidade";
    private $primary = array("idproduto_quantidade");
    private $foreign = array();
    private $schema = "Pinga";
    private $idprodutoQuantidade;
    private $quantidadeMinima;
    private $quantidadeMaxima;
    private $quantidadeRecomendaEstoque;
    private $quantidadeSolicitarCompra;
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
        $sql = "SELECT idproduto_quantidade, quantidade_minima, quantidade_maxima, quantidade_recomenda_estoque, quantidade_solicitar_compra, created, modified
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
     * @return string $idprodutoQuantidade
     */
    public function getIdprodutoQuantidade() 
    {
	    return $this->idprodutoQuantidade;
    }
        
    /**
     * @param string $idprodutoQuantidade
     */
    public function setIdprodutoQuantidade($idprodutoQuantidade) 
    {
	    $this->idprodutoQuantidade = (string) $idprodutoQuantidade;
    }
        
    /**
     * @return integer $quantidadeMinima
     */
    public function getQuantidadeMinima() 
    {
	    return $this->quantidadeMinima;
    }
        
    /**
     * @param integer $quantidadeMinima
     */
    public function setQuantidadeMinima($quantidadeMinima) 
    {
	    $this->quantidadeMinima = (string) $quantidadeMinima;
    }
        
    /**
     * @return integer $quantidadeMaxima
     */
    public function getQuantidadeMaxima() 
    {
	    return $this->quantidadeMaxima;
    }
        
    /**
     * @param integer $quantidadeMaxima
     */
    public function setQuantidadeMaxima($quantidadeMaxima) 
    {
	    $this->quantidadeMaxima = (string) $quantidadeMaxima;
    }
        
    /**
     * @return integer $quantidadeRecomendaEstoque
     */
    public function getQuantidadeRecomendaEstoque() 
    {
	    return $this->quantidadeRecomendaEstoque;
    }
        
    /**
     * @param integer $quantidadeRecomendaEstoque
     */
    public function setQuantidadeRecomendaEstoque($quantidadeRecomendaEstoque) 
    {
	    $this->quantidadeRecomendaEstoque = (string) $quantidadeRecomendaEstoque;
    }
        
    /**
     * @return integer $quantidadeSolicitarCompra
     */
    public function getQuantidadeSolicitarCompra() 
    {
	    return $this->quantidadeSolicitarCompra;
    }
        
    /**
     * @param integer $quantidadeSolicitarCompra
     */
    public function setQuantidadeSolicitarCompra($quantidadeSolicitarCompra) 
    {
	    $this->quantidadeSolicitarCompra = (string) $quantidadeSolicitarCompra;
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