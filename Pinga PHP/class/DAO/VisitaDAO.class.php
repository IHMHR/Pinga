<?php 
require_once("GenericTable.class.php");
/**
 * Classe modelo da camada de persistencia - Visita
 * Persistencia com banco de dados
 * Centralizador dos metodos de acesso ao banco de dados
 * @author Davidson Ferreira
 * @editor IHMHR
 */
class Visita extends GenericTable
{
    private $table = "visita";
    private $primary = array("idvisita");
    private $foreign = array("cliente_idcliente");
    private $schema = "Pinga";
    private $idvisita;
    private $clienteIdcliente;
    private $data;
    private $comecou;
    private $terminou;

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
        $sql = "SELECT idvisita, cliente_idcliente, data, comecou, terminou
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
     * @return string $idvisita
     */
    public function getIdvisita() 
    {
	    return $this->idvisita;
    }
        
    /**
     * @param string $idvisita
     */
    public function setIdvisita($idvisita) 
    {
	    $this->idvisita = (string) $idvisita;
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
     * @return string $comecou
     */
    public function getComecou() 
    {
	    return $this->comecou;
    }
        
    /**
     * @param string $comecou
     */
    public function setComecou($comecou) 
    {
	    $this->comecou = (string) $comecou;
    }
        
    /**
     * @return string $terminou
     */
    public function getTerminou() 
    {
	    return $this->terminou;
    }
        
    /**
     * @param string $terminou
     */
    public function setTerminou($terminou) 
    {
	    $this->terminou = (string) $terminou;
    }
    
}
?>