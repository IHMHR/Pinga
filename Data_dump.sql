INSERT INTO adm.login (lgn,pwd,[status]) VALUES ('123', '123', 1);
SELECT * FROM adm.login;

UPDATE adm.login SET pwd = '40BD001563085FC35165329EA1FF5C5ECBDBBEEF' WHERE lgn = '123';


INSERT INTO Pinga.tipo_continente (tipo_continente, ativo)
VALUES ('Quatro continentes', 0),
('Cinco continentes', 0),('Seis continentes', 1),
('Seis continentes 2', 0),('Sete continentes', 0);

SELECT * FROM Pinga.tipo_continente;

INSERT INTO Pinga.continente (continente, tipo_continente_idtipo_continente)
VALUES ('América', (SELECT ROWGUIDCOL FROM Pinga.tipo_continente WHERE tipo_continente = 'Quatro continentes')),('Eurafrásia', (SELECT ROWGUIDCOL FROM Pinga.tipo_continente WHERE tipo_continente = 'Quatro continentes')),('Oceania', (SELECT ROWGUIDCOL FROM Pinga.tipo_continente WHERE tipo_continente = 'Quatro continentes')),('Antártida', (SELECT ROWGUIDCOL FROM Pinga.tipo_continente WHERE tipo_continente = 'Quatro continentes')),
('América', (SELECT ROWGUIDCOL FROM Pinga.tipo_continente WHERE tipo_continente = 'Cinco continentes')),('Ásia', (SELECT ROWGUIDCOL FROM Pinga.tipo_continente WHERE tipo_continente = 'Cinco continentes')),('Europa', (SELECT ROWGUIDCOL FROM Pinga.tipo_continente WHERE tipo_continente = 'Cinco continentes')),('África', (SELECT ROWGUIDCOL FROM Pinga.tipo_continente WHERE tipo_continente = 'Cinco continentes')),('Oceania', (SELECT ROWGUIDCOL FROM Pinga.tipo_continente WHERE tipo_continente = 'Cinco continentes')),
('América', (SELECT ROWGUIDCOL FROM Pinga.tipo_continente WHERE tipo_continente = 'Seis continentes')),('Ásia', (SELECT ROWGUIDCOL FROM Pinga.tipo_continente WHERE tipo_continente = 'Seis continentes')),('Europa', (SELECT ROWGUIDCOL FROM Pinga.tipo_continente WHERE tipo_continente = 'Seis continentes')),('África', (SELECT ROWGUIDCOL FROM Pinga.tipo_continente WHERE tipo_continente = 'Seis continentes')),('Oceania', (SELECT ROWGUIDCOL FROM Pinga.tipo_continente WHERE tipo_continente = 'Seis continentes')),('Antártida', (SELECT ROWGUIDCOL FROM Pinga.tipo_continente WHERE tipo_continente = 'Seis continentes')),
('América do Norte', (SELECT ROWGUIDCOL FROM Pinga.tipo_continente WHERE tipo_continente = 'Seis continentes 2')),('América do Sul', (SELECT ROWGUIDCOL FROM Pinga.tipo_continente WHERE tipo_continente = 'Seis continentes 2')),('Eurafrásia', (SELECT ROWGUIDCOL FROM Pinga.tipo_continente WHERE tipo_continente = 'Seis continentes 2')),('África', (SELECT ROWGUIDCOL FROM Pinga.tipo_continente WHERE tipo_continente = 'Seis continentes 2')),('Oceania', (SELECT ROWGUIDCOL FROM Pinga.tipo_continente WHERE tipo_continente = 'Seis continentes 2')),('Antártida', (SELECT ROWGUIDCOL FROM Pinga.tipo_continente WHERE tipo_continente = 'Seis continentes 2')),
('América do Norte', (SELECT ROWGUIDCOL FROM Pinga.tipo_continente WHERE tipo_continente = 'Sete continentes')),('América do Sul', (SELECT ROWGUIDCOL FROM Pinga.tipo_continente WHERE tipo_continente = 'Sete continentes')),('Ásia', (SELECT ROWGUIDCOL FROM Pinga.tipo_continente WHERE tipo_continente = 'Sete continentes')),('Europa', (SELECT ROWGUIDCOL FROM Pinga.tipo_continente WHERE tipo_continente = 'Sete continentes')),('Oceania', (SELECT ROWGUIDCOL FROM Pinga.tipo_continente WHERE tipo_continente = 'Sete continentes')),('Antártida', (SELECT ROWGUIDCOL FROM Pinga.tipo_continente WHERE tipo_continente = 'Sete continentes'));

