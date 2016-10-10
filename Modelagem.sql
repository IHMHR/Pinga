USE master;
GO

IF EXISTS(SELECT 1 FROM sys.databases WHERE name = 'pingaDB')
BEGIN
    DROP DATABASE pingaDB;
END

CREATE DATABASE pingaDB ON (NAME = 'pingaDB', FILENAME = 'C:\Users\Martinelli\Documents\GitHub\Pinga\DB\pingaDB.mdf', SIZE = 10MB, MAXSIZE = 25MB, FILEGROWTH = 10% )
LOG ON (NAME = 'pingaDB_LOG', FILENAME = 'C:\Users\Martinelli\Documents\GitHub\Pinga\DB\pingaDB.ldf', SIZE = 5MB, MAXSIZE = 10MB, FILEGROWTH = 20%)
COLLATE Latin1_General_CS_AI;
GO

USE pingaDB;
GO

CREATE SCHEMA Pinga;
GO

IF EXISTS(SELECT 1 FROM sys.tables WHERE name = 'endereco')
BEGIN
    DROP TABLE Pinga.endereco;
END

CREATE TABLE Pinga.endereco (
idendereco UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),
logradouro VARCHAR(100) NOT NULL,
numero INT NULL,
complemento VARCHAR(30) NULL,
ponto_referencia VARCHAR(45) NULL,
bairro VARCHAR(100) NOT NULL,
cidade VARCHAR(80) NOT NULL,
uf CHAR(2) NOT NULL,
pais VARCHAR(50) NULL,
created DATETIME NOT NULL DEFAULT GETDATE(),
modified DATETIME NULL,

CONSTRAINT pk_endereco PRIMARY KEY NONCLUSTERED (idendereco)
);

IF EXISTS(SELECT 1 FROM sys.tables WHERE name = 'telefone_pais')
BEGIN
    DROP TABLE Pinga.telefone_pais;
END

CREATE TABLE Pinga.telefone_pais (
idtelefone_pais UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),
ddi VARCHAR(4) NOT NULL,
pais_sigla CHAR(3) NOT NULL,

CONSTRAINT pk_telefone_pais PRIMARY KEY NONCLUSTERED (idtelefone_pais)
);

IF EXISTS(SELECT 1 FROM sys.tables WHERE name = 'telefone_regiao')
BEGIN
    DROP TABLE Pinga.telefone_regiao;
END

CREATE TABLE Pinga.telefone_regiao (
idtelefone_regiao UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),
ddd VARCHAR(4) NOT NULL,
regiao_sigla CHAR(2) NOT NULL,
telefone_pais_ddi UNIQUEIDENTIFIER NOT NULL,

CONSTRAINT pk_telefone_regiao PRIMARY KEY NONCLUSTERED (idtelefone_regiao),
FOREIGN KEY (telefone_pais_ddi) REFERENCES Pinga.telefone_pais(idtelefone_pais)
);

IF EXISTS(SELECT 1 FROM sys.tables WHERE name = 'telefone_tipo')
BEGIN
    DROP TABLE Pinga.telefone_tipo;
END

CREATE TABLE Pinga.telefone_tipo (
idtelefone_tipo UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),
descricao VARCHAR(20) NOT NULL,

CONSTRAINT pk_telefone_tipo PRIMARY KEY NONCLUSTERED (idtelefone_tipo)
);

IF EXISTS(SELECT 1 FROM sys.tables WHERE name = 'telefone')
BEGIN
    DROP TABLE Pinga.telefone;
END

CREATE TABLE Pinga.telefone (
idtelefone UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),
telefone VARCHAR(11) NOT NULL,
telefone_regiao UNIQUEIDENTIFIER NOT NULL,
telefone_tipo UNIQUEIDENTIFIER NOT NULL,
created DATETIME NOT NULL DEFAULT GETDATE(),
modified DATETIME NULL,

CONSTRAINT pk_telefone PRIMARY KEY NONCLUSTERED (idtelefone),
FOREIGN KEY (telefone_regiao) REFERENCES Pinga.telefone_regiao(idtelefone_regiao),
FOREIGN KEY (telefone_tipo) REFERENCES Pinga.telefone_pais(idtelefone_tipo)
);

