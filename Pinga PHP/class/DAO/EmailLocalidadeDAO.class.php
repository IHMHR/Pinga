<?php 
require_once("GenericTable.class.php");
/**
 * Classe modelo da camada de persistencia - EmailLocalidade
 * Persistencia com banco de dados
 * Centralizador dos metodos de acesso ao banco de dados
 * @author Davidson Ferreira
 * @editor IHMHR
 */
class EmailLocalidade extends GenericTable
{
    private $table = "email_localidade";
    private $primary = array("idemail_localidade");
    private $foreign = array();
    private $schema = "Pinga";
    private $idemailLocalidade;
    private $emailLocalidade;
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
        $sql = "SELECT idemail_localidade, email_localidade, status
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
     * @return string $idemailLocalidade
     */
    public function getIdemailLocalidade() 
    {
	    return $this->idemailLocalidade;
    }
        
    /**
     * @param string $idemailLocalidade
     */
    public function setIdemailLocalidade($idemailLocalidade) 
    {
	    $this->idemailLocalidade = (string) $idemailLocalidade;
    }
        
    /**
     * @return string $emailLocalidade
     */
    public function getEmailLocalidade() 
    {
	    return $this->emailLocalidade;
    }
        
    /**
     * @param string $emailLocalidade
     */
    public function setEmailLocalidade($emailLocalidade) 
    {
	    $this->emailLocalidade = (string) $emailLocalidade;
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