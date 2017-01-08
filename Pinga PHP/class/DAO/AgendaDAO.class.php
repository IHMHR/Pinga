<?php 
require_once("GenericTable.class.php");
/**
 * Classe modelo da camada de persistencia - Agenda
 * Persistencia com banco de dados
 * Centralizador dos metodos de acesso ao banco de dados
 * @author Davidson Ferreira
 * @editor IHMHR
 */
class Agenda extends GenericTable
{
    private $table = "agenda";
    private $primary = array("idagenda");
    private $foreign = array("visita_idvisita","horario_idhorario");
    private $schema = "Pinga";
    private $idagenda;
    private $visitaIdvisita;
    private $horarioIdhorario;
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
        $sql = "SELECT idagenda, visita_idvisita, horario_idhorario, created, modified
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
     * @return string $idagenda
     */
    public function getIdagenda() 
    {
	    return $this->idagenda;
    }
        
    /**
     * @param string $idagenda
     */
    public function setIdagenda($idagenda) 
    {
	    $this->idagenda = (string) $idagenda;
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