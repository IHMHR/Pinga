<?php 
require_once("GenericTable.class.php");
/**
 * Classe modelo da camada de persistencia - ParceiroHasVisita
 * Persistencia com banco de dados
 * Centralizador dos metodos de acesso ao banco de dados
 * @author Davidson Ferreira
 * @editor IHMHR
 */
class ParceiroHasVisita extends GenericTable
{
    private $table = "parceiro_has_visita";
    private $primary = array();
    private $foreign = array("parceiro_idparceiro","visita_idvisita");
    private $schema = "Pinga";
    private $idparceiroHasVisita;
    private $parceiroIdparceiro;
    private $visitaIdvisita;

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
        $sql = "SELECT idparceiro_has_visita, parceiro_idparceiro, visita_idvisita
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
     * @return string $idparceiroHasVisita
     */
    public function getIdparceiroHasVisita() 
    {
	    return $this->idparceiroHasVisita;
    }
        
    /**
     * @param string $idparceiroHasVisita
     */
    public function setIdparceiroHasVisita($idparceiroHasVisita) 
    {
	    $this->idparceiroHasVisita = (string) $idparceiroHasVisita;
    }
        
    /**
     * @return string $parceiroIdparceiro
     */
    public function getParceiroIdparceiro() 
    {
	    return $this->parceiroIdparceiro;
    }
        
    /**
     * @param string $parceiroIdparceiro
     */
    public function setParceiroIdparceiro($parceiroIdparceiro) 
    {
	    $this->parceiroIdparceiro = (string) $parceiroIdparceiro;
    }
        
    /**
     * @return string $visitaIdvisita
     */
    public function getVisitaIdvisita() 
    {
	    return $this->visitaIdvisita;
    }
        
    /**
     * @param string $visitaIdvisita
     */
    public function setVisitaIdvisita($visitaIdvisita) 
    {
	    $this->visitaIdvisita = (string) $visitaIdvisita;
    }
    
}
?>