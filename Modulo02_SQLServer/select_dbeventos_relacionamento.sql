USE DB_EVENTOS;
GO
--inserir dados na tabela TBEventos (4 eventos)

--Obs: As datas podem ser fornecidas nos formatos:
-- MM/dd/yyyy    ou		yyyy-MM-dd
INSERT INTO TBEventos (Descricao, Responsavel, Data, Preco)
VALUES 
('Palestra Javascript','Prof. Joao','2019-08-12', 500),
('Formatura TI','Unip','2019-12-20', 0),
('Passeio por BH','Sinqia','2019-08-10', 100),
('Aula de Ingles','Prof. Maria','2019-08-15', 300)

--inserir dados na tabela TBConvidados (procurar colocar mais de 1
--por evento
INSERT INTO TBConvidados (Cpf, IdEvento, Nome,Email,Telefone) 
VALUES 
('21485474100',1,'Daniel','3365-2211','daniel@impacta.com'),
('01285232101',1,'Gerson','2955-4512','gerson@mail.com'),
('31584744422',2,'Antonio','95443-8874','tony@mail.com'),
('85548525401',2,'Lucy','2201-2201','lucy@mail.com'),
('25478547474',3,'Maria','2201-2201','maria@mail.com'),
('88745124147',4,'Luciano','3211-8875','luciano@gmail.com'),
('01878574197',4,'Denis','3211-8875','denis@gmail.com')

