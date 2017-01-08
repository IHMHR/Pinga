<?php 
require_once("GenericTable.class.php");
/**
 * Classe modelo da camada de persistencia - TipoPeriodicidadeEntrega
 * Persistencia com banco de dados
 * Centralizador dos metodos de acesso ao banco de dados
 * @author Davidson Ferreira
 * @editor IHMHR
 */
class TipoPeriodicidadeEntrega extends GenericTable
{
    private $table = "tipo_periodicidade_entrega";
    private $primary = array("idtipo_periodicidade_entrega");
    private $foreign = array("tipo_periodicidade_entrega");
    private $schema = "Pinga";
    private $idtipoPeriodicidadeEntrega;
    private $tipoPeriodicidadeEntrega;
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
        $sql = "SELECT idtipo_periodicidade_entrega, tipo_periodicidade_entrega, status
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
     * @return string $idtipoPeriodicidadeEntrega
     */
    public function getIdtipoPeriodicidadeEntrega() 
    {
	    return $this->idtipoPeriodicidadeEntrega;
    }
        
    /**
     * @param string $idtipoPeriodicidadeEntrega
     */
    public function setIdtipoPeriodicidadeEntrega($idtipoPeriodicidadeEntrega) 
    {
	    $this->idtipoPeriodicidadeEntrega = (string) $idtipoPeriodicidadeEntrega;
    }
        
    /**
     * @return string $tipoPeriodicidadeEntrega
     */
    public function getTipoPeriodicidadeEntrega() 
    {
	    return $this->tipoPeriodicidadeEntrega;
    }
        
    /**
     * @param string $tipoPeriodicidadeEntrega
     */
    public function setTipoPeriodicidadeEntrega($tipoPeriodicidadeEntrega) 
    {
	    $this->tipoPeriodicidadeEntrega = (string) $tipoPeriodicidadeEntrega;
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