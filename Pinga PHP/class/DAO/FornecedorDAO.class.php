<?php 
require_once("GenericTable.class.php");
/**
 * Classe modelo da camada de persistencia - Fornecedor
 * Persistencia com banco de dados
 * Centralizador dos metodos de acesso ao banco de dados
 * @author Davidson Ferreira
 * @editor IHMHR
 */
class Fornecedor extends GenericTable
{
    private $table = "fornecedor";
    private $primary = array("idfornecedor");
    private $foreign = array("endereco_idendereco","telefone_idtelefone");
    private $schema = "Pinga";
    private $idfornecedor;
    private $nome;
    private $enderecoIdendereco;
    private $telefoneIdtelefone;

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
        $sql = "SELECT idfornecedor, nome, endereco_idendereco, telefone_idtelefone
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
     * @return string $idfornecedor
     */
    public function getIdfornecedor() 
    {
	    return $this->idfornecedor;
    }
        
    /**
     * @param string $idfornecedor
     */
    public function setIdfornecedor($idfornecedor) 
    {
	    $this->idfornecedor = (string) $idfornecedor;
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
    
}
?>