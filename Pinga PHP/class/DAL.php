<?php
/**
* Class that make a connection with SQL Server
* @author IHMHR
*/
require_once("constantes.php");

class DAL
{
	private $pdo = null;

	function __construct()
	{
	}

	function abre_banco()
	{
		if($this->pdo)
		{
			return $this->pdo;
		}

		try
		{
			//return $this->pdo = new PDO("mssql:host=" . SERVER . ";dbname=" . DATABASE . "",	USER_ID, PASSWORD);
			//return $this->pdo = new PDO("sqlsrv:host=" . SERVER . " dbname=" . DATABASE . "", USER_ID, PASSWORD);
			//return $this->pdo = new PDO("sqlsrv:host=" . SERVER . ";dbname=" . DATABASE . "", USER_ID, PASSWORD);
			return $this->pdo = new PDO("sqlsrv:Server=" . SERVER . ";Database=" . DATABASE, USER_ID, PASSWORD); 
			//$conn = new PDO("sqlsrv:Server=localhost;Database=testdb", "UserName", "Password"); 
		}
		catch (PDOException $e)
		{
    		echo "Erro de Conexão \n" . $e . "\n";
    		return FALSE;
  		}
		/*if($conn)
		{
			return $conn;
		}
		else
		{
			return $conn = sqlsrv_connect($svr, $cntInfo);
		}*/
	}

	function fecha_banco($connection)
	{
		$con = null;
	}
}

?>	