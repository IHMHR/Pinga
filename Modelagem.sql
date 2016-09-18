USE master;
GO

IF EXISTS(SELECT 1 FROM sys.databases WHERE name = 'pingaDB')
BEGIN
    DROP DATABASE pingaDB;
END

CREATE DATABASE imobiliaria ON (NAME = 'pingaDB', FILENAME = 'C:\Users\Martinelli\pingaDB.mdf', SIZE = 10MB, MAXSIZE = 25MB, FILEGROWTH = 10% )
LOG ON (NAME = 'pingaDB_LOG', FILENAME = 'C:\Users\Martinelli\pingaDB.ldf', SIZE = 5MB, MAXSIZE = 10MB, FILEGROWTH = 20%)
COLLATE Latin1_General_CS_AI;
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
bairro VARCHAR(100) NOT NULL,
cidade VARCHAR(80) NOT NULL,
uf CHAR(2) NOT NULL,
pais VARCHAR(50) NULL,
created DATETIME NOT NULL,
modified DATETIME NULL,

CONSTRAINT pk_endereco PRIMARY KEY NONCLUSTERED (idendereco)
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
created DATETIME NOT NULL,
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


CONSTRAINT pk_fornecedor PRIMARY KEY NONCLUSTERED (idfornecedor),
FOREIGN KEY (endereco) REFERENCES Pinga.endereco(idendereco)
);

IF EXISTS(SELECT 1 FROM sys.tables WHERE name = 'custo')
BEGIN
    DROP TABLE Pinga.custo;
END

CREATE TABLE Pinga.custo (
idcusto UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),
descricao VARCHAR(60) NOT NULL,
valor DECIMAL(9,2) NOT NULL,
created DATETIME NOT NULL,
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
created DATETIME NOT NULL,
modified DATETIME NULL,

CONSTRAINT pk_fase PRIMARY KEY NONCLUSTERED (idfase)
);

IF EXISTS(SELECT 1 FROM sys.tables WHERE name = 'forma_pagamento')
BEGIN
    DROP TABLE Pinga.forma_pagamento;
END

CREATE TABLE Pinga.forma_pagamento (
idforma_pagamento UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),
descricao VARCHAR(60) NOT NULL,
created DATETIME NOT NULL,
modified DATETIME NULL,

CONSTRAINT pk_forma_pagamento PRIMARY KEY NONCLUSTERED (idforma_pagamento)
);

IF EXISTS(SELECT 1 FROM sys.tables WHERE name = 'cliente')
BEGIN
    DROP TABLE Pinga.cliente;
END

CREATE TABLE Pinga.cliente (
idcliente UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),
nome VARCHAR(60) NOT NULL,
endereco UNIQUEIDENTIFIER NOT NULL,
visitado BIT NOT NULL DEFAULT 0,
created DATETIME NOT NULL,
modified DATETIME NULL,

CONSTRAINT pk_cliente PRIMARY KEY NONCLUSTERED (idcliente),
FOREIGN KEY (endereco) REFERENCES Pinga.endereco(idendereco)
);

IF EXISTS(SELECT 1 FROM sys.tables WHERE name = 'qnt_minima')
BEGIN
    DROP TABLE Pinga.qnt_minima;
END

CREATE TABLE Pinga.qnt_minima (
idqnt_minima UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),
valor INT NOT NULL,
created DATETIME NOT NULL,
modified DATETIME NULL,

CONSTRAINT pk_qnt_minima PRIMARY KEY NONCLUSTERED (idqnt_minima)
);

IF EXISTS(SELECT 1 FROM sys.tables WHERE name = 'idqnt_maxima')
BEGIN
    DROP TABLE Pinga.idqnt_maxima;
END

CREATE TABLE Pinga.idqnt_maxima (
idqnt_maxima UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),
valor INT NOT NULL,
created DATETIME NOT NULL,
modified DATETIME NULL,

CONSTRAINT pk_qnt_maxima PRIMARY KEY NONCLUSTERED (idqnt_maxima)
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
created DATETIME NOT NULL,
modified DATETIME NULL,

CONSTRAINT pk_parceiro PRIMARY KEY NONCLUSTERED (idparceiro),
FOREIGN KEY (endereco) REFERENCES Pinga.endereco(idendereco)
);

IF EXISTS(SELECT 1 FROM sys.tables WHERE name = 'saida')
BEGIN
    DROP TABLE Pinga.saida;
END

CREATE TABLE Pinga.saida (
idsaida UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),
data DATETIME2 NOT NULL DEFAULT GETDATE(),
parceiro UNIQUEIDENTIFIER NOT NULL,
litragem INT NOT NULL,
tipo_litragem UNIQUEIDENTIFIER NOT NULL,
valor DECIMAL (9,2) NOT NULL,
cliente UNIQUEIDENTIFIER NOT NULL,
fase UNIQUEIDENTIFIER NOT NULL,
forma_pagamento UNIQUEIDENTIFIER NOT NULL,

CONSTRAINT pk_saida PRIMARY KEY NONCLUSTERED (idsaida),
FOREIGN KEY (parceiro) REFERENCES Pinga.parceiro(idparceiro),
FOREIGN KEY (tipo_litragem) REFERENCES Pinga.tipo_litragem(idtipo_litragem),
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

CONSTRAINT pk_parcelamento PRIMARY KEY NONCLUSTERED (idparcelamento)
);
