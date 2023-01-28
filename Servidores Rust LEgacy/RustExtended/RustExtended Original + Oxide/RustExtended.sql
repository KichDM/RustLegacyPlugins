CREATE TABLE IF NOT EXISTS `db_blocked_ip` (
  `timestamp` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `ip_address` char(15) NOT NULL,
  UNIQUE KEY `ip` (`ip_address`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

CREATE TABLE IF NOT EXISTS `db_clans` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `created` datetime NOT NULL,
  `name` char(32) NOT NULL,
  `abbrev` char(8) NOT NULL,
  `leader_id` bigint(20) unsigned NOT NULL,
  `flags` set('can_motd','can_abbr','can_ffire','can_tax','can_warp','can_declare','friendlyfire','nodecayhouse') NOT NULL DEFAULT '',
  `balance` bigint(20) unsigned DEFAULT NULL,
  `tax` int(10) unsigned DEFAULT NULL,
  `level` int(10) unsigned NOT NULL,
  `experience` bigint(20) unsigned NOT NULL,
  `location` char(32) DEFAULT NULL,
  `motd` text,
  `penalty` datetime DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `leader_id` (`leader_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

CREATE TABLE IF NOT EXISTS `db_clans_hostile` (
  `clan_id` int(11) unsigned DEFAULT NULL,
  `hostile_id` int(11) unsigned DEFAULT NULL,
  `ending` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

CREATE TABLE IF NOT EXISTS `db_clans_members` (
  `user_id` bigint(20) unsigned NOT NULL,
  `clan_id` int(10) unsigned NOT NULL,
  `privileges` set('invite','dismiss','management','expdetails') NOT NULL DEFAULT '',
  PRIMARY KEY (`user_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

CREATE TABLE IF NOT EXISTS `db_punish_logs` (
  `steam_id` bigint(20) unsigned NOT NULL,
  `timestamp` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `reason` text,
  `details` text
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

CREATE TABLE IF NOT EXISTS `db_server` (
  `name` char(64) NOT NULL,
  `value` text,
  PRIMARY KEY (`name`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

CREATE TABLE IF NOT EXISTS `db_users` (
  `steam_id` bigint(20) unsigned NOT NULL,
  `username` char(64) NOT NULL,
  `password` char(64) DEFAULT NULL,
  `comments` char(255) DEFAULT NULL,
  `hwid` char(32) DEFAULT NULL,
  `rank` tinyint(3) unsigned NOT NULL DEFAULT '0',
  `flags` set('normal','premium','whitelisted','banned','admin','godmode','invis','nopvp','online','safeboxes','onevent','freezed','details') NOT NULL DEFAULT '',
  `language` char(3) DEFAULT NULL,
  `x` float DEFAULT NULL,
  `y` float DEFAULT NULL,
  `z` float DEFAULT NULL,
  `violations` int(10) DEFAULT '0',
  `violation_date` datetime DEFAULT NULL,
  `last_connect_ip` char(16) DEFAULT NULL,
  `last_connect_date` datetime DEFAULT NULL,
  `first_connect_ip` char(16) DEFAULT NULL,
  `first_connect_date` datetime DEFAULT NULL,
  `premium_date` datetime DEFAULT NULL,
  PRIMARY KEY (`steam_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

CREATE TABLE IF NOT EXISTS `db_users_banned` (
  `steam_id` bigint(20) unsigned NOT NULL,
  `ip_address` char(15) DEFAULT NULL,
  `hwid` char(32) DEFAULT NULL,
  `date` datetime NOT NULL,
  `period` datetime NOT NULL,
  `reason` char(255) NOT NULL,
  `details` char(255) DEFAULT NULL,
  PRIMARY KEY (`steam_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

CREATE TABLE IF NOT EXISTS `db_users_countdown` (
  `user_id` bigint(20) unsigned NOT NULL,
  `command` char(64) DEFAULT NULL,
  `expires` datetime DEFAULT NULL,
  KEY `user_id` (`user_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

CREATE TABLE IF NOT EXISTS `db_users_economy` (
  `user_id` bigint(20) unsigned NOT NULL DEFAULT '0',
  `balance` bigint(20) unsigned NOT NULL,
  `killed_players` int(10) NOT NULL,
  `killed_mutants` int(10) NOT NULL,
  `killed_animals` int(10) NOT NULL,
  `deaths` int(10) NOT NULL,
  PRIMARY KEY (`user_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

CREATE TABLE IF NOT EXISTS `db_users_personal` (
  `user_id` bigint(20) unsigned NOT NULL,
  `item_name` char(64) DEFAULT NULL,
  `quantity` int(10) DEFAULT NULL,
  KEY `user_id` (`user_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

CREATE TABLE IF NOT EXISTS `db_users_shared` (
  `owner_id` bigint(20) unsigned NOT NULL,
  `user_id` bigint(20) unsigned NOT NULL,
  KEY `owner_id` (`owner_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
