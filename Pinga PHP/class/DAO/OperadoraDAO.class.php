<?php 
require_once("GenericTable.class.php");
/**
 * Classe modelo da camada de persistencia - Operadora
 * Persistencia com banco de dados
 * Centralizador dos metodos de acesso ao banco de dados
 * @author Davidson Ferreira
 * @editor IHMHR
 */
class Operadora extends GenericTable
{
    private $table = "operadora";
    private $primary = array("idoperadora");
    private $foreign = array("operadora");
    private $schema = "Pinga";
    private $idoperadora;
    private $operadora;
    private $razaoSocial;
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
        $sql = "SELECT idoperadora, operadora, razao_social, status
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
     * @return string $idoperadora
     */
    public function getIdoperadora() 
    {
	    return $this->idoperadora;
    }
        
    /**
     * @param string $idoperadora
     */
    public function setIdoperadora($idoperadora) 
    {
	    $this->idoperadora = (string) $idoperadora;
    }
        
    /**
     * @return string $operadora
     */
    public function getOperadora() 
    {
	    return $this->operadora;
    }
        
    /**
     * @param string $operadora
     */
    public function setOperadora($operadora) 
    {
	    $this->operadora = (string) $operadora;
    }
        
    /**
     * @return string $razaoSocial
     */
    public function getRazaoSocial() 
    {
	    return $this->razaoSocial;
    }
        
    /**
     * @param string $razaoSocial
     */
    public function setRazaoSocial($razaoSocial) 
    {
	    $this->razaoSocial = (string) $razaoSocial;
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