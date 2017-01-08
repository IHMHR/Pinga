<?php 
require_once("GenericTable.class.php");
/**
 * Classe modelo da camada de persistencia - Email
 * Persistencia com banco de dados
 * Centralizador dos metodos de acesso ao banco de dados
 * @author Davidson Ferreira
 * @editor IHMHR
 */
class Email extends GenericTable
{
    private $table = "email";
    private $primary = array("idemail");
    private $foreign = array("email_dominio_idemail_dominio","email_localidade_idemail_localidade");
    private $schema = "Pinga";
    private $idemail;
    private $email;
    private $emailDominioIdemailDominio;
    private $emailLocalidadeIdemailLocalidade;

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
        $sql = "SELECT idemail, email, email_dominio_idemail_dominio, email_localidade_idemail_localidade
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
     * @return string $idemail
     */
    public function getIdemail() 
    {
	    return $this->idemail;
    }
        
    /**
     * @param string $idemail
     */
    public function setIdemail($idemail) 
    {
	    $this->idemail = (string) $idemail;
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
     * @return string $emailDominioIdemailDominio
     */
    public function getEmailDominioIdemailDominio() 
    {
	    return $this->emailDominioIdemailDominio;
    }
        
    /**
     * @param string $emailDominioIdemailDominio
     */
    public function setEmailDominioIdemailDominio($emailDominioIdemailDominio) 
    {
	    $this->emailDominioIdemailDominio = (string) $emailDominioIdemailDominio;
    }
        
    /**
     * @return string $emailLocalidadeIdemailLocalidade
     */
    public function getEmailLocalidadeIdemailLocalidade() 
    {
	    return $this->emailLocalidadeIdemailLocalidade;
    }
        
    /**
     * @param string $emailLocalidadeIdemailLocalidade
     */
    public function setEmailLocalidadeIdemailLocalidade($emailLocalidadeIdemailLocalidade) 
    {
	    $this->emailLocalidadeIdemailLocalidade = (string) $emailLocalidadeIdemailLocalidade;
    }
    
}
?>