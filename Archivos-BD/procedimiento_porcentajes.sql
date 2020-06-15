DROP procedure IF EXISTS `porcentajes`;

DELIMITER $$
USE `boletas`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `porcentajes`(IN fechaP VARCHAR(10))
BEGIN
DECLARE c_a double;
DECLARE c_i double;
DECLARE t_a double;
DECLARE p_a double;
DECLARE p_i double;

SELECT COUNT(asistencia) FROM asistencias WHERE asistencia = 'SI' AND fecha LIKE CONCAT(fechaP,'%') into c_a;
SELECT COUNT(asistencia) FROM asistencias WHERE asistencia = 'NO' AND fecha LIKE CONCAT(fechaP,'%') into c_i;
SELECT COUNT(asistencia) FROM asistencias WHERE  fecha LIKE CONCAT(fechaP,'%') into t_a;

SET p_a = ((c_a*100)/t_a);
SET p_i = ((c_i*100)/t_a);

SELECT c_a, c_i, t_a, p_a, p_i;
END$$

DELIMITER ;
