--
-- ������ ������������ Devart dbForge Studio 2020 for MySQL, ������ 9.0.470.0
-- �������� �������� ��������: http://www.devart.com/ru/dbforge/mysql/studio
-- ���� �������: 23.09.2022 20:44:40
-- ������ �������: 8.0.30
-- ������ �������: 4.1
--

-- 
-- ���������� ������� ������
-- 
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;

-- 
-- ���������� ����� SQL (SQL mode)
-- 
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;

--
-- ��������� ���� ������ �� ���������
--
USE poster;

--
-- ������� ������� `actor_movie`
--
DROP TABLE IF EXISTS actor_movie;

--
-- ������� ������� `actor`
--
DROP TABLE IF EXISTS actor;

--
-- ������� ������� `ticket`
--
DROP TABLE IF EXISTS ticket;

--
-- ������� ������� `user`
--
DROP TABLE IF EXISTS user;

--
-- ������� ������� `session`
--
DROP TABLE IF EXISTS session;

--
-- ������� ������� `movie`
--
DROP TABLE IF EXISTS movie;

--
-- ������� ������� `city`
--
DROP TABLE IF EXISTS city;

--
-- ������� ������� `hall`
--
DROP TABLE IF EXISTS hall;

--
-- ������� ������� `cinema`
--
DROP TABLE IF EXISTS cinema;

--
-- ��������� ���� ������ �� ���������
--
USE poster;

--
-- ������� ������� `cinema`
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
-- ������� ������� `hall`
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
-- ������� ������� ����
--
ALTER TABLE hall
ADD CONSTRAINT FK_hall_cinema FOREIGN KEY (cinema_id)
REFERENCES cinema (id);

--
-- ������� ������� `city`
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
-- ������� ������� ����
--
ALTER TABLE city
ADD CONSTRAINT FK_city_cinema FOREIGN KEY (cinema_id)
REFERENCES cinema (id);

--
-- ������� ������� `movie`
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
-- ������� ������� `session`
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
-- ������� ������� ����
--
ALTER TABLE session
ADD CONSTRAINT FK_session_hall FOREIGN KEY (hall_id)
REFERENCES hall (id);

--
-- ������� ������� ����
--
ALTER TABLE session
ADD CONSTRAINT FK_session_movie FOREIGN KEY (movie_id)
REFERENCES movie (id);

--
-- ������� ������� `user`
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
-- ������� ������� `ticket`
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
-- ������� ������� ����
--
ALTER TABLE ticket
ADD CONSTRAINT FK_ticket_session FOREIGN KEY (session_id)
REFERENCES session (id);

--
-- ������� ������� ����
--
ALTER TABLE ticket
ADD CONSTRAINT FK_ticket_user FOREIGN KEY (user_id)
REFERENCES user (id);

--
-- ������� ������� `actor`
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
-- ������� ������� `actor_movie`
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
-- ������� ������� ����
--
ALTER TABLE actor_movie
ADD CONSTRAINT FK_actor_movie_actor_id FOREIGN KEY (actor_id)
REFERENCES actor (id);

--
-- ������� ������� ����
--
ALTER TABLE actor_movie
ADD CONSTRAINT FK_actor_movie_movie_id FOREIGN KEY (movie_id)
REFERENCES movie (id);

-- 
-- ����� ������ ��� ������� cinema
--
-- ������� poster.cinema �� �������� ������

-- 
-- ����� ������ ��� ������� movie
--
-- ������� poster.movie �� �������� ������

-- 
-- ����� ������ ��� ������� hall
--
-- ������� poster.hall �� �������� ������

-- 
-- ����� ������ ��� ������� user
--
-- ������� poster.user �� �������� ������

-- 
-- ����� ������ ��� ������� session
--
-- ������� poster.session �� �������� ������

-- 
-- ����� ������ ��� ������� actor
--
-- ������� poster.actor �� �������� ������

-- 
-- ����� ������ ��� ������� ticket
--
-- ������� poster.ticket �� �������� ������

-- 
-- ����� ������ ��� ������� city
--
-- ������� poster.city �� �������� ������

-- 
-- ����� ������ ��� ������� actor_movie
--
-- ������� poster.actor_movie �� �������� ������

-- 
-- ������������ ���������� ����� SQL (SQL mode)
--
/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;

-- 
-- ��������� ������� ������
-- 
/*!40014 SET FOREIGN_KEY_CHECKS = @OLD_FOREIGN_KEY_CHECKS */;