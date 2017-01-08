<?php 
require_once("GenericTable.class.php");
/**
 * Classe modelo da camada de persistencia - ClienteHasRepresentante
 * Persistencia com banco de dados
 * Centralizador dos metodos de acesso ao banco de dados
 * @author Davidson Ferreira
 * @editor IHMHR
 */
class ClienteHasRepresentante extends GenericTable
{
    private $table = "cliente_has_representante";
    private $primary = array();
    private $foreign = array("cliente_idcliente","representante_idrepresentante");
    private $schema = "Pinga";
    private $idclienteHasRepresentante;
    private $clienteIdcliente;
    private $representanteIdrepresentante;
    private $responsavelContrato;

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
        $sql = "SELECT idcliente_has_representante, cliente_idcliente, representante_idrepresentante, responsavel_contrato
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
     * @return string $idclienteHasRepresentante
     */
    public function getIdclienteHasRepresentante() 
    {
	    return $this->idclienteHasRepresentante;
    }
        
    /**
     * @param string $idclienteHasRepresentante
     */
    public function setIdclienteHasRepresentante($idclienteHasRepresentante) 
    {
	    $this->idclienteHasRepresentante = (string) $idclienteHasRepresentante;
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
     * @return string $representanteIdrepresentante
     */
    public function getRepresentanteIdrepresentante() 
    {
	    return $this->representanteIdrepresentante;
    }
        
    /**
     * @param string $representanteIdrepresentante
     */
    public function setRepresentanteIdrepresentante($representanteIdrepresentante) 
    {
	    $this->representanteIdrepresentante = (string) $representanteIdrepresentante;
    }
        
    /**
     * @return string $responsavelContrato
     */
    public function getResponsavelContrato() 
    {
	    return $this->responsavelContrato;
    }
        
    /**
     * @param string $responsavelContrato
     */
    public function setResponsavelContrato($responsavelContrato) 
    {
	    $this->responsavelContrato = (string) $responsavelContrato;
    }
    
}
?>