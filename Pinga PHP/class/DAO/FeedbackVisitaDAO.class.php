<?php 
require_once("GenericTable.class.php");
/**
 * Classe modelo da camada de persistencia - FeedbackVisita
 * Persistencia com banco de dados
 * Centralizador dos metodos de acesso ao banco de dados
 * @author Davidson Ferreira
 * @editor IHMHR
 */
class FeedbackVisita extends GenericTable
{
    private $table = "feedback_visita";
    private $primary = array("idfeedback_visita");
    private $foreign = array("visita_idvisita");
    private $schema = "Pinga";
    private $idfeedbackVisita;
    private $visitaIdvisita;
    private $comentario;
    private $nota;
    private $vendaRealizada;
    private $visitaReagendada;
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
        $sql = "SELECT idfeedback_visita, visita_idvisita, comentario, nota, venda_realizada, visita_reagendada, created, modified
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
     * @return string $idfeedbackVisita
     */
    public function getIdfeedbackVisita() 
    {
	    return $this->idfeedbackVisita;
    }
        
    /**
     * @param string $idfeedbackVisita
     */
    public function setIdfeedbackVisita($idfeedbackVisita) 
    {
	    $this->idfeedbackVisita = (string) $idfeedbackVisita;
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
     * @return string $comentario
     */
    public function getComentario() 
    {
	    return $this->comentario;
    }
        
    /**
     * @param string $comentario
     */
    public function setComentario($comentario) 
    {
	    $this->comentario = (string) $comentario;
    }
        
    /**
     * @return integer $nota
     */
    public function getNota() 
    {
	    return $this->nota;
    }
        
    /**
     * @param integer $nota
     */
    public function setNota($nota) 
    {
	    $this->nota = (string) $nota;
    }
        
    /**
     * @return string $vendaRealizada
     */
    public function getVendaRealizada() 
    {
	    return $this->vendaRealizada;
    }
        
    /**
     * @param string $vendaRealizada
     */
    public function setVendaRealizada($vendaRealizada) 
    {
	    $this->vendaRealizada = (string) $vendaRealizada;
    }
        
    /**
     * @return string $visitaReagendada
     */
    public function getVisitaReagendada() 
    {
	    return $this->visitaReagendada;
    }
        
    /**
     * @param string $visitaReagendada
     */
    public function setVisitaReagendada($visitaReagendada) 
    {
	    $this->visitaReagendada = (string) $visitaReagendada;
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