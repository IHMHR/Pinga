<?php 
require_once("GenericTable.class.php");
/**
 * Classe modelo da camada de persistencia - Testemunha
 * Persistencia com banco de dados
 * Centralizador dos metodos de acesso ao banco de dados
 * @author Davidson Ferreira
 * @editor IHMHR
 */
class Testemunha extends GenericTable
{
    private $table = "testemunha";
    private $primary = array("idtestemunha");
    private $foreign = array("contrato_idcontrato");
    private $schema = "Pinga";
    private $idtestemunha;
    private $primeiroNome;
    private $nomeMeio;
    private $sobrenome;
    private $cpf;
    private $contratoIdcontrato;

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
        $sql = "SELECT idtestemunha, primeiro_nome, nome_meio, sobrenome, cpf, contrato_idcontrato
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
     * @return string $idtestemunha
     */
    public function getIdtestemunha() 
    {
	    return $this->idtestemunha;
    }
        
    /**
     * @param string $idtestemunha
     */
    public function setIdtestemunha($idtestemunha) 
    {
	    $this->idtestemunha = (string) $idtestemunha;
    }
        
    /**
     * @return string $primeiroNome
     */
    public function getPrimeiroNome() 
    {
	    return $this->primeiroNome;
    }
        
    /**
     * @param string $primeiroNome
     */
    public function setPrimeiroNome($primeiroNome) 
    {
	    $this->primeiroNome = (string) $primeiroNome;
    }
        
    /**
     * @return string $nomeMeio
     */
    public function getNomeMeio() 
    {
	    return $this->nomeMeio;
    }
        
    /**
     * @param string $nomeMeio
     */
    public function setNomeMeio($nomeMeio) 
    {
	    $this->nomeMeio = (string) $nomeMeio;
    }
        
    /**
     * @return string $sobrenome
     */
    public function getSobrenome() 
    {
	    return $this->sobrenome;
    }
        
    /**
     * @param string $sobrenome
     */
    public function setSobrenome($sobrenome) 
    {
	    $this->sobrenome = (string) $sobrenome;
    }
        
    /**
     * @return string $cpf
     */
    public function getCpf() 
    {
	    return $this->cpf;
    }
        
    /**
     * @param string $cpf
     */
    public function setCpf($cpf) 
    {
	    $this->cpf = (string) $cpf;
    }
        
    /**
     * @return string $contratoIdcontrato
     */
    public function getContratoIdcontrato() 
    {
	    return $this->contratoIdcontrato;
    }
        
    /**
     * @param string $contratoIdcontrato
     */
    public function setContratoIdcontrato($contratoIdcontrato) 
    {
	    $this->contratoIdcontrato = (string) $contratoIdcontrato;
    }
    
}
?>