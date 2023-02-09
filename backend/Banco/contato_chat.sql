-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: localhost
-- Tempo de geração: 07/02/2023 às 22:25
-- Versão do servidor: 10.4.28-MariaDB
-- Versão do PHP: 7.4.28

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Banco de dados: `contato_chat`
--

DELIMITER $$
--
-- Procedimentos
--
DROP PROCEDURE IF EXISTS `criarConversa`$$
CREATE DEFINER=`contato_chat`@`%` PROCEDURE `criarConversa` (IN `@id` INT(11), IN `@nome` VARCHAR(255), IN `@foto_conversa` VARCHAR(255), IN `@participante1_id` INT(11), IN `@participante2_id` INT(11))   BEGIN
	select 
		@idx := id, 
        @count := count(contato_id)
	from 
		conversa cv 
		join contato_conversa ctcv on cv.id = ctcv.conversa_id 
	where
		ctcv.contato_id in (`@participante1_id`, `@participante2_id`)
	group by cv.id
	having
        count(ctcv.contato_id) = 2;  
        
	
    if (@count = 0 or @count is null)
		then 
			select @maxid := ifnull( max(id), 0) + 1 from conversa;
        
        	start transaction;
    
			insert into conversa (
				id,
				nome, 
				foto_conversa
			) values (
				@maxid,
				`@nome`,
				`@foto_conversa`
			);
		
			insert into contato_conversa 
			(
				contato_id,
				conversa_id,
				data_inicio, 
				status
			) 
			values 
				(`@participante1_id`, @maxid, now(), 1),
				(`@participante2_id`, @maxid, now(), 1);
        
			commit;
	else 
		select @maxid := @idx;
    end if;
        
	select 
		cv.id, 
		cv.nome, 
		cv.foto_conversa,
		contato_id
	from 
		conversa cv
		join contato_conversa ccv on (cv.id = ccv.conversa_id)
	
	where id = @maxid;
END$$

DROP PROCEDURE IF EXISTS `enviarMensagem`$$
CREATE DEFINER=`contato_chat`@`%` PROCEDURE `enviarMensagem` (IN `@contato_id` INT(11), IN `@conversa_id` INT(11), IN `@conteudo` TEXT)   BEGIN
	INSERT INTO mensagens
		(conteudo, contato_id, conversa_id, tipo_conteudo)
	VALUES
		(`@conteudo`, `@contato_id`, `@conversa_id`, 1);
END$$

DROP PROCEDURE IF EXISTS `listarContatos`$$
CREATE DEFINER=`contato_chat`@`%` PROCEDURE `listarContatos` ()   BEGIN
	select * from contato;
END$$

DROP PROCEDURE IF EXISTS `listarConversaId`$$
CREATE DEFINER=`contato_chat`@`%` PROCEDURE `listarConversaId` (IN `@id` INT(11))   BEGIN
	-- retornar dados da conversa
		select id, nome, foto_conversa from conversa where id = `@id`;
        
    -- retornar contatos da conversa
		select id, nome, email, telefone, foto_perfil from contato ctt where ctt.id in (select contato_id from contato_conversa where conversa_id = `@id`);
    
    -- retornar mensagens da conversa
		select id, conteudo, contato_id, conversa_id, tipo_conteudo, dt_inicio from mensagens where conversa_id = `@id`;
    
END$$

DROP PROCEDURE IF EXISTS `listarConversas`$$
CREATE DEFINER=`contato_chat`@`%` PROCEDURE `listarConversas` (IN `@id` INT(11))   BEGIN
	select 
		id,
		nome,
		foto_conversa,
		contato_id,
		status
	from 
		conversa cvs
		join contato_conversa ctt_cvs on (cvs.id = ctt_cvs.conversa_id)
	where 
		contato_id = `@id`;
END$$

DROP PROCEDURE IF EXISTS `listarUsuario`$$
CREATE DEFINER=`contato_chat`@`%` PROCEDURE `listarUsuario` (IN `@id` INT(11))   BEGIN
	select id, nome, email, telefone,foto_perfil from contato where id = `@id`;
END$$

