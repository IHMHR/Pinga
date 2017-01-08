<?php 
require_once("GenericTable.class.php");
/**
 * Classe modelo da camada de persistencia - ParceiroHasHorario
 * Persistencia com banco de dados
 * Centralizador dos metodos de acesso ao banco de dados
 * @author Davidson Ferreira
 * @editor IHMHR
 */
class ParceiroHasHorario extends GenericTable
{
    private $table = "parceiro_has_horario";
    private $primary = array("idparceiro_has_horario");
    private $foreign = array("parceiro_idparceiro","horario_idhorario");
    private $schema = "Pinga";
    private $idparceiroHasHorario;
    private $parceiroIdparceiro;
    private $horarioIdhorario;

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
        $sql = "SELECT idparceiro_has_horario, parceiro_idparceiro, horario_idhorario
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
     * @return string $idparceiroHasHorario
     */
    public function getIdparceiroHasHorario() 
    {
	    return $this->idparceiroHasHorario;
    }
        
    /**
     * @param string $idparceiroHasHorario
     */
    public function setIdparceiroHasHorario($idparceiroHasHorario) 
    {
	    $this->idparceiroHasHorario = (string) $idparceiroHasHorario;
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
     * @return string $horarioIdhorario
     */
    public function getHorarioIdhorario() 
    {
	    return $this->horarioIdhorario;
    }
        
    /**
     * @param string $horarioIdhorario
     */
    public function setHorarioIdhorario($horarioIdhorario) 
    {
	    $this->horarioIdhorario = (string) $horarioIdhorario;
    }
    
}
?>