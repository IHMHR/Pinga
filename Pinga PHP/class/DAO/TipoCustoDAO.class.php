<?php 
require_once("GenericTable.class.php");
/**
 * Classe modelo da camada de persistencia - TipoCusto
 * Persistencia com banco de dados
 * Centralizador dos metodos de acesso ao banco de dados
 * @author Davidson Ferreira
 * @editor IHMHR
 */
class TipoCusto extends GenericTable
{
    private $table = "tipo_custo";
    private $primary = array("idtipo_custo");
    private $foreign = array("tipo_custo");
    private $schema = "Pinga";
    private $idtipoCusto;
    private $tipoCusto;

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
        $sql = "SELECT idtipo_custo, tipo_custo
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
     * @return string $idtipoCusto
     */
    public function getIdtipoCusto() 
    {
	    return $this->idtipoCusto;
    }
        
    /**
     * @param string $idtipoCusto
     */
    public function setIdtipoCusto($idtipoCusto) 
    {
	    $this->idtipoCusto = (string) $idtipoCusto;
    }
        
    /**
     * @return string $tipoCusto
     */
    public function getTipoCusto() 
    {
	    return $this->tipoCusto;
    }
        
    /**
     * @param string $tipoCusto
     */
    public function setTipoCusto($tipoCusto) 
    {
	    $this->tipoCusto = (string) $tipoCusto;
    }
    
}
?>