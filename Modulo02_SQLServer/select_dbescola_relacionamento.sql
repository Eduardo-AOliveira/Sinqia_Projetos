USE DB_ESCOLA;
GO

--Listando todos os cursos de todas as escolas
SELECT * FROM TBEscolas, TBCursos

--Listando com restrições
SELECT * FROM TBEscolas, TBCursos 
WHERE 
	TBEscolas.Id = TBCursos.IdEscola

--Lista com relacionamento, permitindo seleção de campos
--usando uma variável como base de pesquisa
DECLARE @Valor FLOAT;
SET @Valor = 1500;

SELECT 
	E.Descricao As Escola,
	C.Descricao As Curso,
	E.Endereco As Endereço,
	C.Preco as Preço
FROM 
	TBEscolas E, TBCursos C
WHERE 
	E.Id = C.IdEscola 
	AND C.Preco >= @Valor

--Consultas envolvendo agrupamentos e funções de agregação.
--Apresentar as escolas e a quantidade de cursos por escola
SELECT
	E.Descricao As Escola,
	E.Telefone As Telefone,
	Count(C.Descricao) As QuantCursos,
	Sum(C.Preco) As Total
From 
	TBEscolas E, TBCursos C
WHERE
	E.Id = C.IdEscola
GROUP BY
	E.Descricao, E.Telefone

SELECT
	E.Descricao As Escola,
	E.Telefone As Telefone,
	Count(C.Descricao) As QuantCursos
From 
	TBEscolas E, TBCursos C
WHERE
	E.Id = C.IdEscola
GROUP BY
	E.Descricao, E.Telefone