SELECT * FROM Pinga.continente c, Pinga.tipo_continente tc
WHERE tc.idtipo_continente = c.tipo_continente_idtipo_continente;

INSERT INTO Pinga.pais (pais, idioma, colacao, DDI, sigla, fuso_horario, continente_idcontinente)
VALUES ('Brasil', 'Português do Brasil', 'Latin1_General_CS_AS', '55', 'BRA', 'UTC-03:00', (SELECT c.ROWGUIDCOL FROM Pinga.continente c INNER JOIN Pinga.tipo_continente tc ON c.tipo_continente_idtipo_continente = tc.idtipo_continente WHERE tc.ativo = 1 AND c.continente = 'América'));

SELECT * FROM Pinga.pais p
INNER JOIN Pinga.continente c ON p.continente_idcontinente = c.idcontinente;
GO

INSERT INTO Pinga.tipo_logradouro (tipo_logradouro)
VALUES ('Rua'), ('Avenida'), ('Alameda');

INSERT INTO Pinga.tipo_complemento (tipo_complemento)
VALUES ('Casa'), ('Apartamento'), ('Casa de esquina');

INSERT INTO Pinga.estado (estado, uf, capital, pais_idpais)
VALUES ('Minas Gerais', 'MG', 0, (SELECT ROWGUIDCOL FROM Pinga.pais WHERE pais = 'Brasil')),
('Rio de Janeiro', 'RJ', 0, (SELECT ROWGUIDCOL FROM Pinga.pais WHERE pais = 'Brasil')),
('São Paulo', 'SP', 0, (SELECT ROWGUIDCOL FROM Pinga.pais WHERE pais = 'Brasil'));

INSERT INTO Pinga.cidade (cidade, DDD, capital, estado_idestado)
VALUES ('Belo Horizonte', '031', 1, (SELECT ROWGUIDCOL FROM Pinga.estado WHERE uf = 'MG')),
('Contagem', '031', 0, (SELECT ROWGUIDCOL FROM Pinga.estado WHERE uf = 'MG')),
('Abaeté', '035', 0, (SELECT ROWGUIDCOL FROM Pinga.estado WHERE uf = 'MG'));

INSERT INTO Pinga.bairro (bairro, regiao, cidade_idcidade)
VALUES ('Alípio de Melo', 'Noroeste', (SELECT ROWGUIDCOL FROM Pinga.cidade WHERE cidade = 'Belo Horizonte')),
('Barroca', 'Oeste', (SELECT ROWGUIDCOL FROM Pinga.cidade WHERE cidade = 'Belo Horizonte'));

INSERT INTO Pinga.endereco (tipo_logradouro_idtipo_logradouro, logradouro, numero, tipo_complemento_idtipo_complemento, complemento, CEP, ponto_referencia, bairro_idbairro, created)
VALUES ((SELECT ROWGUIDCOL FROM Pinga.tipo_logradouro WHERE tipo_logradouro = 'Rua'), 'dos Securitários', 115, (SELECT ROWGUIDCOL FROM Pinga.tipo_complemento WHERE tipo_complemento = 'Casa'), 'com grade branca', '30840760', 'Próxima a padaria Gamela', (SELECT ROWGUIDCOL FROM Pinga.bairro WHERE bairro = 'Alípio de Melo'), GETDATE());


