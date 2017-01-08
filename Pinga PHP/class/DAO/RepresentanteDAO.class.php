<?php 
require_once("GenericTable.class.php");
/**
 * Classe modelo da camada de persistencia - Representante
 * Persistencia com banco de dados
 * Centralizador dos metodos de acesso ao banco de dados
 * @author Davidson Ferreira
 * @editor IHMHR
 */
class Representante extends GenericTable
{
    private $table = "representante";
    private $primary = array("idrepresentante");
    private $foreign = array("telefone_idtelefone");
    private $schema = "Pinga";
    private $idrepresentante;
    private $nome;
    private $telefoneIdtelefone;
    private $email;
    private $departamento;
    private $cargo;
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
        $sql = "SELECT idrepresentante, nome, telefone_idtelefone, email, departamento, cargo, status
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
     * @return string $idrepresentante
     */
    public function getIdrepresentante() 
    {
	    return $this->idrepresentante;
    }
        
    /**
     * @param string $idrepresentante
     */
    public function setIdrepresentante($idrepresentante) 
    {
	    $this->idrepresentante = (string) $idrepresentante;
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
     * @return string $email
     */
    public function getEmail() 
    {
	    return $this->email;
    }
        
    /**
     * @param string $email
     */
    public function setEmail($email) 
    {
	    $this->email = (string) $email;
    }
        
    /**
     * @return string $departamento
     */
    public function getDepartamento() 
    {
	    return $this->departamento;
    }
        
    /**
     * @param string $departamento
     */
    public function setDepartamento($departamento) 
    {
	    $this->departamento = (string) $departamento;
    }
        
    /**
     * @return string $cargo
     */
    public function getCargo() 
    {
	    return $this->cargo;
    }
        
    /**
     * @param string $cargo
     */
    public function setCargo($cargo) 
    {
	    $this->cargo = (string) $cargo;
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