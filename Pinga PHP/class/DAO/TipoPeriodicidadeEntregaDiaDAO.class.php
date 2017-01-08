<?php 
require_once("GenericTable.class.php");
/**
 * Classe modelo da camada de persistencia - TipoPeriodicidadeEntregaDia
 * Persistencia com banco de dados
 * Centralizador dos metodos de acesso ao banco de dados
 * @author Davidson Ferreira
 * @editor IHMHR
 */
class TipoPeriodicidadeEntregaDia extends GenericTable
{
    private $table = "tipo_periodicidade_entrega_dia";
    private $primary = array("idtipo_periodicidade_entrega_dia");
    private $foreign = array();
    private $schema = "Pinga";
    private $idtipoPeriodicidadeEntregaDia;
    private $dias;
    private $diasUteis;
    private $diaFeriado;

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
        $sql = "SELECT idtipo_periodicidade_entrega_dia, dias, dias_uteis, dia_feriado
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
     * @return string $idtipoPeriodicidadeEntregaDia
     */
    public function getIdtipoPeriodicidadeEntregaDia() 
    {
	    return $this->idtipoPeriodicidadeEntregaDia;
    }
        
    /**
     * @param string $idtipoPeriodicidadeEntregaDia
     */
    public function setIdtipoPeriodicidadeEntregaDia($idtipoPeriodicidadeEntregaDia) 
    {
	    $this->idtipoPeriodicidadeEntregaDia = (string) $idtipoPeriodicidadeEntregaDia;
    }
        
    /**
     * @return string $dias
     */
    public function getDias() 
    {
	    return $this->dias;
    }
        
    /**
     * @param string $dias
     */
    public function setDias($dias) 
    {
	    $this->dias = (string) $dias;
    }
        
    /**
     * @return string $diasUteis
     */
    public function getDiasUteis() 
    {
	    return $this->diasUteis;
    }
        
    /**
     * @param string $diasUteis
     */
    public function setDiasUteis($diasUteis) 
    {
	    $this->diasUteis = (string) $diasUteis;
    }
        
    /**
     * @return string $diaFeriado
     */
    public function getDiaFeriado() 
    {
	    return $this->diaFeriado;
    }
        
    /**
     * @param string $diaFeriado
     */
    public function setDiaFeriado($diaFeriado) 
    {
	    $this->diaFeriado = (string) $diaFeriado;
    }
    
}
?>