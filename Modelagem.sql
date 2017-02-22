USE master;
GO

sp_configure 'contained database authentication', 1;
RECONFIGURE;
GO

IF EXISTS(SELECT 1 FROM sys.databases WHERE name = 'pingaDB')
BEGIN
    ALTER DATABASE pingaDB SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE pingaDB;
END

CREATE DATABASE pingaDB CONTAINMENT = PARTIAL
ON (NAME = 'pingaDB', FILENAME = 'C:\Users\IHMHR\Documents\SQL Databases\pingaDB.mdf', SIZE = 10MB, MAXSIZE = 25MB, FILEGROWTH = 2MB )
LOG ON (NAME = 'pingaDB_LOG', FILENAME = 'C:\Users\IHMHR\Documents\SQL Databases\pingaDB.ldf', SIZE = 5MB, MAXSIZE = 10MB, FILEGROWTH = 1MB)
COLLATE Latin1_General_CS_AS;
GO

ALTER DATABASE pingaDB SET OFFLINE
GO

ALTER DATABASE pingaDB SET READ_COMMITTED_SNAPSHOT ON
GO

ALTER DATABASE pingaDB SET ANSI_NULLS ON
GO

ALTER DATABASE pingaDB SET AUTO_CLOSE OFF
GO

ALTER DATABASE pingaDB SET ANSI_PADDING ON
GO

ALTER DATABASE pingaDB SET ANSI_WARNINGS ON
GO

ALTER DATABASE pingaDB SET ARITHABORT OFF
GO

ALTER DATABASE pingaDB SET CONCAT_NULL_YIELDS_NULL ON
GO

ALTER DATABASE pingaDB SET MULTI_USER WITH ROLLBACK IMMEDIATE
GO

ALTER DATABASE pingaDB SET AUTO_CREATE_STATISTICS ON
GO

ALTER DATABASE pingaDB SET AUTO_SHRINK ON
GO

ALTER DATABASE pingaDB SET AUTO_UPDATE_STATISTICS ON
GO

ALTER DATABASE pingaDB SET AUTO_UPDATE_STATISTICS_ASYNC ON
GO

ALTER DATABASE pingaDB SET RECURSIVE_TRIGGERS OFF
GO

ALTER DATABASE pingaDB SET RECOVERY FULL -- FULL BACKUP AND LOG BACKUP
GO

ALTER DATABASE pingaDB SET ONLINE
GO

ALTER DATABASE pingaDB SET NESTED_TRIGGERS = OFF
GO

ALTER DATABASE pingaDB SET DISABLE_BROKER
GO

ALTER DATABASE pingaDB SET COMPATIBILITY_LEVEL = 130
GO

ALTER DATABASE pingaDB ADD FILEGROUP Pinga_FileGroup
GO

ALTER DATABASE pingaDB ADD FILE 
(NAME = 'pingaDB_File1', FILENAME = 'C:\Users\IHMHR\Documents\SQL Databases\pingaDB_File1.ndf', SIZE = 100MB, MAXSIZE = 500MB, FILEGROWTH = 20MB ),
(NAME = 'pingaDB_File2', FILENAME = 'C:\Users\IHMHR\Documents\SQL Databases\pingaDB_File2.ndf', SIZE = 100MB, MAXSIZE = 500MB, FILEGROWTH = 20MB ),
(NAME = 'pingaDB_File3', FILENAME = 'C:\Users\IHMHR\Documents\SQL Databases\pingaDB_File3.ndf', SIZE = 100MB, MAXSIZE = 500MB, FILEGROWTH = 20MB )
TO FILEGROUP Pinga_FileGroup
GO

ALTER DATABASE pingaDB ADD FILEGROUP Adm_FileGroup
GO

ALTER DATABASE pingaDB ADD FILE
(NAME = 'pingaDB_File4', FILENAME = 'C:\Users\IHMHR\Documents\SQL Databases\pingaDB_File4.ndf', SIZE = 75MB, MAXSIZE = 400MB, FILEGROWTH = 15MB),
(NAME = 'pingaDB_File5', FILENAME = 'C:\Users\IHMHR\Documents\SQL Databases\pingaDB_File5.ndf', SIZE = 75MB, MAXSIZE = 400MB, FILEGROWTH = 15MB)
TO FILEGROUP Adm_FileGroup

ALTER DATABASE pingaDB ADD FILEGROUP Legado_FileGroup
GO

ALTER DATABASE pingaDB ADD FILE
(NAME = 'pingaDB_File6', FILENAME = 'C:\Users\IHMHR\Documents\SQL Databases\pingaDB_File6.ndf', SIZE = 50MB, MAXSIZE = 150MB, FILEGROWTH = 10MB)
TO FILEGROUP Legado_FileGroup
GO

ALTER DATABASE pingaDB ADD LOG FILE
(NAME = 'pingaDB_LOG1', FILENAME = 'C:\Users\IHMHR\Documents\SQL Databases\pingaDB1.ldf', SIZE = 150MB, MAXSIZE = 600MB, FILEGROWTH = 25MB),
(NAME = 'pingaDB_LOG2', FILENAME = 'C:\Users\IHMHR\Documents\SQL Databases\pingaDB2.ldf', SIZE = 150MB, MAXSIZE = 600MB, FILEGROWTH = 25MB)
GO

ALTER DATABASE pingaDB MODIFY FILEGROUP Pinga_FileGroup DEFAULT
GO

USE pingaDB;
GO

CREATE SCHEMA Legado;
GO

CREATE SCHEMA Pinga;
GO

IF EXISTS(SELECT 1 FROM sys.tables WHERE name = 'tipo_continente')
BEGIN
    DROP TABLE Pinga.tipo_continente;
END

CREATE TABLE Pinga.tipo_continente (
idtipo_continente UNIQUEIDENTIFIER ROWGUIDCOL NOT NULL DEFAULT NEWID(),
tipo_continente VARCHAR(20) NOT NULL,
ativo BIT NOT NULL DEFAULT 0, -- Validar na aplicação que somente 1 possa spingaer verdadeiro

CONSTRAINT pk_tipo_continente PRIMARY KEY NONCLUSTERED (idtipo_continente)
) ON Pinga_FileGroup;

IF EXISTS(SELECT 1 FROM sys.tables WHERE name = 'continente')
BEGIN
    DROP TABLE Pinga.continente;
END

CREATE TABLE Pinga.continente (
idcontinente UNIQUEIDENTIFIER ROWGUIDCOL NOT NULL DEFAULT NEWID(),
continente VARCHAR(20) NOT NULL,
tipo_continente_idtipo_continente UNIQUEIDENTIFIER NOT NULL,

CONSTRAINT pk_continente PRIMARY KEY NONCLUSTERED (idcontinente),
FOREIGN KEY (tipo_continente_idtipo_continente) REFERENCES Pinga.tipo_continente(idtipo_continente)
) ON Pinga_FileGroup;

IF EXISTS(SELECT 1 FROM sys.tables WHERE name = 'pais')
BEGIN
    DROP TABLE Pinga.pais;
END

CREATE TABLE Pinga.pais (
idpais UNIQUEIDENTIFIER ROWGUIDCOL NOT NULL DEFAULT NEWID(),
pais VARCHAR(40) NOT NULL,
idioma VARCHAR(40) NOT NULL,
colacao VARCHAR(55) NULL,
DDI VARCHAR(4) NOT NULL,
sigla VARCHAR(3) NOT NULL,
fuso_horario CHAR(9) NULL, -- UTC+02:00
continente_idcontinente UNIQUEIDENTIFIER NOT NULL,

CONSTRAINT pk_pais PRIMARY KEY NONCLUSTERED (idpais),
FOREIGN KEY (continente_idcontinente) REFERENCES Pinga.continente(idcontinente),
CONSTRAINT unq_pais UNIQUE (pais, sigla, DDI)
) ON Pinga_FileGroup;

IF EXISTS(SELECT 1 FROM sys.tables WHERE name = 'estado')
BEGIN
    DROP TABLE Pinga.estado;
END

CREATE TABLE Pinga.estado (
idestado UNIQUEIDENTIFIER ROWGUIDCOL NOT NULL DEFAULT NEWID(),
estado VARCHAR(50) NOT NULL,
uf CHAR(2) NOT NULL,
capital BIT NOT NULL DEFAULT 0,
pais_idpais UNIQUEIDENTIFIER NOT NULL,

CONSTRAINT pk_estado PRIMARY KEY NONCLUSTERED (idestado),
FOREIGN KEY (pais_idpais) REFERENCES Pinga.pais(idpais),
CONSTRAINT unq_estado UNIQUE (uf)
) ON Pinga_FileGroup;

IF EXISTS(SELECT 1 FROM sys.tables WHERE name = 'cidade')
BEGIN
    DROP TABLE Pinga.cidade;
END

CREATE TABLE Pinga.cidade (
idcidade UNIQUEIDENTIFIER ROWGUIDCOL NOT NULL DEFAULT NEWID(),
cidade VARCHAR(50) NOT NULL,
DDD CHAR(3) NOT NULL,
capital BIT NOT NULL DEFAULT 0,
estado_idestado UNIQUEIDENTIFIER NOT NULL,

CONSTRAINT pk_cidade PRIMARY KEY NONCLUSTERED (idcidade),
FOREIGN KEY (estado_idestado) REFERENCES Pinga.estado(idestado)
) ON Pinga_FileGroup;

IF EXISTS(SELECT 1 FROM sys.tables WHERE name = 'bairro')
BEGIN
    DROP TABLE Pinga.bairro;
END

CREATE TABLE Pinga.bairro (
idbairro UNIQUEIDENTIFIER ROWGUIDCOL NOT NULL DEFAULT NEWID(),
bairro VARCHAR(50) NOT NULL,
regiao VARCHAR(15) NULL,
cidade_idcidade UNIQUEIDENTIFIER NOT NULL,

CONSTRAINT pk_bairro PRIMARY KEY NONCLUSTERED (idbairro),
FOREIGN KEY (cidade_idcidade) REFERENCES Pinga.cidade(idcidade)
) ON Pinga_FileGroup;

IF EXISTS(SELECT 1 FROM sys.tables WHERE name = 'tipo_logradouro')
BEGIN
    DROP TABLE Pinga.tipo_logradouro;
END

CREATE TABLE Pinga.tipo_logradouro (
idtipo_logradouro UNIQUEIDENTIFIER ROWGUIDCOL NOT NULL DEFAULT NEWID(),
tipo_logradouro VARCHAR(35) NOT NULL,

CONSTRAINT pk_tipo_logradouro PRIMARY KEY NONCLUSTERED (idtipo_logradouro),
CONSTRAINT unq_tipo_logradouro UNIQUE (tipo_logradouro)
) ON Pinga_FileGroup;

IF EXISTS(SELECT 1 FROM sys.tables WHERE name = 'tipo_complemento')
BEGIN
    DROP TABLE Pinga.tipo_complemento;
END

CREATE TABLE Pinga.tipo_complemento (
idtipo_complemento UNIQUEIDENTIFIER ROWGUIDCOL NOT NULL DEFAULT NEWID(),
tipo_complemento VARCHAR(35) NOT NULL,

CONSTRAINT pk_tipo_complemento PRIMARY KEY NONCLUSTERED (idtipo_complemento),
CONSTRAINT unq_tipo_complemento UNIQUE (tipo_complemento)
) ON Pinga_FileGroup;

IF EXISTS(SELECT 1 FROM sys.tables WHERE name = 'endereco')
BEGIN
    DROP TABLE Pinga.endereco;
END

CREATE TABLE Pinga.endereco (
idendereco UNIQUEIDENTIFIER ROWGUIDCOL NOT NULL DEFAULT NEWID(),
tipo_logradouro_idtipo_logradouro UNIQUEIDENTIFIER NOT NULL,
logradouro VARCHAR(100) NOT NULL,
numero INT NULL,
tipo_complemento_idtipo_complemento UNIQUEIDENTIFIER NOT NULL,
complemento VARCHAR(30) NULL,
CEP CHAR(8) NOT NULL,
ponto_referencia VARCHAR(45) NULL,
bairro_idbairro UNIQUEIDENTIFIER NOT NULL,
created SMALLDATETIME NOT NULL DEFAULT GETDATE(),
modified SMALLDATETIME NULL,

CONSTRAINT pk_endereco PRIMARY KEY NONCLUSTERED (idendereco),
FOREIGN KEY (tipo_logradouro_idtipo_logradouro) REFERENCES Pinga.tipo_logradouro(idtipo_logradouro),
FOREIGN KEY (tipo_complemento_idtipo_complemento) REFERENCES Pinga.tipo_complemento(idtipo_complemento),
FOREIGN KEY (bairro_idbairro) REFERENCES Pinga.bairro(idbairro)
) ON Pinga_FileGroup;

IF EXISTS(SELECT 1 FROM sys.tables WHERE name = 'telefone_tipo')
BEGIN
    DROP TABLE Pinga.tipo_telefone;
END

CREATE TABLE Pinga.tipo_telefone (
idtipo_telefone UNIQUEIDENTIFIER ROWGUIDCOL NOT NULL DEFAULT NEWID(),
tipo_telefone VARCHAR(20) NOT NULL,

CONSTRAINT pk_idtipo_telefone PRIMARY KEY NONCLUSTERED (idtipo_telefone),
CONSTRAINT unq_tipo_telefone UNIQUE (tipo_telefone)
);

IF EXISTS(SELECT 1 FROM sys.tables WHERE name = 'operadora')
BEGIN
    DROP TABLE operadora;
END

CREATE TABLE Pinga.operadora (
idoperadora UNIQUEIDENTIFIER ROWGUIDCOL NOT NULL DEFAULT NEWID(),
operadora VARCHAR(25) NOT NULL,
razao_social VARCHAR(40) NOT NULL,
[status] BIT NOT NULL DEFAULT 0,

CONSTRAINT pk_operadora PRIMARY KEY NONCLUSTERED (idoperadora),
CONSTRAINT unq_operadora UNIQUE (operadora)
) ON Pinga_FileGroup;

IF EXISTS(SELECT 1 FROM sys.tables WHERE name = 'telefone')
BEGIN
    DROP TABLE Pinga.telefone;
END

CREATE TABLE Pinga.telefone (
idtelefone UNIQUEIDENTIFIER ROWGUIDCOL NOT NULL DEFAULT NEWID(),
telefone VARCHAR(11) NOT NULL,
cidade_ddd UNIQUEIDENTIFIER NOT NULL,
tipo_telefone_idtipo_telefone UNIQUEIDENTIFIER NOT NULL,
operadora_idoperadora UNIQUEIDENTIFIER NOT NULL,
created SMALLDATETIME NOT NULL DEFAULT GETDATE(),
modified SMALLDATETIME NULL,

CONSTRAINT pk_telefone PRIMARY KEY NONCLUSTERED (idtelefone),
FOREIGN KEY (cidade_ddd) REFERENCES Pinga.cidade(idcidade),
FOREIGN KEY (tipo_telefone_idtipo_telefone) REFERENCES Pinga.tipo_telefone(idtipo_telefone),
FOREIGN KEY (operadora_idoperadora) REFERENCES Pinga.operadora(idoperadora)
) ON Pinga_FileGroup;

IF EXISTS(SELECT 1 FROM sys.tables WHERE name = 'tipo_litragem')
BEGIN
    DROP TABLE Pinga.tipo_litragem;
END

CREATE TABLE Pinga.tipo_litragem (
idtipo_litragem UNIQUEIDENTIFIER ROWGUIDCOL NOT NULL DEFAULT NEWID(),
tipo_litragem VARCHAR(35) NOT NULL,

CONSTRAINT pk_tipo_litragem PRIMARY KEY NONCLUSTERED (idtipo_litragem),
CONSTRAINT unq_tipo_litragem UNIQUE (tipo_litragem)
) ON Pinga_FileGroup;

IF EXISTS(SELECT 1 FROM sys.tables WHERE name = 'tipo_custo')
BEGIN
    DROP TABLE Pinga.tipo_custo;
END

CREATE TABLE Pinga.tipo_custo (
idtipo_custo UNIQUEIDENTIFIER ROWGUIDCOL NOT NULL DEFAULT NEWID(),
tipo_custo VARCHAR(60) NOT NULL,

CONSTRAINT pk_tipo_custo PRIMARY KEY NONCLUSTERED (idtipo_custo),
CONSTRAINT unq_tipo_custo UNIQUE (tipo_custo)
) ON Pinga_FileGroup;

IF EXISTS(SELECT 1 FROM sys.tables WHERE name = 'custo')
BEGIN
    DROP TABLE Pinga.custo;
END

CREATE TABLE Pinga.custo (
idcusto UNIQUEIDENTIFIER ROWGUIDCOL NOT NULL DEFAULT NEWID(),
tipo_custo_idtipo_custo UNIQUEIDENTIFIER NOT NULL,
valor DECIMAL(9,2) NOT NULL,
created SMALLDATETIME NOT NULL DEFAULT GETDATE(),
modified SMALLDATETIME NULL,

CONSTRAINT pk_custo PRIMARY KEY NONCLUSTERED (idcusto),
FOREIGN KEY (tipo_custo_idtipo_custo) REFERENCES Pinga.tipo_custo(idtipo_custo)
) ON Pinga_FileGroup;

