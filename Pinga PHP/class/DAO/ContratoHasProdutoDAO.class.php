<?php 
require_once("GenericTable.class.php");
/**
 * Classe modelo da camada de persistencia - ContratoHasProduto
 * Persistencia com banco de dados
 * Centralizador dos metodos de acesso ao banco de dados
 * @author Davidson Ferreira
 * @editor IHMHR
 */
class ContratoHasProduto extends GenericTable
{
    private $table = "contrato_has_produto";
    private $primary = array("idcontrato_has_produto");
    private $foreign = array("contrato_idcontrato","produto_idproduto");
    private $schema = "Pinga";
    private $idcontratoHasProduto;
    private $contratoIdcontrato;
    private $produtoIdproduto;
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
        $sql = "SELECT idcontrato_has_produto, contrato_idcontrato, produto_idproduto, created, modified
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
     * @return string $idcontratoHasProduto
     */
    public function getIdcontratoHasProduto() 
    {
	    return $this->idcontratoHasProduto;
    }
        
    /**
     * @param string $idcontratoHasProduto
     */
    public function setIdcontratoHasProduto($idcontratoHasProduto) 
    {
	    $this->idcontratoHasProduto = (string) $idcontratoHasProduto;
    }
        
    /**
     * @return string $contratoIdcontrato
     */
    public function getContratoIdcontrato() 
    {
	    return $this->contratoIdcontrato;
    }
        
    /**
     * @param string $contratoIdcontrato
     */
    public function setContratoIdcontrato($contratoIdcontrato) 
    {
	    $this->contratoIdcontrato = (string) $contratoIdcontrato;
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