INSERT INTO Pinga.tipo_telefone (descricao)
VALUES ('Telefone Residencial'),('Celular'),('Telefone Comercial'),('Telefone Extra');

INSERT INTO Pinga.operadora (nome, razao_social, status)
VALUES ('TIM', 'Telecom Italia Mobile', 1);

INSERT INTO Pinga.telefone (telefone, cidade_ddd, tipo_telefone_idtipo_telefone, operadora_idoperadora, created)
VALUES ('988521996', (SELECT ROWGUIDCOL FROM Pinga.cidade WHERE DDD = '031' AND cidade = 'Belo Horizonte'), (SELECT ROWGUIDCOL FROM Pinga.tipo_telefone WHERE descricao = 'Celular'), (SELECT ROWGUIDCOL FROM Pinga.operadora WHERE nome = 'TIM'), GETDATE());

INSERT INTO Pinga.parceiro (nome, endereco_idendereco, status, telefone_idtelefone, created)
VALUES ('Parceiro A', (SELECT ROWGUIDCOL FROM Pinga.endereco WHERE CEP = '30840760' AND logradouro = 'dos Securitários'), 1, (SELECT ROWGUIDCOL FROM Pinga.telefone WHERE telefone = '988521996'), GETDATE()),
('Parceiro B', (SELECT ROWGUIDCOL FROM Pinga.endereco WHERE CEP = '30840760' AND logradouro = 'dos Securitários'), 1, (SELECT ROWGUIDCOL FROM Pinga.telefone WHERE telefone = '988521996'), GETDATE()),
('Parceiro C', (SELECT ROWGUIDCOL FROM Pinga.endereco WHERE CEP = '30840760' AND logradouro = 'dos Securitários'), 1, (SELECT ROWGUIDCOL FROM Pinga.telefone WHERE telefone = '988521996'), GETDATE());


INSERT INTO Pinga.email_localidade (email_localidade, status)
VALUES ('br', 1),('it', 1),('co', 1),('jp', 1),('com.br', 1), ('com', 1);

INSERT INTO Pinga.email_dominio (email_dominio, status)
VALUES ('hotmail', 1),('outlook', 1),('yahoo', 1);

INSERT INTO Pinga.email (email, email_dominio_idemail_dominio, email_localidade_idemail_localidade)
VALUES ('martinelli.igor', (SELECT ROWGUIDCOL FROM Pinga.email_dominio WHERE email_dominio = 'hotmail'), (SELECT ROWGUIDCOL FROM Pinga.email_localidade WHERE email_localidade = 'com'));

INSERT INTO Pinga.cliente (cpf_cnpj,nome_razao_social, apelido_nome_fantasia, inscricao_municipal, identidade_inscricao_estadual, data_nascimento_fundacao, sexo, email_idemail, endereco_idendereco, telefone_idtelefone, created)
VALUES ('13089902605', 'Igor Henrique Martinelli de Heredia Ramos', 'IHMHR', '13089902605', 'MG17771898', '1996-09-22', 'M', (SELECT e.ROWGUIDCOL FROM Pinga.email e INNER JOIN Pinga.email_dominio em ON em.idemail_dominio = e.email_dominio_idemail_dominio INNER JOIN Pinga.email_localidade el ON el.idemail_localidade = e.email_localidade_idemail_localidade WHERE e.email = 'martinelli.igor' AND em.email_dominio = 'hotmail' AND el.email_localidade = 'com'), (SELECT ROWGUIDCOL FROM Pinga.endereco WHERE CEP = '30840760' AND logradouro = 'dos Securitários'), (SELECT ROWGUIDCOL FROM Pinga.telefone WHERE telefone = '988521996'), GETDATE());


INSERT INTO Pinga.horario (horario_inicio, tempo_duracao, dia_semana, [status])
VALUES ('08:00', '00:15', 2, 1),('08:00', '00:15', 3, 1),('08:00', '00:15', 4, 1),
('08:00', '00:15', 5, 1),('08:00', '00:15', 6, 1),('08:00', '00:15', 7, 1);