IF EXISTS(SELECT 1 FROM sys.tables WHERE name = 'parcelamento')
BEGIN
    DROP TABLE Pinga.parcelamento;
END

CREATE TABLE Pinga.parcelamento (
idparcelamento UNIQUEIDENTIFIER ROWGUIDCOL NOT NULL DEFAULT NEWID(),
data_pagamento DATE NOT NULL,
data_vencimento DATE NOT NULL,
parcelas INT NOT NULL,
juros DECIMAL(8,5) NULL,
created SMALLDATETIME NOT NULL DEFAULT GETDATE(),
modified SMALLDATETIME NULL,

CONSTRAINT pk_parcelamento PRIMARY KEY NONCLUSTERED (idparcelamento)
) ON Pinga_FileGroup;

IF EXISTS(SELECT 1 FROM sys.tables WHERE name = 'entrada')
BEGIN
	ALTER TABLE Pinga.entrada SET (SYSTEM_VERSIONING = OFF);
    DROP TABLE Pinga.entrada;
END

CREATE TABLE Pinga.entrada (
identrada UNIQUEIDENTIFIER ROWGUIDCOL NOT NULL DEFAULT NEWID(),
data DATE NOT NULL DEFAULT GETDATE(),
litragem INT NOT NULL,
tipo_litragem_idtipo_litragem UNIQUEIDENTIFIER NOT NULL,
custo_idcusto UNIQUEIDENTIFIER NOT NULL,
parcelamento_idparcelamento UNIQUEIDENTIFIER NOT NULL,
created DATETIME2 GENERATED ALWAYS AS ROW START NOT NULL,
modified DATETIME2 GENERATED ALWAYS AS ROW END NOT NULL,
PERIOD FOR SYSTEM_TIME(created, modified),

CONSTRAINT pk_entrada PRIMARY KEY NONCLUSTERED (identrada),
FOREIGN KEY (tipo_litragem_idtipo_litragem) REFERENCES Pinga.tipo_litragem(idtipo_litragem),
FOREIGN KEY (custo_idcusto) REFERENCES Pinga.custo(idcusto),
FOREIGN KEY (parcelamento_idparcelamento) REFERENCES Pinga.parcelamento(idparcelamento)
) ON Pinga_FileGroup
WITH (SYSTEM_VERSIONING = ON (HISTORY_TABLE = Legado.entrada));

IF EXISTS(SELECT 1 FROM sys.tables WHERE name = 'fornecedor')
BEGIN
    DROP TABLE Pinga.fornecedor;
END

CREATE TABLE Pinga.fornecedor (
idfornecedor UNIQUEIDENTIFIER ROWGUIDCOL NOT NULL DEFAULT NEWID(),
nome VARCHAR(60) NOT NULL,
endereco_idendereco UNIQUEIDENTIFIER NOT NULL,
telefone_idtelefone UNIQUEIDENTIFIER NOT NULL,

CONSTRAINT pk_fornecedor PRIMARY KEY NONCLUSTERED (idfornecedor),
FOREIGN KEY (endereco_idendereco) REFERENCES Pinga.endereco(idendereco),
FOREIGN KEY (telefone_idtelefone) REFERENCES Pinga.telefone(idtelefone)
) ON Pinga_FileGroup;

IF EXISTS(SELECT 1 FROM sys.tables WHERE name = 'fase')
BEGIN
    DROP TABLE Pinga.fase;
END

CREATE TABLE Pinga.fase (
idfase UNIQUEIDENTIFIER ROWGUIDCOL NOT NULL DEFAULT NEWID(),
fase VARCHAR(60) NOT NULL,
created SMALLDATETIME NOT NULL DEFAULT GETDATE(),
modified SMALLDATETIME NULL,

CONSTRAINT pk_fase PRIMARY KEY NONCLUSTERED (idfase),
CONSTRAINT unq_fase UNIQUE (fase)
) ON Pinga_FileGroup;

IF EXISTS(SELECT 1 FROM sys.tables WHERE name = 'forma_pagamento')
BEGIN
    DROP TABLE Pinga.forma_pagamento;
END

CREATE TABLE Pinga.forma_pagamento (
idforma_pagamento UNIQUEIDENTIFIER ROWGUIDCOL NOT NULL DEFAULT NEWID(),
forma_pagamento VARCHAR(45) NOT NULL,
created SMALLDATETIME NOT NULL DEFAULT GETDATE(),
modified SMALLDATETIME NULL,

CONSTRAINT pk_forma_pagamento PRIMARY KEY NONCLUSTERED (idforma_pagamento),
CONSTRAINT unq_forma_pagamento UNIQUE (forma_pagamento)
) ON Pinga_FileGroup;

IF EXISTS(SELECT 1 FROM sys.tables WHERE name = 'email_localidade')
BEGIN
    DROP TABLE Pinga.email_localidade;
END

CREATE TABLE Pinga.email_localidade (
idemail_localidade UNIQUEIDENTIFIER ROWGUIDCOL NOT NULL DEFAULT NEWID(),
email_localidade VARCHAR(10) NOT NULL,
[status] BIT NOT NULL DEFAULT 0,
	
CONSTRAINT pk_email_localidade PRIMARY KEY NONCLUSTERED (idemail_localidade)
) ON Pinga_FileGroup;

IF EXISTS(SELECT 1 FROM sys.tables WHERE name = 'email_dominio')
BEGIN
    DROP TABLE Pinga.email_dominio;
END

CREATE TABLE Pinga.email_dominio (
idemail_dominio UNIQUEIDENTIFIER ROWGUIDCOL NOT NULL DEFAULT NEWID(),
email_dominio VARCHAR(20) NOT NULL,
[status] BIT NOT NULL DEFAULT 0,
	
CONSTRAINT pk_email_dominio PRIMARY KEY NONCLUSTERED (idemail_dominio)
) ON Pinga_FileGroup;

IF EXISTS(SELECT 1 FROM sys.tables WHERE name = 'email')
BEGIN
    DROP TABLE Pinga.email;
END

CREATE TABLE Pinga.email (
idemail UNIQUEIDENTIFIER ROWGUIDCOL NOT NULL DEFAULT NEWID(),
email VARCHAR(35) NOT NULL,
email_dominio_idemail_dominio UNIQUEIDENTIFIER NOT NULL,
email_localidade_idemail_localidade UNIQUEIDENTIFIER NOT NULL,
	
CONSTRAINT pk_email PRIMARY KEY NONCLUSTERED (idemail),
FOREIGN KEY (email_dominio_idemail_dominio) REFERENCES Pinga.email_dominio(idemail_dominio),
FOREIGN KEY (email_localidade_idemail_localidade) REFERENCES Pinga.email_localidade(idemail_localidade)
) ON Pinga_FileGroup;

IF EXISTS(SELECT 1 FROM sys.tables WHERE name = 'cliente')
BEGIN
    DROP TABLE Pinga.cliente;
END

CREATE TABLE Pinga.cliente (
idcliente UNIQUEIDENTIFIER ROWGUIDCOL NOT NULL DEFAULT NEWID(),
cpf_cnpj VARCHAR(14) NOT NULL,
nome_razao_social VARCHAR(60) NOT NULL,
apelido_nome_fantasia VARCHAR(60) NOT NULL,
inscricao_municipal CHAR(14) NULL,
identidade_inscricao_estadual CHAR(14) NULL,
data_nascimento_fundacao DATE NOT NULL,
sexo CHAR(1) NULL,
email_idemail UNIQUEIDENTIFIER NOT NULL,
endereco_idendereco UNIQUEIDENTIFIER NOT NULL,
telefone_idtelefone UNIQUEIDENTIFIER NOT NULL,
created SMALLDATETIME NOT NULL DEFAULT GETDATE(),
modified SMALLDATETIME NULL,

CONSTRAINT pk_cliente PRIMARY KEY NONCLUSTERED (idcliente),
FOREIGN KEY (endereco_idendereco) REFERENCES Pinga.endereco(idendereco),
FOREIGN KEY (telefone_idtelefone) REFERENCES Pinga.telefone(idtelefone),
FOREIGN KEY (email_idemail) REFERENCES Pinga.email(idemail),
CONSTRAINT chk_sexo CHECK (sexo IN ('M', 'F')),
CONSTRAINT unq_cpf_cnpj UNIQUE NONCLUSTERED (cpf_cnpj)
) ON Pinga_FileGroup;

IF EXISTS(SELECT 1 FROM sys.tables WHERE name = 'informacoes_cliente')
BEGIN
    DROP TABLE Pinga.informacoes_cliente;
END

CREATE TABLE Pinga.informacoes_cliente (
idinformacoes_cliente UNIQUEIDENTIFIER ROWGUIDCOL NOT NULL DEFAULT NEWID(),
cliente_idcliente UNIQUEIDENTIFIER NOT NULL,
tipo_cliente CHAR(2) NOT NULL,
visitado BIT NOT NULL DEFAULT 0,
created SMALLDATETIME NOT NULL DEFAULT GETDATE(),
modified SMALLDATETIME NULL,

CONSTRAINT pk_informacoes_cliente PRIMARY KEY NONCLUSTERED (idinformacoes_cliente),
FOREIGN KEY (cliente_idcliente) REFERENCES Pinga.cliente(idcliente),
CONSTRAINT chk_tipo_cliente CHECK (tipo_cliente IN ('PF', 'PJ'))
) ON Pinga_FileGroup;

IF EXISTS(SELECT 1 FROM sys.tables WHERE name = 'produto_quantidade')
BEGIN
    DROP TABLE Pinga.produto_quantidade;
END

CREATE TABLE Pinga.produto_quantidade (
idproduto_quantidade UNIQUEIDENTIFIER ROWGUIDCOL NOT NULL DEFAULT NEWID(),
quantidade_minima INT NOT NULL,
quantidade_maxima INT NOT NULL,
quantidade_recomenda_estoque INT NOT NULL,
quantidade_solicitar_compra INT NOT NULL,
created SMALLDATETIME NOT NULL DEFAULT GETDATE(),
modified SMALLDATETIME NULL,

CONSTRAINT pk_idproduto_quantidade PRIMARY KEY NONCLUSTERED (idproduto_quantidade)
) ON Pinga_FileGroup;

IF EXISTS(SELECT 1 FROM sys.tables WHERE name = 'produto')
BEGIN
    DROP TABLE Pinga.produto;
END

CREATE TABLE Pinga.produto (
idproduto UNIQUEIDENTIFIER ROWGUIDCOL NOT NULL DEFAULT NEWID(),
produto VARCHAR(30) NOT NULL,
tipo_litragem_idtipo_litragem UNIQUEIDENTIFIER NOT NULL,
litragem INT NULL,
vendendo BIT NOT NULL DEFAULT 0,
valor_unitario DECIMAL(9,2) NULL,
produto_quantidade_idproduto_quantidade UNIQUEIDENTIFIER NOT NULL,
created SMALLDATETIME NOT NULL DEFAULT GETDATE(),
modified SMALLDATETIME NULL,

CONSTRAINT pk_produto PRIMARY KEY NONCLUSTERED (idproduto),
FOREIGN KEY (tipo_litragem_idtipo_litragem) REFERENCES Pinga.tipo_litragem(idtipo_litragem),
FOREIGN KEY (produto_quantidade_idproduto_quantidade) REFERENCES Pinga.produto_quantidade(idproduto_quantidade),
CONSTRAINT unq_produto UNIQUE (produto)
) ON Pinga_FileGroup;

IF EXISTS(SELECT 1 FROM sys.tables WHERE name = 'parceiro')
BEGIN
    DROP TABLE Pinga.parceiro;
END

CREATE TABLE Pinga.parceiro (
idparceiro UNIQUEIDENTIFIER ROWGUIDCOL NOT NULL DEFAULT NEWID(),
nome VARCHAR(60) NOT NULL,
endereco_idendereco UNIQUEIDENTIFIER NOT NULL,
[status] BIT NOT NULL DEFAULT 0,
telefone_idtelefone UNIQUEIDENTIFIER NOT NULL,
created SMALLDATETIME NOT NULL DEFAULT GETDATE(),
modified SMALLDATETIME NULL,

CONSTRAINT pk_parceiro PRIMARY KEY NONCLUSTERED (idparceiro),
FOREIGN KEY (endereco_idendereco) REFERENCES Pinga.endereco(idendereco),
FOREIGN KEY (telefone_idtelefone) REFERENCES Pinga.telefone(idtelefone)
) ON Pinga_FileGroup;

IF EXISTS(SELECT 1 FROM sys.tables WHERE name = 'saida')
BEGIN
    DROP TABLE Pinga.saida;
END

CREATE TABLE Pinga.saida (
idsaida UNIQUEIDENTIFIER ROWGUIDCOL NOT NULL DEFAULT NEWID(),
data SMALLDATETIME NOT NULL DEFAULT GETDATE(),
parceiro_idparceiro UNIQUEIDENTIFIER NOT NULL,
cliente_idcliente UNIQUEIDENTIFIER NOT NULL,
fase_idfase UNIQUEIDENTIFIER NOT NULL,
forma_pagamento_idforma_pagamento UNIQUEIDENTIFIER NOT NULL,
parcelamento_idparcelamento UNIQUEIDENTIFIER NOT NULL,
created SMALLDATETIME NOT NULL DEFAULT GETDATE(),
modified SMALLDATETIME NULL,

CONSTRAINT pk_saida PRIMARY KEY NONCLUSTERED (idsaida),
FOREIGN KEY (parceiro_idparceiro) REFERENCES Pinga.parceiro(idparceiro),
FOREIGN KEY (cliente_idcliente) REFERENCES Pinga.cliente(idcliente),
FOREIGN KEY (fase_idfase) REFERENCES Pinga.fase(idfase),
FOREIGN KEY (forma_pagamento_idforma_pagamento) REFERENCES Pinga.forma_pagamento(idforma_pagamento),
FOREIGN KEY (parcelamento_idparcelamento) REFERENCES Pinga.parcelamento(idparcelamento)
) ON Pinga_FileGroup;

IF EXISTS(SELECT 1 FROM sys.tables WHERE name = 'itens_saida')
BEGIN
    ALTER TABLE Pinga.itens_saida SET (SYSTEM_VERSIONING = OFF);
	DROP TABLE Pinga.itens_saida;
END

CREATE TABLE Pinga.itens_saida (
iditens_saida UNIQUEIDENTIFIER ROWGUIDCOL NOT NULL DEFAULT NEWID(),
saida_idsaida UNIQUEIDENTIFIER NOT NULL,
produto_idproduto UNIQUEIDENTIFIER NOT NULL,
quantidade INT NOT NULL,
valor_saida DECIMAL(9,2) NOT NULL,
created DATETIME2 GENERATED ALWAYS AS ROW START NOT NULL,
modified DATETIME2 GENERATED ALWAYS AS ROW END NOT NULL,
PERIOD FOR SYSTEM_TIME (created, modified),

CONSTRAINT pk_itens_saida PRIMARY KEY NONCLUSTERED (iditens_saida),
FOREIGN KEY (saida_idsaida) REFERENCES Pinga.saida(idsaida),
FOREIGN KEY (produto_idproduto) REFERENCES Pinga.produto(idproduto)
) ON Pinga_FileGroup
WITH (SYSTEM_VERSIONING = ON (HISTORY_TABLE = Legado.itens_saida));

IF EXISTS(SELECT 1 FROM sys.tables WHERE name = 'estoque')
BEGIN
	ALTER TABLE Pinga.estoque SET (SYSTEM_VERSIONING = OFF);
    DROP TABLE Pinga.estoque;
END

CREATE TABLE Pinga.estoque (
idestoque UNIQUEIDENTIFIER ROWGUIDCOL NOT NULL DEFAULT NEWID(),
produto_idproduto UNIQUEIDENTIFIER NOT NULL,
quantidade INT NOT NULL,
created DATETIME2 GENERATED ALWAYS AS ROW START NOT NULL,
modified DATETIME2 GENERATED ALWAYS AS ROW END NOT NULL,
PERIOD FOR SYSTEM_TIME (created, modified),

CONSTRAINT pk_estoque PRIMARY KEY NONCLUSTERED (idestoque),
FOREIGN KEY (produto_idproduto) REFERENCES Pinga.produto(idproduto)
) ON Pinga_FileGroup
WITH (SYSTEM_VERSIONING = ON (HISTORY_TABLE = Legado.estoque));

IF EXISTS(SELECT 1 FROM sys.tables WHERE name = 'students')
BEGIN
    DROP TABLE students;
END
GO

CREATE SCHEMA adm;
GO

CREATE TABLE adm.login(
idlogin UNIQUEIDENTIFIER ROWGUIDCOL NOT NULL DEFAULT NEWID(),
lgn VARCHAR(30) NOT NULL,
pwd VARCHAR(65) NOT NULL,
[status] BIT NOT NULL DEFAULT 0,
created SMALLDATETIME NOT NULL DEFAULT GETDATE(),
modified SMALLDATETIME NULL,

CONSTRAINT pk_login PRIMARY KEY NONCLUSTERED (idlogin)
) ON Adm_FileGroup;

