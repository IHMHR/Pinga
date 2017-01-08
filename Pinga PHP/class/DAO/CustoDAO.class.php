<?php 
require_once("GenericTable.class.php");
/**
 * Classe modelo da camada de persistencia - Custo
 * Persistencia com banco de dados
 * Centralizador dos metodos de acesso ao banco de dados
 * @author Davidson Ferreira
 * @editor IHMHR
 */
class Custo extends GenericTable
{
    private $table = "custo";
    private $primary = array("idcusto");
    private $foreign = array("tipo_custo_idtipo_custo");
    private $schema = "Pinga";
    private $idcusto;
    private $tipoCustoIdtipoCusto;
    private $valor;
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
        $sql = "SELECT idcusto, tipo_custo_idtipo_custo, valor, created, modified
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
     * @return string $idcusto
     */
    public function getIdcusto() 
    {
	    return $this->idcusto;
    }
        
    /**
     * @param string $idcusto
     */
    public function setIdcusto($idcusto) 
    {
	    $this->idcusto = (string) $idcusto;
    }
        
    /**
     * @return string $tipoCustoIdtipoCusto
     */
    public function getTipoCustoIdtipoCusto() 
    {
	    return $this->tipoCustoIdtipoCusto;
    }
        
    /**
     * @param string $tipoCustoIdtipoCusto
     */
    public function setTipoCustoIdtipoCusto($tipoCustoIdtipoCusto) 
    {
	    $this->tipoCustoIdtipoCusto = (string) $tipoCustoIdtipoCusto;
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