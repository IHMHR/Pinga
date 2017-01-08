<?php 
require_once("GenericTable.class.php");
/**
 * Classe modelo da camada de persistencia - ItensSaida
 * Persistencia com banco de dados
 * Centralizador dos metodos de acesso ao banco de dados
 * @author Davidson Ferreira
 * @editor IHMHR
 */
class ItensSaida extends GenericTable
{
    private $table = "itens_saida";
    private $primary = array("iditens_saida");
    private $foreign = array("saida_idsaida","entrada_identrada","produto_idproduto");
    private $schema = "Pinga";
    private $iditensSaida;
    private $saidaIdsaida;
    private $entradaIdentrada;
    private $produtoIdproduto;
    private $quantidade;
    private $valorSaida;
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
        $sql = "SELECT iditens_saida, saida_idsaida, entrada_identrada, produto_idproduto, quantidade, valor_saida, created, modified
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
     * @return string $iditensSaida
     */
    public function getIditensSaida() 
    {
	    return $this->iditensSaida;
    }
        
    /**
     * @param string $iditensSaida
     */
    public function setIditensSaida($iditensSaida) 
    {
	    $this->iditensSaida = (string) $iditensSaida;
    }
        
    /**
     * @return string $saidaIdsaida
     */
    public function getSaidaIdsaida() 
    {
	    return $this->saidaIdsaida;
    }
        
    /**
     * @param string $saidaIdsaida
     */
    public function setSaidaIdsaida($saidaIdsaida) 
    {
	    $this->saidaIdsaida = (string) $saidaIdsaida;
    }
        
    /**
     * @return string $entradaIdentrada
     */
    public function getEntradaIdentrada() 
    {
	    return $this->entradaIdentrada;
    }
        
    /**
     * @param string $entradaIdentrada
     */
    public function setEntradaIdentrada($entradaIdentrada) 
    {
	    $this->entradaIdentrada = (string) $entradaIdentrada;
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
     * @return string $valorSaida
     */
    public function getValorSaida() 
    {
	    return $this->valorSaida;
    }
        
    /**
     * @param string $valorSaida
     */
    public function setValorSaida($valorSaida) 
    {
	    $this->valorSaida = (string) $valorSaida;
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