INSERT INTO adm.login (lgn,pwd,[status]) VALUES ('123', '123', 1);
SELECT * FROM adm.login;

UPDATE adm.login SET pwd = '40BD001563085FC35165329EA1FF5C5ECBDBBEEF' WHERE lgn = '123';

exec sp_tables;


IF EXISTS(SELECT 1 FROM sys.tables WHERE name = 'cliente_has_parceiro')
BEGIN
    DROP TABLE Pinga.cliente_has_parceiro;
END

CREATE TABLE Pinga.cliente_has_parceiro (
idcliente_has_parceiro UNIQUEIDENTIFIER ROWGUIDCOL NOT NULL DEFAULT NEWID(),
cliente_idcliente UNIQUEIDENTIFIER NOT NULL,
parceiro_idparceiro UNIQUEIDENTIFIER NOT NULL,
created SMALLDATETIME NOT NULL DEFAULT GETDATE(),
modified SMALLDATETIME NULL,

FOREIGN KEY (cliente_idcliente) REFERENCES Pinga.cliente(idcliente),
FOREIGN KEY (parceiro_idparceiro) REFERENCES Pinga.parceiro(idparceiro)
) ON Pinga_FileGroup;

IF EXISTS(SELECT 1 FROM sys.tables WHERE name = 'representante')
BEGIN
    DROP TABLE Pinga.representante;
END

CREATE TABLE Pinga.representante (
idrepresentante UNIQUEIDENTIFIER ROWGUIDCOL NOT NULL DEFAULT NEWID(),
nome VARCHAR(50) NOT NULL,
telefone_idtelefone UNIQUEIDENTIFIER NOT NULL,
email VARCHAR(50) NULL,
departamento VARCHAR(30) NULL,
cargo VARCHAR(25) NOT NULL,
[status] BIT NOT NULL DEFAULT 0,

CONSTRAINT pk_representante PRIMARY KEY NONCLUSTERED (idrepresentante),
FOREIGN KEY (telefone_idtelefone) REFERENCES Pinga.telefone(idtelefone)
) ON Pinga_FileGroup;

IF EXISTS(SELECT 1 FROM sys.tables WHERE name = 'cliente_has_representante')
BEGIN
    DROP TABLE Pinga.cliente_has_representante;
END

CREATE TABLE Pinga.cliente_has_representante (
idcliente_has_representante UNIQUEIDENTIFIER ROWGUIDCOL NOT NULL DEFAULT NEWID(),
cliente_idcliente UNIQUEIDENTIFIER NOT NULL,
representante_idrepresentante UNIQUEIDENTIFIER NOT NULL,
responsavel_contrato BIT NOT NULL DEFAULT 0

FOREIGN KEY (cliente_idcliente) REFERENCES Pinga.cliente(idcliente),
FOREIGN KEY (representante_idrepresentante) REFERENCES Pinga.representante(idrepresentante)
) ON Pinga_FileGroup;

/*CREATE TABLE vendedor (
idvendedor UNIQUEIDENTIFIER ROWGUIDCOL NOT NULL DEFAULT NEWID(),
firstName
middleName
lastName
birthDate
Pis
cpf,
identidade,
orgaoEmissor,
dataEmissao,
dataAdmissao,
dataDemissao,
email,
telefone_idtelefone
endereco_idendereco,
[status],

);*/

IF EXISTS(SELECT 1 FROM sys.tables WHERE name = 'visita')
BEGIN
    DROP TABLE Pinga.visita;
END

CREATE TABLE Pinga.visita (
idvisita UNIQUEIDENTIFIER ROWGUIDCOL NOT NULL DEFAULT NEWID(),
cliente_idcliente UNIQUEIDENTIFIER NOT NULL,
[data] DATE NOT NULL,
comecou TIME NULL,
terminou TIME NULL,
--realizada_por (Criar table FUNCIONARIOS ou VENDEDORES)

CONSTRAINT pk_visita PRIMARY KEY NONCLUSTERED (idvisita),
FOREIGN KEY (cliente_idcliente) REFERENCES Pinga.cliente(idcliente)
) ON Pinga_FileGroup;

IF EXISTS(SELECT 1 FROM sys.tables WHERE name = 'parceiro_has_visita')
BEGIN
    DROP TABLE Pinga.parceiro_has_visita;
END

CREATE TABLE Pinga.parceiro_has_visita (
idparceiro_has_visita UNIQUEIDENTIFIER ROWGUIDCOL NOT NULL DEFAULT NEWID(),
parceiro_idparceiro UNIQUEIDENTIFIER NOT NULL,
visita_idvisita UNIQUEIDENTIFIER NOT NULL

FOREIGN KEY (parceiro_idparceiro) REFERENCES Pinga.parceiro(idparceiro),
FOREIGN KEY (visita_idvisita) REFERENCES Pinga.visita(idvisita),
) ON Pinga_FileGroup;

IF EXISTS(SELECT 1 FROM sys.tables WHERE name = 'feedback_visita')
BEGIN
    DROP TABLE Pinga.feedback_visita;
END

CREATE TABLE Pinga.feedback_visita (
idfeedback_visita UNIQUEIDENTIFIER ROWGUIDCOL NOT NULL DEFAULT NEWID(),
visita_idvisita UNIQUEIDENTIFIER NOT NULL,
comentario VARCHAR(100) NULL,
nota TINYINT NOT NULL,
venda_realizada BIT NOT NULL,
visita_reagendada BIT NOT NULL, -- criar uma nova visita
created SMALLDATETIME NOT NULL DEFAULT GETDATE(),
modified SMALLDATETIME NULL,

CONSTRAINT pk_feedback_visita PRIMARY KEY NONCLUSTERED (idfeedback_visita),
FOREIGN KEY (visita_idvisita) REFERENCES Pinga.visita(idvisita)
) ON Pinga_FileGroup;

IF EXISTS(SELECT 1 FROM sys.tables WHERE name = 'tipo_periodicidade_entrega')
BEGIN
    DROP TABLE Pinga.tipo_periodicidade_entrega;
END

CREATE TABLE Pinga.tipo_periodicidade_entrega (
idtipo_periodicidade_entrega UNIQUEIDENTIFIER ROWGUIDCOL NOT NULL DEFAULT NEWID(),
tipo_periodicidade_entrega VARCHAR(15) NOT NULL,
[status] BIT NOT NULL DEFAULT 0,
	
CONSTRAINT pk_tipo_periodicidade_entrega PRIMARY KEY NONCLUSTERED (idtipo_periodicidade_entrega),
CONSTRAINT unq_tipo_periodicidade_entrega UNIQUE (tipo_periodicidade_entrega)
) ON Pinga_FileGroup;

IF EXISTS(SELECT 1 FROM sys.tables WHERE name = 'tipo_periodicidade_entrega_dia')
BEGIN
    DROP TABLE Pinga.tipo_periodicidade_entrega_dia;
END

CREATE TABLE Pinga.tipo_periodicidade_entrega_dia (
idtipo_periodicidade_entrega_dia UNIQUEIDENTIFIER ROWGUIDCOL NOT NULL DEFAULT NEWID(),
dias VARCHAR(85) NOT NULL,
dias_uteis BIT NOT NULL DEFAULT 0, -- somente será 1 se todos os dias são uteis
dia_feriado BIT NOT NULL DEFAULT 0, -- avaliar se é para feriados que são no dia certo ou que são em dias variaveis

CONSTRAINT pk_tipo_periodicidade_entrega_dia PRIMARY KEY NONCLUSTERED (idtipo_periodicidade_entrega_dia)
) ON Pinga_FileGroup;

IF EXISTS(SELECT 1 FROM sys.tables WHERE name = 'periodicidade_entrega')
BEGIN
    DROP TABLE Pinga.periodicidade_entrega;
END

CREATE TABLE Pinga.periodicidade_entrega (
idperiodicidade_entrega UNIQUEIDENTIFIER ROWGUIDCOL NOT NULL DEFAULT NEWID(),
tipo_periodicidade_entrega_idtipo_periodicidade_entrega UNIQUEIDENTIFIER NOT NULL,
cliente_idcliente UNIQUEIDENTIFIER NOT NULL,
[status] BIT NOT NULL DEFAULT 0,

CONSTRAINT pk_periodicidade_entrega PRIMARY KEY NONCLUSTERED (idperiodicidade_entrega),
FOREIGN KEY (tipo_periodicidade_entrega_idtipo_periodicidade_entrega) REFERENCES Pinga.tipo_periodicidade_entrega(idtipo_periodicidade_entrega),
FOREIGN KEY (cliente_idcliente) REFERENCES Pinga.cliente(idcliente)
) ON Pinga_FileGroup;

IF EXISTS(SELECT 1 FROM sys.tables WHERE name = 'periodicidade_has_produto')
BEGIN
    DROP TABLE Pinga.periodicidade_has_produto;
END

CREATE TABLE Pinga.periodicidade_has_produto (
idperiodicidade_has_produto UNIQUEIDENTIFIER ROWGUIDCOL NOT NULL DEFAULT NEWID(),
periodicidade_entrega_idperiodicidade_entrega UNIQUEIDENTIFIER NOT NULL,
produto_idproduto UNIQUEIDENTIFIER NOT NULL,
	
CONSTRAINT pk_periodicidade_has_produto PRIMARY KEY NONCLUSTERED (idperiodicidade_has_produto),
FOREIGN KEY (periodicidade_entrega_idperiodicidade_entrega) REFERENCES Pinga.periodicidade_entrega(idperiodicidade_entrega),
FOREIGN KEY (produto_idproduto) REFERENCES Pinga.produto(idproduto),
) ON Pinga_FileGroup;

IF EXISTS(SELECT 1 FROM sys.tables WHERE name = 'contrato')
BEGIN
    DROP TABLE Pinga.contrato;
END

CREATE TABLE Pinga.contrato (
idcontrato UNIQUEIDENTIFIER ROWGUIDCOL NOT NULL DEFAULT NEWID(),
cliente_idcliente UNIQUEIDENTIFIER NOT NULL,
data_entrada_vigor DATE NOT NULL,
data_expiracao DATE NOT NULL,
data_assinatura DATE NULL,
periodicidade_entrega_idperiodicidade_entrega UNIQUEIDENTIFIER NOT NULL,
prorrogavel BIT NOT NULL DEFAULT 0,
[status] BIT NOT NULL DEFAULT 0,
forma_pagamento_idforma_pagamento UNIQUEIDENTIFIER NOT NULL,
multa_quebra DECIMAL (9,2) NOT NULL,

CONSTRAINT pk_contrato PRIMARY KEY NONCLUSTERED (idcontrato),
FOREIGN KEY (cliente_idcliente) REFERENCES Pinga.cliente(idcliente),
FOREIGN KEY (periodicidade_entrega_idperiodicidade_entrega) REFERENCES Pinga.periodicidade_entrega(idperiodicidade_entrega),
FOREIGN KEY (forma_pagamento_idforma_pagamento) REFERENCES Pinga.forma_pagamento(idforma_pagamento)
) ON Pinga_FileGroup;

IF EXISTS(SELECT 1 FROM sys.tables WHERE name = 'contrato_has_produto')
BEGIN
	DROP TABLE Pinga.contrato_has_produto;
END

CREATE TABLE Pinga.contrato_has_produto (
idcontrato_has_produto UNIQUEIDENTIFIER ROWGUIDCOL NOT NULL DEFAULT NEWID(),
contrato_idcontrato UNIQUEIDENTIFIER NOT NULL,
produto_idproduto UNIQUEIDENTIFIER NOT NULL,
created SMALLDATETIME NOT NULL DEFAULT GETDATE(),
modified SMALLDATETIME NULL,

CONSTRAINT pk_contrato_has_produto PRIMARY KEY NONCLUSTERED (idcontrato_has_produto),
FOREIGN KEY (contrato_idcontrato) REFERENCES Pinga.contrato(idcontrato),
FOREIGN KEY (produto_idproduto) REFERENCES Pinga.produto(idproduto),
) ON Pinga_FileGroup;

IF EXISTS(SELECT 1 FROM sys.tables WHERE name = 'testemunha')
BEGIN
    DROP TABLE Pinga.testemunha;
END

CREATE TABLE Pinga.testemunha (
idtestemunha UNIQUEIDENTIFIER ROWGUIDCOL NOT NULL DEFAULT NEWID(),
primeiro_nome VARCHAR(20) NOT NULL,
nome_meio VARCHAR(40) NULL,
sobrenome VARCHAR(25) NOT NULL,
cpf CHAR(11) NOT NULL,
contrato_idcontrato UNIQUEIDENTIFIER NOT NULL,

CONSTRAINT pk_testemunha PRIMARY KEY NONCLUSTERED (idtestemunha),
FOREIGN KEY (contrato_idcontrato) REFERENCES Pinga.contrato(idcontrato)
) ON Pinga_FileGroup;

CREATE TABLE adm.parceiro_has_login (
idparceiro_has_login UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),
parceiro_idparceiro UNIQUEIDENTIFIER NOT NULL,
login_idlogin UNIQUEIDENTIFIER NOT NULL,
created DATETIME NOT NULL DEFAULT GETDATE(),
modified DATETIME NULL,

CONSTRAINT pk_parceiro_has_login PRIMARY KEY (idparceiro_has_login),
FOREIGN KEY (parceiro_idparceiro) REFERENCES Pinga.parceiro(idparceiro),
FOREIGN KEY (login_idlogin) REFERENCES adm.login(idlogin)
) ON Adm_FileGroup;

--ALTER TABLE PingaDB.Pinga.visita ALTER COLUMN endereco UNIQUEIDENTIFIER NULL;


IF EXISTS(SELECT 1 FROM sys.tables WHERE name = 'log_erros')
BEGIN
    DROP TABLE adm.log_erros;
END

CREATE TABLE adm.log_erros (
idlog_erros UNIQUEIDENTIFIER ROWGUIDCOL NOT NULL DEFAULT NEWID(),
usuario VARCHAR(30) NOT NULL DEFAULT SYSTEM_USER,
erro VARCHAR(100) NOT NULL,
horario SMALLDATETIME NOT NULL DEFAULT GETDATE(),
procedimento VARCHAR(80) NOT NULL,
possivel_causa VARCHAR(80) NULL,
error_comes_from VARCHAR(20) NOT NULL, --database, application

CONSTRAINT pk_log_erros PRIMARY KEY NONCLUSTERED (idlog_erros),
CONSTRAINT chk_error_from CHECK (error_comes_from IN ('database','application'))
) ON Adm_FileGroup;
GO

CREATE OR ALTER PROCEDURE adm.usp_errorLog
	@erro VARCHAR(250),
	@procedimento VARCHAR(80),
	@possivelCausa VARCHAR(80),
	@errorComesFrom VARCHAR(20)
AS
BEGIN
	SET NOCOUNT ON;
	IF XACT_STATE() = 1
	BEGIN
		COMMIT;
	END
	ELSE IF XACT_STATE() = -1
	BEGIN
		ROLLBACK;
	END

	BEGIN TRY
		BEGIN TRANSACTION;
			INSERT INTO adm.log_erros (usuario, erro, horario, procedimento, possivel_causa, error_comes_from)
			VALUES (SYSTEM_USER, @erro, GETDATE(), @procedimento, @possivelCausa, @errorComesFrom);
		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		ROLLBACK;
		THROW 99999, 'Erro no errorLog', 1;
	END CATCH;
END;
GO

--EXEC sp_refreshsqlmodule 'adm.usp_errorLog'
--EXEC adm.usp_errorLog 'Erro', 'procedimento', 'possivelCausa', 'database';
--TRUNCATE TABLE adm.log_erros;

CREATE OR ALTER PROCEDURE Pinga.usp_InserirNovoTipoContinente
    @tipoContinente VARCHAR(20),
    @ativo BIT
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        SET NOCOUNT ON;
        BEGIN TRANSACTION;
            INSERT INTO Pinga.tipo_continente (tipo_continente, ativo)
            VALUES (@tipoContinente, @ativo);
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK;
        DECLARE @err VARCHAR(250) = (SELECT CONCAT(N'ErrorNumber: ', ERROR_NUMBER(),
                                                   N' - ErrorMessage: ', CONVERT(VARCHAR(200), ERROR_MESSAGE() COLLATE Latin1_General_CS_AS),
                                                   N'::L ', ERROR_LINE()));
        DECLARE @proc VARCHAR(50) = (SELECT CONCAT(N'USER PROCEDURE: ', CONVERT(VARCHAR(30), ERROR_PROCEDURE() COLLATE Latin1_General_CS_AS)));
        EXECUTE adm.usp_errorLog @err, @proc, 'Desconhecida', 'database';
        THROW 51921, 'Falha ao realizar o insert do tipo continente.', 1;
    END CATCH
END;


