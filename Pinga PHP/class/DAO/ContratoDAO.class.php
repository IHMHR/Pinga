<?php 
require_once("GenericTable.class.php");
/**
 * Classe modelo da camada de persistencia - Contrato
 * Persistencia com banco de dados
 * Centralizador dos metodos de acesso ao banco de dados
 * @author Davidson Ferreira
 * @editor IHMHR
 */
class Contrato extends GenericTable
{
    private $table = "contrato";
    private $primary = array("idcontrato");
    private $foreign = array("cliente_idcliente","periodicidade_entrega_idperiodicidade_entrega","forma_pagamento_idforma_pagamento");
    private $schema = "Pinga";
    private $idcontrato;
    private $clienteIdcliente;
    private $dataEntradaVigor;
    private $dataExpiracao;
    private $dataAssinatura;
    private $periodicidadeEntregaIdperiodicidadeEntrega;
    private $prorrogavel;
    private $status;
    private $formaPagamentoIdformaPagamento;
    private $multaQuebra;

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
        $sql = "SELECT idcontrato, cliente_idcliente, data_entrada_vigor, data_expiracao, data_assinatura, periodicidade_entrega_idperiodicidade_entrega, prorrogavel, status, forma_pagamento_idforma_pagamento, multa_quebra
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
     * @return string $idcontrato
     */
    public function getIdcontrato() 
    {
	    return $this->idcontrato;
    }
        
    /**
     * @param string $idcontrato
     */
    public function setIdcontrato($idcontrato) 
    {
	    $this->idcontrato = (string) $idcontrato;
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
     * @return string $dataEntradaVigor
     */
    public function getDataEntradaVigor() 
    {
	    return $this->dataEntradaVigor;
    }
        
    /**
     * @param string $dataEntradaVigor
     */
    public function setDataEntradaVigor($dataEntradaVigor) 
    {
	    $this->dataEntradaVigor = (string) $dataEntradaVigor;
    }
        
    /**
     * @return string $dataExpiracao
     */
    public function getDataExpiracao() 
    {
	    return $this->dataExpiracao;
    }
        
    /**
     * @param string $dataExpiracao
     */
    public function setDataExpiracao($dataExpiracao) 
    {
	    $this->dataExpiracao = (string) $dataExpiracao;
    }
        
    /**
     * @return string $dataAssinatura
     */
    public function getDataAssinatura() 
    {
	    return $this->dataAssinatura;
    }
        
    /**
     * @param string $dataAssinatura
     */
    public function setDataAssinatura($dataAssinatura) 
    {
	    $this->dataAssinatura = (string) $dataAssinatura;
    }
        
    /**
     * @return string $periodicidadeEntregaIdperiodicidadeEntrega
     */
    public function getPeriodicidadeEntregaIdperiodicidadeEntrega() 
    {
	    return $this->periodicidadeEntregaIdperiodicidadeEntrega;
    }
        
    /**
     * @param string $periodicidadeEntregaIdperiodicidadeEntrega
     */
    public function setPeriodicidadeEntregaIdperiodicidadeEntrega($periodicidadeEntregaIdperiodicidadeEntrega) 
    {
	    $this->periodicidadeEntregaIdperiodicidadeEntrega = (string) $periodicidadeEntregaIdperiodicidadeEntrega;
    }
        
    /**
     * @return string $prorrogavel
     */
    public function getProrrogavel() 
    {
	    return $this->prorrogavel;
    }
        
    /**
     * @param string $prorrogavel
     */
    public function setProrrogavel($prorrogavel) 
    {
	    $this->prorrogavel = (string) $prorrogavel;
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
     * @return string $multaQuebra
     */
    public function getMultaQuebra() 
    {
	    return $this->multaQuebra;
    }
        
    /**
     * @param string $multaQuebra
     */
    public function setMultaQuebra($multaQuebra) 
    {
	    $this->multaQuebra = (string) $multaQuebra;
    }
    
}
?>