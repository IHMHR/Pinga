<?php
/**
 * Classe de controle dos modelos - table
 * Funcoes basicas automatizadas - insert - update- delete
 * Gera objeto da classe de modelo - getObjetcClass
 * Controle de transacao e log de erros em arquivo
 * @author Davidson Ferreira
 */
class GenericTable
{
    private $countPrimaryUpdateDelete;
    private $databasePersist = NULL;
    private $countResult = 0;
    private $countAffectedRows = 0;
    private $arrayListTable = array();

    /**
     * Construtor da classe
     */
    function __construct() {

    }

    /**
     * Monta um objeto de dados a partir do result set e converte para a classe especificada
     * O nome dos campos do SQL devem ser iguais aos nomes das propriedades da classe para o correto mapeamento
     * @param result mysql_query()
     * @param string $class
     * @return Object Class
     */
    public function getObjetcClass($result, $class = __CLASS__)
    {
        return mysql_fetch_object($result,$class);
    }

    /**
     * Add registro no banco de dados
     * @return integer mysql_insert_id()
     */
    protected function insert($objectTable){
        try{
            $sqlInsert = $this->montaInsert($this->montaArrayListTable($objectTable));
            $retorno = mysql_query($sqlInsert);
            if($retorno){
                $idAdd = mysql_insert_id();
                if($idAdd > 0)
                {
                    return mysql_insert_id();
                }
                else
                {
                    return true;
                }
            }
            else{
                $this->errorHandler($sqlInsert, mysql_error(), __LINE__, __FILE__);
                return false;
            }
        }
        catch(Exception $e){
            $this->errorHandler($sqlInsert, $e->getMessage(), __LINE__, __FILE__);
            return false;
        }
    }

    /**
     * Update em registro no banco de dados
     * @return integer mysql_affected_rows()
     */
    protected function update($objectTable){
        try{
            $sqlUpdate = $this->montaUpdate($this->montaArrayListTable($objectTable));
            if($this->countPrimaryUpdateDelete > 0){
                $retorno = mysql_query($sqlUpdate);
                if($retorno){
                    // SETA A QUANTIDADE DE REGISTROS ALTERADOS
                    $this->countAffectedRows = mysql_affected_rows();
                    return $retorno;
                }
                else{
                    $this->errorHandler($sqlUpdate, mysql_error(), __LINE__, __FILE__);
                    return false;
                }
            }
            else{
                echo "Falta informar a primary key no objeto para update";
                $this->errorHandler($sqlUpdate, "Falta informar a primary key no objeto para update", __LINE__, __FILE__);
                return false;
            }
        }
        catch(Exception $e){
            $this->errorHandler($sqlUpdate, $e->getMessage(), __LINE__, __FILE__);
            return false;
        }
    }

    /**
     * Delete em registro no banco de dados
     * @return integer mysql_affected_rows()
     */
    protected function delete($objectTable){
        try{
            $sqlDelete = $this->montaDelete($this->montaArrayListTable($objectTable));
            if($this->countPrimaryUpdateDelete > 0){
                $retorno = mysql_query($sqlDelete);
                if($retorno){
                    // SETA A QUANTIDADE DE REGISTROS APAGADOS
                    $this->countAffectedRows = mysql_affected_rows();
                    return $retorno;
                }
                else{
                    $this->errorHandler($sqlDelete, mysql_error(), __LINE__, __FILE__);
                    return false;
                }
            }
            else{
                echo "Falta informar a primary key no objeto para delete";
                $this->errorHandler($sqlDelete, "Falta informar a primary key no objeto para delete", __LINE__, __FILE__);
                return false;
            }
        }
        catch(Exception $e){
            $this->errorHandler($sqlDelete, $e->getMessage(), __LINE__, __FILE__);
            return false;
        }
    }

    /**
     * Inicia uma transacao no banco de dados
     */
    public function starTransaction(){
        mysql_query("START TRANSACTION");
    }

    /**
     * Confirma uma transacao no banco de dados
     */
    public function commit(){
        mysql_query("COMMIT");
    }

    /**
     * Cancela uma transacao iniciada no banco de dados
     */
    public function rollback(){
        mysql_query("ROLLBACK");
    }

    /**
     * Fecha conexao com banco de dados
     */
    public function fechaConexao(){
        mysql_close();
    }

    /**
     * Monta instrucao select SQL
     * @param Array $arrayListTable
     * @return string $comandoInsert
     */
    private function montaInsert(Array $arrayListTable){
        $fieldsInsert = "";
        $valuesInsert = "";
        $primary = $arrayListTable["primary"];
        $comandoInsert = "INSERT INTO ".$this->getNomeDatabase().$arrayListTable["table"]." (";
        // PERCORRE ARRAYLIST PARA MONTAR INSERT
        foreach($arrayListTable as $name=>$value){
            if($name != "table" && $name != "primary"){
                if(in_array($name,$primary)){
                    //if($value > 0){
                        $fieldsInsert .= $name.",";
                        $valuesInsert .= $this->removeAspas($value, $this->getTypeVariable($value)).",";
                    //}
                }
                else{
                    $fieldsInsert .= $name.",";
                    $valuesInsert .= $this->removeAspas($value, $this->getTypeVariable($value)).",";
                }
            }
        }
        // RETIRA ULTIMA VIRGULA E FECHA PARENTESES DE FIELDS
        $comandoInsert .= substr($fieldsInsert,0,strlen($fieldsInsert)-1).") VALUES(".substr($valuesInsert,0,strlen($valuesInsert)-1).")";
        return $comandoInsert;
    }

