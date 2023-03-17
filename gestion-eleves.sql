-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Hôte : 127.0.0.1
-- Généré le : ven. 17 mars 2023 à 16:21
-- Version du serveur : 10.4.22-MariaDB
-- Version de PHP : 8.0.13

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de données : `gestion-eleves`
--

DELIMITER $$
--
-- Fonctions
--
CREATE DEFINER=`root`@`localhost` FUNCTION `func_save_eleve` (`p_code` VARCHAR(255), `p_nom` VARCHAR(255), `p_prenom` VARCHAR(255), `p_niveau` INT, `p_id_fil` INT) RETURNS INT(11) BEGIN
    DECLARE new_id INT;
    SELECT COALESCE(MAX(id), 0) + 1 INTO new_id FROM Eleve;
    INSERT INTO Eleve (id, code, nom, prenom, niveau, id_fil) VALUES (new_id, p_code, p_nom, p_prenom, p_niveau, p_id_fil);
    RETURN new_id;
END$$

CREATE DEFINER=`root`@`localhost` FUNCTION `func_save_filiere` (`p_code` VARCHAR(255), `p_designation` VARCHAR(255)) RETURNS INT(11) BEGIN
    DECLARE new_id INT;
    SELECT COALESCE(MAX(id), 0) + 1 INTO new_id FROM filiere;
    INSERT INTO filiere (id, code, designation) VALUES (new_id, p_code, p_designation);
    RETURN new_id;
END$$

CREATE DEFINER=`root`@`localhost` FUNCTION `func_save_matiere` (`p_code` VARCHAR(255), `p_designation` VARCHAR(255), `p_VH` INT, `p_id_module` INT) RETURNS INT(11) BEGIN
DECLARE
new_id INT;
SELECT COALESCE(MAX(id), 0) + 1 INTO new_id FROM matiere;
INSERT INTO matiere (id, code, designation, VH, id_module) VALUES (new_id, p_code, p_designation, p_VH, p_id_module);
RETURN new_id; 
END$$

CREATE DEFINER=`root`@`localhost` FUNCTION `func_save_moyennes` (`p_id_eleve` INT, `p_id_fil` INT, `p_niveau` INT, `p_moyenne` FLOAT) RETURNS INT(11) BEGIN 
  DECLARE new_id INT;
  SELECT COALESCE(MAX(id), 0) + 1 INTO new_id FROM moyennes;
  INSERT INTO Eleve (id, id_eleve, id_fil, niveau, moyenne) VALUES (new_id, p_id_eleve, p_id_fil, p_niveau, p_moyenne);
  RETURN new_id; 
  END$$

CREATE DEFINER=`root`@`localhost` FUNCTION `func_save_notes` (`p_code` VARCHAR(255), `p_id_eleve` INT, `p_id_mat` INT, `p_note` FLOAT) RETURNS INT(11) BEGIN
DECLARE
new_id INT;
SELECT COALESCE(MAX(id), 0) + 1 INTO new_id FROM notes;
INSERT INTO notes (id, code, id_eleve, id_mat, note) VALUES (new_id, p_code, p_id_eleve, p_id_mat, p_note);
RETURN new_id; 
END$$

DELIMITER ;

-- --------------------------------------------------------

--
-- Structure de la table `eleve`
--

