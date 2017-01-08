<?php 
require_once("GenericTable.class.php");
/**
 * Classe modelo da camada de persistencia - PeriodicidadeHasProduto
 * Persistencia com banco de dados
 * Centralizador dos metodos de acesso ao banco de dados
 * @author Davidson Ferreira
 * @editor IHMHR
 */
class PeriodicidadeHasProduto extends GenericTable
{
    private $table = "periodicidade_has_produto";
    private $primary = array("idperiodicidade_has_produto");
    private $foreign = array("periodicidade_entrega_idperiodicidade_entrega","produto_idproduto");
    private $schema = "Pinga";
    private $idperiodicidadeHasProduto;
    private $periodicidadeEntregaIdperiodicidadeEntrega;
    private $produtoIdproduto;

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
        $sql = "SELECT idperiodicidade_has_produto, periodicidade_entrega_idperiodicidade_entrega, produto_idproduto
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
     * @return string $idperiodicidadeHasProduto
     */
    public function getIdperiodicidadeHasProduto() 
    {
	    return $this->idperiodicidadeHasProduto;
    }
        
    /**
     * @param string $idperiodicidadeHasProduto
     */
    public function setIdperiodicidadeHasProduto($idperiodicidadeHasProduto) 
    {
	    $this->idperiodicidadeHasProduto = (string) $idperiodicidadeHasProduto;
    }
        
    /**
     * @return string $periodicidadeEntregaIdperiodicidadeEntrega
     */
    public function getPeriodicidadeEntregaIdperiodicidadeEntrega() 
    {
	    return $this->periodicidadeEntregaIdperiodicidadeEntrega;
    }
        
    /**
     * @param string $periodicidadeEntregaIdperiodicidadeEntrega
     */
    public function setPeriodicidadeEntregaIdperiodicidadeEntrega($periodicidadeEntregaIdperiodicidadeEntrega) 
    {
	    $this->periodicidadeEntregaIdperiodicidadeEntrega = (string) $periodicidadeEntregaIdperiodicidadeEntrega;
    }
        
    /**
     * @return string $produtoIdproduto
     */
    public function getProdutoIdproduto() 
    {
	    return $this->produtoIdproduto;
    }
        
    /**
     * @param string $produtoIdproduto
     */
    public function setProdutoIdproduto($produtoIdproduto) 
    {
	    $this->produtoIdproduto = (string) $produtoIdproduto;
    }
    
}
?>