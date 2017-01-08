<?php 
require_once("GenericTable.class.php");
/**
 * Classe modelo da camada de persistencia - Entrada
 * Persistencia com banco de dados
 * Centralizador dos metodos de acesso ao banco de dados
 * @author Davidson Ferreira
 * @editor IHMHR
 */
class Entrada extends GenericTable
{
    private $table = "entrada";
    private $primary = array("identrada");
    private $foreign = array("tipo_litragem_idtipo_litragem","custo_idcusto","parcelamento_idparcelamento");
    private $schema = "Pinga";
    private $identrada;
    private $data;
    private $litragem;
    private $tipoLitragemIdtipoLitragem;
    private $valor;
    private $custoIdcusto;
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
        $sql = "SELECT identrada, data, litragem, tipo_litragem_idtipo_litragem, valor, custo_idcusto, parcelamento_idparcelamento, created, modified
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
     * @return string $identrada
     */
    public function getIdentrada() 
    {
	    return $this->identrada;
    }
        
    /**
     * @param string $identrada
     */
    public function setIdentrada($identrada) 
    {
	    $this->identrada = (string) $identrada;
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
     * @return integer $litragem
     */
    public function getLitragem() 
    {
	    return $this->litragem;
    }
        
    /**
     * @param integer $litragem
     */
    public function setLitragem($litragem) 
    {
	    $this->litragem = (string) $litragem;
    }
        
    /**
     * @return string $tipoLitragemIdtipoLitragem
     */
    public function getTipoLitragemIdtipoLitragem() 
    {
	    return $this->tipoLitragemIdtipoLitragem;
    }
        
    /**
     * @param string $tipoLitragemIdtipoLitragem
     */
    public function setTipoLitragemIdtipoLitragem($tipoLitragemIdtipoLitragem) 
    {
	    $this->tipoLitragemIdtipoLitragem = (string) $tipoLitragemIdtipoLitragem;
    }
        
    /**
     * @return string $valor
     */
    public function getValor() 
    {
	    return $this->valor;
    }
        
    /**
     * @param string $valor
     */
    public function setValor($valor) 
    {
	    $this->valor = (string) $valor;
    }
        
    /**
     * @return string $custoIdcusto
     */
    public function getCustoIdcusto() 
    {
	    return $this->custoIdcusto;
    }
        
    /**
     * @param string $custoIdcusto
     */
    public function setCustoIdcusto($custoIdcusto) 
    {
	    $this->custoIdcusto = (string) $custoIdcusto;
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