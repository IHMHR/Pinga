<?php 
require_once("GenericTable.class.php");
/**
 * Classe modelo da camada de persistencia - ClienteHasParceiro
 * Persistencia com banco de dados
 * Centralizador dos metodos de acesso ao banco de dados
 * @author Davidson Ferreira
 * @editor IHMHR
 */
class ClienteHasParceiro extends GenericTable
{
    private $table = "cliente_has_parceiro";
    private $primary = array();
    private $foreign = array("cliente_idcliente","parceiro_idparceiro");
    private $schema = "Pinga";
    private $idclienteHasParceiro;
    private $clienteIdcliente;
    private $parceiroIdparceiro;
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
        $sql = "SELECT idcliente_has_parceiro, cliente_idcliente, parceiro_idparceiro, created, modified
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
     * @return string $idclienteHasParceiro
     */
    public function getIdclienteHasParceiro() 
    {
	    return $this->idclienteHasParceiro;
    }
        
    /**
     * @param string $idclienteHasParceiro
     */
    public function setIdclienteHasParceiro($idclienteHasParceiro) 
    {
	    $this->idclienteHasParceiro = (string) $idclienteHasParceiro;
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
     * @return string $parceiroIdparceiro
     */
    public function getParceiroIdparceiro() 
    {
	    return $this->parceiroIdparceiro;
    }
        
    /**
     * @param string $parceiroIdparceiro
     */
    public function setParceiroIdparceiro($parceiroIdparceiro) 
    {
	    $this->parceiroIdparceiro = (string) $parceiroIdparceiro;
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