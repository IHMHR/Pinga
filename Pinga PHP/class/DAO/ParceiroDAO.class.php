<?php 
require_once("GenericTable.class.php");
/**
 * Classe modelo da camada de persistencia - Parceiro
 * Persistencia com banco de dados
 * Centralizador dos metodos de acesso ao banco de dados
 * @author Davidson Ferreira
 * @editor IHMHR
 */
class Parceiro extends GenericTable
{
    private $table = "parceiro";
    private $primary = array("idparceiro");
    private $foreign = array("endereco_idendereco","telefone_idtelefone");
    private $schema = "Pinga";
    private $idparceiro;
    private $nome;
    private $enderecoIdendereco;
    private $status;
    private $telefoneIdtelefone;
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
        $sql = "SELECT idparceiro, nome, endereco_idendereco, status, telefone_idtelefone, created, modified
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
     * @return string $idparceiro
     */
    public function getIdparceiro() 
    {
	    return $this->idparceiro;
    }
        
    /**
     * @param string $idparceiro
     */
    public function setIdparceiro($idparceiro) 
    {
	    $this->idparceiro = (string) $idparceiro;
    }
        
    /**
     * @return string $nome
     */
    public function getNome() 
    {
	    return $this->nome;
    }
        
    /**
     * @param string $nome
     */
    public function setNome($nome) 
    {
	    $this->nome = (string) $nome;
    }
        
    /**
     * @return string $enderecoIdendereco
     */
    public function getEnderecoIdendereco() 
    {
	    return $this->enderecoIdendereco;
    }
        
    /**
     * @param string $enderecoIdendereco
     */
    public function setEnderecoIdendereco($enderecoIdendereco) 
    {
	    $this->enderecoIdendereco = (string) $enderecoIdendereco;
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
        
    /**
     * @return string $telefoneIdtelefone
     */
    public function getTelefoneIdtelefone() 
    {
	    return $this->telefoneIdtelefone;
    }
        
    /**
     * @param string $telefoneIdtelefone
     */
    public function setTelefoneIdtelefone($telefoneIdtelefone) 
    {
	    $this->telefoneIdtelefone = (string) $telefoneIdtelefone;
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