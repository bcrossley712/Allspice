CREATE TABLE IF NOT EXISTS accounts(
  id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name varchar(255) COMMENT 'User Name',
  email varchar(255) COMMENT 'User Email',
  picture varchar(255) COMMENT 'User Picture'
) default charset utf8 COMMENT '';
CREATE TABLE IF NOT EXISTS recipes(
  id INT AUTO_INCREMENT PRIMARY KEY,
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  title TEXT NOT NULL,
  subtitle TEXT NOT NULL,
  category TEXT NOT NULL,
  imgUrl TEXT NOT NULL,
  creatorId VARCHAR(255) NOT NULL,
  FOREIGN KEY (creatorId) REFERENCES accounts (id)
) default charset utf8;
CREATE TABLE IF NOT EXISTS steps(
  id INT AUTO_INCREMENT PRIMARY KEY,
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  sequence INT NOT NULL,
  body TEXT NOT NULL,
  recipeId INT NOT NULL,
  FOREIGN KEY (recipeId) REFERENCES recipes (id)
) default charset utf8;
CREATE TABLE IF NOT EXISTS ingredients(
  id INT AUTO_INCREMENT PRIMARY KEY,
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name TEXT NOT NULL,
  quantity TEXT NOT NULL,
  recipeId INT NOT NULL,
  FOREIGN KEY (recipeId) REFERENCES recipes (id)
) default charset utf8;
CREATE TABLE IF NOT EXISTS favorites(
  id INT AUTO_INCREMENT PRIMARY KEY,
  accountId VARCHAR(255) NOT NULL,
  FOREIGN KEY (accountId) REFERENCES accounts (id),
  recipeId INT NOT NULL,
  FOREIGN KEY (recipeId) REFERENCES recipes (id)
) default charset utf8;
SELECT
  r.*,
  a.*,
  i.*,
  s.*
FROM
  recipes r
  JOIN accounts a ON r.creatorId = a.id
  JOIN ingredients i ON i.recipeId = r.id
  JOIN steps s ON s.recipeId = r.id
WHERE
  r.id = 2