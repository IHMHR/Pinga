<?php 
require_once("GenericTable.class.php");
/**
 * Classe modelo da camada de persistencia - Saida
 * Persistencia com banco de dados
 * Centralizador dos metodos de acesso ao banco de dados
 * @author Davidson Ferreira
 * @editor IHMHR
 */
class Saida extends GenericTable
{
    private $table = "saida";
    private $primary = array("idsaida");
    private $foreign = array("parceiro_idparceiro","cliente_idcliente","fase_idfase","forma_pagamento_idforma_pagamento","parcelamento_idparcelamento");
    private $schema = "Pinga";
    private $idsaida;
    private $data;
    private $parceiroIdparceiro;
    private $clienteIdcliente;
    private $faseIdfase;
    private $formaPagamentoIdformaPagamento;
    private $parcelamentoIdparcelamento;
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
        $sql = "SELECT idsaida, data, parceiro_idparceiro, cliente_idcliente, fase_idfase, forma_pagamento_idforma_pagamento, parcelamento_idparcelamento, created, modified
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
     * @return string $idsaida
     */
    public function getIdsaida() 
    {
	    return $this->idsaida;
    }
        
    /**
     * @param string $idsaida
     */
    public function setIdsaida($idsaida) 
    {
	    $this->idsaida = (string) $idsaida;
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
     * @return string $faseIdfase
     */
    public function getFaseIdfase() 
    {
	    return $this->faseIdfase;
    }
        
    /**
     * @param string $faseIdfase
     */
    public function setFaseIdfase($faseIdfase) 
    {
	    $this->faseIdfase = (string) $faseIdfase;
    }
        
    /**
     * @return string $formaPagamentoIdformaPagamento
     */
    public function getFormaPagamentoIdformaPagamento() 
    {
	    return $this->formaPagamentoIdformaPagamento;
    }
        
    /**
     * @param string $formaPagamentoIdformaPagamento
     */
    public function setFormaPagamentoIdformaPagamento($formaPagamentoIdformaPagamento) 
    {
	    $this->formaPagamentoIdformaPagamento = (string) $formaPagamentoIdformaPagamento;
    }
        
    /**
     * @return string $parcelamentoIdparcelamento
     */
    public function getParcelamentoIdparcelamento() 
    {
	    return $this->parcelamentoIdparcelamento;
    }
        
    /**
     * @param string $parcelamentoIdparcelamento
     */
    public function setParcelamentoIdparcelamento($parcelamentoIdparcelamento) 
    {
	    $this->parcelamentoIdparcelamento = (string) $parcelamentoIdparcelamento;
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