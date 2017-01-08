<?php 
require_once("GenericTable.class.php");
/**
 * Classe modelo da camada de persistencia - Parcelamento
 * Persistencia com banco de dados
 * Centralizador dos metodos de acesso ao banco de dados
 * @author Davidson Ferreira
 * @editor IHMHR
 */
class Parcelamento extends GenericTable
{
    private $table = "parcelamento";
    private $primary = array("idparcelamento");
    private $foreign = array();
    private $schema = "Pinga";
    private $idparcelamento;
    private $EntradaSaida;
    private $dataPagamento;
    private $dataVencimento;
    private $parcelas;
    private $juros;
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
        $sql = "SELECT idparcelamento, Entrada_Saida, data_pagamento, data_vencimento, parcelas, juros, created, modified
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
     * @return string $idparcelamento
     */
    public function getIdparcelamento() 
    {
	    return $this->idparcelamento;
    }
        
    /**
     * @param string $idparcelamento
     */
    public function setIdparcelamento($idparcelamento) 
    {
	    $this->idparcelamento = (string) $idparcelamento;
    }
        
    /**
     * @return string $EntradaSaida
     */
    public function getEntradaSaida() 
    {
	    return $this->EntradaSaida;
    }
        
    /**
     * @param string $EntradaSaida
     */
    public function setEntradaSaida($EntradaSaida) 
    {
	    $this->EntradaSaida = (string) $EntradaSaida;
    }
        
    /**
     * @return string $dataPagamento
     */
    public function getDataPagamento() 
    {
	    return $this->dataPagamento;
    }
        
    /**
     * @param string $dataPagamento
     */
    public function setDataPagamento($dataPagamento) 
    {
	    $this->dataPagamento = (string) $dataPagamento;
    }
        
    /**
     * @return string $dataVencimento
     */
    public function getDataVencimento() 
    {
	    return $this->dataVencimento;
    }
        
    /**
     * @param string $dataVencimento
     */
    public function setDataVencimento($dataVencimento) 
    {
	    $this->dataVencimento = (string) $dataVencimento;
    }
        
    /**
     * @return integer $parcelas
     */
    public function getParcelas() 
    {
	    return $this->parcelas;
    }
        
    /**
     * @param integer $parcelas
     */
    public function setParcelas($parcelas) 
    {
	    $this->parcelas = (string) $parcelas;
    }
        
    /**
     * @return string $juros
     */
    public function getJuros() 
    {
	    return $this->juros;
    }
        
    /**
     * @param string $juros
     */
    public function setJuros($juros) 
    {
	    $this->juros = (string) $juros;
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