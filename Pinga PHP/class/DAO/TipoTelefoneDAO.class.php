<?php 
require_once("GenericTable.class.php");
/**
 * Classe modelo da camada de persistencia - TipoTelefone
 * Persistencia com banco de dados
 * Centralizador dos metodos de acesso ao banco de dados
 * @author Davidson Ferreira
 * @editor IHMHR
 */
class TipoTelefone extends GenericTable
{
    private $table = "tipo_telefone";
    private $primary = array("idtipo_telefone");
    private $foreign = array("tipo_telefone");
    private $schema = "Pinga";
    private $idtipoTelefone;
    private $tipoTelefone;

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
        $sql = "SELECT idtipo_telefone, tipo_telefone
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
     * @return string $idtipoTelefone
     */
    public function getIdtipoTelefone() 
    {
	    return $this->idtipoTelefone;
    }
        
    /**
     * @param string $idtipoTelefone
     */
    public function setIdtipoTelefone($idtipoTelefone) 
    {
	    $this->idtipoTelefone = (string) $idtipoTelefone;
    }
        
    /**
     * @return string $tipoTelefone
     */
    public function getTipoTelefone() 
    {
	    return $this->tipoTelefone;
    }
        
    /**
     * @param string $tipoTelefone
     */
    public function setTipoTelefone($tipoTelefone) 
    {
	    $this->tipoTelefone = (string) $tipoTelefone;
    }
    
}
?>