IF EXISTS(SELECT 1 FROM sys.tables WHERE name = 'tipo_litragem')
BEGIN
    DROP TABLE Pinga.tipo_litragem;
END

CREATE TABLE Pinga.tipo_litragem (
idtipo_litragem UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),
descricao VARCHAR(35) NOT NULL,

CONSTRAINT pk_tipo_litragem PRIMARY KEY NONCLUSTERED (idtipo_litragem)
);

IF EXISTS(SELECT 1 FROM sys.tables WHERE name = 'produto')
BEGIN
    DROP TABLE Pinga.produto;
END

CREATE TABLE Pinga.produto (
idproduto UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),
descricao VARCHAR(30) NOT NULL,
litragem INT NULL,
tipo_litragem UNIQUEIDENTIFIER NOT NULL,
vendendo BIT NOT NULL DEFAULT 0,
valor_unitario DECIMAL(9,2) NULL,
created DATETIME NOT NULL DEFAULT GETDATE(),
modified DATETIME NULL,

CONSTRAINT pk_produto PRIMARY KEY NONCLUSTERED (idproduto),
FOREIGN KEY (tipo_litragem) REFERENCES Pinga.tipo_litragem(idtipo_litragem)
);

IF EXISTS(SELECT 1 FROM sys.tables WHERE name = 'entrada')
BEGIN
    DROP TABLE Pinga.entrada;
END

CREATE TABLE Pinga.entrada (
identrada UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),
data DATE NOT NULL DEFAULT GETDATE(),
litragem INT NOT NULL,
tipo_litragem UNIQUEIDENTIFIER NOT NULL,
valor DECIMAL(9,2) NOT NULL,
created DATETIME NOT NULL DEFAULT GETDATE(),
modified DATETIME NULL,

CONSTRAINT pk_entrada PRIMARY KEY NONCLUSTERED (identrada),
FOREIGN KEY (tipo_litragem) REFERENCES Pinga.tipo_litragem(idtipo_litragem)
);

IF EXISTS(SELECT 1 FROM sys.tables WHERE name = 'fornecedor')
BEGIN
    DROP TABLE Pinga.fornecedor;
END

CREATE TABLE Pinga.fornecedor (
idfornecedor UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),
nome VARCHAR(60) NOT NULL,
endereco UNIQUEIDENTIFIER NOT NULL,
telefone UNIQUEIDENTIFIER NOT NULL,

CONSTRAINT pk_fornecedor PRIMARY KEY NONCLUSTERED (idfornecedor),
FOREIGN KEY (endereco) REFERENCES Pinga.endereco(idendereco),
FOREIGN KEY (telefone) REFERENCES Pinga.telefone(idtelefone)
);

IF EXISTS(SELECT 1 FROM sys.tables WHERE name = 'custo')
BEGIN
    DROP TABLE Pinga.custo;
END

CREATE TABLE Pinga.custo (
idcusto UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),
descricao VARCHAR(60) NOT NULL,
valor DECIMAL(9,2) NOT NULL,
created DATETIME NOT NULL DEFAULT GETDATE(),
modified DATETIME NULL,

CONSTRAINT pk_custo PRIMARY KEY NONCLUSTERED (idcusto)
);

IF EXISTS(SELECT 1 FROM sys.tables WHERE name = 'fase')
BEGIN
    DROP TABLE Pinga.fase;
END

CREATE TABLE Pinga.fase (
idfase UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),
descricao VARCHAR(60) NOT NULL,
created DATETIME NOT NULL DEFAULT GETDATE(),
modified DATETIME NULL,

CONSTRAINT pk_fase PRIMARY KEY NONCLUSTERED (idfase)
);

IF EXISTS(SELECT 1 FROM sys.tables WHERE name = 'forma_pagamento')
BEGIN
    DROP TABLE Pinga.forma_pagamento;
END

CREATE TABLE Pinga.forma_pagamento (
idforma_pagamento UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),
descricao VARCHAR(45) NOT NULL,
created DATETIME NOT NULL DEFAULT GETDATE(),
modified DATETIME NULL,

