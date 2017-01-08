<?php 
require_once("GenericTable.class.php");
/**
 * Classe modelo da camada de persistencia - FormaPagamento
 * Persistencia com banco de dados
 * Centralizador dos metodos de acesso ao banco de dados
 * @author Davidson Ferreira
 * @editor IHMHR
 */
class FormaPagamento extends GenericTable
{
    private $table = "forma_pagamento";
    private $primary = array("idforma_pagamento");
    private $foreign = array("forma_pagamento");
    private $schema = "Pinga";
    private $idformaPagamento;
    private $formaPagamento;
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
        $sql = "SELECT idforma_pagamento, forma_pagamento, created, modified
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
     * @return string $idformaPagamento
     */
    public function getIdformaPagamento() 
    {
	    return $this->idformaPagamento;
    }
        
    /**
     * @param string $idformaPagamento
     */
    public function setIdformaPagamento($idformaPagamento) 
    {
	    $this->idformaPagamento = (string) $idformaPagamento;
    }
        
    /**
     * @return string $formaPagamento
     */
    public function getFormaPagamento() 
    {
	    return $this->formaPagamento;
    }
        
    /**
     * @param string $formaPagamento
     */
    public function setFormaPagamento($formaPagamento) 
    {
	    $this->formaPagamento = (string) $formaPagamento;
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