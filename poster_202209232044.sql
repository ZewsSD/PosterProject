--
-- Скрипт сгенерирован Devart dbForge Studio 2020 for MySQL, Версия 9.0.470.0
-- Домашняя страница продукта: http://www.devart.com/ru/dbforge/mysql/studio
-- Дата скрипта: 23.09.2022 20:44:40
-- Версия сервера: 8.0.30
-- Версия клиента: 4.1
--

-- 
-- Отключение внешних ключей
-- 
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;

-- 
-- Установить режим SQL (SQL mode)
-- 
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;

--
-- Установка базы данных по умолчанию
--
USE poster;

--
-- Удалить таблицу `actor_movie`
--
DROP TABLE IF EXISTS actor_movie;

--
-- Удалить таблицу `actor`
--
DROP TABLE IF EXISTS actor;

--
-- Удалить таблицу `ticket`
--
DROP TABLE IF EXISTS ticket;

--
-- Удалить таблицу `user`
--
DROP TABLE IF EXISTS user;

--
-- Удалить таблицу `session`
--
DROP TABLE IF EXISTS session;

--
-- Удалить таблицу `movie`
--
DROP TABLE IF EXISTS movie;

--
-- Удалить таблицу `city`
--
DROP TABLE IF EXISTS city;

--
-- Удалить таблицу `hall`
--
DROP TABLE IF EXISTS hall;

--
-- Удалить таблицу `cinema`
--
DROP TABLE IF EXISTS cinema;

--
-- Установка базы данных по умолчанию
--
USE poster;

--
-- Создать таблицу `cinema`
--
CREATE TABLE cinema (
  id int NOT NULL AUTO_INCREMENT,
  work_time time DEFAULT NULL,
  title varchar(50) DEFAULT NULL,
  address varchar(50) DEFAULT NULL,
  PRIMARY KEY (id)
)
ENGINE = INNODB,
CHARACTER SET utf8mb3,
COLLATE utf8mb3_general_ci;

--
-- Создать таблицу `hall`
--
CREATE TABLE hall (
  id int NOT NULL AUTO_INCREMENT,
  places_in_line int DEFAULT NULL,
  cinema_id int DEFAULT NULL,
  count_line int DEFAULT NULL,
  PRIMARY KEY (id)
)
ENGINE = INNODB,
CHARACTER SET utf8mb3,
COLLATE utf8mb3_general_ci;

--
-- Создать внешний ключ
--
ALTER TABLE hall
ADD CONSTRAINT FK_hall_cinema FOREIGN KEY (cinema_id)
REFERENCES cinema (id);

--
-- Создать таблицу `city`
--
CREATE TABLE city (
  id int NOT NULL,
  name varchar(50) DEFAULT NULL,
  cinema_id int DEFAULT NULL,
  PRIMARY KEY (id)
)
ENGINE = INNODB,
CHARACTER SET utf8mb3,
COLLATE utf8mb3_general_ci;

--
-- Создать внешний ключ
--
ALTER TABLE city
ADD CONSTRAINT FK_city_cinema FOREIGN KEY (cinema_id)
REFERENCES cinema (id);

--
-- Создать таблицу `movie`
--
CREATE TABLE movie (
  id int NOT NULL AUTO_INCREMENT,
  title varchar(50) DEFAULT NULL,
  release_date date DEFAULT NULL,
  producer varchar(50) DEFAULT NULL,
  description varchar(100) DEFAULT NULL,
  rating double DEFAULT NULL,
  picture blob DEFAULT NULL,
  PRIMARY KEY (id)
)
ENGINE = INNODB,
CHARACTER SET utf8mb3,
COLLATE utf8mb3_general_ci;

--
-- Создать таблицу `session`
--
CREATE TABLE session (
  id int NOT NULL AUTO_INCREMENT,
  movie_id int DEFAULT NULL,
  date date DEFAULT NULL,
  hall_id int DEFAULT NULL,
  PRIMARY KEY (id)
)
ENGINE = INNODB,
CHARACTER SET utf8mb3,
COLLATE utf8mb3_general_ci;

