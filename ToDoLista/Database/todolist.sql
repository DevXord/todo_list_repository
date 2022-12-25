CREATE DATABASE `todolist`;

CREATE TABLE `users` (
  `ID_User` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(45) NOT NULL,
  `JoinDate` datetime DEFAULT NULL,
  `LastLoginDate` datetime DEFAULT NULL,
  `Selected` tinyint(3) DEFAULT 0,
  PRIMARY KEY (`ID_User`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

CREATE TABLE `tasks` (
  `ID_Task` int(11) NOT NULL AUTO_INCREMENT,
  `User_ID` int(11) NOT NULL,
  `Task` varchar(45) DEFAULT NULL,
  `EnteredDate` datetime DEFAULT NULL,
  `EndDate` datetime DEFAULT NULL,
  `IsToDo` tinyint(3) NOT NULL DEFAULT 0,
  PRIMARY KEY (`ID_Task`),
  KEY `userRelation_idx` (`User_ID`),
  CONSTRAINT `userRelation` FOREIGN KEY (`User_ID`) REFERENCES `users` (`ID_User`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