DROP PROCEDURE IF EXISTS `RegistrarUsuario`$$
CREATE DEFINER=`contato_chat`@`%` PROCEDURE `RegistrarUsuario` (IN `@nome` VARCHAR(100), IN `@email` VARCHAR(255), IN `@telefone` VARCHAR(15), IN `@foto_perfil` VARCHAR(255), IN `@senha` CHAR(8), OUT `@id` INT(11))   BEGIN
    insert into contato(
		nome, 
		email, 
        telefone, 
        foto_perfil, 
        senha
	) values (
    `@nome`,
    `@email`,
    `@telefone`,
    `@foto_perfil`,
    `@senha`
    );
    select @id := id from contato where email = `@email`;
    set `@id` = @id;
END$$

DROP PROCEDURE IF EXISTS `testLogin`$$
CREATE DEFINER=`contato_chat`@`%` PROCEDURE `testLogin` (IN `@login` VARCHAR(255), IN `@pass` CHAR(8))   BEGIN
	select 
		id,
		nome,
        email,
        telefone,
		foto_perfil
	from 
		contato
	where 
		email = `@login` and senha = `@pass`;
END$$

DELIMITER ;

-- --------------------------------------------------------

--
-- Estrutura para tabela `contato`
--

DROP TABLE IF EXISTS `contato`;
CREATE TABLE `contato` (
  `id` int(11) NOT NULL,
  `nome` varchar(100) NOT NULL,
  `email` varchar(255) NOT NULL,
  `telefone` varchar(15) NOT NULL,
  `foto_perfil` varchar(255) NOT NULL DEFAULT 'img_padrao',
  `senha` char(8) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Despejando dados para a tabela `contato`
--

INSERT INTO `contato` (`id`, `nome`, `email`, `telefone`, `foto_perfil`, `senha`) VALUES
(20, 'Daniel', 'danielcaitano9@hotmail.com', '75981844960', '', '123456'),
(21, 'lucas', 'lucas@mail.com', '75991348765', '', '123456'),
(23, 'jose', 'jose@mail.com', '75998454785', '', '123456');

-- --------------------------------------------------------

--
-- Estrutura para tabela `contato_conversa`
--

DROP TABLE IF EXISTS `contato_conversa`;
CREATE TABLE `contato_conversa` (
  `contato_id` int(11) NOT NULL,
  `conversa_id` int(11) NOT NULL,
  `data_inicio` datetime NOT NULL,
  `data_fim` datetime DEFAULT NULL,
  `status` int(11) NOT NULL DEFAULT 1
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Despejando dados para a tabela `contato_conversa`
--

INSERT INTO `contato_conversa` (`contato_id`, `conversa_id`, `data_inicio`, `data_fim`, `status`) VALUES
(20, 1, '2023-02-07 01:03:21', NULL, 1),
(21, 1, '2023-02-07 01:03:21', NULL, 1),
(21, 2, '2023-02-07 01:33:09', NULL, 1),
(23, 2, '2023-02-07 01:33:09', NULL, 1),
(20, 3, '2023-02-07 01:33:33', NULL, 1),
(23, 3, '2023-02-07 01:33:33', NULL, 1);

-- --------------------------------------------------------

--
-- Estrutura para tabela `conversa`
--

DROP TABLE IF EXISTS `conversa`;
CREATE TABLE `conversa` (
  `id` int(11) NOT NULL,
  `nome` varchar(255) NOT NULL,
  `foto_conversa` varchar(255) NOT NULL DEFAULT 'img_padrao_grupo'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Despejando dados para a tabela `conversa`
--

INSERT INTO `conversa` (`id`, `nome`, `foto_conversa`) VALUES
(1, 'Daniellucas', 'string'),
(2, 'joselucas', 'string'),
(3, 'joseDaniel', 'string');

-- --------------------------------------------------------

--
-- Estrutura para tabela `mensagens`
--

DROP TABLE IF EXISTS `mensagens`;
CREATE TABLE `mensagens` (
  `id` int(11) NOT NULL,
  `conteudo` text NOT NULL,
  `contato_id` int(11) NOT NULL,
  `conversa_id` int(11) NOT NULL,
  `tipo_conteudo` int(11) NOT NULL,
  `dt_inicio` datetime NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Despejando dados para a tabela `mensagens`
--

INSERT INTO `mensagens` (`id`, `conteudo`, `contato_id`, `conversa_id`, `tipo_conteudo`, `dt_inicio`) VALUES
(40, 'oi', 20, 1, 1, '2023-02-07 01:03:23'),
(41, 'Fala tu!', 21, 1, 1, '2023-02-07 01:03:31'),
(42, 'ficou massa ', 21, 1, 1, '2023-02-07 01:13:25'),
(43, '...', 20, 1, 1, '2023-02-07 01:13:26'),
(44, 'isso ta absurdo', 21, 1, 1, '2023-02-07 01:13:30'),
(45, 'muito pica', 21, 1, 1, '2023-02-07 01:13:36'),
(46, 'kkkkk', 20, 1, 1, '2023-02-07 01:13:44'),
(47, '<3', 21, 1, 1, '2023-02-07 01:13:51'),
(48, 's2', 21, 1, 1, '2023-02-07 01:13:57'),
(49, '_|_', 21, 1, 1, '2023-02-07 01:14:03'),
(50, 'oi miggs', 21, 1, 1, '2023-02-07 01:29:08'),
(51, '666', 20, 1, 1, '2023-02-07 01:29:19'),
(52, 'ta repreendido', 21, 1, 1, '2023-02-07 01:29:28'),
(53, '777', 21, 1, 1, '2023-02-07 01:29:30'),
(55, 'oi', 23, 3, 1, '2023-02-07 01:33:46'),
(56, 'oi lindo', 23, 2, 1, '2023-02-07 01:33:56'),
(57, 'ola', 20, 3, 1, '2023-02-07 01:34:06'),
(58, '777', 23, 3, 1, '2023-02-07 01:34:55'),
(59, 'oi gato ', 21, 2, 1, '2023-02-07 01:39:22'),
(60, 'como vai ', 21, 2, 1, '2023-02-07 01:39:26'),
(61, '?', 21, 2, 1, '2023-02-07 01:39:29');

--
-- Índices para tabelas despejadas
--

--
-- Índices de tabela `contato`
--
ALTER TABLE `contato`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `email` (`email`),
  ADD UNIQUE KEY `telefone` (`telefone`);

--
-- Índices de tabela `contato_conversa`
--
ALTER TABLE `contato_conversa`
  ADD PRIMARY KEY (`conversa_id`,`contato_id`),
  ADD KEY `conversa_id` (`conversa_id`),
  ADD KEY `contato_id` (`contato_id`);

--
-- Índices de tabela `conversa`
--
ALTER TABLE `conversa`
  ADD PRIMARY KEY (`id`);

--
-- Índices de tabela `mensagens`
--
ALTER TABLE `mensagens`
  ADD PRIMARY KEY (`id`),
  ADD KEY `contato_id` (`contato_id`),
  ADD KEY `conversa_id` (`conversa_id`);

--
-- AUTO_INCREMENT para tabelas despejadas
--

--
-- AUTO_INCREMENT de tabela `contato`
--
ALTER TABLE `contato`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=28;

--
-- AUTO_INCREMENT de tabela `mensagens`
--
ALTER TABLE `mensagens`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=62;

--
-- Restrições para tabelas despejadas
--

--
-- Restrições para tabelas `contato_conversa`
--
ALTER TABLE `contato_conversa`
  ADD CONSTRAINT `contato_conversa_ibfk_1` FOREIGN KEY (`conversa_id`) REFERENCES `conversa` (`id`),
  ADD CONSTRAINT `contato_conversa_ibfk_2` FOREIGN KEY (`contato_id`) REFERENCES `contato` (`id`);

--
-- Restrições para tabelas `mensagens`
--
ALTER TABLE `mensagens`
  ADD CONSTRAINT `mensagens_ibfk_1` FOREIGN KEY (`contato_id`) REFERENCES `contato` (`id`),
  ADD CONSTRAINT `mensagens_ibfk_2` FOREIGN KEY (`conversa_id`) REFERENCES `conversa` (`id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
