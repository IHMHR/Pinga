<?php 
require_once("GenericTable.class.php");
/**
 * Classe modelo da camada de persistencia - TipoLogradouro
 * Persistencia com banco de dados
 * Centralizador dos metodos de acesso ao banco de dados
 * @author Davidson Ferreira
 * @editor IHMHR
 */
class TipoLogradouro extends GenericTable
{
    private $table = "tipo_logradouro";
    private $primary = array("idtipo_logradouro");
    private $foreign = array("tipo_logradouro");
    private $schema = "Pinga";
    private $idtipoLogradouro;
    private $tipoLogradouro;

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
        $sql = "SELECT idtipo_logradouro, tipo_logradouro
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
     * @return string $idtipoLogradouro
     */
    public function getIdtipoLogradouro() 
    {
	    return $this->idtipoLogradouro;
    }
        
    /**
     * @param string $idtipoLogradouro
     */
    public function setIdtipoLogradouro($idtipoLogradouro) 
    {
	    $this->idtipoLogradouro = (string) $idtipoLogradouro;
    }
        
    /**
     * @return string $tipoLogradouro
     */
    public function getTipoLogradouro() 
    {
	    return $this->tipoLogradouro;
    }
        
    /**
     * @param string $tipoLogradouro
     */
    public function setTipoLogradouro($tipoLogradouro) 
    {
	    $this->tipoLogradouro = (string) $tipoLogradouro;
    }
    
}
?>