CONSTRAINT pk_forma_pagamento PRIMARY KEY NONCLUSTERED (idforma_pagamento)
);

IF EXISTS(SELECT 1 FROM sys.tables WHERE name = 'cliente')
BEGIN
    DROP TABLE Pinga.cliente;
END

CREATE TABLE Pinga.cliente (
idcliente UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),
cpf_cnpj VARCHAR(14) NOT NULL,
razao_social VARCHAR(60) NOT NULL,
nome_fantasia VARCHAR(60) NOT NULL,
inscricao_municipal CHAR(14) NULL,
inscricao_estadual CHAR(14) NULL,
data_fundacao DATE NOT NULL,
endereco UNIQUEIDENTIFIER NOT NULL,
visitado BIT NOT NULL DEFAULT 0,
telefone UNIQUEIDENTIFIER NOT NULL,
created DATETIME NOT NULL DEFAULT GETDATE(),
modified DATETIME NULL,

CONSTRAINT pk_cliente PRIMARY KEY NONCLUSTERED (idcliente),
FOREIGN KEY (endereco) REFERENCES Pinga.endereco(idendereco),
FOREIGN KEY (telefone) REFERENCES Pinga.telefone(idtelefone)
);

IF EXISTS(SELECT 1 FROM sys.tables WHERE name = 'qnt_minima')
BEGIN
    DROP TABLE Pinga.qnt_minima;
END

CREATE TABLE Pinga.qnt_minima (
idqnt_minima UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),
valor INT NOT NULL,
produto UNIQUEIDENTIFIER NOT NULL,
created DATETIME NOT NULL DEFAULT GETDATE(),
modified DATETIME NULL,

CONSTRAINT pk_qnt_minima PRIMARY KEY NONCLUSTERED (idqnt_minima),
FOREIGN KEY (produto) REFERENCES Pinga.produto(idproduto)
);

IF EXISTS(SELECT 1 FROM sys.tables WHERE name = 'idqnt_maxima')
BEGIN
    DROP TABLE Pinga.idqnt_maxima;
END

CREATE TABLE Pinga.idqnt_maxima (
idqnt_maxima UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),
valor INT NOT NULL,
produto UNIQUEIDENTIFIER NOT NULL,
created DATETIME NOT NULL DEFAULT GETDATE(),
modified DATETIME NULL,

CONSTRAINT pk_qnt_maxima PRIMARY KEY NONCLUSTERED (idqnt_maxima),
FOREIGN KEY (produto) REFERENCES Pinga.produto(idproduto)
);

IF EXISTS(SELECT 1 FROM sys.tables WHERE name = 'parceiro')
BEGIN
    DROP TABLE Pinga.parceiro;
END

CREATE TABLE Pinga.parceiro (
idparceiro UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),
nome VARCHAR(60) NOT NULL,
endereco UNIQUEIDENTIFIER NOT NULL,
ativo BIT NOT NULL DEFAULT 0,
telefone UNIQUEIDENTIFIER NOT NULL,
created DATETIME NOT NULL DEFAULT GETDATE(),
modified DATETIME NULL,

CONSTRAINT pk_parceiro PRIMARY KEY NONCLUSTERED (idparceiro),
FOREIGN KEY (endereco) REFERENCES Pinga.endereco(idendereco),
FOREIGN KEY (telefone) REFERENCES Pinga.telefone(idtelefone)
);

IF EXISTS(SELECT 1 FROM sys.tables WHERE name = 'saida')
BEGIN
    DROP TABLE Pinga.saida;
END

CREATE TABLE Pinga.saida (
idsaida UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),
data DATETIME2 NOT NULL DEFAULT GETDATE(),
parceiro UNIQUEIDENTIFIER NOT NULL,
/*litragem INT NOT NULL,
tipo_litragem UNIQUEIDENTIFIER NOT NULL,
valor DECIMAL (9,2) NOT NULL,*/
cliente UNIQUEIDENTIFIER NOT NULL,
fase UNIQUEIDENTIFIER NOT NULL,
forma_pagamento UNIQUEIDENTIFIER NOT NULL,
created DATETIME NOT NULL DEFAULT GETDATE(),
modified DATETIME NULL,

