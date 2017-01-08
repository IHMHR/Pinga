<?php 
require_once("GenericTable.class.php");
/**
 * Classe modelo da camada de persistencia - PeriodicidadeEntrega
 * Persistencia com banco de dados
 * Centralizador dos metodos de acesso ao banco de dados
 * @author Davidson Ferreira
 * @editor IHMHR
 */
class PeriodicidadeEntrega extends GenericTable
{
    private $table = "periodicidade_entrega";
    private $primary = array("idperiodicidade_entrega");
    private $foreign = array("tipo_periodicidade_entrega_idtipo_periodicidade_entrega","cliente_idcliente");
    private $schema = "Pinga";
    private $idperiodicidadeEntrega;
    private $tipoPeriodicidadeEntregaIdtipoPeriodicidadeEntrega;
    private $clienteIdcliente;
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
        $sql = "SELECT idperiodicidade_entrega, tipo_periodicidade_entrega_idtipo_periodicidade_entrega, cliente_idcliente, status
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
     * @return string $idperiodicidadeEntrega
     */
    public function getIdperiodicidadeEntrega() 
    {
	    return $this->idperiodicidadeEntrega;
    }
        
    /**
     * @param string $idperiodicidadeEntrega
     */
    public function setIdperiodicidadeEntrega($idperiodicidadeEntrega) 
    {
	    $this->idperiodicidadeEntrega = (string) $idperiodicidadeEntrega;
    }
        
    /**
     * @return string $tipoPeriodicidadeEntregaIdtipoPeriodicidadeEntrega
     */
    public function getTipoPeriodicidadeEntregaIdtipoPeriodicidadeEntrega() 
    {
	    return $this->tipoPeriodicidadeEntregaIdtipoPeriodicidadeEntrega;
    }
        
    /**
     * @param string $tipoPeriodicidadeEntregaIdtipoPeriodicidadeEntrega
     */
    public function setTipoPeriodicidadeEntregaIdtipoPeriodicidadeEntrega($tipoPeriodicidadeEntregaIdtipoPeriodicidadeEntrega) 
    {
	    $this->tipoPeriodicidadeEntregaIdtipoPeriodicidadeEntrega = (string) $tipoPeriodicidadeEntregaIdtipoPeriodicidadeEntrega;
    }
        
    /**
     * @return string $clienteIdcliente
     */
    public function getClienteIdcliente() 
    {
	    return $this->clienteIdcliente;
    }
        
    /**
     * @param string $clienteIdcliente
     */
    public function setClienteIdcliente($clienteIdcliente) 
    {
	    $this->clienteIdcliente = (string) $clienteIdcliente;
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