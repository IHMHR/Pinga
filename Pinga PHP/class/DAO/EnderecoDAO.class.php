<?php 
require_once("GenericTable.class.php");
/**
 * Classe modelo da camada de persistencia - Endereco
 * Persistencia com banco de dados
 * Centralizador dos metodos de acesso ao banco de dados
 * @author Davidson Ferreira
 * @editor IHMHR
 */
class Endereco extends GenericTable
{
    private $table = "endereco";
    private $primary = array("idendereco");
    private $foreign = array("tipo_logradouro_idtipo_logradouro","tipo_complemento_idtipo_complemento","bairro_idbairro");
    private $schema = "Pinga";
    private $idendereco;
    private $tipoLogradouroIdtipoLogradouro;
    private $logradouro;
    private $numero;
    private $tipoComplementoIdtipoComplemento;
    private $complemento;
    private $CEP;
    private $pontoReferencia;
    private $bairroIdbairro;
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
        $sql = "SELECT idendereco, tipo_logradouro_idtipo_logradouro, logradouro, numero, tipo_complemento_idtipo_complemento, complemento, CEP, ponto_referencia, bairro_idbairro, created, modified
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
     * @return string $idendereco
     */
    public function getIdendereco() 
    {
	    return $this->idendereco;
    }
        
    /**
     * @param string $idendereco
     */
    public function setIdendereco($idendereco) 
    {
	    $this->idendereco = (string) $idendereco;
    }
        
    /**
     * @return string $tipoLogradouroIdtipoLogradouro
     */
    public function getTipoLogradouroIdtipoLogradouro() 
    {
	    return $this->tipoLogradouroIdtipoLogradouro;
    }
        
    /**
     * @param string $tipoLogradouroIdtipoLogradouro
     */
    public function setTipoLogradouroIdtipoLogradouro($tipoLogradouroIdtipoLogradouro) 
    {
	    $this->tipoLogradouroIdtipoLogradouro = (string) $tipoLogradouroIdtipoLogradouro;
    }
        
    /**
     * @return string $logradouro
     */
    public function getLogradouro() 
    {
	    return $this->logradouro;
    }
        
    /**
     * @param string $logradouro
     */
    public function setLogradouro($logradouro) 
    {
	    $this->logradouro = (string) $logradouro;
    }
        
    /**
     * @return integer $numero
     */
    public function getNumero() 
    {
	    return $this->numero;
    }
        
    /**
     * @param integer $numero
     */
    public function setNumero($numero) 
    {
	    $this->numero = (string) $numero;
    }
        
    /**
     * @return string $tipoComplementoIdtipoComplemento
     */
    public function getTipoComplementoIdtipoComplemento() 
    {
	    return $this->tipoComplementoIdtipoComplemento;
    }
        
    /**
     * @param string $tipoComplementoIdtipoComplemento
     */
    public function setTipoComplementoIdtipoComplemento($tipoComplementoIdtipoComplemento) 
    {
	    $this->tipoComplementoIdtipoComplemento = (string) $tipoComplementoIdtipoComplemento;
    }
        
    /**
     * @return string $complemento
     */
    public function getComplemento() 
    {
	    return $this->complemento;
    }
        
    /**
     * @param string $complemento
     */
    public function setComplemento($complemento) 
    {
	    $this->complemento = (string) $complemento;
    }
        
    /**
     * @return string $CEP
     */
    public function getCEP() 
    {
	    return $this->CEP;
    }
        
    /**
     * @param string $CEP
     */
    public function setCEP($CEP) 
    {
	    $this->CEP = (string) $CEP;
    }
        
    /**
     * @return string $pontoReferencia
     */
    public function getPontoReferencia() 
    {
	    return $this->pontoReferencia;
    }
        
    /**
     * @param string $pontoReferencia
     */
    public function setPontoReferencia($pontoReferencia) 
    {
	    $this->pontoReferencia = (string) $pontoReferencia;
    }
        
    /**
     * @return string $bairroIdbairro
     */
    public function getBairroIdbairro() 
    {
	    return $this->bairroIdbairro;
    }
        
    /**
     * @param string $bairroIdbairro
     */
    public function setBairroIdbairro($bairroIdbairro) 
    {
	    $this->bairroIdbairro = (string) $bairroIdbairro;
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