CONSTRAINT pk_saida PRIMARY KEY NONCLUSTERED (idsaida),
FOREIGN KEY (parceiro) REFERENCES Pinga.parceiro(idparceiro),
/*FOREIGN KEY (tipo_litragem) REFERENCES Pinga.tipo_litragem(idtipo_litragem),*/
FOREIGN KEY (cliente) REFERENCES Pinga.cliente(idcliente),
FOREIGN KEY (fase) REFERENCES Pinga.fase(idfase),
FOREIGN KEY (forma_pagamento) REFERENCES Pinga.forma_pagamento(idforma_pagamento)
);

IF EXISTS(SELECT 1 FROM sys.tables WHERE name = 'itens_saida')
BEGIN
    DROP TABLE Pinga.itens_saida;
END

CREATE TABLE Pinga.itens_saida (
iditens_saida UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),
saida UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),
entrada UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),
produto UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),
quantidade INT NOT NULL,
valor_saida DECIMAL(9,2) NOT NULL,
created DATETIME NOT NULL DEFAULT GETDATE(),
modified DATETIME NULL,

CONSTRAINT pk_itens_saida PRIMARY KEY NONCLUSTERED (iditens_saida),
FOREIGN KEY (saida) REFERENCES Pinga.saida(idsaida),
FOREIGN KEY (produto) REFERENCES Pinga.produto(idproduto),
FOREIGN KEY (saida) REFERENCES Pinga.saida(idsaida)
);

IF EXISTS(SELECT 1 FROM sys.tables WHERE name = 'parcelamento')
BEGIN
    DROP TABLE Pinga.parcelamento;
END

CREATE TABLE Pinga.parcelamento (
idparcelamento UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),
Entrada_Saida UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),
data_pagamento DATE NOT NULL,
data_vencimento DATE NOT NULL,
parcelas INT NOT NULL,
juros DECIMAL(8,5) NULL,
created DATETIME NOT NULL DEFAULT GETDATE(),
modified DATETIME NULL,

CONSTRAINT pk_parcelamento PRIMARY KEY NONCLUSTERED (idparcelamento)
);

IF EXISTS(SELECT 1 FROM sys.tables WHERE name = 'students')
BEGIN
    DROP TABLE students;
END
GO

CREATE SCHEMA adm;
GO

CREATE TABLE adm.login(
idlogin UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),
lgn VARCHAR(30) NOT NULL,
pwd VARCHAR(65) NOT NULL,
ativo BIT NOT NULL DEFAULT 0,
created DATETIME NOT NULL DEFAULT GETDATE(),
modified DATETIME NULL,

CONSTRAINT pk_login PRIMARY KEY NONCLUSTERED (idlogin)
)

INSERT INTO adm.login (lgn,pwd,ativo) VALUES ('123', '123', 1);
SELECT * FROM adm.login;

UPDATE adm.login SET pwd = '40BD001563085FC35165329EA1FF5C5ECBDBBEEF' WHERE idlogin = 'C42F99A9-8CEF-4E64-A48D-4B3F94CBFE7B';

exec sp_tables;

/*SELECT c.nome AS 'Nome Cliente', CASE WHEN c.visitado = 1 THEN 'Sim' ELSE 'Não' END AS 'Cliente Visitado',
CONVERT(CHAR(10), c.created, 103) AS 'Data Cadastro', e.logradouro, e.numero, e.complemento, e.bairro, e.cidade, e.uf,
c.idcliente, e.idendereco, s.cliente AS 'Vnd'
FROM pingaDB.Pinga.cliente c INNER JOIN pingaDB.Pinga.endereco e ON c.endereco = e.idendereco
LEFT JOIN pingaDB.Pinga.saida s ON s.cliente = c.idcliente*/


SELECT * FROM pingaDB.Pinga.entrada;


/*18/09/2016 00:00:00
2016-09-18*/