    /**
     * Monta instrucao update SQL
     * @param Array $arrayListTable
     * @return string $comandoUpdate
     */
    private function montaUpdate(Array $arrayListTable){
        $fieldsUpdate = "";
        $whereUpdate  = "";
        $this->countPrimaryUpdateDelete = 0;
        $primary = $arrayListTable["primary"];
        $comandoUpdate = "UPDATE ".$this->getNomeDatabase().$arrayListTable["table"]." SET ";
        // PERCORRE ARRAYLIST PARA MONTAR UPDATE
        foreach($arrayListTable as $name=>$value){
            if($name != "table" && $name != "primary"){
                if(in_array($name,$primary)){
                    if($value != ""){
                        if($whereUpdate == ""){
                            $whereUpdate .= "WHERE ".$name." = ".$this->removeAspas($value, $this->getTypeVariable($value));
                        }
                        else{
                            $whereUpdate .= " AND ".$name." = ".$this->removeAspas($value, $this->getTypeVariable($value));
                        }
                        $this->countPrimaryUpdateDelete++;
                    }
                }
                else{
                    $fieldsUpdate .= $name." = ".$this->removeAspas($value, $this->getTypeVariable($value)).",";
                }
            }
        }
        // RETIRA ULTIMA VIRGULA E FECHA PARENTESES DE FIELDS
        $comandoUpdate .= substr($fieldsUpdate,0,strlen($fieldsUpdate)-1)." ".$whereUpdate;
        return $comandoUpdate;
    }

    /**
     * Monta instrucao delete SQL
     * @param Array $arrayListTable
     * @return string $comandoDelete
     */
    private function montaDelete(Array $arrayListTable){
        $whereDelete  = "";
        $this->countPrimaryUpdateDelete = 0;
        $primary = $arrayListTable["primary"];
        $comandoDelete = "DELETE FROM ".$this->getNomeDatabase().$arrayListTable["table"]." ";
        // PERCORRE ARRAYLIST PARA MONTAR DELETE
        foreach($arrayListTable as $name=>$value){
            if($name != "table" && $name != "primary"){
                if(in_array($name,$primary)){
                    if($value != ""){
                        if($whereDelete == ""){
                            $whereDelete .= "WHERE ".$name." = ".$this->removeAspas($value, $this->getTypeVariable($value));
                        }
                        else{
                            $whereDelete .= " AND ".$name." = ".$this->removeAspas($value, $this->getTypeVariable($value));
                        }
                        $this->countPrimaryUpdateDelete++;
                    }
                }
            }
        }
        // RETIRA ULTIMA VIRGULA E FECHA PARENTESES DE FIELDS
        $comandoDelete .= $whereDelete;
        return $comandoDelete;
    }

    /**
     * Define o tipo de dados
     * @param string $var
     * @return string $var
     */
    private function getTypeVariable($var){
        if(is_int($var) || is_integer($var)) return "int";
        else if(is_double($var) || is_float($var)) return "double";
        else return "text";
    }

    /**
     * Remove aspas e trata tipo de dados
     * @param string $theValue
     * @param string $theType
     * @param string $theDefinedValue
     * @param string $theNotDefinedValue
     * @return string $theValue
     */
    public function removeAspas($theValue, $theType, $theDefinedValue = "", $theNotDefinedValue = "")
    {
      $theValue = get_magic_quotes_gpc() ? stripslashes($theValue) : $theValue;

      $theValue = function_exists("mysql_real_escape_string") ? mysql_real_escape_string($theValue) : mysql_escape_string($theValue);

      switch ($theType) {
        case "text":
          $theValue = ($theValue != "") ? "'" . $theValue . "'" : "NULL";
          break;
        case "long":
        case "int":
          $theValue = ($theValue != "") ? intval($theValue) : "NULL";
          break;
        case "double":
          $theValue = ($theValue != "") ? "'" . doubleval($theValue) . "'" : "NULL";
          break;
        case "date":
          $theValue = ($theValue != "") ? "'" . $theValue . "'" : "NULL";
          break;
        case "defined":
          $theValue = ($theValue != "") ? $theDefinedValue : $theNotDefinedValue;
          break;
      }
      return $theValue;
    }

    /**
     * Trata aspas
     * @param string $value
     * @return string $theValue
     */
    public function trataAspas($value)
    {
        if (get_magic_quotes_gpc())

        {

            $value = stripslashes($value);

        }

        $value = mysql_real_escape_string($value);
        return $value;
    }

