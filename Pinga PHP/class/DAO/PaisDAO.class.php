<?php 
require_once("GenericTable.class.php");
/**
 * Classe modelo da camada de persistencia - Pais
 * Persistencia com banco de dados
 * Centralizador dos metodos de acesso ao banco de dados
 * @author Davidson Ferreira
 * @editor IHMHR
 */
class Pais extends GenericTable
{
    private $table = "pais";
    private $primary = array("idpais");
    private $foreign = array("pais","DDI","sigla","continente_idcontinente");
    private $schema = "Pinga";
    private $idpais;
    private $pais;
    private $idioma;
    private $colacao;
    private $DDI;
    private $sigla;
    private $fusoHorario;
    private $continenteIdcontinente;

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
        $sql = "SELECT idpais, pais, idioma, colacao, DDI, sigla, fuso_horario, continente_idcontinente
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
     * @return string $idpais
     */
    public function getIdpais() 
    {
	    return $this->idpais;
    }
        
    /**
     * @param string $idpais
     */
    public function setIdpais($idpais) 
    {
	    $this->idpais = (string) $idpais;
    }
        
    /**
     * @return string $pais
     */
    public function getPais() 
    {
	    return $this->pais;
    }
        
    /**
     * @param string $pais
     */
    public function setPais($pais) 
    {
	    $this->pais = (string) $pais;
    }
        
    /**
     * @return string $idioma
     */
    public function getIdioma() 
    {
	    return $this->idioma;
    }
        
    /**
     * @param string $idioma
     */
    public function setIdioma($idioma) 
    {
	    $this->idioma = (string) $idioma;
    }
        
    /**
     * @return string $colacao
     */
    public function getColacao() 
    {
	    return $this->colacao;
    }
        
    /**
     * @param string $colacao
     */
    public function setColacao($colacao) 
    {
	    $this->colacao = (string) $colacao;
    }
        
    /**
     * @return string $DDI
     */
    public function getDDI() 
    {
	    return $this->DDI;
    }
        
    /**
     * @param string $DDI
     */
    public function setDDI($DDI) 
    {
	    $this->DDI = (string) $DDI;
    }
        
    /**
     * @return string $sigla
     */
    public function getSigla() 
    {
	    return $this->sigla;
    }
        
    /**
     * @param string $sigla
     */
    public function setSigla($sigla) 
    {
	    $this->sigla = (string) $sigla;
    }
        
    /**
     * @return string $fusoHorario
     */
    public function getFusoHorario() 
    {
	    return $this->fusoHorario;
    }
        
    /**
     * @param string $fusoHorario
     */
    public function setFusoHorario($fusoHorario) 
    {
	    $this->fusoHorario = (string) $fusoHorario;
    }
        
    /**
     * @return string $continenteIdcontinente
     */
    public function getContinenteIdcontinente() 
    {
	    return $this->continenteIdcontinente;
    }
        
    /**
     * @param string $continenteIdcontinente
     */
    public function setContinenteIdcontinente($continenteIdcontinente) 
    {
	    $this->continenteIdcontinente = (string) $continenteIdcontinente;
    }
    
}
?>