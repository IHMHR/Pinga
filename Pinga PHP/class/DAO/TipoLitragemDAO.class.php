<?php 
require_once("GenericTable.class.php");
/**
 * Classe modelo da camada de persistencia - TipoLitragem
 * Persistencia com banco de dados
 * Centralizador dos metodos de acesso ao banco de dados
 * @author Davidson Ferreira
 * @editor IHMHR
 */
class TipoLitragem extends GenericTable
{
    private $table = "tipo_litragem";
    private $primary = array("idtipo_litragem");
    private $foreign = array("tipo_litragem");
    private $schema = "Pinga";
    private $idtipoLitragem;
    private $tipoLitragem;

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
        $sql = "SELECT idtipo_litragem, tipo_litragem
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
     * @return string $idtipoLitragem
     */
    public function getIdtipoLitragem() 
    {
	    return $this->idtipoLitragem;
    }
        
    /**
     * @param string $idtipoLitragem
     */
    public function setIdtipoLitragem($idtipoLitragem) 
    {
	    $this->idtipoLitragem = (string) $idtipoLitragem;
    }
        
    /**
     * @return string $tipoLitragem
     */
    public function getTipoLitragem() 
    {
	    return $this->tipoLitragem;
    }
        
    /**
     * @param string $tipoLitragem
     */
    public function setTipoLitragem($tipoLitragem) 
    {
	    $this->tipoLitragem = (string) $tipoLitragem;
    }
    
}
?>