INSERT INTO Pinga.parceiro_has_horario (parceiro_idparceiro, horario_idhorario)
VALUES ((SELECT ROWGUIDCOL FROM Pinga.parceiro WHERE nome = 'Parceiro A'), (SELECT ROWGUIDCOL FROM Pinga.horario WHERE horario_inicio = '08:00' AND dia_semana = 2)),
((SELECT ROWGUIDCOL FROM Pinga.parceiro WHERE nome = 'Parceiro A'), (SELECT ROWGUIDCOL FROM Pinga.horario WHERE horario_inicio = '08:00' AND dia_semana = 3)),
((SELECT ROWGUIDCOL FROM Pinga.parceiro WHERE nome = 'Parceiro A'), (SELECT ROWGUIDCOL FROM Pinga.horario WHERE horario_inicio = '08:00' AND dia_semana = 4));


INSERT INTO Pinga.visita (parceiro_has_horario_idparceiro_has_horario, cliente_idcliente)
VALUES ((SELECT TOP 1 ROWGUIDCOL FROM Pinga.parceiro_has_horario WHERE parceiro_idparceiro = (SELECT ROWGUIDCOL FROM Pinga.parceiro WHERE nome = 'Parceiro A')), (SELECT ROWGUIDCOL FROM Pinga.cliente WHERE cpf_cnpj = '13089902605')),
((SELECT TOP 1 ROWGUIDCOL FROM Pinga.parceiro_has_horario WHERE parceiro_idparceiro = (SELECT ROWGUIDCOL FROM Pinga.parceiro WHERE nome = 'Parceiro A')), (SELECT ROWGUIDCOL FROM Pinga.cliente WHERE cpf_cnpj = '13089902605')),
((SELECT TOP 1 ROWGUIDCOL FROM Pinga.parceiro_has_horario WHERE parceiro_idparceiro = (SELECT ROWGUIDCOL FROM Pinga.parceiro WHERE nome = 'Parceiro A')), (SELECT ROWGUIDCOL FROM Pinga.cliente WHERE cpf_cnpj = '13089902605')),
((SELECT TOP 1 ROWGUIDCOL FROM Pinga.parceiro_has_horario WHERE parceiro_idparceiro = (SELECT ROWGUIDCOL FROM Pinga.parceiro WHERE nome = 'Parceiro A')), (SELECT ROWGUIDCOL FROM Pinga.cliente WHERE cpf_cnpj = '13089902605'));


INSERT INTO Pinga.excecoes (data, [status])
VALUES ('20170101', 1),('20171225', 1), ('20170907', 1);

-- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- --

INSERT INTO Pinga.feedback_visita (visita_idvisita, [data], comecou, terminou, comentario, nota, venda_realizada, cliente_convertido, visita_idvisita)
VALUES ();

INSERT INTO Pinga.parceiro_has_visita (parceiro_idparceiro, visita_idvisita)
VALUES ((SELECT ROWGUIDCOL FROM Pinga.parceiro WHERE nome = 'Parceiro A'), '9DE53D8F-9B54-4386-85E3-328A045872A7');

