<?php 
require_once("GenericTable.class.php");
/**
 * Classe modelo da camada de persistencia - InformacoesCliente
 * Persistencia com banco de dados
 * Centralizador dos metodos de acesso ao banco de dados
 * @author Davidson Ferreira
 * @editor IHMHR
 */
class InformacoesCliente extends GenericTable
{
    private $table = "informacoes_cliente";
    private $primary = array("idinformacoes_cliente");
    private $foreign = array("cliente_idcliente");
    private $schema = "Pinga";
    private $idinformacoesCliente;
    private $clienteIdcliente;
    private $tipoCliente;
    private $visitado;
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
        $sql = "SELECT idinformacoes_cliente, cliente_idcliente, tipo_cliente, visitado, created, modified
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
     * @return string $idinformacoesCliente
     */
    public function getIdinformacoesCliente() 
    {
	    return $this->idinformacoesCliente;
    }
        
    /**
     * @param string $idinformacoesCliente
     */
    public function setIdinformacoesCliente($idinformacoesCliente) 
    {
	    $this->idinformacoesCliente = (string) $idinformacoesCliente;
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
     * @return string $tipoCliente
     */
    public function getTipoCliente() 
    {
	    return $this->tipoCliente;
    }
        
    /**
     * @param string $tipoCliente
     */
    public function setTipoCliente($tipoCliente) 
    {
	    $this->tipoCliente = (string) $tipoCliente;
    }
        
    /**
     * @return string $visitado
     */
    public function getVisitado() 
    {
	    return $this->visitado;
    }
        
    /**
     * @param string $visitado
     */
    public function setVisitado($visitado) 
    {
	    $this->visitado = (string) $visitado;
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