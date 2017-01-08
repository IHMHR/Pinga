<?php 
require_once("GenericTable.class.php");
/**
 * Classe modelo da camada de persistencia - Cliente
 * Persistencia com banco de dados
 * Centralizador dos metodos de acesso ao banco de dados
 * @author Davidson Ferreira
 * @editor IHMHR
 */
class Cliente extends GenericTable
{
    private $table = "cliente";
    private $primary = array("idcliente");
    private $foreign = array("cpf_cnpj","email_idemail","endereco_idendereco","telefone_idtelefone");
    private $schema = "Pinga";
    private $idcliente;
    private $cpfCnpj;
    private $nomeRazaoSocial;
    private $apelidoNomeFantasia;
    private $inscricaoMunicipal;
    private $identidadeInscricaoEstadual;
    private $dataNascimentoFundacao;
    private $sexo;
    private $emailIdemail;
    private $enderecoIdendereco;
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
        $sql = "SELECT idcliente, cpf_cnpj, nome_razao_social, apelido_nome_fantasia, inscricao_municipal, identidade_inscricao_estadual, data_nascimento_fundacao, sexo, email_idemail, endereco_idendereco, telefone_idtelefone, created, modified
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
     * @return string $idcliente
     */
    public function getIdcliente() 
    {
	    return $this->idcliente;
    }
        
    /**
     * @param string $idcliente
     */
    public function setIdcliente($idcliente) 
    {
	    $this->idcliente = (string) $idcliente;
    }
        
    /**
     * @return string $cpfCnpj
     */
    public function getCpfCnpj() 
    {
	    return $this->cpfCnpj;
    }
        
    /**
     * @param string $cpfCnpj
     */
    public function setCpfCnpj($cpfCnpj) 
    {
	    $this->cpfCnpj = (string) $cpfCnpj;
    }
        
    /**
     * @return string $nomeRazaoSocial
     */
    public function getNomeRazaoSocial() 
    {
	    return $this->nomeRazaoSocial;
    }
        
    /**
     * @param string $nomeRazaoSocial
     */
    public function setNomeRazaoSocial($nomeRazaoSocial) 
    {
	    $this->nomeRazaoSocial = (string) $nomeRazaoSocial;
    }
        
    /**
     * @return string $apelidoNomeFantasia
     */
    public function getApelidoNomeFantasia() 
    {
	    return $this->apelidoNomeFantasia;
    }
        
    /**
     * @param string $apelidoNomeFantasia
     */
    public function setApelidoNomeFantasia($apelidoNomeFantasia) 
    {
	    $this->apelidoNomeFantasia = (string) $apelidoNomeFantasia;
    }
        
    /**
     * @return string $inscricaoMunicipal
     */
    public function getInscricaoMunicipal() 
    {
	    return $this->inscricaoMunicipal;
    }
        
    /**
     * @param string $inscricaoMunicipal
     */
    public function setInscricaoMunicipal($inscricaoMunicipal) 
    {
	    $this->inscricaoMunicipal = (string) $inscricaoMunicipal;
    }
        
    /**
     * @return string $identidadeInscricaoEstadual
     */
    public function getIdentidadeInscricaoEstadual() 
    {
	    return $this->identidadeInscricaoEstadual;
    }
        
    /**
     * @param string $identidadeInscricaoEstadual
     */
    public function setIdentidadeInscricaoEstadual($identidadeInscricaoEstadual) 
    {
	    $this->identidadeInscricaoEstadual = (string) $identidadeInscricaoEstadual;
    }
        
    /**
     * @return string $dataNascimentoFundacao
     */
    public function getDataNascimentoFundacao() 
    {
	    return $this->dataNascimentoFundacao;
    }
        
    /**
     * @param string $dataNascimentoFundacao
     */
    public function setDataNascimentoFundacao($dataNascimentoFundacao) 
    {
	    $this->dataNascimentoFundacao = (string) $dataNascimentoFundacao;
    }
        
    /**
     * @return string $sexo
     */
    public function getSexo() 
    {
	    return $this->sexo;
    }
        
    /**
     * @param string $sexo
     */
    public function setSexo($sexo) 
    {
	    $this->sexo = (string) $sexo;
    }
        
    /**
     * @return string $emailIdemail
     */
    public function getEmailIdemail() 
    {
	    return $this->emailIdemail;
    }
        
    /**
     * @param string $emailIdemail
     */
    public function setEmailIdemail($emailIdemail) 
    {
	    $this->emailIdemail = (string) $emailIdemail;
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