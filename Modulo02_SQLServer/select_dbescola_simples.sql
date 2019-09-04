/*
	Trabalhando com consultas simples 
*/
USE DB_ESCOLA;
GO

--listando todas as escolas
SELECT * FROM TBEscolas

--listando apenas o nome e o telefone
SELECT Descricao, Telefone FROM TBEscolas

--Forma 2
SELECT 
	Descricao AS Descrição, 
	Telefone AS Fone 
FROM TBEscolas

--Forma 3
SELECT 
	Descricao Descrição, 
	Telefone Fone 
FROM TBEscolas

--Forma 4
SELECT 
	E.Descricao, E.Endereco
FROM TBEscolas E

--Forma 5 (menos desejavel)
SELECT 
	TBEscolas.Descricao, TBEscolas.Endereco
FROM TBEscolas

---- Restrições ---------------
SELECT * FROM TBEscolas WHERE Descricao LIKE 'F%'
SELECT * FROM TBEscolas WHERE Descricao = 'UNA'
SELECT * FROM TBEscolas WHERE 
	Id BETWEEN 2 AND 5 
	AND Endereco LIKE 'Av%'