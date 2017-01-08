<?php 
require_once("GenericTable.class.php");
/**
 * Classe modelo da camada de persistencia - TipoComplemento
 * Persistencia com banco de dados
 * Centralizador dos metodos de acesso ao banco de dados
 * @author Davidson Ferreira
 * @editor IHMHR
 */
class TipoComplemento extends GenericTable
{
    private $table = "tipo_complemento";
    private $primary = array("idtipo_complemento");
    private $foreign = array("tipo_complemento");
    private $schema = "Pinga";
    private $idtipoComplemento;
    private $tipoComplemento;

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
        $sql = "SELECT idtipo_complemento, tipo_complemento
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
     * @return string $idtipoComplemento
     */
    public function getIdtipoComplemento() 
    {
	    return $this->idtipoComplemento;
    }
        
    /**
     * @param string $idtipoComplemento
     */
    public function setIdtipoComplemento($idtipoComplemento) 
    {
	    $this->idtipoComplemento = (string) $idtipoComplemento;
    }
        
    /**
     * @return string $tipoComplemento
     */
    public function getTipoComplemento() 
    {
	    return $this->tipoComplemento;
    }
        
    /**
     * @param string $tipoComplemento
     */
    public function setTipoComplemento($tipoComplemento) 
    {
	    $this->tipoComplemento = (string) $tipoComplemento;
    }
    
}
?>