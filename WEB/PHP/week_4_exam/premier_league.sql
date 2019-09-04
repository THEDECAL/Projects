-- phpMyAdmin SQL Dump
-- version 4.8.4
-- https://www.phpmyadmin.net/
--
-- Хост: 127.0.0.1
-- Время создания: Авг 04 2019 г., 10:51
-- Версия сервера: 10.1.37-MariaDB
-- Версия PHP: 7.1.26

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- База данных: `premier_league`
--

-- --------------------------------------------------------

--
-- Структура таблицы `commands`
--

CREATE TABLE `commands` (
  `id` int(11) NOT NULL,
  `name` varchar(32) DEFAULT NULL,
  `coach` varchar(64) DEFAULT NULL,
  `emblem_filename` varchar(255) NOT NULL,
  `home_stadium_id` int(11) DEFAULT NULL,
  `isDelete` tinyint(1) NOT NULL DEFAULT '0'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `commands`
--

INSERT INTO `commands` (`id`, `name`, `coach`, `emblem_filename`, `home_stadium_id`, `isDelete`) VALUES
(1, 'Арсенал', 'Унаи Эмери', '5d36f86b3b11b.svg', 1, 0),
(2, 'Манчестер Юнайтед', 'Уле Гуннар Сульшер', '5d3837c42ac24.svg', 2, 0),
(3, 'Ливерпуль', 'Юрген Клопп', '5d3bcb6173c26.svg', 3, 0),
(4, 'Манчестер Сити', 'Пеп Гвардиола', '5d3ca830618bc.png', 4, 0),
(5, 'Челси', 'Фрэнк Лэмпард', '5d3cad93127ad.svg', 5, 0);

-- --------------------------------------------------------

--
-- Структура таблицы `goals`
--

CREATE TABLE `goals` (
  `id` int(11) NOT NULL,
  `player_id` int(11) NOT NULL,
  `player_passed_id` int(11) NOT NULL,
  `match_id` int(11) NOT NULL,
  `goal_minute` int(11) NOT NULL,
  `isDelete` tinyint(1) NOT NULL DEFAULT '0'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `goals`
--

INSERT INTO `goals` (`id`, `player_id`, `player_passed_id`, `match_id`, `goal_minute`, `isDelete`) VALUES
(1, 11, 13, 1, 1, 0);

-- --------------------------------------------------------

--
-- Структура таблицы `matches`
--

CREATE TABLE `matches` (
  `id` int(11) NOT NULL,
  `first_command_id` int(11) NOT NULL,
  `second_command_id` int(11) NOT NULL,
  `score` varchar(5) NOT NULL,
  `date` datetime NOT NULL,
  `isDelete` tinyint(1) NOT NULL DEFAULT '0'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `matches`
--

INSERT INTO `matches` (`id`, `first_command_id`, `second_command_id`, `score`, `date`, `isDelete`) VALUES
(1, 1, 2, '3:2', '2019-08-01 18:00:00', 0),
(2, 3, 4, '', '2019-09-27 17:00:00', 0);

-- --------------------------------------------------------

--
-- Структура таблицы `news`
--

CREATE TABLE `news` (
  `id` int(11) NOT NULL,
  `date` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `title` varchar(255) NOT NULL,
  `text` mediumtext,
  `isDeleted` tinyint(1) NOT NULL DEFAULT '0'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `news`
--

INSERT INTO `news` (`id`, `date`, `title`, `text`, `isDeleted`) VALUES
(1, '2019-08-04 10:56:43', '\"Ливерпуль\" и \"Манчестер Сити\" сыграют 27 сентября', '\"Ливерпуль\" и \"Манчестер Сити\" сыграют 27 сентября в 5 часов вечера. Фанаты с нетерпением ожидают игры.', 0),
(2, '2019-08-04 11:43:01', '\"Арсенал\" побеждает \"Манчестер Юнайтед\"', '\"Арсенал\" побеждает \"Манчестер Юнайтед\" со счётом 3:2!', 0);

-- --------------------------------------------------------

--
-- Структура таблицы `penalized_persons`
--

CREATE TABLE `penalized_persons` (
  `id` int(11) NOT NULL,
  `match_id` int(11) NOT NULL,
  `player_id` int(11) NOT NULL,
  `cnt_rcard` int(11) NOT NULL,
  `cnt_ycard` int(11) NOT NULL,
  `isDelete` tinyint(1) NOT NULL DEFAULT '0'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `penalized_persons`
--

INSERT INTO `penalized_persons` (`id`, `match_id`, `player_id`, `cnt_rcard`, `cnt_ycard`, `isDelete`) VALUES
(1, 1, 15, 1, 2, 0);

-- --------------------------------------------------------

--
-- Структура таблицы `players`
--

CREATE TABLE `players` (
  `id` int(11) NOT NULL,
  `position_id` int(11) NOT NULL,
  `command_id` int(11) NOT NULL,
  `season_year` int(4) NOT NULL,
  `name` varchar(64) NOT NULL,
  `photo_filename` varchar(255) NOT NULL,
  `isDelete` tinyint(1) NOT NULL DEFAULT '0'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `players`
--

INSERT INTO `players` (`id`, `position_id`, `command_id`, `season_year`, `name`, `photo_filename`, `isDelete`) VALUES
(5, 1, 1, 2019, 'Бернд Лено', '5d380b76729ba.jpg', 0),
(6, 1, 2, 2019, 'Давид де Хеа', '5d3839436ff79.jpg', 0),
(7, 21, 1, 2019, 'Эктор Бельерин', '5d385c65c0708.jpg', 0),
(8, 22, 1, 2019, 'Мохаммед эль-Ненни', '5d385d21f10c9.jpg', 0),
(9, 21, 1, 2019, ' Сократис Папастатопулос', '5d385dd3c8ced.jpg', 0),
(10, 21, 1, 2019, 'Лоран Косельни', '5d385e1ec11b6.jpg', 0),
(11, 22, 1, 2019, 'Генрих Мхитарян', '5d385ebe47e22.jpg', 0),
(12, 23, 1, 2019, 'Александр Ляказетт', '5d385f664410d.jpg', 0),
(13, 22, 1, 2019, 'Месут Озиль', '5d385fc7507b7.jpg', 0),
(14, 22, 1, 2019, 'Лукас Торрейра', '5d3860160ac7e.jpg', 0),
(15, 23, 1, 2019, 'Пьер-Эмерик Обамеянг', '5d3860e5c0424.jpg', 0),
(16, 22, 1, 2019, 'Энзли Мейтленд-Найлз', '5d393d23e4285.jpg', 0),
(17, 21, 2, 2019, 'Виктор Линделёф', '5d3964a18a3bc.jpg', 0),
(18, 21, 2, 2019, 'Эрик Байи', '5d396c035511b.jpg', 0),
(19, 21, 2, 2019, 'Фил Джонс', '5d396cce4e66e.jpg', 0),
(20, 22, 2, 2019, 'Поль Погба', '5d396d14ba32b.jpg', 0),
(21, 23, 2, 2019, 'Алексис Санчес', '5d396d604aa0d.jpg', 0),
(22, 22, 2, 2019, 'Хуан Мата', '5d396dbe641cd.jpg', 0),
(23, 23, 2, 2019, 'Ромелу Лукаку', '5d396e13a7b1a.jpg', 0),
(24, 23, 2, 2019, 'Маркус Рашфорд', '5d396e4e68492.jpg', 0),
(25, 22, 2, 2019, 'Антони Марсьяль', '5d396e8c7fd72.jpg', 0),
(26, 21, 2, 2019, 'Крис Смоллинг', '5d39773138a81.jpg', 0),
(47, 21, 3, 2019, 'Натаниэл Клайн', '5d3ca78e4671a.jpg', 0),
(48, 22, 3, 2019, 'Фабиньо', '5d3ca78ee7dfd.jpg', 0),
(49, 21, 3, 2019, 'Вирджил ван Дейк', '5d3ca78f327f3.jpg', 0),
(50, 22, 3, 2019, 'Джорджиньо Вейналдум', '5d3ca78fc8804.jpg', 0),
(51, 21, 3, 2019, 'Деян Ловрен', '5d3ca79033fce.jpg', 0),
(52, 22, 3, 2019, 'Джеймс Милнер', '5d3ca7906cf3d.jpg', 0),
(53, 22, 3, 2019, 'Наби Кейта', '5d3ca790a447c.jpg', 0),
(54, 23, 3, 2019, 'Роберто Фирмино', '5d3ca790da5c0.jpg', 0),
(55, 23, 3, 2019, 'Садио Мане', '5d3ca791264e8.jpg', 0),
(56, 23, 3, 2019, 'Мохаммед Салах', '5d3ca791683b8.jpg', 0),
(57, 21, 4, 2019, 'Кайл Уокер', '5d3cacd66df4f.jpg', 0),
(58, 21, 4, 2019, 'Данило', '5d3cacd6b14f1.jpg', 0),
(59, 21, 4, 2019, 'Джон Стоунз', '5d3cacd6f33a2.jpg', 0),
(60, 23, 4, 2019, 'Рахим Стерлинг', '5d3cacd7428ac.jpg', 0),
(61, 22, 4, 2019, 'Илкай Гюндоган', '5d3cacd77892e.jpg', 0),
(62, 23, 4, 2019, 'Габриэл Жезус', '5d3cacd7b406e.jpg', 0),
(63, 23, 4, 2019, 'Серхио Агуэро', '5d3cacd7ee6c4.jpg', 0),
(64, 22, 4, 2019, 'Александр Зинченко', '5d3cacd83b017.jpg', 0),
(65, 21, 4, 2019, 'Эмерик Ляпорт', '5d3cacd87decb.jpg', 0),
(66, 21, 4, 2019, 'Эльяким Мангаля', '5d3cacd8bf04a.jpg', 0),
(87, 21, 5, 2019, 'Антонио Рюдигер', '5d3d8d824e36e.jpg', 0),
(88, 21, 5, 2019, 'Маркос Алонсо', '5d3d8d829b344.jpg', 0),
(89, 21, 5, 2019, 'Давиде Дзаппакоста', '5d3d8d82dc4db.jpg', 0),
(90, 21, 5, 2019, 'Андреас Кристенсен', '5d3d8d83396b0.png', 0),
(91, 22, 5, 2019, 'Итан Ампаду', '5d3d8d8395201.jpg', 0),
(92, 23, 5, 2019, 'Оливье Жиру', '5d3d8d83d69b9.jpg', 0),
(93, 22, 5, 2019, 'Жоржиньо', '5d3d8d8424bff.jpg', 0),
(94, 22, 5, 2019, 'Дэнни Дринкуотер', '5d3d8d8462be4.jpg', 0),
(95, 21, 5, 2019, 'Давид Луис', '5d3d8d84a5f3a.jpg', 0),
(96, 21, 5, 2019, 'Эмерсон Палмери', '5d3d8d84da2e5.jpg', 0);

-- --------------------------------------------------------

--
-- Структура таблицы `positions`
--

CREATE TABLE `positions` (
  `id` int(11) NOT NULL,
  `name` varchar(48) DEFAULT NULL,
  `isDelete` tinyint(1) NOT NULL DEFAULT '0'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `positions`
--

INSERT INTO `positions` (`id`, `name`, `isDelete`) VALUES
(1, 'Вратарь', 0),
(21, 'Защитник', 0),
(22, 'Полузащитник', 0),
(23, 'Нападающий', 0);

-- --------------------------------------------------------

--
-- Структура таблицы `stadiums`
--

CREATE TABLE `stadiums` (
  `id` int(11) NOT NULL,
  `city` varchar(32) NOT NULL,
  `name` varchar(64) DEFAULT NULL,
  `isDelete` tinyint(1) NOT NULL DEFAULT '0'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `stadiums`
--

INSERT INTO `stadiums` (`id`, `city`, `name`, `isDelete`) VALUES
(1, 'Лондон', 'Эмирейтс', 0),
(2, 'Манчестер', 'Олд Траффорд', 0),
(3, 'Ливерпуль', 'Энфилд', 0),
(4, 'Манчестер', 'Этихад', 0),
(5, 'Лондон', 'Стэмфорд Бридж', 0);

-- --------------------------------------------------------

--
-- Структура таблицы `users`
--

CREATE TABLE `users` (
  `id` int(11) NOT NULL,
  `username` varchar(32) DEFAULT NULL,
  `password` char(60) NOT NULL,
  `authKey` char(60) NOT NULL,
  `accessToken` char(60) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `users`
--

INSERT INTO `users` (`id`, `username`, `password`, `authKey`, `accessToken`) VALUES
(1, 'admin', '$2y$13$N8LsceKLX8NhlEoKUmeRSe6WT3KH2c3PvYj07r..G/eShRLZT95Ny', '', '');

--
-- Индексы сохранённых таблиц
--

--
-- Индексы таблицы `commands`
--
ALTER TABLE `commands`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `name` (`name`),
  ADD UNIQUE KEY `coach` (`coach`),
  ADD UNIQUE KEY `home_stadium_id` (`home_stadium_id`),
  ADD KEY `fk_commands_to_stadiums_id` (`home_stadium_id`) USING BTREE;

--
-- Индексы таблицы `goals`
--
ALTER TABLE `goals`
  ADD PRIMARY KEY (`id`),
  ADD KEY `fk_goals_to_matches_id` (`match_id`) USING BTREE,
  ADD KEY `fk_goals_to_players_id1` (`player_passed_id`) USING BTREE,
  ADD KEY `fk_goals_to_players_id2` (`player_id`) USING BTREE;

--
-- Индексы таблицы `matches`
--
ALTER TABLE `matches`
  ADD PRIMARY KEY (`id`),
  ADD KEY `fk_matches_to_commands_id1` (`first_command_id`) USING BTREE,
  ADD KEY `fk_matches_to_commands_id2` (`second_command_id`) USING BTREE;

--
-- Индексы таблицы `news`
--
ALTER TABLE `news`
  ADD PRIMARY KEY (`id`);

--
-- Индексы таблицы `penalized_persons`
--
ALTER TABLE `penalized_persons`
  ADD PRIMARY KEY (`id`),
  ADD KEY `fk_penalized_persons_to_players_id` (`player_id`) USING BTREE,
  ADD KEY `fk_penalized_persons_to_matches_id` (`match_id`) USING BTREE;

--
-- Индексы таблицы `players`
--
ALTER TABLE `players`
  ADD PRIMARY KEY (`id`),
  ADD KEY `fk_to_positions_id` (`position_id`),
  ADD KEY `fk_players_to_commands_id` (`command_id`);

--
-- Индексы таблицы `positions`
--
ALTER TABLE `positions`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `name` (`name`);

--
-- Индексы таблицы `stadiums`
--
ALTER TABLE `stadiums`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `name` (`name`);

--
-- Индексы таблицы `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `username` (`username`);

--
-- AUTO_INCREMENT для сохранённых таблиц
--

--
-- AUTO_INCREMENT для таблицы `commands`
--
ALTER TABLE `commands`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT для таблицы `goals`
--
ALTER TABLE `goals`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT для таблицы `matches`
--
ALTER TABLE `matches`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT для таблицы `news`
--
ALTER TABLE `news`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT для таблицы `penalized_persons`
--
ALTER TABLE `penalized_persons`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT для таблицы `players`
--
ALTER TABLE `players`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=97;

--
-- AUTO_INCREMENT для таблицы `positions`
--
ALTER TABLE `positions`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=25;

--
-- AUTO_INCREMENT для таблицы `stadiums`
--
ALTER TABLE `stadiums`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT для таблицы `users`
--
ALTER TABLE `users`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- Ограничения внешнего ключа сохраненных таблиц
--

--
-- Ограничения внешнего ключа таблицы `commands`
--
ALTER TABLE `commands`
  ADD CONSTRAINT `fk_to_stadiums_id` FOREIGN KEY (`home_stadium_id`) REFERENCES `stadiums` (`id`);

--
-- Ограничения внешнего ключа таблицы `goals`
--
ALTER TABLE `goals`
  ADD CONSTRAINT `fk_goals_to_matches_id` FOREIGN KEY (`match_id`) REFERENCES `matches` (`id`),
  ADD CONSTRAINT `fk_goals_to_players_id1` FOREIGN KEY (`player_id`) REFERENCES `players` (`id`),
  ADD CONSTRAINT `fk_goals_to_players_id2` FOREIGN KEY (`player_passed_id`) REFERENCES `players` (`id`);

--
-- Ограничения внешнего ключа таблицы `matches`
--
ALTER TABLE `matches`
  ADD CONSTRAINT `fk_matches_to_commands_id1` FOREIGN KEY (`first_command_id`) REFERENCES `commands` (`id`),
  ADD CONSTRAINT `fk_matches_to_commands_id2` FOREIGN KEY (`second_command_id`) REFERENCES `commands` (`id`);

--
-- Ограничения внешнего ключа таблицы `penalized_persons`
--
ALTER TABLE `penalized_persons`
  ADD CONSTRAINT `fk_penalized_persons_to_matches_id` FOREIGN KEY (`match_id`) REFERENCES `matches` (`id`),
  ADD CONSTRAINT `fk_penalized_persons_to_players_id` FOREIGN KEY (`player_id`) REFERENCES `players` (`id`);

--
-- Ограничения внешнего ключа таблицы `players`
--
ALTER TABLE `players`
  ADD CONSTRAINT `fk_players_to_commands_id` FOREIGN KEY (`command_id`) REFERENCES `commands` (`id`),
  ADD CONSTRAINT `fk_players_to_positions_id` FOREIGN KEY (`position_id`) REFERENCES `positions` (`id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
