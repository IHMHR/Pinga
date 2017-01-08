<?php 
require_once("GenericTable.class.php");
/**
 * Classe modelo da camada de persistencia - Telefone
 * Persistencia com banco de dados
 * Centralizador dos metodos de acesso ao banco de dados
 * @author Davidson Ferreira
 * @editor IHMHR
 */
class Telefone extends GenericTable
{
    private $table = "telefone";
    private $primary = array("idtelefone");
    private $foreign = array("cidade_ddd","tipo_telefone_idtipo_telefone","operadora_idoperadora");
    private $schema = "Pinga";
    private $idtelefone;
    private $telefone;
    private $cidadeDdd;
    private $tipoTelefoneIdtipoTelefone;
    private $operadoraIdoperadora;
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
        $sql = "SELECT idtelefone, telefone, cidade_ddd, tipo_telefone_idtipo_telefone, operadora_idoperadora, created, modified
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
     * @return string $idtelefone
     */
    public function getIdtelefone() 
    {
	    return $this->idtelefone;
    }
        
    /**
     * @param string $idtelefone
     */
    public function setIdtelefone($idtelefone) 
    {
	    $this->idtelefone = (string) $idtelefone;
    }
        
    /**
     * @return string $telefone
     */
    public function getTelefone() 
    {
	    return $this->telefone;
    }
        
    /**
     * @param string $telefone
     */
    public function setTelefone($telefone) 
    {
	    $this->telefone = (string) $telefone;
    }
        
    /**
     * @return string $cidadeDdd
     */
    public function getCidadeDdd() 
    {
	    return $this->cidadeDdd;
    }
        
    /**
     * @param string $cidadeDdd
     */
    public function setCidadeDdd($cidadeDdd) 
    {
	    $this->cidadeDdd = (string) $cidadeDdd;
    }
        
    /**
     * @return string $tipoTelefoneIdtipoTelefone
     */
    public function getTipoTelefoneIdtipoTelefone() 
    {
	    return $this->tipoTelefoneIdtipoTelefone;
    }
        
    /**
     * @param string $tipoTelefoneIdtipoTelefone
     */
    public function setTipoTelefoneIdtipoTelefone($tipoTelefoneIdtipoTelefone) 
    {
	    $this->tipoTelefoneIdtipoTelefone = (string) $tipoTelefoneIdtipoTelefone;
    }
        
    /**
     * @return string $operadoraIdoperadora
     */
    public function getOperadoraIdoperadora() 
    {
	    return $this->operadoraIdoperadora;
    }
        
    /**
     * @param string $operadoraIdoperadora
     */
    public function setOperadoraIdoperadora($operadoraIdoperadora) 
    {
	    $this->operadoraIdoperadora = (string) $operadoraIdoperadora;
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