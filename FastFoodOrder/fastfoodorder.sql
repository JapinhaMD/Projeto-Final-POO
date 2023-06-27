CREATE TABLE `itempedido` (
  `id` int(11) NOT NULL,
  `nome` varchar(50) NOT NULL,
  `quantidade` int(11) NOT NULL,
  `preco_unit` decimal(10,2) NOT NULL,
  `pedido_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;


INSERT INTO `itempedido` (`id`, `nome`, `quantidade`, `preco_unit`, `pedido_id`) VALUES
(1, 'pizza', 1, 57.00, 1),
(2, 'hotdog', 2, 9.00, 1);


CREATE TABLE `pedido` (
  `id` int(11) NOT NULL,
  `data` date NOT NULL,
  `cliente` varchar(40) NOT NULL,
  `status` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;


INSERT INTO `pedido` (`id`, `data`, `cliente`, `status`) VALUES
(4, '2023-02-22', 'japa', 'em preparo'),
(5, '2023-12-23', 'david', 'em preparo'),
(6, '2023-12-23', 'japa', 'em andamento');

ALTER TABLE `itempedido`
  ADD PRIMARY KEY (`id`);

ALTER TABLE `pedido`
  ADD PRIMARY KEY (`id`);

ALTER TABLE `itempedido`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;


ALTER TABLE `pedido`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
