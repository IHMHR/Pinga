<?php 
require_once("GenericTable.class.php");
/**
 * Classe modelo da camada de persistencia - TipoContinente
 * Persistencia com banco de dados
 * Centralizador dos metodos de acesso ao banco de dados
 * @author Davidson Ferreira
 * @editor IHMHR
 */
class TipoContinente extends GenericTable
{
    private $table = "tipo_continente";
    private $primary = array("idtipo_continente");
    private $foreign = array();
    private $schema = "Pinga";
    private $idtipoContinente;
    private $tipoContinente;
    private $ativo;

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
        $sql = "SELECT idtipo_continente, tipo_continente, ativo
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
     * @return string $idtipoContinente
     */
    public function getIdtipoContinente() 
    {
	    return $this->idtipoContinente;
    }
        
    /**
     * @param string $idtipoContinente
     */
    public function setIdtipoContinente($idtipoContinente) 
    {
	    $this->idtipoContinente = (string) $idtipoContinente;
    }
        
    /**
     * @return string $tipoContinente
     */
    public function getTipoContinente() 
    {
	    return $this->tipoContinente;
    }
        
    /**
     * @param string $tipoContinente
     */
    public function setTipoContinente($tipoContinente) 
    {
	    $this->tipoContinente = (string) $tipoContinente;
    }
        
    /**
     * @return string $ativo
     */
    public function getAtivo() 
    {
	    return $this->ativo;
    }
        
    /**
     * @param string $ativo
     */
    public function setAtivo($ativo) 
    {
	    $this->ativo = (string) $ativo;
    }
    
}
?>