CREATE OR ALTER PROCEDURE Pinga.usp_InserirNovoPais
	@pais VARCHAR(40),
	@idioma VARCHAR(40),
	@colacao VARCHAR(55),
	@DDI VARCHAR(4),
	@sigla VARCHAR(3),
	@fusoHorario CHAR(9),
	@continenteIdcontinente UNIQUEIDENTIFIER
AS
BEGIN
	SET NOCOUNT ON;
	BEGIN TRY
		SET NOCOUNT ON;
		BEGIN TRANSACTION
			INSERT INTO Pinga.pais (pais, idioma, colacao, DDI, sigla, fuso_horario, continente_idcontinente)
			VALUES (@pais, @idioma, @colacao, @DDI, @sigla, @fusoHorario, @continenteIdcontinente);
		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		ROLLBACK;
		DECLARE @err VARCHAR(250) = (SELECT CONCAT(N'ErrorNumber: ', ERROR_NUMBER(),
												   N' - ErrorMessage: ', CONVERT(VARCHAR(200), ERROR_MESSAGE() COLLATE Latin1_General_CS_AS),
												   N'::L ', ERROR_LINE()));
		DECLARE @proc VARCHAR(50) = (SELECT CONCAT(N'USER PROCEDURE: ', CONVERT(VARCHAR(30), ERROR_PROCEDURE() COLLATE Latin1_General_CS_AS)));
		EXECUTE adm.usp_errorLog @err, @proc, 'Desconhecida', 'database';
		THROW 51921, 'Falha ao realizar o insert do país.', 1;
	END CATCH
END;

EXEC Pinga.usp_InserirNovoPais 'Argentina', 'Espanhol', 'Latin1_General_CS_AS', '54', 'ARG', 'UTC-03:00', '1D611A60-2721-420A-8B6C-33FB2A660024';
GO

/* USP's INSERIR PRODUTO */
CREATE PROCEDURE Pinga.usp_InserirNovoProduto
	@descricao VARCHAR(30),
	@tipoLitragemIdtipoLitragem UNIQUEIDENTIFIER,
	@litragem INT,
	@vendendo BIT,
	@valorUnitario DECIMAL(9,2),
	@produtoQuantidadeIdprodutoQuantidade UNIQUEIDENTIFIER
AS
BEGIN
	SET NOCOUNT ON;
	BEGIN TRY
		SET NOCOUNT ON;
		BEGIN TRANSACTION
			INSERT INTO Pinga.produto (produto, tipo_litragem_idtipo_litragem, litragem, vendendo, valor_unitario, produto_quantidade_idproduto_quantidade, created)
			VALUES (@descricao, @tipoLitragemIdtipoLitragem, @litragem, @vendendo, @valorUnitario, @produtoQuantidadeIdprodutoQuantidade, GETDATE());
		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		ROLLBACK;
		DECLARE @err VARCHAR(250) = (SELECT CONCAT(N'ErrorNumber: ', ERROR_NUMBER(),
												   N' - ErrorMessage: ', CONVERT(VARCHAR(200), ERROR_MESSAGE() COLLATE Latin1_General_CS_AS),
												   N'::L ', ERROR_LINE()));
		DECLARE @proc VARCHAR(50) = (SELECT CONCAT(N'USER PROCEDURE: ', CONVERT(VARCHAR(30), ERROR_PROCEDURE() COLLATE Latin1_General_CS_AS)));
		EXECUTE adm.usp_errorLog @err, @proc, 'Desconhecida', 'database';
		THROW 51921, 'Falha ao realizar o insert do produto apenas.', 1;
	END CATCH
END;
GO

CREATE PROCEDURE Pinga.usp_InserirNovoProdutoComTipoLitragem
	@descricaoProduto VARCHAR(30),
	@descricaoTipoLitragem VARCHAR(35),
	@litragem INT,
	@vendendo BIT,
	@valorUnitario DECIMAL(9,2),
	@produtoQuantidadeIdprodutoQuantidade UNIQUEIDENTIFIER
AS
BEGIN
	SET NOCOUNT ON;
	BEGIN TRY
		BEGIN TRANSACTION
			INSERT INTO Pinga.tipo_litragem (tipo_litragem)
			VALUES (@descricaoTipoLitragem);
		COMMIT TRANSACTION;   
		DECLARE @idtipoLitagrem UNIQUEIDENTIFIER = (SELECT TOP 1 idtipo_litragem FROM Pinga.tipo_litragem WHERE tipo_litragem = @descricaoTipoLitragem);
		BEGIN TRANSACTION
			INSERT INTO Pinga.produto (produto, tipo_litragem_idtipo_litragem, litragem, vendendo, valor_unitario, produto_quantidade_idproduto_quantidade, created)
			VALUES (@descricaoProduto, @idtipoLitagrem, @litragem, @vendendo, @valorUnitario, @produtoQuantidadeIdprodutoQuantidade, GETDATE());
		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		ROLLBACK;
		DECLARE @err VARCHAR(250) = (SELECT CONCAT(N'ErrorNumber: ', ERROR_NUMBER(),
												   N' - ErrorMessage: ', CONVERT(VARCHAR(200), ERROR_MESSAGE() COLLATE Latin1_General_CS_AS),
												   N'::L ', ERROR_LINE()));
		DECLARE @proc VARCHAR(50) = (SELECT CONCAT(N'USER PROCEDURE: ', CONVERT(VARCHAR(30), ERROR_PROCEDURE() COLLATE Latin1_General_CS_AS)));
		EXECUTE adm.usp_errorLog @err, @proc, 'Desconhecida', 'database';
		THROW 51921, 'Falha ao realizar o insert do produto com tipo litragem.', 1;
	END CATCH
END;
GO

CREATE PROCEDURE Pinga.usp_InserirNovoProdutoComQuantidadeProduto
	@descricao VARCHAR(30),
	@tipoLitragemIdtipoLitragem UNIQUEIDENTIFIER,
	@litragem INT,
	@vendendo BIT,
	@valorUnitario DECIMAL(9,2),
	@quantidadeMinima INT,
	@quantidadeMaxima INT,
	@quantidadeRecomendaEstoque INT,
	@quantidadeSolicitarCompra INT
AS
BEGIN
	SET NOCOUNT ON;
	BEGIN TRY
		BEGIN TRANSACTION
			INSERT INTO Pinga.produto_quantidade (quantidade_minima, quantidade_maxima, quantidade_recomenda_estoque, quantidade_solicitar_compra, created)
			VALUES (@quantidadeMinima, @quantidadeMaxima, @quantidadeRecomendaEstoque, @quantidadeSolicitarCompra, GETDATE());
		COMMIT TRANSACTION;   
		DECLARE @idprodutoQuantidade UNIQUEIDENTIFIER = (SELECT TOP 1 idproduto_quantidade FROM Pinga.produto_quantidade WHERE quantidade_minima = @quantidadeMinima AND quantidade_maxima = @quantidadeMaxima AND quantidade_recomenda_estoque = @quantidadeRecomendaEstoque AND quantidade_solicitar_compra = @quantidadeSolicitarCompra ORDER BY created DESC);
		BEGIN TRANSACTION
			INSERT INTO Pinga.produto (produto, tipo_litragem_idtipo_litragem, litragem, vendendo, valor_unitario, produto_quantidade_idproduto_quantidade, created)
			VALUES (@descricao, @tipoLitragemIdtipoLitragem, @litragem, @vendendo, @valorUnitario, @idprodutoQuantidade, GETDATE());
		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		ROLLBACK;
		DECLARE @err VARCHAR(250) = (SELECT CONCAT(N'ErrorNumber: ', ERROR_NUMBER(),
												   N' - ErrorMessage: ', CONVERT(VARCHAR(200), ERROR_MESSAGE() COLLATE Latin1_General_CS_AS),
												   N'::L ', ERROR_LINE()));
		DECLARE @proc VARCHAR(50) = (SELECT CONCAT(N'USER PROCEDURE: ', CONVERT(VARCHAR(30), ERROR_PROCEDURE() COLLATE Latin1_General_CS_AS)));
		EXECUTE adm.usp_errorLog @err, @proc, 'Desconhecida', 'database';
		THROW 51921, 'Falha ao realizar o insert do produto com quantidade produto.', 1;
	END CATCH
END;
GO

CREATE PROCEDURE Pinga.usp_InserirNovoProdutoCompleto
	@descricao VARCHAR(30),
	@descricaoTipoLitragem VARCHAR(35),
	@litragem INT,
	@vendendo BIT,
	@valorUnitario DECIMAL(9,2),
	@quantidadeMinima INT,
	@quantidadeMaxima INT,
	@quantidadeRecomendaEstoque INT,
	@quantidadeSolicitarCompra INT
AS
BEGIN
	SET NOCOUNT ON;
	BEGIN TRY
		BEGIN TRANSACTION
			INSERT INTO Pinga.tipo_litragem (tipo_litragem)
			VALUES (@descricaoTipoLitragem);
		COMMIT TRANSACTION;
		BEGIN TRANSACTION
			INSERT INTO Pinga.produto_quantidade (quantidade_minima, quantidade_maxima, quantidade_recomenda_estoque, quantidade_solicitar_compra, created)
			VALUES (@quantidadeMinima, @quantidadeMaxima, @quantidadeRecomendaEstoque, @quantidadeSolicitarCompra, GETDATE());
		COMMIT TRANSACTION;
		DECLARE @idtipoLitagrem UNIQUEIDENTIFIER = (SELECT TOP 1 idtipo_litragem FROM Pinga.tipo_litragem WHERE tipo_litragem = @descricaoTipoLitragem);
		DECLARE @idprodutoQuantidade UNIQUEIDENTIFIER = (SELECT TOP 1 idproduto_quantidade FROM Pinga.produto_quantidade WHERE quantidade_minima = @quantidadeMinima AND quantidade_maxima = @quantidadeMaxima AND quantidade_recomenda_estoque = @quantidadeRecomendaEstoque AND quantidade_solicitar_compra = @quantidadeSolicitarCompra ORDER BY created DESC); 
		BEGIN TRANSACTION
			INSERT INTO Pinga.produto (produto, tipo_litragem_idtipo_litragem, litragem, vendendo, valor_unitario, produto_quantidade_idproduto_quantidade, created)
			VALUES (@descricao, @idtipoLitagrem, @litragem, @vendendo, @valorUnitario, @idprodutoQuantidade, GETDATE());
		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		ROLLBACK;
		DECLARE @err VARCHAR(250) = (SELECT CONCAT(N'ErrorNumber: ', ERROR_NUMBER(),
												   N' - ErrorMessage: ', CONVERT(VARCHAR(200), ERROR_MESSAGE() COLLATE Latin1_General_CS_AS),
												   N'::L ', ERROR_LINE()));
		DECLARE @proc VARCHAR(50) = (SELECT CONCAT(N'USER PROCEDURE: ', CONVERT(VARCHAR(30), ERROR_PROCEDURE() COLLATE Latin1_General_CS_AS)));
		EXECUTE adm.usp_errorLog @err, @proc, 'Desconhecida', 'database';
		THROW 51921, 'Falha ao realizar o insert do produto completo.', 1;
	END CATCH
END;
GO
/* USP's INSERIR PRODUTO */

/* USP's INSERIR CLIENTE */
CREATE OR ALTER PROCEDURE Pinga.usp_InserirNovoCliente
    @cpfCnpj VARCHAR(14),
	@nomeRazaoSocial VARCHAR(60),
	@apelidoNomeFantasia VARCHAR(60),
	@inscricaoMunicipal CHAR(14),
	@identidadeInscricaoestadual CHAR(14),
	@dataNascimentoFundacao DATE,
	@sexo CHAR(1),
	@enderecoIdendereco UNIQUEIDENTIFIER,
	@telefoneIdtelefone UNIQUEIDENTIFIER
AS
BEGIN
	SET NOCOUNT ON;
	BEGIN TRY
		BEGIN TRANSACTION
			INSERT INTO Pinga.cliente (cpf_cnpj, nome_razao_social, apelido_nome_fantasia, inscricao_municipal, identidade_inscricao_estadual, data_nascimento_fundacao, sexo, endereco_idendereco, telefone_idtelefone, created)
			VALUES (@cpfCnpj, @nomeRazaoSocial, @apelidoNomeFantasia, @inscricaoMunicipal, @identidadeInscricaoEstadual, @dataNascimentoFundacao, @sexo, @enderecoIdendereco, @telefoneIdtelefone, GETDATE());
		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		ROLLBACK;
		DECLARE @err VARCHAR(250) = (SELECT CONCAT(N'ErrorNumber: ', ERROR_NUMBER(),
												   N' - ErrorMessage: ', CONVERT(VARCHAR(200), ERROR_MESSAGE() COLLATE Latin1_General_CS_AS),
												   N'::L ', ERROR_LINE()));
		DECLARE @proc VARCHAR(50) = (SELECT CONCAT(N'USER PROCEDURE: ', CONVERT(VARCHAR(30), ERROR_PROCEDURE() COLLATE Latin1_General_CS_AS)));
		EXECUTE adm.usp_errorLog @err, @proc, 'Desconhecida', 'database';
		THROW 51921, 'Falha ao realizar o insert do cliente apenas.', 1;
	END CATCH
END;
GO


/*
CREATE PROCEDURE Pinga.usp_InserirNovoClienteComEndereco
    @cpfCnpj VARCHAR(14),
	@nomeRazaoSocial VARCHAR(60),
	@apelidoNomeFantasia VARCHAR(60),
	@inscricaoMunicipal CHAR(14),
	@identidadeInscricaoestadual CHAR(14),
	@dataNascimentoFundacao DATE,
	@sexo CHAR(1),
	
	--@enderecoIdendereco UNIQUEIDENTIFIER,
	@logradouro....
	
	@telefoneIdtelefone UNIQUEIDENTIFIER
AS
BEGIN
	BEGIN TRY
		BEGIN TRANSACTION
			INSERT INTO Pinga.*/
				 /* CHAMAR A USP INSERIR ENDERECO ?? */
/* USP's INSERIR CLIENTE */

/* USP's INSERIR ENDERECO */
CREATE OR ALTER PROCEDURE Pinga.usp_InserirNovoPais
	@pais VARCHAR(40),
	@idioma VARCHAR(40),
	@colacao VARCHAR(55),
	@DDI VARCHAR(4),
	@sigla VARCHAR(3),
	@fuso_horario CHAR(9),
	@continenteIdcontinente UNIQUEIDENTIFIER
AS
BEGIN
	SET NOCOUNT ON;
	BEGIN TRY
		BEGIN TRANSACTION
			INSERT INTO Pinga.pais (pais, idioma, colacao, DDI, sigla, fuso_horario, continente_idcontinente)
			VALUES (@pais, @idioma, @colacao, @DDI, @sigla, @fuso_horario, @continenteIdcontinente);
			COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		ROLLBACK;
		DECLARE @err VARCHAR(250) = (SELECT CONCAT(N'ErrorNumber: ', ERROR_NUMBER(),
												   N' - ErrorMessage: ', CONVERT(VARCHAR(200), ERROR_MESSAGE() COLLATE Latin1_General_CS_AS),
												   N'::L ', ERROR_LINE()));
		DECLARE @proc VARCHAR(50) = (SELECT CONCAT(N'USER PROCEDURE: ', CONVERT(VARCHAR(30), ERROR_PROCEDURE() COLLATE Latin1_General_CS_AS)));
		EXECUTE adm.usp_errorLog @err, @proc, 'Desconhecida', 'database';
		THROW 51921, 'Falha ao realizar o insert do pais.', 1;
	END CATCH
END;
GO

CREATE OR ALTER PROCEDURE Pinga.usp_InserirNovoEstado
	@estado VARCHAR(50),
	@uf CHAR(2),
	@capital BIT,
	@paisIdpais UNIQUEIDENTIFIER
AS
BEGIN
	SET NOCOUNT ON;
	BEGIN TRY
		BEGIN TRANSACTION
			INSERT INTO Pinga.estado (estado, uf, capital, pais_idpais)
			VALUES (@estado, @uf, @capital, @paisIdpais);
			COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		ROLLBACK;
		DECLARE @err VARCHAR(250) = (SELECT CONCAT(N'ErrorNumber: ', ERROR_NUMBER(),
												   N' - ErrorMessage: ', CONVERT(VARCHAR(200), ERROR_MESSAGE() COLLATE Latin1_General_CS_AS),
												   N'::L ', ERROR_LINE()));
		DECLARE @proc VARCHAR(50) = (SELECT CONCAT(N'USER PROCEDURE: ', CONVERT(VARCHAR(30), ERROR_PROCEDURE() COLLATE Latin1_General_CS_AS)));
		EXECUTE adm.usp_errorLog @err, @proc, 'Desconhecida', 'database';
		THROW 51921, 'Falha ao realizar o insert do pais.', 1;
	END CATCH
END;
GO

CREATE OR ALTER PROCEDURE Pinga.usp_InserirNovaCidade
	@cidade VARCHAR(50),
	@DDD CHAR(3),
	@capital BIT,
	@estadoIdestado UNIQUEIDENTIFIER