--
-- Создать внешний ключ
--
ALTER TABLE session
ADD CONSTRAINT FK_session_hall FOREIGN KEY (hall_id)
REFERENCES hall (id);

--
-- Создать внешний ключ
--
ALTER TABLE session
ADD CONSTRAINT FK_session_movie FOREIGN KEY (movie_id)
REFERENCES movie (id);

--
-- Создать таблицу `user`
--
CREATE TABLE user (
  id int NOT NULL AUTO_INCREMENT,
  name varchar(50) DEFAULT NULL,
  surname varchar(50) DEFAULT NULL,
  phone_number int DEFAULT NULL,
  PRIMARY KEY (id)
)
ENGINE = INNODB,
CHARACTER SET utf8mb3,
COLLATE utf8mb3_general_ci;

--
-- Создать таблицу `ticket`
--
CREATE TABLE ticket (
  id int NOT NULL AUTO_INCREMENT,
  session_id int DEFAULT NULL,
  price int DEFAULT NULL,
  line int DEFAULT NULL,
  place int DEFAULT NULL,
  user_id int DEFAULT NULL,
  PRIMARY KEY (id)
)
ENGINE = INNODB,
CHARACTER SET utf8mb3,
COLLATE utf8mb3_general_ci;

--
-- Создать внешний ключ
--
ALTER TABLE ticket
ADD CONSTRAINT FK_ticket_session FOREIGN KEY (session_id)
REFERENCES session (id);

--
-- Создать внешний ключ
--
ALTER TABLE ticket
ADD CONSTRAINT FK_ticket_user FOREIGN KEY (user_id)
REFERENCES user (id);

--
-- Создать таблицу `actor`
--
CREATE TABLE actor (
  id int NOT NULL AUTO_INCREMENT,
  name varchar(50) DEFAULT NULL,
  surname varchar(50) DEFAULT NULL,
  patronymic varchar(50) DEFAULT NULL,
  PRIMARY KEY (id)
)
ENGINE = INNODB,
CHARACTER SET utf8mb3,
COLLATE utf8mb3_general_ci;

--
-- Создать таблицу `actor_movie`
--
CREATE TABLE actor_movie (
  id int NOT NULL AUTO_INCREMENT,
  actor_id int DEFAULT NULL,
  movie_id int DEFAULT NULL,
  PRIMARY KEY (id)
)
ENGINE = INNODB,
CHARACTER SET utf8mb3,
COLLATE utf8mb3_general_ci;

--
-- Создать внешний ключ
--
ALTER TABLE actor_movie
ADD CONSTRAINT FK_actor_movie_actor_id FOREIGN KEY (actor_id)
REFERENCES actor (id);

--
-- Создать внешний ключ
--
ALTER TABLE actor_movie
ADD CONSTRAINT FK_actor_movie_movie_id FOREIGN KEY (movie_id)
REFERENCES movie (id);

-- 
-- Вывод данных для таблицы cinema
--
-- Таблица poster.cinema не содержит данных

-- 
-- Вывод данных для таблицы movie
--
-- Таблица poster.movie не содержит данных

-- 
-- Вывод данных для таблицы hall
--
-- Таблица poster.hall не содержит данных

-- 
-- Вывод данных для таблицы user
--
-- Таблица poster.user не содержит данных

-- 
-- Вывод данных для таблицы session
--
-- Таблица poster.session не содержит данных

-- 
-- Вывод данных для таблицы actor
--
-- Таблица poster.actor не содержит данных

-- 
-- Вывод данных для таблицы ticket
--
-- Таблица poster.ticket не содержит данных

-- 
-- Вывод данных для таблицы city
--
-- Таблица poster.city не содержит данных

-- 
-- Вывод данных для таблицы actor_movie
--
-- Таблица poster.actor_movie не содержит данных

-- 
-- Восстановить предыдущий режим SQL (SQL mode)
--
/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;

-- 
-- Включение внешних ключей
-- 
/*!40014 SET FOREIGN_KEY_CHECKS = @OLD_FOREIGN_KEY_CHECKS */;