INSERT INTO Pinga.parceiro_has_visita (parceiro_idparceiro, visita_idvisita)
VALUES ((SELECT ROWGUIDCOL FROM Pinga.parceiro WHERE nome = 'Parceiro A'), '45076C04-E3D5-4F5F-A4FA-6510186AA82D')
,((SELECT ROWGUIDCOL FROM Pinga.parceiro WHERE nome = 'Parceiro A'), 'BB315B67-BBBE-40C8-8AD5-DC03FA9B443E')
,((SELECT ROWGUIDCOL FROM Pinga.parceiro WHERE nome = 'Parceiro A'), '7777F6EA-8B26-48F9-8885-B9A3590320E3')
,((SELECT ROWGUIDCOL FROM Pinga.parceiro WHERE nome = 'Parceiro A'), '12D61FE3-8949-400F-AAD4-6610378742D4')
,((SELECT ROWGUIDCOL FROM Pinga.parceiro WHERE nome = 'Parceiro A'), '77FA9E7B-A9DE-44D3-907E-B656C74764ED')
,((SELECT ROWGUIDCOL FROM Pinga.parceiro WHERE nome = 'Parceiro A'), '57C18D8D-79D7-4DBD-857A-EDA171EA7438')
,((SELECT ROWGUIDCOL FROM Pinga.parceiro WHERE nome = 'Parceiro A'), 'C912999C-520B-426B-811F-151AA37A69D0');


INSERT INTO Pinga.visita (cliente_idcliente, data, comecou, terminou)
VALUES ('D48127E5-04EF-4F4E-A8EB-2D4F5AC21B01', DATEADD(d, -2, GETDATE()), '15:00', '15:15'),
('D48127E5-04EF-4F4E-A8EB-2D4F5AC21B01', DATEADD(d, -3, GETDATE()), '15:00', '15:15'),
('D48127E5-04EF-4F4E-A8EB-2D4F5AC21B01', DATEADD(d, -4, GETDATE()), '15:30', '15:45'),
('D48127E5-04EF-4F4E-A8EB-2D4F5AC21B01', DATEADD(d, -7, GETDATE()), '16:00', '16:15');


SELECT ROWGUIDCOL, CAST(horario_inicio AS VARCHAR(5)) AS Horario, CAST(tempo_duracao AS VARCHAR(5)) AS TempoDuracao, dia_semana, [status] FROM Pinga.horario



INSERT INTO Pinga.parceiro_has_horario (parceiro_idparceiro, horario_idhorario)
VALUES ((SELECT ROWGUIDCOL FROM Pinga.parceiro WHERE nome = 'Parceiro A'), 'F16968A0-72D7-4CA5-8806-D800F1A68108'), ((SELECT ROWGUIDCOL FROM Pinga.parceiro WHERE nome = 'Parceiro A'), '333DCEE8-6A46-40B4-84FD-9EB541C060A6'), ((SELECT ROWGUIDCOL FROM Pinga.parceiro WHERE nome = 'Parceiro A'), 'EC898152-D2B2-4A23-81D5-D7F55F683A6F'),
((SELECT ROWGUIDCOL FROM Pinga.parceiro WHERE nome = 'Parceiro B'), 'F16968A0-72D7-4CA5-8806-D800F1A68108'), ((SELECT ROWGUIDCOL FROM Pinga.parceiro WHERE nome = 'Parceiro B'), '333DCEE8-6A46-40B4-84FD-9EB541C060A6'), ((SELECT ROWGUIDCOL FROM Pinga.parceiro WHERE nome = 'Parceiro B'), 'EC898152-D2B2-4A23-81D5-D7F55F683A6F'),
((SELECT ROWGUIDCOL FROM Pinga.parceiro WHERE nome = 'Parceiro C'), 'F16968A0-72D7-4CA5-8806-D800F1A68108'), ((SELECT ROWGUIDCOL FROM Pinga.parceiro WHERE nome = 'Parceiro C'), '333DCEE8-6A46-40B4-84FD-9EB541C060A6'), ((SELECT ROWGUIDCOL FROM Pinga.parceiro WHERE nome = 'Parceiro C'), 'EC898152-D2B2-4A23-81D5-D7F55F683A6F');

INSERT INTO Pinga.agenda (visita_idvisita, horario_idhorario)
VALUES ('BB315B67-BBBE-40C8-8AD5-DC03FA9B443E', 'CAEF609E-8F11-44DB-AE1B-00846217C15C'),
('45076C04-E3D5-4F5F-A4FA-6510186AA82D', 'CAEF609E-8F11-44DB-AE1B-00846217C15C');