AS
BEGIN
	SET NOCOUNT ON;
	BEGIN TRY
		BEGIN TRANSACTION;
			INSERT INTO Pinga.cidade (cidade, DDD, capital, estado_idestado)
			VALUES (@cidade, @DDD, @capital, @estadoIdestado);
		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		ROLLBACK;
		DECLARE @err VARCHAR(250) = (SELECT CONCAT(N'ErrorNumber: ', ERROR_NUMBER(),
												   N' - ErrorMessage: ', CONVERT(VARCHAR(200), ERROR_MESSAGE() COLLATE Latin1_General_CS_AS),
												   N'::L ', ERROR_LINE()));
		DECLARE @proc VARCHAR(50) = (SELECT CONCAT(N'USER PROCEDURE: ', CONVERT(VARCHAR(30), ERROR_PROCEDURE() COLLATE Latin1_General_CS_AS)));
		EXECUTE adm.usp_errorLog @err, @proc, 'Desconhecida', 'database';
		THROW 51921, 'Falha ao realizar o insert da cidade.', 1;
	END CATCH
END
GO

CREATE OR ALTER PROCEDURE Pinga.usp_InserirNovoBairro
	@bairro VARCHAR(50),
	@regiao VARCHAR(15),
	@cidadeIdcidade UNIQUEIDENTIFIER
AS
BEGIN
	SET NOCOUNT ON;
	BEGIN TRY
		BEGIN TRANSACTION;
			INSERT INTO Pinga.bairro (bairro, regiao, cidade_idcidade)
			VALUES (@bairro, @regiao, @cidadeIdcidade);
		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		ROLLBACK;
		DECLARE @err VARCHAR(250) = (SELECT CONCAT(N'ErrorNumber: ', ERROR_NUMBER(),
												   N' - ErrorMessage: ', CONVERT(VARCHAR(200), ERROR_MESSAGE() COLLATE Latin1_General_CS_AS),
												   N'::L ', ERROR_LINE()));
		DECLARE @proc VARCHAR(50) = (SELECT CONCAT(N'USER PROCEDURE: ', CONVERT(VARCHAR(30), ERROR_PROCEDURE() COLLATE Latin1_General_CS_AS)));
		EXECUTE adm.usp_errorLog @err, @proc, 'Desconhecida', 'database';
		THROW 51921, 'Falha ao realizar o insert do bairro.', 1;
	END CATCH
END
GO

CREATE OR ALTER PROCEDURE Pinga.usp_InserirNovoTipoLogradouro
	@tipoLogradouro VARCHAR(35)
AS
BEGIN
	SET NOCOUNT ON;
	BEGIN TRY
		BEGIN TRANSACTION;
			INSERT INTO Pinga.tipo_logradouro (tipo_logradouro)
			VALUES (@tipoLogradouro);
		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		ROLLBACK;
		DECLARE @err VARCHAR(250) = (SELECT CONCAT(N'ErrorNumber: ', ERROR_NUMBER(),
												   N' - ErrorMessage: ', CONVERT(VARCHAR(200), ERROR_MESSAGE() COLLATE Latin1_General_CS_AS),
												   N'::L ', ERROR_LINE()));
		DECLARE @proc VARCHAR(50) = (SELECT CONCAT(N'USER PROCEDURE: ', CONVERT(VARCHAR(30), ERROR_PROCEDURE() COLLATE Latin1_General_CS_AS)));
		EXECUTE adm.usp_errorLog @err, @proc, 'Desconhecida', 'database';
		THROW 51921, 'Falha ao realizar o insert do tipo logradouro.', 1;
	END CATCH
END
GO

CREATE OR ALTER PROCEDURE Pinga.usp_InserirNovoTipoComplemento
	@tipoComplemento VARCHAR(35)
AS
BEGIN
	SET NOCOUNT ON;
	BEGIN TRY
		BEGIN TRANSACTION;
			INSERT INTO Pinga.tipo_complemento (tipo_complemento)
			VALUES (@tipoComplemento);
		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		ROLLBACK;
		DECLARE @err VARCHAR(250) = (SELECT CONCAT(N'ErrorNumber: ', ERROR_NUMBER(),
												   N' - ErrorMessage: ', CONVERT(VARCHAR(200), ERROR_MESSAGE() COLLATE Latin1_General_CS_AS),
												   N'::L ', ERROR_LINE()));
		DECLARE @proc VARCHAR(50) = (SELECT CONCAT(N'USER PROCEDURE: ', CONVERT(VARCHAR(30), ERROR_PROCEDURE() COLLATE Latin1_General_CS_AS)));
		EXECUTE adm.usp_errorLog @err, @proc, 'Desconhecida', 'database';
		THROW 51921, 'Falha ao realizar o insert do tipo complemento.', 1;
	END CATCH
END
GO

CREATE OR ALTER PROCEDURE Pinga.usp_InserirNovoEndereco
	@tipoLogradouroIdtipoLogradouro UNIQUEIDENTIFIER,
	@logradouro VARCHAR(100),
	@numero INT,
	@tipoComplementoIdtipoComplemento UNIQUEIDENTIFIER,
	@complemento VARCHAR(30),
	@CEP CHAR(8),
	@pontoReferencia VARCHAR(45),
	@bairroIdbairro UNIQUEIDENTIFIER
	AS
BEGIN
	SET NOCOUNT ON;
	BEGIN TRY
		BEGIN TRANSACTION
			INSERT INTO Pinga.endereco (tipo_logradouro_idtipo_logradouro, logradouro, numero, tipo_complemento_idtipo_complemento, complemento, CEP, ponto_referencia, bairro_idbairro, created)
			VALUES (@tipoLogradouroIdtipoLogradouro, @logradouro, @numero, @tipoComplementoIdtipoComplemento, @complemento, @CEP, @pontoReferencia, @bairroIdbairro, GETDATE());
			COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		ROLLBACK;
		DECLARE @err VARCHAR(250) = (SELECT CONCAT(N'ErrorNumber: ', ERROR_NUMBER(),
												   N' - ErrorMessage: ', CONVERT(VARCHAR(200), ERROR_MESSAGE() COLLATE Latin1_General_CS_AS),
												   N'::L ', ERROR_LINE()));
		DECLARE @proc VARCHAR(50) = (SELECT CONCAT(N'USER PROCEDURE: ', CONVERT(VARCHAR(30), ERROR_PROCEDURE() COLLATE Latin1_General_CS_AS)));
		EXECUTE adm.usp_errorLog @err, @proc, 'Desconhecida', 'database';
		THROW 51921, 'Falha ao realizar o insert do endereco apenas.', 1;
	END CATCH
END;
GO

CREATE OR ALTER PROCEDURE Pinga.usp_InserirNovoEnderecoComTipoLogradouro
	@tipoLogradouro VARCHAR(35),
	@logradouro VARCHAR(100),
	@numero INT,
	@tipoComplementoIdtipoComplemento UNIQUEIDENTIFIER,
	@complemento VARCHAR(30),
	@CEP CHAR(8),
	@pontoReferencia VARCHAR(45),
	@bairroIdbairro UNIQUEIDENTIFIER
	AS
BEGIN
	SET NOCOUNT ON;
	BEGIN TRY
		BEGIN TRANSACTION
			EXECUTE Pinga.usp_InserirNovoTipoLogradouro @tipoLogradouro;
		COMMIT TRANSACTION;
		DECLARE @idTipoLogradouro UNIQUEIDENTIFIER = (SELECT TOP 1 idtipo_endereco FROM Pinga.tipo_endereco WHERE tipo_logradouro = @tipoLogradouro);
		BEGIN TRANSACTION
			INSERT INTO Pinga.endereco (tipo_logradouro_idtipo_logradouro, logradouro, numero, tipo_complemento_idtipo_complemento, complemento, CEP, ponto_referencia, bairro_idbairro, created)
			VALUES (@idTipoLogradouro, @logradouro, @numero, @tipoComplementoIdtipoComplemento, @complemento, @CEP, @pontoReferencia, @bairroIdbairro, GETDATE());
		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		ROLLBACK;
		DECLARE @err VARCHAR(250) = (SELECT CONCAT(N'ErrorNumber: ', ERROR_NUMBER(),
												   N' - ErrorMessage: ', CONVERT(VARCHAR(200), ERROR_MESSAGE() COLLATE Latin1_General_CS_AS),
												   N'::L ', ERROR_LINE()));
		DECLARE @proc VARCHAR(50) = (SELECT CONCAT(N'USER PROCEDURE: ', CONVERT(VARCHAR(30), ERROR_PROCEDURE() COLLATE Latin1_General_CS_AS)));
		EXECUTE adm.usp_errorLog @err, @proc, 'Desconhecida', 'database';
		THROW 51921, 'Falha ao realizar o insert do endereco com tipo logradouro.', 1;
	END CATCH
END;
GO

CREATE OR ALTER PROCEDURE Pinga.usp_InserirNovoEnderecoComTipoComplemento
	@tipoLogradouroIdtipoLogradouro UNIQUEIDENTIFIER,
	@logradouro VARCHAR(100),
	@numero INT,
	@tipoComplemento VARCHAR(35),
	@complemento VARCHAR(30),
	@CEP CHAR(8),
	@pontoReferencia VARCHAR(45),
	@bairroIdbairro UNIQUEIDENTIFIER
	AS
BEGIN
	SET NOCOUNT ON;
	BEGIN TRY
		BEGIN TRANSACTION
			EXECUTE Pinga.usp_InserirNovoTipoLogradouro @tipoComplemento;
		COMMIT TRANSACTION;
		DECLARE @idTipoComplemento UNIQUEIDENTIFIER = (SELECT TOP 1 idtipo_complemento FROM Pinga.tipo_complemento WHERE tipo_complemento = @tipoComplemento);
		BEGIN TRANSACTION
			INSERT INTO Pinga.endereco (tipo_logradouro_idtipo_logradouro, logradouro, numero, tipo_complemento_idtipo_complemento, complemento, CEP, ponto_referencia, bairro_idbairro, created)
			VALUES (@tipoLogradouroIdtipoLogradouro, @logradouro, @numero, @tipoComplemento, @complemento, @CEP, @pontoReferencia, @bairroIdbairro, GETDATE());
		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		ROLLBACK;
		DECLARE @err VARCHAR(250) = (SELECT CONCAT(N'ErrorNumber: ', ERROR_NUMBER(),
												   N' - ErrorMessage: ', CONVERT(VARCHAR(200), ERROR_MESSAGE() COLLATE Latin1_General_CS_AS),
												   N'::L ', ERROR_LINE()));
		DECLARE @proc VARCHAR(50) = (SELECT CONCAT(N'USER PROCEDURE: ', CONVERT(VARCHAR(30), ERROR_PROCEDURE() COLLATE Latin1_General_CS_AS)));
		EXECUTE adm.usp_errorLog @err, @proc, 'Desconhecida', 'database';
		THROW 51921, 'Falha ao realizar o insert do endereco com tipo complemento.', 1;
	END CATCH
END;
GO

CREATE OR ALTER PROCEDURE Pinga.usp_InserirNovoEnderecoComTipoComplemento
	@tipoLogradouroIdtipoLogradouro UNIQUEIDENTIFIER,
	@logradouro VARCHAR(100),
	@numero INT,
	@tipoComplementoIdtipoComplemento UNIQUEIDENTIFIER,
	@complemento VARCHAR(30),
	@CEP CHAR(8),
	@pontoReferencia VARCHAR(45),
	@bairro VARCHAR(50),
	@regiao VARCHAR(15),
	@cidadeIdcidade UNIQUEIDENTIFIER
	AS
BEGIN
	SET NOCOUNT ON;
	BEGIN TRY
		BEGIN TRANSACTION
			EXECUTE Pinga.usp_InserirNovoBairro @bairro, @regiao, @cidadeIdcidade;
		COMMIT TRANSACTION;
		DECLARE @Idbairro UNIQUEIDENTIFIER = (SELECT TOP 1 idbairro FROM Pinga.bairro WHERE bairro = @bairro AND regiao = @regiao AND cidade_idcidade = @cidadeIdcidade);
		BEGIN TRANSACTION
			INSERT INTO Pinga.endereco (tipo_logradouro_idtipo_logradouro, logradouro, numero, tipo_complemento_idtipo_complemento, complemento, CEP, ponto_referencia, bairro_idbairro, created)
			VALUES (@tipoLogradouroIdtipoLogradouro, @logradouro, @numero, @tipoComplementoIdtipoComplemento, @complemento, @CEP, @pontoReferencia, @Idbairro, GETDATE());
		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		ROLLBACK;
		DECLARE @err VARCHAR(250) = (SELECT CONCAT(N'ErrorNumber: ', ERROR_NUMBER(),
												   N' - ErrorMessage: ', CONVERT(VARCHAR(200), ERROR_MESSAGE() COLLATE Latin1_General_CS_AS),
												   N'::L ', ERROR_LINE()));
		DECLARE @proc VARCHAR(50) = (SELECT CONCAT(N'USER PROCEDURE: ', CONVERT(VARCHAR(30), ERROR_PROCEDURE() COLLATE Latin1_General_CS_AS)));
		EXECUTE adm.usp_errorLog @err, @proc, 'Desconhecida', 'database';
		THROW 51921, 'Falha ao realizar o insert do endereco com tipo complemento.', 1;
	END CATCH
END;
GO
/* USP's INSERIR ENDERECO */

/* USP's INSERIR PRODUTO */
CREATE OR ALTER PROCEDURE usp_InserirNovoProduto
	@descricao VARCHAR(30),
	@tipoLitragemIdtipoLitragem UNIQUEIDENTIFIER,
	@litragem INT,
	@vendendo BIT,
	@valorUnitario DECIMAL(9,2),
	@produtoQuantidadeIdprodutoQuantidade UNIQUEIDENTIFIER
AS
BEGIN
	SET NOCOUNT ON;
	BEGIN TRY
		BEGIN TRANSACTION;
			INSERT INTO Pinga.produto (produto, tipo_litragem_idtipo_litragem, litragem, vendendo, valor_unitario, produto_quantidade_idproduto_quantidade, created)			VALUES (@descricao, @tipoLitragemIdtipoLitragem, @litragem, @vendendo, @valorUnitario, @produtoQuantidadeIdprodutoQuantidade,GETDATE());
		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		ROLLBACK;
		DECLARE @err VARCHAR(250) = (SELECT CONCAT(N'ErrorNumber: ', ERROR_NUMBER(),
												   N' - ErrorMessage: ', CONVERT(VARCHAR(200), ERROR_MESSAGE() COLLATE Latin1_General_CS_AS),
												   N'::L ', ERROR_LINE()));
		DECLARE @proc VARCHAR(50) = (SELECT CONCAT(N'USER PROCEDURE: ', CONVERT(VARCHAR(30), ERROR_PROCEDURE() COLLATE Latin1_General_CS_AS)));
		EXECUTE adm.usp_errorLog @err, @proc, 'Desconhecida', 'database';
		THROW 51921, 'Falha ao realizar o insert do produto apenas.', 1;
	END CATCH
END;
GO

CREATE OR ALTER PROCEDURE usp_InserirNovoProdutoComTipoLitragem
	@descricao VARCHAR(30),
	@descricaoLitragem VARCHAR(35),
	@litragem INT,
	@vendendo BIT,
	@valorUnitario DECIMAL(9,2),
	@produtoQuantidadeIdprodutoQuantidade UNIQUEIDENTIFIER
AS
BEGIN
	SET NOCOUNT ON;
	BEGIN TRY
		BEGIN TRANSACTION;
			INSERT INTO Pinga.tipo_litragem (tipo_litragem)
			VALUES (@descricaoLitragem);
		COMMIT TRANSACTION;
		DECLARE @idtipoLitragem UNIQUEIDENTIFIER = (SELECT TOP 1 idtipo_litragem FROM Pinga.tipo_litragem WHERE tipo_litragem = @descricaoLitragem);
		BEGIN TRANSACTION;
			INSERT INTO Pinga.produto (produto, tipo_litragem_idtipo_litragem, litragem, vendendo, valor_unitario, produto_quantidade_idproduto_quantidade, created)
			VALUES (@descricao, @idtipoLitragem, @litragem, @vendendo, @valorUnitario, @produtoQuantidadeIdprodutoQuantidade,GETDATE());
		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		ROLLBACK;
		DECLARE @err VARCHAR(250) = (SELECT CONCAT(N'ErrorNumber: ', ERROR_NUMBER(),
												   N' - ErrorMessage: ', CONVERT(VARCHAR(200), ERROR_MESSAGE() COLLATE Latin1_General_CS_AS),
												   N'::L ', ERROR_LINE()));
		DECLARE @proc VARCHAR(50) = (SELECT CONCAT(N'USER PROCEDURE: ', CONVERT(VARCHAR(30), ERROR_PROCEDURE() COLLATE Latin1_General_CS_AS)));
		EXECUTE adm.usp_errorLog @err, @proc, 'Desconhecida', 'database';
		THROW 51921, 'Falha ao realizar o insert do produto com tipo litragem.', 1;
	END CATCH
END;
GO

