CREATE TABLE `catalog`.`Products` (
  `ProductId` INT NOT NULL AUTO_INCREMENT,
  `ProductUpc` VARCHAR(45) NOT NULL,
  `ProductName` VARCHAR(45) NULL,
  `ThumbnailImage` VARCHAR(200) NULL,
  `LargeImage` VARCHAR(200) NULL,
  `ListPrice` FLOAT(8,2) NULL,
  `SalePrice` FLOAT(8,2) NULL,
  `Description` TEXT NULL,
  PRIMARY KEY (`ProductId`),
  UNIQUE INDEX `ProductUpc_UNIQUE` (`ProductUpc` ASC));
