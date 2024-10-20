CREATE TABLE games (
	id INT AUTO_INCREMENT PRIMARY KEY,
    Title VARCHAR(255),                     -- Para o título do jogo
    MaximoJogadores INT,                    -- Máximo de jogadores, sendo um número inteiro
    Multiplataforma BOOLEAN,                -- Indica se é multiplataforma (sim/não)
    Genero VARCHAR(255),                    -- Gênero do jogo
    Fabricante VARCHAR(255),                -- Fabricante ou Publisher
    Nota DECIMAL(3,2),                      -- Nota de avaliação, com até 2 casas decimais
    Vendas DECIMAL(10,2),                   -- Vendas, número decimal
    Preco DECIMAL(10,2),                    -- Preço de revenda usado, número decimal
    Consola VARCHAR(50),                    -- Console de lançamento (plataforma)
    AnoLancamento INT                       -- Ano de lançamento, sendo um número inteiro
);

ALTER TABLE allgames 
MODIFY COLUMN id INT AUTO_INCREMENT PRIMARY KEY;
DESCRIBE allgames;
ALTER TABLE allgames 
DROP COLUMN id;

ALTER TABLE allgames 
ADD COLUMN ID INT AUTO_INCREMENT PRIMARY KEY FIRST;
ALTER TABLE allgames 
CHANGE COLUMN Title Titulo VARCHAR(255);
