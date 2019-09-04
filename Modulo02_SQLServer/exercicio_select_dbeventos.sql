
--selecionar todos os eventos cujo preço esteja 
--entre 500 e 1000 reais
SELECT * FROM TBEventos WHERE Preco BETWEEN 500 AND 1000
--SELECT * FROM TBEventos WHERE Preco >= 500 AND Preco <= 1000

--selecionar todos os convidados (nome, email)
--que estiverem inscritos em eventos gratis
SELECT 
	C.Nome, C.Email, E.Descricao
FROM
	TBConvidados C, TBEventos E
WHERE
	E.Id = C.IdEvento AND E.Preco = 0

--Apresentar a quantidade de convidados por evento
--(exibir o nome do evento e a quantidade de convidados)
SELECT 
	E.Descricao As Evento,
	Count(C.Cpf) As QuantConvidados
FROM
	TBEventos E, TBConvidados C
WHERE
	E.Id = C.IdEvento
GROUP BY
	E.Descricao

--Apresentar o valor arrecadado por evento
--(apresentar o nome do evento e o total pago pelos convidados)
SELECT 
	E.Descricao As Evento,
	Sum(E.Preco) As ValorTotal
FROM
	TBEventos E, TBConvidados C
WHERE
	E.Id = C.IdEvento
GROUP BY
	E.Descricao
