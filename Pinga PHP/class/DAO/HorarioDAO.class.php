<?php 
require_once("GenericTable.class.php");
/**
 * Classe modelo da camada de persistencia - Horario
 * Persistencia com banco de dados
 * Centralizador dos metodos de acesso ao banco de dados
 * @author Davidson Ferreira
 * @editor IHMHR
 */
class Horario extends GenericTable
{
    private $table = "horario";
    private $primary = array("idhorario");
    private $foreign = array();
    private $schema = "Pinga";
    private $idhorario;
    private $horarioInicio;
    private $tempoDuracao;
    private $diaSemana;
    private $status;

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
        $sql = "SELECT idhorario, horario_inicio, tempo_duracao, dia_semana, status
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
     * @return string $idhorario
     */
    public function getIdhorario() 
    {
	    return $this->idhorario;
    }
        
    /**
     * @param string $idhorario
     */
    public function setIdhorario($idhorario) 
    {
	    $this->idhorario = (string) $idhorario;
    }
        
    /**
     * @return string $horarioInicio
     */
    public function getHorarioInicio() 
    {
	    return $this->horarioInicio;
    }
        
    /**
     * @param string $horarioInicio
     */
    public function setHorarioInicio($horarioInicio) 
    {
	    $this->horarioInicio = (string) $horarioInicio;
    }
        
    /**
     * @return string $tempoDuracao
     */
    public function getTempoDuracao() 
    {
	    return $this->tempoDuracao;
    }
        
    /**
     * @param string $tempoDuracao
     */
    public function setTempoDuracao($tempoDuracao) 
    {
	    $this->tempoDuracao = (string) $tempoDuracao;
    }
        
    /**
     * @return integer $diaSemana
     */
    public function getDiaSemana() 
    {
	    return $this->diaSemana;
    }
        
    /**
     * @param integer $diaSemana
     */
    public function setDiaSemana($diaSemana) 
    {
	    $this->diaSemana = (string) $diaSemana;
    }
        
    /**
     * @return string $status
     */
    public function getStatus() 
    {
	    return $this->status;
    }
        
    /**
     * @param string $status
     */
    public function setStatus($status) 
    {
	    $this->status = (string) $status;
    }
    
}
?>