/*SELECT p.nome, CASE WHEN p.ativo = 1 THEN 'Sim' ELSE 'Não', e.logradouro, e.numero, e.complemento, e.bairro, e.cidade, e.uf, s.parceiro
FROM Pinga.parceiro p INNER JOIN Pinga.endereco e ON e.idendereco = p.endereco
LEFT JOIN Pinga.saida s ON s.cliente = p.idparceiro*/

INSERT INTO pingaDB.Pinga.tipo_litragem VALUES (NEWID(), 'Meiotinha'),(NEWID(), 'Litro');

SELECT * FROM pingaDB.Pinga.saida

SELECT p.idparceiro, p.nome, CASE WHEN p.ativo = 1 THEN 'Sim' ELSE 'Não' END AS ativo, e.logradouro, e.numero, e.complemento, e.bairro, e.cidade, e.uf, s.parceiro FROM Pinga.parceiro p INNER JOIN Pinga.endereco e ON e.idendereco = p.endereco LEFT JOIN Pinga.saida s ON s.cliente = p.idparceiro;

SELECT data, parceiro, cliente, fase, forma_pagamento
FROM pingaDB.Pinga.saida


SELECT * FROM pingaDB.Pinga.produto
SELECT descricao FROM Pinga.forma_pagamento;

SELECT * FROM pingaDB.Pinga.saida

SELECT * FROM pingaDB.Pinga.produto

SELECT idproduto, p.descricao, litragem, tl.descricao, CASE WHEN p.vendendo = 1 THEN 'Vendendo' ELSE 'Fora do mercado' END AS Vendendo, p.valor_unitario
FROM Pinga.produto p
INNER JOIN Pinga.tipo_litragem tl ON p.tipo_litragem = tl.idtipo_litragem

CREATE TABLE Pinga.estoque (
idestoque UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),
produto UNIQUEIDENTIFIER NOT NULL,
quantidade INT NOT NULL,

CONSTRAINT pk_estoque PRIMARY KEY NONCLUSTERED (idestoque),
FOREIGN KEY (produto) REFERENCES Pinga.produto(idproduto)
);
GO

/*CREATE TRIGGER Pinga.trg_estoque
ON Pinga.entrada AFTER INSERT
AS
	INSERT INTO estoque VALUES ();
GO*/

SELECT * FROM pingaDB.Pinga.cliente;


SELECT produto, quantidade, (p.descricao + N' - ' + quantidade) AS item FROM Pinga.estoque e INNER JOIN Pinga.produto p ON p.idproduto = e.produto;



IF EXISTS(SELECT 1 FROM sys.tables WHERE name = 'cliente_has_parceiro')
BEGIN
    DROP TABLE Pinga.cliente_has_parceiro;
END

CREATE TABLE Pinga.cliente_has_parceiro (
idcliente_has_parceiro UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),
cliente UNIQUEIDENTIFIER NOT NULL,
parceiro UNIQUEIDENTIFIER NOT NULL,
created DATETIME NOT NULL DEFAULT GETDATE()

FOREIGN KEY (cliente) REFERENCES Pinga.cliente(idcliente),
FOREIGN KEY (parceiro) REFERENCES Pinga.parceiro(idparceiro)
);

IF EXISTS(SELECT 1 FROM sys.tables WHERE name = 'representante')
BEGIN
    DROP TABLE Pinga.representante;
END

CREATE TABLE Pinga.representante (
idrepresentante UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),
nome VARCHAR(50) NOT NULL,
telefone UNIQUEIDENTIFIER NOT NULL,
email VARCHAR(50) NULL,
departamento VARCHAR(30) NULL,
cargo VARCHAR(25) NOT NULL,
status BIT NOT NULL DEFAULT 0,

CONSTRAINT pk_representante PRIMARY KEY NONCLUSTERED (idrepresentante),
FOREIGN KEY (telefone) REFERENCES Pinga.telefone(idtelefone)
);

IF EXISTS(SELECT 1 FROM sys.tables WHERE name = 'cliente_has_representante')
BEGIN
    DROP TABLE Pinga.cliente_has_representante;
END