CREATE TABLE `eleve` (
  `id` int(11) NOT NULL,
  `code` varchar(255) NOT NULL,
  `nom` varchar(255) NOT NULL,
  `prenom` varchar(255) NOT NULL,
  `niveau` int(11) NOT NULL,
  `id_fil` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Structure de la table `filiere`
--

CREATE TABLE `filiere` (
  `id` int(11) NOT NULL,
  `code` varchar(255) NOT NULL,
  `designation` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Structure de la table `matiere`
--

CREATE TABLE `matiere` (
  `id` int(11) NOT NULL,
  `code` varchar(255) NOT NULL,
  `designation` varchar(255) NOT NULL,
  `VH` int(11) NOT NULL,
  `id_module` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Structure de la table `module`
--

CREATE TABLE `module` (
  `id` int(11) NOT NULL,
  `code` varchar(255) NOT NULL,
  `designation` varchar(255) NOT NULL,
  `niveau` int(11) NOT NULL,
  `semestre` int(11) NOT NULL,
  `id_fil` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Structure de la table `moyennes`
--

CREATE TABLE `moyennes` (
  `id` int(11) NOT NULL,
  `id_eleve` int(11) NOT NULL,
  `id_fil` int(11) NOT NULL,
  `niveau` int(11) NOT NULL,
  `moyenne` float NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Structure de la table `notes`
--

CREATE TABLE `notes` (
  `id` int(11) NOT NULL,
  `id_eleve` int(11) NOT NULL,
  `id_mat` int(11) NOT NULL,
  `note` float NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Index pour les tables déchargées
--

--
-- Index pour la table `eleve`
--
ALTER TABLE `eleve`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `code` (`code`),
  ADD KEY `id_fil` (`id_fil`);

--
-- Index pour la table `filiere`
--
ALTER TABLE `filiere`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `code` (`code`);

--
-- Index pour la table `matiere`
--
ALTER TABLE `matiere`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `code` (`code`),
  ADD KEY `id_module` (`id_module`);

--
-- Index pour la table `module`
--
ALTER TABLE `module`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `code` (`code`),
  ADD KEY `id_fil` (`id_fil`);

--
-- Index pour la table `moyennes`
--
ALTER TABLE `moyennes`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `id_eleve` (`id_eleve`,`id_fil`,`niveau`),
  ADD KEY `id_fil` (`id_fil`);

--
-- Index pour la table `notes`
--
ALTER TABLE `notes`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `id_eleve` (`id_eleve`,`id_mat`),
  ADD KEY `id_mat` (`id_mat`);

--
-- AUTO_INCREMENT pour les tables déchargées
--

--
-- AUTO_INCREMENT pour la table `eleve`
--
ALTER TABLE `eleve`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT pour la table `filiere`
--
ALTER TABLE `filiere`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT pour la table `matiere`
--
ALTER TABLE `matiere`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT pour la table `module`
--
ALTER TABLE `module`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT pour la table `moyennes`
--
ALTER TABLE `moyennes`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT pour la table `notes`
--
ALTER TABLE `notes`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- Contraintes pour les tables déchargées
--

--
-- Contraintes pour la table `eleve`
--
ALTER TABLE `eleve`
  ADD CONSTRAINT `eleve_ibfk_1` FOREIGN KEY (`id_fil`) REFERENCES `filiere` (`id`);

--
-- Contraintes pour la table `matiere`
--
ALTER TABLE `matiere`
  ADD CONSTRAINT `matiere_ibfk_1` FOREIGN KEY (`id_module`) REFERENCES `module` (`id`);

--
-- Contraintes pour la table `module`
--
ALTER TABLE `module`
  ADD CONSTRAINT `module_ibfk_1` FOREIGN KEY (`id_fil`) REFERENCES `filiere` (`id`);

--
-- Contraintes pour la table `moyennes`
--
ALTER TABLE `moyennes`
  ADD CONSTRAINT `moyennes_ibfk_1` FOREIGN KEY (`id_eleve`) REFERENCES `eleve` (`id`),
  ADD CONSTRAINT `moyennes_ibfk_2` FOREIGN KEY (`id_fil`) REFERENCES `filiere` (`id`);

--
-- Contraintes pour la table `notes`
--
ALTER TABLE `notes`
  ADD CONSTRAINT `notes_ibfk_1` FOREIGN KEY (`id_eleve`) REFERENCES `eleve` (`id`),
  ADD CONSTRAINT `notes_ibfk_2` FOREIGN KEY (`id_mat`) REFERENCES `matiere` (`id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
