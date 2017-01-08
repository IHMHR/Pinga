<?php 
require_once("GenericTable.class.php");
/**
 * Classe modelo da camada de persistencia - EmailDominio
 * Persistencia com banco de dados
 * Centralizador dos metodos de acesso ao banco de dados
 * @author Davidson Ferreira
 * @editor IHMHR
 */
class EmailDominio extends GenericTable
{
    private $table = "email_dominio";
    private $primary = array("idemail_dominio");
    private $foreign = array();
    private $schema = "Pinga";
    private $idemailDominio;
    private $emailDominio;
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
        $sql = "SELECT idemail_dominio, email_dominio, status
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
     * @return string $idemailDominio
     */
    public function getIdemailDominio() 
    {
	    return $this->idemailDominio;
    }
        
    /**
     * @param string $idemailDominio
     */
    public function setIdemailDominio($idemailDominio) 
    {
	    $this->idemailDominio = (string) $idemailDominio;
    }
        
    /**
     * @return string $emailDominio
     */
    public function getEmailDominio() 
    {
	    return $this->emailDominio;
    }
        
    /**
     * @param string $emailDominio
     */
    public function setEmailDominio($emailDominio) 
    {
	    $this->emailDominio = (string) $emailDominio;
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