-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema boletas
-- -----------------------------------------------------
DROP SCHEMA IF EXISTS `boletas` ;

-- -----------------------------------------------------
-- Schema boletas
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `boletas` DEFAULT CHARACTER SET utf8 ;
USE `boletas` ;

-- -----------------------------------------------------
-- Table `boletas`.`asignacion`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `boletas`.`asignacion` (
  `id_asignacion` INT NOT NULL AUTO_INCREMENT,
  `grado` VARCHAR(1) NULL,
  `grupo` VARCHAR(1) NULL,
  PRIMARY KEY (`id_asignacion`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `boletas`.`privilegios`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `boletas`.`privilegios` (
  `id_privilegios` INT NOT NULL,
  `nombre_privilegios` VARCHAR(45) NULL,
  PRIMARY KEY (`id_privilegios`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `boletas`.`usuarios`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `boletas`.`usuarios` (
  `id_usuario` VARCHAR(255) NOT NULL,
  `nombre` VARCHAR(50) NOT NULL,
  `pass` BLOB NOT NULL,
  `preg_recuperacion` VARCHAR(40) NOT NULL,
  `respuesta` VARCHAR(40) NOT NULL,
  `id_asignacion` INT NULL,
  `tipo_usuario` INT NOT NULL,
  PRIMARY KEY (`id_usuario`),
  INDEX `fk_usuarios_asignaciones1_idx` (`id_asignacion` ASC) VISIBLE,
  INDEX `fk_usuarios_privilegios1_idx` (`tipo_usuario` ASC) VISIBLE,
  CONSTRAINT `fk_usuarios_asignaciones1`
    FOREIGN KEY (`id_asignacion`)
    REFERENCES `boletas`.`asignacion` (`id_asignacion`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_usuarios_privilegios1`
    FOREIGN KEY (`tipo_usuario`)
    REFERENCES `boletas`.`privilegios` (`id_privilegios`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `boletas`.`alumnos`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `boletas`.`alumnos` (
  `no_control` VARCHAR(8) NOT NULL,
  `no_tarjeta` VARCHAR(10) NOT NULL,
  `nombre` VARCHAR(50) NOT NULL,
  `apellidos` VARCHAR(50) NOT NULL,
  `id_asignacion` INT NOT NULL,
  `edad` VARCHAR(2) NOT NULL,
  `tipo_sangre` VARCHAR(3) NOT NULL,
  `alergias` VARCHAR(100) NOT NULL,
  `domicilio` VARCHAR(50) NOT NULL,
  `tutor` VARCHAR(50) NOT NULL,
  `tel_tutor` VARCHAR(10) NOT NULL,
  `persona1` VARCHAR(50) NOT NULL,
  `tel_persona1` VARCHAR(10) NOT NULL,
  `persona2` VARCHAR(50) NOT NULL,
  `tel_persona2` VARCHAR(10) NOT NULL,
  `foto` MEDIUMBLOB NULL,
  PRIMARY KEY (`no_control`),
  INDEX `fk_alumnos_asignaciones_idx` (`id_asignacion` ASC) VISIBLE,
  CONSTRAINT `fk_alumnos_asignaciones`
    FOREIGN KEY (`id_asignacion`)
    REFERENCES `boletas`.`asignacion` (`id_asignacion`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `boletas`.`materias`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `boletas`.`materias` (
  `id_materia` INT NOT NULL AUTO_INCREMENT,
  `grado` VARCHAR(1) NOT NULL,
  `nombre` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`id_materia`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `boletas`.`asistencias`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `boletas`.`asistencias` (
  `no_control` VARCHAR(8) NOT NULL,
  `asistencia` VARCHAR(2) NULL,
  `asistencia_justificada` VARCHAR(2) NULL,
  `fecha` DATETIME NULL,
  INDEX `fk_asistencias_alumnos1_idx` (`no_control` ASC) VISIBLE,
  CONSTRAINT `fk_asistencias_alumnos1`
    FOREIGN KEY (`no_control`)
    REFERENCES `boletas`.`alumnos` (`no_control`)
    ON DELETE CASCADE
    ON UPDATE CASCADE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `boletas`.`calificaciones`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `boletas`.`calificaciones` (
  `id_materia` INT NOT NULL,
  `no_control` VARCHAR(8) NOT NULL,
  `bloque1` INT NULL,
  `bloque2` INT NULL,
  `bloque3` INT NULL,
  `bloque4` INT NULL,
  `bloque5` INT NULL,
  `observaciones` VARCHAR(300) NULL,
  INDEX `fk_calificaciones_materias1_idx` (`id_materia` ASC) VISIBLE,
  INDEX `fk_calificaciones_alumnos1_idx` (`no_control` ASC) VISIBLE,
  PRIMARY KEY (`no_control`, `id_materia`),
  CONSTRAINT `fk_calificaciones_materias1`
    FOREIGN KEY (`id_materia`)
    REFERENCES `boletas`.`materias` (`id_materia`)
    ON DELETE CASCADE
    ON UPDATE CASCADE,
  CONSTRAINT `fk_calificaciones_alumnos1`
    FOREIGN KEY (`no_control`)
    REFERENCES `boletas`.`alumnos` (`no_control`)
    ON DELETE CASCADE
    ON UPDATE CASCADE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `boletas`.`registro_asistencias`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `boletas`.`registro_asistencias` (
  `id_usuario` VARCHAR(255) NOT NULL,
  `fecha` DATE NOT NULL,
  INDEX `fk_registro_asistencias_usuarios1_idx` (`id_usuario` ASC) VISIBLE,
  PRIMARY KEY (`id_usuario`, `fecha`),
  CONSTRAINT `fk_registro_asistencias_usuarios1`
    FOREIGN KEY (`id_usuario`)
    REFERENCES `boletas`.`usuarios` (`id_usuario`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
