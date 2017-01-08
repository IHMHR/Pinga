<?php 
require_once("GenericTable.class.php");
/**
 * Classe modelo da camada de persistencia - Estado
 * Persistencia com banco de dados
 * Centralizador dos metodos de acesso ao banco de dados
 * @author Davidson Ferreira
 * @editor IHMHR
 */
class Estado extends GenericTable
{
    private $table = "estado";
    private $primary = array("idestado");
    private $foreign = array("uf","pais_idpais");
    private $schema = "Pinga";
    private $idestado;
    private $estado;
    private $uf;
    private $capital;
    private $paisIdpais;

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
        $sql = "SELECT idestado, estado, uf, capital, pais_idpais
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
     * @return string $idestado
     */
    public function getIdestado() 
    {
	    return $this->idestado;
    }
        
    /**
     * @param string $idestado
     */
    public function setIdestado($idestado) 
    {
	    $this->idestado = (string) $idestado;
    }
        
    /**
     * @return string $estado
     */
    public function getEstado() 
    {
	    return $this->estado;
    }
        
    /**
     * @param string $estado
     */
    public function setEstado($estado) 
    {
	    $this->estado = (string) $estado;
    }
        
    /**
     * @return string $uf
     */
    public function getUf() 
    {
	    return $this->uf;
    }
        
    /**
     * @param string $uf
     */
    public function setUf($uf) 
    {
	    $this->uf = (string) $uf;
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
     * @return string $paisIdpais
     */
    public function getPaisIdpais() 
    {
	    return $this->paisIdpais;
    }
        
    /**
     * @param string $paisIdpais
     */
    public function setPaisIdpais($paisIdpais) 
    {
	    $this->paisIdpais = (string) $paisIdpais;
    }
    
}
?>