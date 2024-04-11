-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Servidor: localhost
-- Tiempo de generación: 11-04-2024 a las 04:54:58
-- Versión del servidor: 10.4.28-MariaDB
-- Versión de PHP: 8.0.28

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `employee_database`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `position`
--

CREATE TABLE `position` (
  `positionId` int(11) NOT NULL,
  `postitionName` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Volcado de datos para la tabla `position`
--

INSERT INTO `position` (`positionId`, `postitionName`) VALUES
(1, 'Cajero'),
(2, 'Administrador'),
(3, 'Organizador de estantes'),
(4, 'Supernumerario'),
(5, 'Servicios generales'),
(6, 'Domiciliario'),
(7, 'Analista');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `user_information`
--

CREATE TABLE `user_information` (
  `userId` int(11) NOT NULL,
  `userName` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `userLastName` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `positionId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Volcado de datos para la tabla `user_information`
--

INSERT INTO `user_information` (`userId`, `userName`, `userLastName`, `positionId`) VALUES
(1, 'Juan', 'Pérez', 3),
(2, 'María', 'González', 3),
(3, 'Pedro', 'Martínez', 2),
(4, 'Laura', 'Hernández', 5),
(5, 'Carlos', 'López', 1),
(6, 'Ana', 'Díaz', 1),
(7, 'Javier', 'Rodríguez', 3),
(8, 'Sofía', 'Sánchez', 3),
(9, 'Luis', 'Ramírez', 5),
(10, 'Elena', 'Torres', 5),
(11, 'Andrés', 'Flores', 1),
(12, 'Carmen', 'Vázquez', 3),
(13, 'Diego', 'Gómez', 2),
(14, 'Marta', 'Jiménez', 1),
(15, 'José', 'Ruiz', 2),
(16, 'Paula', 'Alvarez', 1),
(17, 'Alejandro', 'Moreno', 4),
(18, 'Lucía', 'Fernández', 1),
(19, 'Roberto', 'Santos', 3),
(20, 'Isabel', 'Castro', 1),
(21, 'Daniel', 'Ortega', 3),
(22, 'Patricia', 'Núñez', 4),
(23, 'Manuel', 'Iglesias', 3),
(24, 'Eva', 'Molina', 5),
(25, 'Rafael', 'Suárez', 1),
(26, 'Teresa', 'Dominguez', 5),
(27, 'Miguel', 'Torres', 3),
(28, 'Natalia', 'Navarro', 2),
(29, 'Francisco', 'Ramos', 1),
(30, 'Sara', 'López', 3),
(31, 'Pablo', 'García', 5),
(32, 'Cristina', 'Martínez', 3),
(33, 'Jorge', 'Herrera', 5),
(34, 'Adriana', 'Muñoz', 3),
(35, 'Víctor', 'Castillo', 4),
(36, 'Beatriz', 'Gutiérrez', 3),
(37, 'Roberto', 'Reyes', 4),
(38, 'Carla', 'Serrano', 2),
(39, 'Antonio', 'Delgado', 4),
(40, 'Elena', 'Pérez', 5),
(41, 'Claudia', 'Sanchez', 2),
(42, 'Luna Merlina', 'Sanchez', 6);

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `position`
--
ALTER TABLE `position`
  ADD PRIMARY KEY (`positionId`);

--
-- Indices de la tabla `user_information`
--
ALTER TABLE `user_information`
  ADD PRIMARY KEY (`userId`),
  ADD KEY `positionId` (`positionId`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `position`
--
ALTER TABLE `position`
  MODIFY `positionId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT de la tabla `user_information`
--
ALTER TABLE `user_information`
  MODIFY `userId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=43;

--
-- Restricciones para tablas volcadas
--

--
-- Filtros para la tabla `user_information`
--
ALTER TABLE `user_information`
  ADD CONSTRAINT `user_information_ibfk_1` FOREIGN KEY (`positionId`) REFERENCES `position` (`positionId`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