CREATE OR ALTER PROCEDURE usp_InserirNovoProdutoComQuantidadeProduto
	@descricao VARCHAR(30),
	@tipoLitragemIdtipoLitragem UNIQUEIDENTIFIER,
	@litragem INT,
	@vendendo BIT,
	@valorUnitario DECIMAL(9,2),
	@quantidadeMinima INT,
	@quantidadeMaxima INT,
	@quantidadeRecomendaEstoque INT,
	@quantidadeSolicitarCompra INT
AS
BEGIN
	SET NOCOUNT ON;
	BEGIN TRY
		BEGIN TRANSACTION;
			INSERT INTO Pinga.produto_quantidade (quantidade_minima, quantidade_maxima, quantidade_recomenda_estoque, quantidade_solicitar_compra, created)
			VALUES (@quantidadeMinima, @quantidadeMaxima, @quantidadeRecomendaEstoque, @quantidadeSolicitarCompra, GETDATE());
		COMMIT TRANSACTION;
		DECLARE @idquantidadeProduto UNIQUEIDENTIFIER = (SELECT TOP 1 idproduto_quantidade FROM Pinga.produto_quantidade WHERE quantidade_minima = @quantidadeMinima AND quantidade_maxima = @quantidadeMaxima AND quantidade_recomenda_estoque = @quantidadeRecomendaEstoque AND quantidade_solicitar_compra = @quantidadeSolicitarCompra);
		BEGIN TRANSACTION;
			INSERT INTO Pinga.produto (produto, tipo_litragem_idtipo_litragem, litragem, vendendo, valor_unitario, produto_quantidade_idproduto_quantidade, created)
			VALUES (@descricao, @tipoLitragemIdtipoLitragem, @litragem, @vendendo, @valorUnitario, @idquantidadeProduto,GETDATE());
		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		ROLLBACK;
		THROW 51921, 'Falha ao realizar o insert do produto com quantidade produto.', 1;
	END CATCH
END;
GO

CREATE OR ALTER PROCEDURE usp_InserirNovoProdutoCompleto
	@descricao VARCHAR(30),
	@descricaoLitragem VARCHAR(35),
	@litragem INT,
	@vendendo BIT,
	@valorUnitario DECIMAL(9,2),
	@quantidadeMinima INT,
	@quantidadeMaxima INT,
	@quantidadeRecomendaEstoque INT,
	@quantidadeSolicitarCompra INT
AS
BEGIN
	SET NOCOUNT ON;
	BEGIN TRY
		BEGIN TRANSACTION;
			INSERT INTO Pinga.tipo_litragem (tipo_litragem)
			VALUES (@descricaoLitragem);
		COMMIT TRANSACTION;
		BEGIN TRANSACTION;
			INSERT INTO Pinga.produto_quantidade (quantidade_minima, quantidade_maxima, quantidade_recomenda_estoque, quantidade_solicitar_compra, created)
			VALUES (@quantidadeMinima, @quantidadeMaxima, @quantidadeRecomendaEstoque, @quantidadeSolicitarCompra, GETDATE());
		COMMIT TRANSACTION;
		DECLARE @idtipoLitragem UNIQUEIDENTIFIER = (SELECT TOP 1 idtipo_litragem FROM Pinga.tipo_litragem WHERE tipo_litragem = @descricaoLitragem);
		DECLARE @idquantidadeProduto UNIQUEIDENTIFIER = (SELECT TOP 1 idproduto_quantidade FROM Pinga.produto_quantidade WHERE quantidade_minima = @quantidadeMinima AND quantidade_maxima = @quantidadeMaxima AND quantidade_recomenda_estoque = @quantidadeRecomendaEstoque AND quantidade_solicitar_compra = @quantidadeSolicitarCompra);
		BEGIN TRANSACTION;
			INSERT INTO Pinga.produto (produto, tipo_litragem_idtipo_litragem, litragem, vendendo, valor_unitario, produto_quantidade_idproduto_quantidade, created)
			VALUES (@descricao, @idtipoLitragem, @litragem, @vendendo, @valorUnitario, @idquantidadeProduto,GETDATE());
		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		ROLLBACK;
		DECLARE @err VARCHAR(250) = (SELECT CONCAT(N'ErrorNumber: ', ERROR_NUMBER(),
												   N' - ErrorMessage: ', CONVERT(VARCHAR(200), ERROR_MESSAGE() COLLATE Latin1_General_CS_AS),
												   N'::L ', ERROR_LINE()));
		DECLARE @proc VARCHAR(50) = (SELECT CONCAT(N'USER PROCEDURE: ', CONVERT(VARCHAR(30), ERROR_PROCEDURE() COLLATE Latin1_General_CS_AS)));
		EXECUTE adm.usp_errorLog @err, @proc, 'Desconhecida', 'database';
		THROW 51921, 'Falha ao realizar o insert do produto com quantidade produto.', 1;
	END CATCH
END;
GO
/* USP's INSERIR PRODUTO */

/* USP's INSERIR CONTRATO */
CREATE OR ALTER PROCEDURE usp_InserirNovoContrato
    @clienteIdcliente UNIQUEIDENTIFIER,
    @dataEntradaVigor DATE,
    @dataExpiracao DATE,
    @dataAssinatura DATE,
    @periodicidadeEntregaIdperiodicidadeEntrega UNIQUEIDENTIFIER,
    @prorrogavel BIT,
    @status BIT,
    @formaPagementoIdformaPagamento UNIQUEIDENTIFIER,
    @multaQuebra DECIMAL(9,2)
AS
BEGIN
	SET NOCOUNT ON;
    BEGIN TRY
        BEGIN TRANSACTION;
            INSERT INTO Pinga.contrato (cliente_idcliente, data_entrada_vigor, data_expiracao, data_assinatura, periodicidade_entrega_idperiodicidade_entrega, prorrogavel, [status], forma_pagamento_idforma_pagamento, multa_quebra)
            VALUES (@clienteIdcliente, @dataEntradaVigor, @dataExpiracao, @dataAssinatura, @periodicidadeEntregaIdperiodicidadeEntrega, @prorrogavel, @status, @formaPagementoIdformaPagamento, @multaQuebra);
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
		ROLLBACK;
		DECLARE @err VARCHAR(250) = (SELECT CONCAT(N'ErrorNumber: ', ERROR_NUMBER(),
												   N' - ErrorMessage: ', CONVERT(VARCHAR(200), ERROR_MESSAGE() COLLATE Latin1_General_CS_AS),
												   N'::L ', ERROR_LINE()));
		DECLARE @proc VARCHAR(50) = (SELECT CONCAT(N'USER PROCEDURE: ', CONVERT(VARCHAR(30), ERROR_PROCEDURE() COLLATE Latin1_General_CS_AS)));
		EXECUTE adm.usp_errorLog @err, @proc, 'Desconhecida', 'database';
        THROW 51921, 'Falha ao realizar o insert do contrato apenas', 1;
    END CATCH
END;
GO

CREATE OR ALTER PROCEDURE usp_InserirNovoContratoComCliente
	@cpfCnpj VARCHAR(14),
	@nomeRazaoSocial VARCHAR(60),
	@apelidoNomeFantasia VARCHAR(60),
	@inscricaoMunicipal CHAR(14),
	@identidadeInscricaoestadual CHAR(14),
	@dataNascimentoFundacao DATE,
	@sexo CHAR(1),
	@enderecoIdendereco UNIQUEIDENTIFIER,
	@telefoneIdtelefone UNIQUEIDENTIFIER,
    @dataEntradaVigor DATE,
    @dataExpiracao DATE,
    @dataAssinatura DATE,
    @periodicidadeEntregaIdperiodicidadeEntrega UNIQUEIDENTIFIER,
    @prorrogavel BIT,
    @status BIT,
    @formaPagementoIdformaPagamento UNIQUEIDENTIFIER,
    @multaQuebra DECIMAL(9,2)
AS
BEGIN
	SET NOCOUNT ON;
    BEGIN TRY
		BEGIN TRANSACTION;
			EXECUTE Pinga.usp_InserirNovoCliente @cpfCnpj, @nomeRazaoSocial, @apelidoNomeFantasia, @inscricaoMunicipal, @identidadeInscricaoestadual, @dataNascimentoFundacao, @sexo, @enderecoIdendereco, @telefoneIdtelefone;
		COMMIT TRANSACTION;
		DECLARE @idCliente UNIQUEIDENTIFIER = (SELECT TOP 1 idcliente FROM Pinga.cliente WHERE cpf_cnpj = @cpfCnpj AND nome_razao_social = @nomeRazaoSocial AND apelido_nome_fantasia = @apelidoNomeFantasia AND inscricao_municipal = @inscricaoMunicipal AND identidade_inscricao_estadual = @identidadeInscricaoestadual AND data_nascimento_fundacao = @dataNascimentoFundacao AND sexo = @sexo AND endereco_idendereco = @enderecoIdendereco AND telefone_idtelefone = @telefoneIdtelefone);
        BEGIN TRANSACTION;
            INSERT INTO Pinga.contrato (cliente_idcliente, data_entrada_vigor, data_expiracao, data_assinatura, periodicidade_entrega_idperiodicidade_entrega, prorrogavel, [status], forma_pagamento_idforma_pagamento, multa_quebra)
            VALUES (@idCliente, @dataEntradaVigor, @dataExpiracao, @dataAssinatura, @periodicidadeEntregaIdperiodicidadeEntrega, @prorrogavel, @status, @formaPagementoIdformaPagamento, @multaQuebra);
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
		ROLLBACK;
		DECLARE @err VARCHAR(250) = (SELECT CONCAT(N'ErrorNumber: ', ERROR_NUMBER(),
												   N' - ErrorMessage: ', CONVERT(VARCHAR(200), ERROR_MESSAGE() COLLATE Latin1_General_CS_AS),
												   N'::L ', ERROR_LINE()));
		DECLARE @proc VARCHAR(50) = (SELECT CONCAT(N'USER PROCEDURE: ', CONVERT(VARCHAR(30), ERROR_PROCEDURE() COLLATE Latin1_General_CS_AS)));
		EXECUTE adm.usp_errorLog @err, @proc, 'Desconhecida', 'database';
        THROW 51921, 'Falha ao realizar o insert do contrato com cliente', 1;
    END CATCH
END;
GO

CREATE OR ALTER PROCEDURE usp_InserirNovoContratoComPeriodicidade
    @clienteIdcliente UNIQUEIDENTIFIER,
    @dataEntradaVigor DATE,
    @dataExpiracao DATE,
    @dataAssinatura DATE,
	@tipoPeriodicidadeEntregaIdtipoPeriodicidadeEntrega UNIQUEIDENTIFIER,
	@statusPeriodicidadeEntrega BIT,
    @prorrogavel BIT,
    @status BIT,
    @formaPagementoIdformaPagamento UNIQUEIDENTIFIER,
    @multaQuebra DECIMAL(9,2)
AS
BEGIN
	SET NOCOUNT ON;
    BEGIN TRY
		BEGIN TRANSACTION;
			INSERT INTO Pinga.periodicidade_entrega (tipo_periodicidade_entrega_idtipo_periodicidade_entrega, cliente_idcliente, [status])
			VALUES (@tipoPeriodicidadeEntregaIdtipoPeriodicidadeEntrega, @clienteIdcliente, @statusPeriodicidadeEntrega);
		COMMIT TRANSACTION;
		DECLARE @IdperiodicidadeEntrega UNIQUEIDENTIFIER = (SELECT TOP 1 idperiodicidade_entrega FROM Pinga.periodicidade_entrega WHERE tipo_periodicidade_entrega_idtipo_periodicidade_entrega = @tipoPeriodicidadeEntregaIdtipoPeriodicidadeEntrega AND cliente_idcliente = @clienteIdcliente AND [status] = @statusPeriodicidadeEntrega);
        BEGIN TRANSACTION;
			INSERT INTO Pinga.contrato (cliente_idcliente, data_entrada_vigor, data_expiracao, data_assinatura, periodicidade_entrega_idperiodicidade_entrega, prorrogavel, [status], forma_pagamento_idforma_pagamento, multa_quebra)
            VALUES (@clienteIdcliente, @dataEntradaVigor, @dataExpiracao, @dataAssinatura, @IdperiodicidadeEntrega, @prorrogavel, @status, @formaPagementoIdformaPagamento, @multaQuebra);
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
		ROLLBACK;
		DECLARE @err VARCHAR(250) = (SELECT CONCAT(N'ErrorNumber: ', ERROR_NUMBER(),
												   N' - ErrorMessage: ', CONVERT(VARCHAR(200), ERROR_MESSAGE() COLLATE Latin1_General_CS_AS),
												   N'::L ', ERROR_LINE()));
		DECLARE @proc VARCHAR(50) = (SELECT CONCAT(N'USER PROCEDURE: ', CONVERT(VARCHAR(30), ERROR_PROCEDURE() COLLATE Latin1_General_CS_AS)));
		EXECUTE adm.usp_errorLog @err, @proc, 'Desconhecida', 'database';
        THROW 51921, 'Falha ao realizar o insert do contrato com periodicidade', 1;
    END CATCH
END;
GO

CREATE OR ALTER PROCEDURE usp_InserirNovoContratoComFormaPagamento
	@clienteIdcliente UNIQUEIDENTIFIER,
    @dataEntradaVigor DATE,
    @dataExpiracao DATE,
    @dataAssinatura DATE,
    @periodicidadeEntregaIdperiodicidadeEntrega UNIQUEIDENTIFIER,
    @prorrogavel BIT,
    @status BIT,
	@descricaoFormaPagamento VARCHAR(45),
    @multaQuebra DECIMAL(9,2)
AS
BEGIN
	SET NOCOUNT ON;
    BEGIN TRY
		BEGIN TRANSACTION;
			INSERT INTO Pinga.forma_pagamento (forma_pagamento, created)
			VALUES (@descricaoFormaPagamento, GETDATE());
		COMMIT TRANSACTION;
		DECLARE @idFormaPagamento UNIQUEIDENTIFIER = (SELECT TOP 1 idforma_pagamento FROM Pinga.forma_pagamento WHERE forma_pagamento = @descricaoFormaPagamento ORDER BY created DESC);
        BEGIN TRANSACTION;
            INSERT INTO Pinga.contrato (cliente_idcliente, data_entrada_vigor, data_expiracao, data_assinatura, periodicidade_entrega_idperiodicidade_entrega, prorrogavel, [status], forma_pagamento_idforma_pagamento, multa_quebra)
            VALUES (@clienteIdcliente, @dataEntradaVigor, @dataExpiracao, @dataAssinatura, @periodicidadeEntregaIdperiodicidadeEntrega, @prorrogavel, @status, @idFormaPagamento, @multaQuebra);
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
		ROLLBACK;
		DECLARE @err VARCHAR(250) = (SELECT CONCAT(N'ErrorNumber: ', ERROR_NUMBER(),
												   N' - ErrorMessage: ', CONVERT(VARCHAR(200), ERROR_MESSAGE() COLLATE Latin1_General_CS_AS),
												   N'::L ', ERROR_LINE()));
		DECLARE @proc VARCHAR(50) = (SELECT CONCAT(N'USER PROCEDURE: ', CONVERT(VARCHAR(30), ERROR_PROCEDURE() COLLATE Latin1_General_CS_AS)));
		EXECUTE adm.usp_errorLog @err, @proc, 'Desconhecida', 'database';
        THROW 51921, 'Falha ao realizar o insert do contrato com forma de pagamento', 1;
    END CATCH
END;
GO
/* USP's INSERIR CONTRATO */

CREATE OR ALTER PROCEDURE Pinga.usp_InserirNovoTipoLitragem
    @tipoLitragem VARCHAR(35)
AS
BEGIN
    SET NOCOUNT ON;
    SET ANSI_NULLS ON;

    BEGIN TRY
        BEGIN TRANSACTION;
            INSERT INTO Pinga.tipo_litragem (tipo_litragem)
            VALUES (@tipoLitragem);
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK;
        DECLARE @err VARCHAR(250) = (SELECT CONCAT(N'ErrorNumber: ', ERROR_NUMBER(),
                                                   N' - ErrorMessage: ', CONVERT(VARCHAR(200), ERROR_MESSAGE() COLLATE Latin1_General_CS_AS),
                                                   N'::L ', ERROR_LINE()));
        DECLARE @proc VARCHAR(50) = (SELECT CONCAT(N'USER PROCEDURE: ', CONVERT(VARCHAR(30), ERROR_PROCEDURE() COLLATE Latin1_General_CS_AS)));
        EXECUTE adm.usp_errorLog @err, @proc, 'Desconhecida', 'database';
        THROW 51921, 'Falha ao realizar o insert do tipo litragem apenas.', 1;
    END CATCH
END;
GO 

CREATE OR ALTER PROCEDURE Pinga.usp_InserirNovoProdutoQuantidade
    @quantidadeMinima INT,
	@quantidadeMaxima INT,
	@quantidadeRecomendaEstoque INT,
	@quantidadeSolicitarCompra INT
