<?php 
require_once("GenericTable.class.php");
/**
 * Classe modelo da camada de persistencia - Cidade
 * Persistencia com banco de dados
 * Centralizador dos metodos de acesso ao banco de dados
 * @author Davidson Ferreira
 * @editor IHMHR
 */
class Cidade extends GenericTable
{
    private $table = "cidade";
    private $primary = array("idcidade");
    private $foreign = array("estado_idestado");
    private $schema = "Pinga";
    private $idcidade;
    private $cidade;
    private $DDD;
    private $capital;
    private $estadoIdestado;

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
        $sql = "SELECT idcidade, cidade, DDD, capital, estado_idestado
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
     * @return string $idcidade
     */
    public function getIdcidade() 
    {
	    return $this->idcidade;
    }
        
    /**
     * @param string $idcidade
     */
    public function setIdcidade($idcidade) 
    {
	    $this->idcidade = (string) $idcidade;
    }
        
    /**
     * @return string $cidade
     */
    public function getCidade() 
    {
	    return $this->cidade;
    }
        
    /**
     * @param string $cidade
     */
    public function setCidade($cidade) 
    {
	    $this->cidade = (string) $cidade;
    }
        
    /**
     * @return string $DDD
     */
    public function getDDD() 
    {
	    return $this->DDD;
    }
        
    /**
     * @param string $DDD
     */
    public function setDDD($DDD) 
    {
	    $this->DDD = (string) $DDD;
    }
        
    /**
     * @return string $capital
     */
    public function getCapital() 
    {
	    return $this->capital;
    }
        
    /**
     * @param string $capital
     */
    public function setCapital($capital) 
    {
	    $this->capital = (string) $capital;
    }
        
    /**
     * @return string $estadoIdestado
     */
    public function getEstadoIdestado() 
    {
	    return $this->estadoIdestado;
    }
        
    /**
     * @param string $estadoIdestado
     */
    public function setEstadoIdestado($estadoIdestado) 
    {
	    $this->estadoIdestado = (string) $estadoIdestado;
    }
    
}
?>