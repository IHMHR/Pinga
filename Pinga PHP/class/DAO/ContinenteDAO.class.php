<?php 
require_once("GenericTable.class.php");
/**
 * Classe modelo da camada de persistencia - Continente
 * Persistencia com banco de dados
 * Centralizador dos metodos de acesso ao banco de dados
 * @author Davidson Ferreira
 * @editor IHMHR
 */
class Continente extends GenericTable
{
    private $table = "continente";
    private $primary = array("idcontinente");
    private $foreign = array("tipo_continente_idtipo_continente");
    private $schema = "Pinga";
    private $idcontinente;
    private $continente;
    private $tipoContinenteIdtipoContinente;

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
        $sql = "SELECT idcontinente, continente, tipo_continente_idtipo_continente
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
     * @return string $idcontinente
     */
    public function getIdcontinente() 
    {
	    return $this->idcontinente;
    }
        
    /**
     * @param string $idcontinente
     */
    public function setIdcontinente($idcontinente) 
    {
	    $this->idcontinente = (string) $idcontinente;
    }
        
    /**
     * @return string $continente
     */
    public function getContinente() 
    {
	    return $this->continente;
    }
        
    /**
     * @param string $continente
     */
    public function setContinente($continente) 
    {
	    $this->continente = (string) $continente;
    }
        
    /**
     * @return string $tipoContinenteIdtipoContinente
     */
    public function getTipoContinenteIdtipoContinente() 
    {
	    return $this->tipoContinenteIdtipoContinente;
    }
        
    /**
     * @param string $tipoContinenteIdtipoContinente
     */
    public function setTipoContinenteIdtipoContinente($tipoContinenteIdtipoContinente) 
    {
	    $this->tipoContinenteIdtipoContinente = (string) $tipoContinenteIdtipoContinente;
    }
    
}
?>