CREATE TABLE Pinga.cliente_has_representante (
idcliente_has_representante UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),
cliente UNIQUEIDENTIFIER NOT NULL,
representante UNIQUEIDENTIFIER NOT NULL,
responsavel_contrato BIT NOT NULL DEFAULT 0

FOREIGN KEY (cliente) REFERENCES Pinga.cliente(idcliente),
FOREIGN KEY (representante) REFERENCES Pinga.representante(idrepresentante)
);

IF EXISTS(SELECT 1 FROM sys.tables WHERE name = 'visita')
BEGIN
    DROP TABLE Pinga.visita;
END

CREATE TABLE Pinga.visita (
idvisita UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),
cliente UNIQUEIDENTIFIER NOT NULL,
data DATETIME NOT NULL,
endereco UNIQUEIDENTIFIER NOT NULL,
comecou TIME NULL,
terminou TIME NULL,

CONSTRAINT pk_visita PRIMARY KEY NONCLUSTERED (idvisita),
FOREIGN KEY (cliente) REFERENCES Pinga.cliente(idcliente),
FOREIGN KEY (endereco) REFERENCES Pinga.endereco(idendereco)
);

IF EXISTS(SELECT 1 FROM sys.tables WHERE name = 'parceiro_has_visita')
BEGIN
    DROP TABLE Pinga.parceiro_has_visita;
END

CREATE TABLE Pinga.parceiro_has_visita (
idparceiro_has_visita UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),
parceiro UNIQUEIDENTIFIER NOT NULL,
visita UNIQUEIDENTIFIER NOT NULL

FOREIGN KEY (parceiro) REFERENCES Pinga.parceiro(idparceiro),
FOREIGN KEY (visita) REFERENCES Pinga.visita(idvisita),
);

IF EXISTS(SELECT 1 FROM sys.tables WHERE name = 'feedback_visita')
BEGIN
    DROP TABLE Pinga.feedback_visita;
END

CREATE TABLE Pinga.feedback_visita (
idfeedback_visita UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),
visita UNIQUEIDENTIFIER NOT NULL,
comentario VARCHAR(100) NULL,
nota TINYINT NOT NULL,
venda_realizada BIT NOT NULL,
visita_reagendada BIT NOT NULL, -- criar uma nova visita

CONSTRAINT pk_feedback_visita PRIMARY KEY NONCLUSTERED (idfeedback_visita),
FOREIGN KEY (visita) REFERENCES Pinga.visita(idvisita)
);

IF EXISTS(SELECT 1 FROM sys.tables WHERE name = 'contrato')
BEGIN
    DROP TABLE Pinga.contrato;
END

CREATE TABLE Pinga.contrato (
idcontrato UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),
cliente UNIQUEIDENTIFIER NOT NULL,
data_entrada_vigor DATE NOT NULL,
data_expiracao DATE NOT NULL,
data_assinatura DATE NULL,
prorrogavel BIT NOT NULL DEFAULT 0,
status BIT NOT NULL DEFAULT 0,
forma_pagamento UNIQUEIDENTIFIER NOT NULL,
multa_quebra DECIMAL (9,2) NOT NULL,

CONSTRAINT pk_contrato PRIMARY KEY NONCLUSTERED (idcontrato),
FOREIGN KEY (cliente) REFERENCES Pinga.cliente(idcliente),
FOREIGN KEY (forma_pagamento) REFERENCES Pinga.forma_pagamento(idforma_pagamento)
);

IF EXISTS(SELECT 1 FROM sys.tables WHERE name = 'testemunha')
BEGIN
    DROP TABLE Pinga.testemunha;
END

CREATE TABLE Pinga.testemunha (
idtestemunha UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),
primeiro_nome VARCHAR(20) NOT NULL,
nome_meio VARCHAR(40) NULL,
sobrenome VARCHAR(25) NOT NULL,
cpf CHAR(11) NOT NULL,
contrato UNIQUEIDENTIFIER NOT NULL,

CONSTRAINT pk_testemunha PRIMARY KEY NONCLUSTERED (idtestemunha),
FOREIGN KEY (contrato) REFERENCES Pinga.contrato(idcontrato)
);

