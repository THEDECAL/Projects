-- phpMyAdmin SQL Dump
-- version 4.8.4
-- https://www.phpmyadmin.net/
--
-- Хост: 127.0.0.1
-- Время создания: Июл 12 2019 г., 15:53
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
-- База данных: `photo_gallery_db`
--

-- --------------------------------------------------------

--
-- Структура таблицы `logins`
--

CREATE TABLE `logins` (
  `id` int(11) NOT NULL,
  `login` varchar(32) NOT NULL,
  `password` varchar(32) NOT NULL,
  `email` varchar(64) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `logins`
--

INSERT INTO `logins` (`id`, `login`, `password`, `email`) VALUES
(1, 'admin', '123', 'admin@photo-gallery.com'),
(2, 'the-decal', '123', 'thedecal1@gmail.com');

-- --------------------------------------------------------

--
-- Структура таблицы `photos`
--

CREATE TABLE `photos` (
  `id` int(11) NOT NULL,
  `login_id` int(11) NOT NULL,
  `name` varchar(32) NOT NULL,
  `description` varchar(64) DEFAULT NULL,
  `file_name` varchar(13) NOT NULL,
  `file_ext` varchar(4) NOT NULL,
  `date` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `is_remove` tinyint(1) NOT NULL DEFAULT '0'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `photos`
--

INSERT INTO `photos` (`id`, `login_id`, `name`, `description`, `file_name`, `file_ext`, `date`, `is_remove`) VALUES
(7, 1, 'ÐšÐ¾Ð°Ð»Ð°', '', '5d26f4fb2fdc9', 'jpg', '2019-07-11 05:36:11', 1),
(8, 1, 'ÐœÐµÐ´ÑƒÐ·Ð°', '', '5d26f52928e8f', 'jpg', '2019-07-11 05:36:57', 0),
(9, 1, 'Ð¥Ñ€Ð¸Ð·Ð°Ð½Ñ‚ÐµÐ¼Ð°', 'ÐšÑ€Ð°ÑÐ¸Ð²Ñ‹Ð¹ ÐºÑ€Ð°ÑÐ½Ñ‹Ð¹ Ñ†Ð²ÐµÑ‚Ð¾Ðº', '5d26f56603f2b', 'jpg', '2019-07-11 05:37:58', 0),
(10, 2, 'ÐŸÐ¸Ð½Ð³Ð²Ð¸Ð½Ñ‹', 'Ð­Ñ‚Ð¸ Ð¼Ð¸Ð»Ñ‹Ðµ Ð¿Ð¸Ð½Ð³Ð²Ð¸Ð½Ñ‹...', '5d26f599dbdd1', 'jpg', '2019-07-11 05:38:49', 0),
(11, 2, 'ÐŸÑƒÑÑ‚Ñ‹Ð½Ñ', '', '5d26fbb8e5308', 'jpg', '2019-07-11 06:04:56', 0),
(13, 2, 'ÐœÐ°ÑÐº', 'ÐœÐÐ¯Ðš!', '5d27379616182', 'jpg', '2019-07-11 13:15:37', 0);

-- --------------------------------------------------------

--
-- Дублирующая структура для представления `photos_view`
-- (См. Ниже фактическое представление)
--
CREATE TABLE `photos_view` (
`id` int(11)
,`login` varchar(32)
,`name` varchar(32)
,`description` varchar(64)
,`file_name` varchar(13)
,`file_ext` varchar(4)
,`date` timestamp
);

-- --------------------------------------------------------

--
-- Структура для представления `photos_view`
--
DROP TABLE IF EXISTS `photos_view`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `photos_view`  AS  select `photos`.`id` AS `id`,`logins`.`login` AS `login`,`photos`.`name` AS `name`,`photos`.`description` AS `description`,`photos`.`file_name` AS `file_name`,`photos`.`file_ext` AS `file_ext`,`photos`.`date` AS `date` from (`logins` join `photos`) where ((`photos`.`is_remove` = 0) and (`logins`.`id` = `photos`.`login_id`)) ;

--
-- Индексы сохранённых таблиц
--

--
-- Индексы таблицы `logins`
--
ALTER TABLE `logins`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `login` (`login`),
  ADD UNIQUE KEY `email` (`email`);

--
-- Индексы таблицы `photos`
--
ALTER TABLE `photos`
  ADD PRIMARY KEY (`id`),
  ADD KEY `FK_logins_id` (`login_id`);

--
-- AUTO_INCREMENT для сохранённых таблиц
--

--
-- AUTO_INCREMENT для таблицы `logins`
--
ALTER TABLE `logins`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT для таблицы `photos`
--
ALTER TABLE `photos`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=14;

--
-- Ограничения внешнего ключа сохраненных таблиц
--

--
-- Ограничения внешнего ключа таблицы `photos`
--
ALTER TABLE `photos`
  ADD CONSTRAINT `FK_logins_id` FOREIGN KEY (`login_id`) REFERENCES `logins` (`id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
