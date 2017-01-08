<?php 
require_once("GenericTable.class.php");
/**
 * Classe modelo da camada de persistencia - Estoque
 * Persistencia com banco de dados
 * Centralizador dos metodos de acesso ao banco de dados
 * @author Davidson Ferreira
 * @editor IHMHR
 */
class Estoque extends GenericTable
{
    private $table = "estoque";
    private $primary = array("idestoque");
    private $foreign = array("produto_idproduto");
    private $schema = "Pinga";
    private $idestoque;
    private $produtoIdproduto;
    private $quantidade;
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
        $sql = "SELECT idestoque, produto_idproduto, quantidade, created, modified
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
     * @return string $idestoque
     */
    public function getIdestoque() 
    {
	    return $this->idestoque;
    }
        
    /**
     * @param string $idestoque
     */
    public function setIdestoque($idestoque) 
    {
	    $this->idestoque = (string) $idestoque;
    }
        
    /**
     * @return string $produtoIdproduto
     */
    public function getProdutoIdproduto() 
    {
	    return $this->produtoIdproduto;
    }
        
    /**
     * @param string $produtoIdproduto
     */
    public function setProdutoIdproduto($produtoIdproduto) 
    {
	    $this->produtoIdproduto = (string) $produtoIdproduto;
    }
        
    /**
     * @return integer $quantidade
     */
    public function getQuantidade() 
    {
	    return $this->quantidade;
    }
        
    /**
     * @param integer $quantidade
     */
    public function setQuantidade($quantidade) 
    {
	    $this->quantidade = (string) $quantidade;
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