AS
BEGIN
    SET NOCOUNT ON;
    SET ANSI_NULLS ON;

    BEGIN TRY
        BEGIN TRANSACTION;
            INSERT INTO Pinga.produto_quantidade (quantidade_minima, quantidade_maxima, quantidade_recomenda_estoque, quantidade_solicitar_compra, created)
            VALUES (@quantidadeMinima, @quantidadeMaxima, @quantidadeRecomendaEstoque, @quantidadeSolicitarCompra, GETDATE());
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK;
        DECLARE @err VARCHAR(250) = (SELECT CONCAT(N'ErrorNumber: ', ERROR_NUMBER(),
                                                   N' - ErrorMessage: ', CONVERT(VARCHAR(200), ERROR_MESSAGE() COLLATE Latin1_General_CS_AS),
                                                   N'::L ', ERROR_LINE()));
        DECLARE @proc VARCHAR(50) = (SELECT CONCAT(N'USER PROCEDURE: ', CONVERT(VARCHAR(30), ERROR_PROCEDURE() COLLATE Latin1_General_CS_AS)));
        EXECUTE adm.usp_errorLog @err, @proc, 'Desconhecida', 'database';
        THROW 51921, 'Falha ao realizar o insert do produto quantidade apenas.', 1;
    END CATCH
END;
GO

CREATE OR ALTER PROCEDURE Pinga.usp_InserirNovoTipoCusto
    @tipoCusto VARCHAR(60)
AS
BEGIN
    SET NOCOUNT ON;
    SET ANSI_NULLS ON;

    BEGIN TRY
        BEGIN TRANSACTION;
            INSERT INTO Pinga.tipo_custo (tipo_custo)
            VALUES (@tipoCusto);
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK;
        DECLARE @err VARCHAR(250) = (SELECT CONCAT(N'ErrorNumber: ', ERROR_NUMBER(),
                                                   N' - ErrorMessage: ', CONVERT(VARCHAR(200), ERROR_MESSAGE() COLLATE Latin1_General_CS_AS),
                                                   N'::L ', ERROR_LINE()));
        DECLARE @proc VARCHAR(50) = (SELECT CONCAT(N'USER PROCEDURE: ', CONVERT(VARCHAR(30), ERROR_PROCEDURE() COLLATE Latin1_General_CS_AS)));
        EXECUTE adm.usp_errorLog @err, @proc, 'Desconhecida', 'database';
        THROW 51921, 'Falha ao realizar o insert do tipo custo apenas.', 1;
    END CATCH
END;
GO

CREATE OR ALTER PROCEDURE Pinga.usp_InserirNovaFormaPagamento
    @formaPagamento VARCHAR(45)
AS
BEGIN
    SET NOCOUNT ON;
    SET ANSI_NULLS ON;

    BEGIN TRY
        BEGIN TRANSACTION;
            INSERT INTO Pinga.forma_pagamento(forma_pagamento, created)
            VALUES (@formaPagamento, GETDATE());
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK;
        DECLARE @err VARCHAR(250) = (SELECT CONCAT(N'ErrorNumber: ', ERROR_NUMBER(),
                                                   N' - ErrorMessage: ', CONVERT(VARCHAR(200), ERROR_MESSAGE() COLLATE Latin1_General_CS_AS),
                                                   N'::L ', ERROR_LINE()));
        DECLARE @proc VARCHAR(50) = (SELECT CONCAT(N'USER PROCEDURE: ', CONVERT(VARCHAR(30), ERROR_PROCEDURE() COLLATE Latin1_General_CS_AS)));
        EXECUTE adm.usp_errorLog @err, @proc, 'Desconhecida', 'database';
        THROW 51921, 'Falha ao realizar o insert da forma de pagamento apenas.', 1;
    END CATCH
END;
GO

CREATE OR ALTER PROCEDURE Pinga.usp_InserirNovaEntrada
    @data DATE, 
	@litragem INT,
	@tipoLitragemIdtipoLitragem UNIQUEIDENTIFIER,
	@custoIdcusto UNIQUEIDENTIFIER,
	@parcelamentoIdparcelamento UNIQUEIDENTIFIER
AS
BEGIN
    SET NOCOUNT ON;
    SET ANSI_NULLS ON;

    BEGIN TRY
        BEGIN TRANSACTION;
            INSERT INTO Pinga.entrada (data, litragem, tipo_litragem_idtipo_litragem, custo_idcusto, parcelamento_idparcelamento)
            VALUES (@data, @litragem, @tipoLitragemIdtipoLitragem, @custoIdcusto, @parcelamentoIdparcelamento);
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK;
        DECLARE @err VARCHAR(250) = (SELECT CONCAT(N'ErrorNumber: ', ERROR_NUMBER(),
                                                   N' - ErrorMessage: ', CONVERT(VARCHAR(200), ERROR_MESSAGE() COLLATE Latin1_General_CS_AS),
                                                   N'::L ', ERROR_LINE()));
        DECLARE @proc VARCHAR(50) = (SELECT CONCAT(N'USER PROCEDURE: ', CONVERT(VARCHAR(30), ERROR_PROCEDURE() COLLATE Latin1_General_CS_AS)));
        EXECUTE adm.usp_errorLog @err, @proc, 'Desconhecida', 'database';
        THROW 51921, 'Falha ao realizar o insert da entrada apenas.', 1;
    END CATCH
END;
GO

/* TRIGGER's PARA VALIDAÇÃO */
CREATE OR ALTER TRIGGER Pinga.utr_ValidarTipoContinente
ON Pinga.tipo_continente WITH ENCRYPTION
AFTER INSERT, UPDATE
AS
	-- Validar para que somente 1 possa ser verdadeiro
	DECLARE @qntValidos INT = (SELECT COUNT(1) FROM tipo_continente WHERE ativo = 1);
	IF @qntValidos > 1
	BEGIN
		ROLLBACK;
		DECLARE @err VARCHAR(250) = (SELECT CONCAT(N'ErrorNumber: ', ERROR_NUMBER(),
												   N' - ErrorMessage: ', CONVERT(VARCHAR(200), ERROR_MESSAGE() COLLATE Latin1_General_CS_AS),
												   N'::L ', ERROR_LINE()));
		DECLARE @proc VARCHAR(50) = (SELECT CONCAT(N'USER TRIGGER: ', CONVERT(VARCHAR(30), ERROR_PROCEDURE() COLLATE Latin1_General_CS_AS)));
		EXECUTE adm.usp_errorLog @err, @proc, 'Regra de Negócio', 'database';
		THROW 61921, 'Mais de um tipo continente ativo, somente 1 pode ser ativo.', 1;
	END
GO
/* TRIGGER's PARA VALIDAÇÃO */

/* USP's INSERIR CUSTO */
CREATE OR ALTER PROCEDURE Pinga.usp_InserirNovoCusto
	@tipoCustoIdtipoCusto UNIQUEIDENTIFIER,
	@valor DECIMAL(9,2)
AS
BEGIN
	SET NOCOUNT ON;
	SET ANSI_NULLS ON;

	BEGIN TRY
		BEGIN TRANSACTION;
			INSERT INTO Pinga.custo (tipo_custo_idtipo_custo, valor, created)
			VALUES (@tipoCustoIdtipoCusto, @valor, GETDATE());
		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		ROLLBACK;
		DECLARE @err VARCHAR(250) = (SELECT CONCAT(N'ErrorNumber: ', ERROR_NUMBER(),
												   N' - ErrorMessage: ', CONVERT(VARCHAR(200), ERROR_MESSAGE() COLLATE Latin1_General_CS_AS),
												   N'::L ', ERROR_LINE()));
		DECLARE @proc VARCHAR(50) = (SELECT CONCAT(N'USER PROCEDURE: ', CONVERT(VARCHAR(30), ERROR_PROCEDURE() COLLATE Latin1_General_CS_AS)));
		EXECUTE adm.usp_errorLog @err, @proc, 'Desconhecida', 'database';
        THROW 51921, 'Falha ao realizar o insert do custo apenas.', 1;
	END CATCH
END;
GO

CREATE OR ALTER PROCEDURE Pinga.usp_InserirNovoCustoComTipoCusto
	@descricaoTipoCusto VARCHAR(60),
	@valor DECIMAL(9,2)
AS
BEGIN
	SET NOCOUNT ON;
	SET ANSI_NULLS ON;

	BEGIN TRY
		BEGIN TRANSACTION;
			INSERT INTO Pinga.tipo_custo (tipo_custo)
			VALUES (@descricaoTipoCusto);			
		COMMIT TRANSACTION;
		DECLARE @IdTipoCusto UNIQUEIDENTIFIER = (SELECT TOP 1 ROWGUIDCOL FROM Pinga.tipo_custo WHERE tipo_custo = @descricaoTipoCusto);
		BEGIN TRANSACTION;
			INSERT INTO Pinga.custo (tipo_custo_idtipo_custo, valor, created)
			VALUES (@IdTipoCusto, @valor, GETDATE());
		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		ROLLBACK;
		DECLARE @err VARCHAR(250) = (SELECT CONCAT(N'ErrorNumber: ', ERROR_NUMBER(),
												   N' - ErrorMessage: ', CONVERT(VARCHAR(200), ERROR_MESSAGE() COLLATE Latin1_General_CS_AS),
												   N'::L ', ERROR_LINE()));
		DECLARE @proc VARCHAR(50) = (SELECT CONCAT(N'USER PROCEDURE: ', CONVERT(VARCHAR(30), ERROR_PROCEDURE() COLLATE Latin1_General_CS_AS)));
		EXECUTE adm.usp_errorLog @err, @proc, 'Desconhecida', 'database';
        THROW 51921, 'Falha ao realizar o insert do custo com tipo custo.', 1;
	END CATCH
END;
GO
/* USP's INSERIR CUSTO */

/* USP's INSERIR VISITA */
/*CREATE OR ALTER PROCEDURE Pinga.usp_InserirNovaVisita
	@clienteIdcliente UNIQUEIDENTIFIER,
	@data DATE,
	@comecou TIME,
	@terminou TIME
AS
BEGIN
	SET NOCOUNT ON;
	SET ANSI_NULLS ON;

	BEGIN TRY
		INSERT INTO Pinga.visita (cliente_idcliente, [data], comecou, terminou)
		VALUES (@clienteIdcliente, @data, @comecou, @terminou);
	END TRY
	BEGIN CATCH
		ROLLBACK;
		DECLARE @err VARCHAR(250) = (SELECT CONCAT(N'ErrorNumber: ', ERROR_NUMBER(),
												   N' - ErrorMessage: ', CONVERT(VARCHAR(200), ERROR_MESSAGE() COLLATE Latin1_General_CS_AS),
												   N'::L ', ERROR_LINE()));
		DECLARE @proc VARCHAR(50) = (SELECT CONCAT(N'USER PROCEDURE: ', CONVERT(VARCHAR(30), ERROR_PROCEDURE() COLLATE Latin1_General_CS_AS)));
		EXECUTE adm.usp_errorLog @err, @proc, 'Desconhecida', 'database';
        THROW 51921, 'Falha ao realizar o insert da visita apenas.', 1;
	END CATCH
END;
GO

CREATE OR ALTER PROCEDURE Pinga.usp_InserirNovaVisitaComCliente
	@cpfCnpj VARCHAR(14),
	@nomeRazaoSocial VARCHAR(60),
	@apelidoNomeFantasia VARCHAR(60),
	@inscricaoMunicipal CHAR(14),
	@identidadeInscricaoestadual CHAR(14),
	@dataNascimentoFundacao DATE,
	@sexo CHAR(1),
	@enderecoIdendereco UNIQUEIDENTIFIER,
	@telefoneIdtelefone UNIQUEIDENTIFIER,
	@data DATE,
	@comecou TIME,
	@terminou TIME
AS
BEGIN
	SET NOCOUNT ON;
	SET ANSI_NULLS ON;

	BEGIN TRY
		BEGIN TRANSACTION;
			EXECUTE Pinga.usp_InserirNovoCliente @cpfCnpj, @nomeRazaoSocial, @apelidoNomeFantasia, @inscricaoMunicipal, @identidadeInscricaoestadual, @dataNascimentoFundacao, @sexo, @enderecoIdendereco, @telefoneIdtelefone;
		COMMIT TRANSACTION;
		DECLARE @ClienteIdCliente UNIQUEIDENTIFIER = (SELECT TOP 1 ROWGUIDCOL FROM Pinga.cliente WHERE cpf_cnpj = @cpfCnpj AND nome_razao_social = @nomeRazaoSocial AND apelido_nome_fantasia = @apelidoNomeFantasia AND inscricao_municipal = @inscricaoMunicipal AND identidade_inscricao_estadual = @identidadeInscricaoestadual AND data_nascimento_fundacao = @dataNascimentoFundacao AND sexo = @sexo AND endereco_idendereco = @enderecoIdendereco AND telefone_idtelefone = @telefoneIdtelefone);
		BEGIN TRANSACTION;
			INSERT INTO Pinga.visita (cliente_idcliente, [data], comecou, terminou)
			VALUES (@ClienteIdCliente, @data, @comecou, @terminou);
		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		ROLLBACK;
		DECLARE @err VARCHAR(250) = (SELECT CONCAT(N'ErrorNumber: ', ERROR_NUMBER(),
												   N' - ErrorMessage: ', CONVERT(VARCHAR(200), ERROR_MESSAGE() COLLATE Latin1_General_CS_AS),
												   N'::L ', ERROR_LINE()));
		DECLARE @proc VARCHAR(50) = (SELECT CONCAT(N'USER PROCEDURE: ', CONVERT(VARCHAR(30), ERROR_PROCEDURE() COLLATE Latin1_General_CS_AS)));
		EXECUTE adm.usp_errorLog @err, @proc, 'Desconhecida', 'database';
        THROW 51921, 'Falha ao realizar o insert da visita com cliente.', 1;
	END CATCH
END;
GO

CREATE OR ALTER PROCEDURE Pinga.usp_InserirNovaVisistaParceiro
	@parceiroIdparceiro UNIQUEIDENTIFIER,
	@visitaIdvisita UNIQUEIDENTIFIER
AS
BEGIN
	SET NOCOUNT ON;
	SET ANSI_NULLS ON;

	BEGIN TRY
		BEGIN TRANSACTION;
			INSERT INTO Pinga.parceiro_has_visita (idparceiro_has_visita, visita_idvisita)
			VALUES (@parceiroIdparceiro, @visitaIdvisita);
		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		ROLLBACK;
		DECLARE @err VARCHAR(250) = (SELECT CONCAT(N'ErrorNumber: ', ERROR_NUMBER(),
												   N' - ErrorMessage: ', CONVERT(VARCHAR(200), ERROR_MESSAGE() COLLATE Latin1_General_CS_AS),
												   N'::L ', ERROR_LINE()));
		DECLARE @proc VARCHAR(50) = (SELECT CONCAT(N'USER PROCEDURE: ', CONVERT(VARCHAR(30), ERROR_PROCEDURE() COLLATE Latin1_General_CS_AS)));
		EXECUTE adm.usp_errorLog @err, @proc, 'Desconhecida', 'database';
        THROW 51921, 'Falha ao realizar o insert da visita com cliente.', 1;
	END CATCH
END;
GO

CREATE OR ALTER PROCEDURE Pinga.usp_InserirNovaVisistaParceiroComVisista
	@parceiroIdparceiro UNIQUEIDENTIFIER,
	@clienteIdcliente UNIQUEIDENTIFIER,
	@data DATE,
	@comecou TIME,
	@terminou TIME
AS
BEGIN
	SET NOCOUNT ON;
	SET ANSI_NULLS ON;

	BEGIN TRY
		BEGIN TRANSACTION;
			EXEC Pinga.usp_InserirNovaVisita @clienteIdcliente, @data, @comecou, @terminou;
		COMMIT TRANSACTION;
		DECLARE @IdVisita UNIQUEIDENTIFIER = (SELECT TOP 1 ROWGUIDCOL FROM Pinga.visita WHERE cliente_idcliente = @clienteIdcliente AND [data] = @data AND comecou = @comecou AND terminou = @terminou);
		BEGIN TRANSACTION;
			INSERT INTO Pinga.parceiro_has_visita (idparceiro_has_visita, visita_idvisita)
			VALUES (@parceiroIdparceiro, @IdVisita);
		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		ROLLBACK;
		DECLARE @err VARCHAR(250) = (SELECT CONCAT(N'ErrorNumber: ', ERROR_NUMBER(),
												   N' - ErrorMessage: ', CONVERT(VARCHAR(200), ERROR_MESSAGE() COLLATE Latin1_General_CS_AS),
												   N'::L ', ERROR_LINE()));
		DECLARE @proc VARCHAR(50) = (SELECT CONCAT(N'USER PROCEDURE: ', CONVERT(VARCHAR(30), ERROR_PROCEDURE() COLLATE Latin1_General_CS_AS)));
		EXECUTE adm.usp_errorLog @err, @proc, 'Desconhecida', 'database';
        THROW 51921, 'Falha ao realizar o insert da visita com cliente.', 1;
	END CATCH
END;
GO

CREATE OR ALTER PROCEDURE Pinga.usp_InserirNovoFeedBackVisita
	@visitaIdvisita UNIQUEIDENTIFIER,
	@comentario VARCHAR(100),
	@nota TINYINT,
	@vendaRealizada BIT,
	@visitaReagendada BIT,
	@data DATE,
	@comecou TIME,
	@terminou TIME
AS
BEGIN
	SET NOCOUNT ON;
	SET ANSI_NULLS ON;

	BEGIN TRY
		BEGIN TRANSACTION;
			INSERT INTO Pinga.feedback_visita (visita_idvisita, comentario, nota, venda_realizada, visita_reagendada)
			VALUES (@visitaIdvisita, @comentario, @nota, @vendaRealizada, @visitaReagendada);
		COMMIT TRANSACTION;
		IF @visitaReagendada = 1
		BEGIN
			BEGIN TRANSACTION;
				DECLARE @ClienteIdCliente UNIQUEIDENTIFIER = (SELECT TOP 1 cliente_idcliente FROM Pinga.visita WHERE idvisita = @visitaIdvisita);


				-- Criar uma FUNCTION para retornar a data disponivel para visita
				INSERT INTO Pinga.visita (cliente_idcliente, [data], comecou, terminou)
				VALUES (@ClienteIdCliente, @data, @comecou, @terminou);


			COMMIT TRANSACTION;
		END;
	END TRY
	BEGIN CATCH
		ROLLBACK;
		DECLARE @err VARCHAR(250) = (SELECT CONCAT(N'ErrorNumber: ', ERROR_NUMBER(),
												   N' - ErrorMessage: ', CONVERT(VARCHAR(200), ERROR_MESSAGE() COLLATE Latin1_General_CS_AS),
												   N'::L ', ERROR_LINE()));
		DECLARE @proc VARCHAR(50) = (SELECT CONCAT(N'USER PROCEDURE: ', CONVERT(VARCHAR(30), ERROR_PROCEDURE() COLLATE Latin1_General_CS_AS)));
		EXECUTE adm.usp_errorLog @err, @proc, 'Desconhecida', 'database';
        THROW 51921, 'Falha ao realizar o insert do feedback.', 1;
	END CATCH
END;
GO*/
/* USP's INSERIR VISITA */

