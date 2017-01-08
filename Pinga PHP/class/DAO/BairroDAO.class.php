<?php 
require_once("GenericTable.class.php");
/**
 * Classe modelo da camada de persistencia - Bairro
 * Persistencia com banco de dados
 * Centralizador dos metodos de acesso ao banco de dados
 * @author Davidson Ferreira
 * @editor IHMHR
 */
class Bairro extends GenericTable
{
    private $table = "bairro";
    private $primary = array("idbairro");
    private $foreign = array("cidade_idcidade");
    private $schema = "Pinga";
    private $idbairro;
    private $bairro;
    private $regiao;
    private $cidadeIdcidade;

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
        $sql = "SELECT idbairro, bairro, regiao, cidade_idcidade
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
     * @return string $idbairro
     */
    public function getIdbairro() 
    {
	    return $this->idbairro;
    }
        
    /**
     * @param string $idbairro
     */
    public function setIdbairro($idbairro) 
    {
	    $this->idbairro = (string) $idbairro;
    }
        
    /**
     * @return string $bairro
     */
    public function getBairro() 
    {
	    return $this->bairro;
    }
        
    /**
     * @param string $bairro
     */
    public function setBairro($bairro) 
    {
	    $this->bairro = (string) $bairro;
    }
        
    /**
     * @return string $regiao
     */
    public function getRegiao() 
    {
	    return $this->regiao;
    }
        
    /**
     * @param string $regiao
     */
    public function setRegiao($regiao) 
    {
	    $this->regiao = (string) $regiao;
    }
        
    /**
     * @return string $cidadeIdcidade
     */
    public function getCidadeIdcidade() 
    {
	    return $this->cidadeIdcidade;
    }
        
    /**
     * @param string $cidadeIdcidade
     */
    public function setCidadeIdcidade($cidadeIdcidade) 
    {
	    $this->cidadeIdcidade = (string) $cidadeIdcidade;
    }
    
}
?>