    /**
     * Retorna o nome da base de dados para concatenar nos comandos insert|update|delete
     * @return string $databasePersist
     */
    private function getNomeDatabase(){
        // SETA BASE DE DADOS SELECIONADA
        $databasePersist = "";

        // VERIFICA SE FOI ESPECIFICADO BANCO DE DADOS
        if(!is_null($this->databasePersist) && trim($this->databasePersist) != "")
        {
            $databasePersist = $this->databasePersist.".";
        }
        return $databasePersist;
    }

    /**
     * Monta array com os campos e dados de uma table
     * @param Class $objectTable
     * @return Array $arrayListTable
     */
    private function montaArrayListTable($objectTable){
        // NOME DO ARRAYLIST FINAL
        $arrayListTable = array();
        // NOME DA CLASSE
        $nomeClasse = get_class($objectTable);
        // CONVERTE OBJETO EM ARRAY
        $arrayList = (Array) $objectTable;

        // SQL BUSCA CAMPOS DA TABELA
        $sqlBuscaCamposTable = "SHOW COLUMNS FROM ".$this->getNomeDatabase().$objectTable->getTable();

        // QUERY BUSCA CAMPOS DA TABELA
        $sqlBuscaCamposTable = mysql_query($sqlBuscaCamposTable);

        // ARRAYLIST COM CAMPOS DA TABELA
        $arrayListCamposTable[] = 'table';
        $arrayListCamposTable[] = 'primary';

        while($rowCamposTable = mysql_fetch_array($sqlBuscaCamposTable))
        {
            $arrayListCamposTable[] = $rowCamposTable['Field'];
        }

        // PERCORRE ARRALIST
        foreach($arrayList as $name=>$value){
            // VERIFICA SE ATRIBUTO FOI
            if(isset($value)){
                // GUARDA NOME DO FILED NO DB
                $nomeField = "";
                // NOME DA PROPRIEDADE
                $nomePropriedade = $nome;

                if (strpos($name, $nomeClasse) !== false)
                {
                    $nomePropriedade = substr($name,strlen($nomeClasse)+1);
                }
                // PERCORRE O NOME DA PROPRIEDADE PARA MONTAR NOME DO FIELD NO DB
                for($i=0; $i<strlen($nomePropriedade); $i++){
                    // VERIFICA NO LETRA É MAIUSCULA
                    if(preg_match('/^[^a-z]*$/', $nomePropriedade[$i])){
                        if($i > 0){
                            $nomeField .= trim("_".strtolower($nomePropriedade[$i]));
                        }
                        else{
                            $nomeField .= trim(strtolower($nomePropriedade[$i]));
                        }
                    }
                    else{
                        $nomeField .= trim(strtolower($nomePropriedade[$i]));
                    }
                }

                // VERIFICA SE PROPRIEDADE/CAMPO EXISTE NA BASE DE DADOS PARA PERSISTENCIA
                if(in_array($nomeField, $arrayListCamposTable))
                {
                    $this->arrayListTable[$nomeField] = $value;
                }
            }
        }
        return $this->arrayListTable;
    }

    /**
     * @return the $databasePersist
     */
    public function getDatabasePersist() {
        return $this->databasePersist;
    }

    /**
     * Retorna a quantidade de registro do resultset
     * @param $result
     * @return the $countResult
     */
    public function getCountResult($result) {
        return mysql_num_rows($result);
    }

    /**
     * @return the $countAffectedRows
     */
    public function getCountAffectedRows() {
        return $this->countAffectedRows;
    }

    /**
     * @param integer $countAffectedRows
     * @return the $countAffectedRows
     */
    public function setCountAffectedRows($countAffectedRows) {
        $this->countAffectedRows = $countAffectedRows;
    }

    /**
     * @param NULL $databasePersist
     */
    public function setDatabasePersist($databasePersist) {
        $this->databasePersist = $databasePersist;
    }

    /**
     * Limpa arrayListTable
     */
    public function resetArrayListTable()
    {
        $this->arrayListTable = array();
    }

    /**
     * Função para tratar os ERROS de comandos SQL.
     * 30/07/2013
     *
     * Exemplo: $queryTeste = mysql_query($sqlTeste) or die($this->errorHandler($sqlTeste, mysql_error(), __LINE__, __FILE__));
     *
     * @param string $query contém o SQL com erro
     * @param string $error contém a descrição do erro fornecida pelo MySQL com a função mysql_error()
     * @param int $linha contém a linha do arquivo passada pela constante mágica __LINE__
     * @param string $arquivo contém o nome do arquivo passado pela constante mágica __FILE__
     * @author Cauê Gonzalez
     */
    protected function errorHandler($query, $error, $linha, $arquivo)
    {
        $wsdl = "http://".$_SERVER['HTTP_HOST']."/ws/webservice/logError.php?wsdl";
        $clientWsdl = new SoapClient($wsdl);
        return $clientWsdl->errorHandler($query, $error, $linha, $arquivo);
    }
}
?>