CREATE OR ALTER FUNCTION Pinga.udf_IdentificarDataParaVisita (
	@parceiroIdparceiro UNIQUEIDENTIFIER,
	@clienteIdcliente UNIQUEIDENTIFIER,
	@dataAgendada SMALLDATETIME)
RETURNS SMALLDATETIME
WITH ENCRYPTION
AS
BEGIN
	IF @parceiroIdparceiro IS NULL OR @clienteIdcliente IS NULL
	BEGIN
		RETURN NULL;
	END

	DECLARE @novaVisita SMALLDATETIME;
	DECLARE @proxDiaUtil DATE = (SELECT adm.udf_ProximoDiaUtil(@dataAgendada));

	-- Table Variable to stored values to use
	/*DECLARE @table TABLE
	(
		diaSemana TINYINT,
		qntVisitas INT
	);
	INSERT INTO @table
	SELECT DATEPART(dw,@dataAgendada)[Dia da Semana], COUNT(*) FROM Pinga.visita v
	INNER JOIN Pinga.parceiro_has_visita phv
	ON v.idvisita = phv.visita_idvisita
	INNER JOIN Pinga.parceiro p
	ON p.idparceiro = phv.parceiro_idparceiro
	INNER JOIN Pinga.cliente c
	ON c.idcliente = v.cliente_idcliente
	GROUP BY v.[data]
	HAVING COUNT(v.[data]) > 0;*/

	-- Identificar o melhor dia para retorno no cliente
	-- podemos marcar no segundo melhor dia (2º dia mais visitado)
	-- Identificar horario disponivel na agenda do parceiro
	
	-- Implementações para a v2.0

	DECLARE @temp VARCHAR(50) = CONCAT(@proxDiaUtil, ' ', DATEPART(HOUR, @dataAgendada), ':', DATEPART(MINUTE, @dataAgendada));
	SET @novaVisita = (CONVERT(SMALLDATETIME, @temp));
	RETURN @novaVisita;
END;
GO

-- SELECT Pinga.udf_IdentificarDataParaVisita @parceiroIdparceiro, @clienteIdcliente, @data
--SELECT Pinga.udf_IdentificarDataParaVisita('4D140F96-EA43-4F8C-AC50-98FC29110F02', 'D48127E5-04EF-4F4E-A8EB-2D4F5AC21B01', GETDATE()) AS UserFunction; 
SELECT Pinga.udf_IdentificarDataParaVisita(NULL, NULL, GETDATE())

IF EXISTS(SELECT 1 FROM sys.tables WHERE name = 'horario')
BEGIN
	DROP TABLE Pinga.horario;
END

CREATE TABLE Pinga.horario (
idhorario UNIQUEIDENTIFIER ROWGUIDCOL NOT NULL DEFAULT NEWID(),
horario_inicio TIME NOT NULL,
tempo_duracao TIME NOT NULL,
dia_semana TINYINT NOT NULL, -- 1=Domingo,2=Segunda...6=Sexta,7=Sabado
[status] BIT NOT NULL DEFAULT 0,

CONSTRAINT pk_horario PRIMARY KEY NONCLUSTERED (idhorario),
CONSTRAINT chk_dia_semana CHECK (dia_semana IN (1,2,3,4,5,6,7))
);

IF EXISTS(SELECT 1 FROM sys.tables WHERE name = 'parceiro_has_horario')
BEGIN
	DROP TABLE Pinga.parceiro_has_horario;
END

CREATE TABLE Pinga.parceiro_has_horario (
idparceiro_has_horario UNIQUEIDENTIFIER ROWGUIDCOL NOT NULL DEFAULT NEWID(),
parceiro_idparceiro UNIQUEIDENTIFIER NOT NULL,
horario_idhorario UNIQUEIDENTIFIER NOT NULL,

CONSTRAINT pk_parceiro_has_horario PRIMARY KEY NONCLUSTERED (idparceiro_has_horario),
FOREIGN KEY (parceiro_idparceiro) REFERENCES Pinga.parceiro(idparceiro),
FOREIGN KEY (horario_idhorario) REFERENCES Pinga.horario(idhorario)
);

IF EXISTS(SELECT 1 FROM sys.tables WHERE name = 'excecoes')
BEGIN
	DROP TABLE Pinga.excecoes;
END

CREATE TABLE Pinga.excecoes (
idexcecoes UNIQUEIDENTIFIER ROWGUIDCOL NOT NULL DEFAULT NEWID(),
[data] DATE NOT NULL,
[status] BIT NOT NULL DEFAULT 0,

CONSTRAINT pk_excecoes PRIMARY KEY NONCLUSTERED (idexcecoes)
);

IF EXISTS(SELECT 1 FROM sys.tables WHERE name = 'agenda')
BEGIN
	ALTER TABLE Pinga.agenda SET (SYSTEM_VERSIONING = OFF);
	DROP TABLE Pinga.agenda;
END

CREATE TABLE Pinga.agenda (
idagenda UNIQUEIDENTIFIER ROWGUIDCOL NOT NULL DEFAULT NEWID(),
visita_idvisita UNIQUEIDENTIFIER NOT NULL,
horario_idhorario UNIQUEIDENTIFIER NOT NULL,
created DATETIME2 GENERATED ALWAYS AS ROW START NOT NULL,
modified DATETIME2 GENERATED ALWAYS AS ROW END NOT NULL,
PERIOD FOR SYSTEM_TIME (created, modified),

CONSTRAINT pk_agenda PRIMARY KEY NONCLUSTERED (idagenda),
FOREIGN KEY (visita_idvisita) REFERENCES Pinga.visita(idvisita),
FOREIGN KEY (horario_idhorario) REFERENCES Pinga.horario(idhorario)
)
WITH (SYSTEM_VERSIONING = ON (HISTORY_TABLE = Legado.agenda));
GO

CREATE OR ALTER FUNCTION adm.udf_ProximoDiaUtil (
	@data DATE)
RETURNS DATE
BEGIN
	DECLARE @DATERETURN DATE;
	DECLARE @WDAY INT = DATEPART(WEEKDAY, @data);
	SET @DATERETURN = (
		SELECT CASE
			WHEN @WDAY = 1 THEN DATEADD(DAY, 1, @data) -- domingo
			WHEN @WDAY = 7 THEN DATEADD(DAY, 2, @data) -- sabado
			ELSE DATEADD(DAY, 1, @data)
		END
	);
	IF NOT EXISTS(SELECT 1 FROM Pinga.excecoes WHERE [data] = @DATERETURN AND [status] = 1)
	BEGIN
		RETURN @DATERETURN;
	END
	ELSE
	BEGIN
		-- Este dia é uma exceção, devemos encontrar o prox dia util
		SET @DATERETURN = DATEADD(DAY, 1, @DATERETURN); -- adicionamos mais um dia e verificados se é fds
		SET @WDAY = DATEPART(WEEKDAY, @DATERETURN);
		SET @DATERETURN = (
			SELECT CASE
				WHEN @WDAY = 1 THEN DATEADD(DAY, 1, @DATERETURN) -- domingo
				WHEN @WDAY = 7 THEN DATEADD(DAY, 2, @DATERETURN) -- sabado
				ELSE DATEADD(DAY, 1, @DATERETURN)
			END
		);
	END
	
	RETURN @DATERETURN;
END;

SELECT adm.udf_ProximoDiaUtil('20170105')

IF EXISTS(SELECT 1 FROM sys.syslogins WHERE name = 'AppLogin')
BEGIN
	DROP LOGIN AppLogin;
END

CREATE LOGIN AppLogin
       WITH PASSWORD = '220996';
       CHECK_POLICY = OFF,
       CHECK_EXPIRATION = OFF,
       DEFAULT_DATABASE = pingaDB;
GO

IF EXISTS(SELECT 1 FROM sys.sysusers WHERE name = 'AppUser')
BEGIN
	DROP USER AppUser;
END

CREATE USER AppUser FOR LOGIN AppLogin;
GO

DENY CREATE TABLE, CREATE VIEW, CREATE PROCEDURE, CREATE FUNCTION, CREATE ROLE, CREATE DEFAULT, BACKUP DATABASE, BACKUP LOG TO AppUser;
GRANT SELECT, UPDATE, INSERT, DELETE, EXECUTE ON SCHEMA::Pinga TO AppUser;
GO

CREATE OR ALTER VIEW Pinga.uvw_VisualizarEndereco
WITH ENCRYPTION, SCHEMABINDING
AS
	SELECT e.idendereco ,tl.tipo_logradouro, e.logradouro, e.numero, tc.tipo_complemento, e.complemento, e.CEP, e.ponto_referencia,
		   b.bairro, c.DDD, c.cidade, c.capital, es.uf, es.estado, p.sigla, p.DDI, p.pais, p.fuso_horario, tcon.tipo_continente, con.continente
	FROM Pinga.endereco e
	INNER JOIN Pinga.tipo_logradouro tl ON e.tipo_logradouro_idtipo_logradouro = tl.idtipo_logradouro
	INNER JOIN Pinga.tipo_complemento tc ON e.tipo_complemento_idtipo_complemento = tc.idtipo_complemento
	INNER JOIN Pinga.bairro b ON e.bairro_idbairro = b.idbairro
	INNER JOIN Pinga.cidade c ON b.cidade_idcidade = c.idcidade
	INNER JOIN Pinga.estado es ON c.estado_idestado = es.idestado
	INNER JOIN Pinga.pais p ON es.pais_idpais = p.idpais
	INNER JOIN Pinga.continente con ON p.continente_idcontinente = con.idcontinente
	INNER JOIN Pinga.tipo_continente tcon ON con.tipo_continente_idtipo_continente = tcon.idtipo_continente
	WHERE tcon.ativo = 1;
GO

CREATE OR ALTER VIEW Pinga.uvw_VisualizarEmail
WITH ENCRYPTION, SCHEMABINDING
AS
	SELECT e.idemail, CONCAT(e.email, '@', ed.email_dominio, '.', el.email_localidade) AS email
	FROM Pinga.email e
	INNER JOIN Pinga.email_dominio ed ON e.email_dominio_idemail_dominio = ed.idemail_dominio
	INNER JOIN Pinga.email_localidade el ON e.email_localidade_idemail_localidade = el.idemail_localidade
	WHERE el.[status] = 1;
GO

CREATE OR ALTER VIEW Pinga.uvw_VisualizarTelefone
WITH ENCRYPTION, SCHEMABINDING
AS
	SELECT t.idtelefone, tt.tipo_telefone, CONCAT('(', c.DDD, ')') AS ddd, t.telefone, o.operadora, c.cidade
	FROM Pinga.telefone t
	INNER JOIN Pinga.operadora o ON t.operadora_idoperadora = o.idoperadora
	INNER JOIN Pinga.cidade c ON t.cidade_ddd = c.idcidade
	INNER JOIN Pinga.tipo_telefone tt ON t.tipo_telefone_idtipo_telefone = tt.idtipo_telefone
	WHERE o.[status] = 1
GO

CREATE OR ALTER VIEW Pinga.uvw_VisualizarInfoCliente
WITH ENCRYPTION, SCHEMABINDING
AS
	SELECT idcliente, cpf_cnpj, nome_razao_social, apelido_nome_fantasia, inscricao_municipal, identidade_inscricao_estadual, data_nascimento_fundacao, sexo,
	email.idemail, email.email,
	en.idendereco, en.tipo_logradouro, en.logradouro, en.numero, en.tipo_complemento, en.complemento, en.CEP, en.ponto_referencia, en.bairro, en.DDD, en.cidade, en.capital, en.uf, en.estado, en.sigla, en.DDI, en.pais, en.fuso_horario, en.tipo_continente, en.continente,
	tel.idtelefone, tel.tipo_telefone, tel.ddd AS telefone_DDD, tel.telefone, tel.operadora, tel.cidade AS telefone_cidade
	FROM Pinga.cliente c
	LEFT JOIN Pinga.uvw_VisualizarEmail email ON c.email_idemail = email.idemail
	LEFT JOIN Pinga.uvw_VisualizarEndereco en ON c.endereco_idendereco = en.idendereco
	LEFT JOIN Pinga.uvw_VisualizarTelefone tel ON tel.idtelefone = c.telefone_idtelefone
GO


SELECT * FROM Pinga.uvw_VisualizarInfoCliente WITH (READUNCOMMITTED, NOLOCK)

SELECT * FROM Pinga.uvw_VisualizarInfoCliente


DECLARE @backup_location VARCHAR(100) = CONCAT(N'C:\Users\IHMHR\Documents\SQL Databases\Backup\Backup_', REPLACE(CONVERT(CHAR(10), GETDATE(), 103), '/', ''), N'_FULL.bak');
DECLARE @backup_mirror_location VARCHAR(100) = CONCAT(N'C:\Users\IHMHR\Documents\SQL Databases\Backup\Mirror Backup\Backup_', REPLACE(CONVERT(CHAR(10), GETDATE(), 103), '/', ''), N'_FULL_MIRROR.bak');

BACKUP DATABASE pingaDB
	TO DISK = @backup_location
	--MIRROR TO DISK = @backup_mirror_location --O espelhamento do backup não está disponível nesta edição do SQL Server. Consulte a documentação online para obter mais detalhes sobre o suporte de recursos em diferentes edições do SQL Server.
	WITH NOINIT /*NÃO SERÁ SOBREESCRITO O ARQUIVO DE BACKUP*/,
		 SKIP /*NÃO VERIFICAR A VALIDADE DO BACKUP*/,
		 CHECKSUM,
		 STOP_ON_ERROR,
		 DESCRIPTION = N'FULL BACKUP DA BASE DE DADOS pingaDB',
		 NAME = N'Backup pingaDB',
		 /*ENCRYPTION
			(
				ALGORITHM = AES_256,
				SERVER CERTIFICATE = BackupEncryptCert
			),*/ --BACKUP DATABASE WITH ENCRYPTION não é suportado em Express Edition (64-bit).
		 STATS = 1,
		 NOFORMAT;
GO

DECLARE @backup_log_location VARCHAR(100) = CONCAT(N'C:\Users\IHMHR\Documents\SQL Databases\Backup\Backup_', REPLACE(CONVERT(CHAR(10), GETDATE(), 103), '/', ''), N'_LOG.bak');

BACKUP LOG pingaDB
	TO DISK = @backup_log_location
	WITH NOINIT,
		 SKIP,
		 CHECKSUM,
		 STOP_ON_ERROR,
		 DESCRIPTION = N'LOG BACKUP DA BASE DE DADOS pingaDB',
		 NAME = N'Backup pingaDB',
		 STATS = 1,
		 NOFORMAT;
GO

RESTORE DATABASE pingaDB
FROM DISK = N'C:\Users\IHMHR\Documents\SQL Databases\Backup\Backup_10012017_FULL.bak'
WITH RECOVERY,
	 REPLACE,
	 CHECKSUM, 
	 STOP_ON_ERROR,
	 STATS = 1;
GO
