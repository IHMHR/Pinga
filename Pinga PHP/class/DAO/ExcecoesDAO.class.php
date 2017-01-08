<?php 
require_once("GenericTable.class.php");
/**
 * Classe modelo da camada de persistencia - Excecoes
 * Persistencia com banco de dados
 * Centralizador dos metodos de acesso ao banco de dados
 * @author Davidson Ferreira
 * @editor IHMHR
 */
class Excecoes extends GenericTable
{
    private $table = "excecoes";
    private $primary = array("idexcecoes");
    private $foreign = array();
    private $schema = "Pinga";
    private $idexcecoes;
    private $data;
    private $status;

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
        $sql = "SELECT idexcecoes, data, status
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
     * @return string $idexcecoes
     */
    public function getIdexcecoes() 
    {
	    return $this->idexcecoes;
    }
        
    /**
     * @param string $idexcecoes
     */
    public function setIdexcecoes($idexcecoes) 
    {
	    $this->idexcecoes = (string) $idexcecoes;
    }
        
    /**
     * @return string $data
     */
    public function getData() 
    {
	    return $this->data;
    }
        
    /**
     * @param string $data
     */
    public function setData($data) 
    {
	    $this->data = (string) $data;
    }
        
    /**
     * @return string $status
     */
    public function getStatus() 
    {
	    return $this->status;
    }
        
    /**
     * @param string $status
     */
    public function setStatus($status) 
    {
	    $this->status = (string) $status;
    }
    
}
?>