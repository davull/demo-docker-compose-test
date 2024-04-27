-- MySQL dump 10.13  Distrib 8.0.36, for Linux (x86_64)
--
-- Host: localhost    Database: orders
-- ------------------------------------------------------
-- Server version	11.3.2-MariaDB-1:11.3.2+maria~ubu2204

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Current Database: `orders`
--

CREATE DATABASE /*!32312 IF NOT EXISTS*/ `orders` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci */;

USE `orders`;

--
-- Table structure for table `Products`
--

DROP TABLE IF EXISTS `Products`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Products` (
  `Sku` varchar(50) NOT NULL,
  `Ean` varchar(50) NOT NULL,
  `Name` varchar(255) NOT NULL,
  `Description` text NOT NULL,
  `Price` decimal(10,2) NOT NULL,
  `Stock` int(11) NOT NULL,
  PRIMARY KEY (`Sku`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Products`
--

LOCK TABLES `Products` WRITE;
/*!40000 ALTER TABLE `Products` DISABLE KEYS */;
INSERT INTO `Products` VALUES ('AD58776','2613592562313','Monitor','10-inch touch screen, compatible with stylus pen, perfect for drawing and note-taking.',474.85,487),('AP99119','0225349200458','Smartphone','27-inch 4K UHD monitor with HDR10 support and minimal bezel design.',772.48,237),('CZ53484','6368963523559','Laptop','Lightweight and portable with 15.6-inch Full HD display, 8GB RAM, and 256GB SSD storage.',356.65,568),('DW66529','9980828459581','Laptop','High-performance device with a 6.5-inch OLED screen, 5G connectivity, and advanced camera system.',691.65,427),('FA25407','5391015198161','Smartwatch','Noise-cancelling wireless headphones with up to 20 hours of battery life.',174.62,412),('FA76633','3947698047818','Monitor','27-inch 4K UHD monitor with HDR10 support and minimal bezel design.',126.24,950),('FB35922','8881699627936','Tablet','10-inch touch screen, compatible with stylus pen, perfect for drawing and note-taking.',861.65,105),('FC16317','7719849237234','External Hard Drive','Wireless gaming mouse with high precision sensor and 9 programmable buttons.',82.91,252),('FE19152','3259816034946','Keyboard','27-inch 4K UHD monitor with HDR10 support and minimal bezel design.',682.67,788),('GR81300','2665102017240','Graphics Card','27-inch 4K UHD monitor with HDR10 support and minimal bezel design.',776.60,812),('GS37661','2277763130635','Smartwatch','10-inch touch screen, compatible with stylus pen, perfect for drawing and note-taking.',399.37,165),('HP87474','7997465591767','Graphics Card','Lightweight and portable with 15.6-inch Full HD display, 8GB RAM, and 256GB SSD storage.',318.86,556),('IS20644','1534523183005','Smartwatch','Features heart rate monitor, GPS, and water resistance up to 50 meters. Compatible with iOS and Android.',789.44,954),('KX17761','0150732977252','External Hard Drive','10-inch touch screen, compatible with stylus pen, perfect for drawing and note-taking.',916.94,445),('LU95673','6032995696139','Headphones','Noise-cancelling wireless headphones with up to 20 hours of battery life.',94.11,567),('LW27571','6093121217291','Laptop','High-performance device with a 6.5-inch OLED screen, 5G connectivity, and advanced camera system.',469.92,355),('MY29339','6404191439894','Mouse','Wireless gaming mouse with high precision sensor and 9 programmable buttons.',64.76,975),('NR75371','4820045132278','Laptop','27-inch 4K UHD monitor with HDR10 support and minimal bezel design.',399.64,887),('OL19077','6796006499071','Headphones','Mechanical keyboard with customizable RGB lighting and ergonomic design.',364.91,104),('TD68253','6491441394812','Smartphone','High-performance device with a 6.5-inch OLED screen, 5G connectivity, and advanced camera system.',617.19,544),('TH53571','0245988677671','Keyboard','Mechanical keyboard with customizable RGB lighting and ergonomic design.',274.66,742),('UZ04525','3719713163656','External Hard Drive','10-inch touch screen, compatible with stylus pen, perfect for drawing and note-taking.',417.14,186),('VK54113','8839104901621','Headphones','10-inch touch screen, compatible with stylus pen, perfect for drawing and note-taking.',743.17,172),('WP13912','4916298427855','Monitor','27-inch 4K UHD monitor with HDR10 support and minimal bezel design.',938.49,436),('WW79090','7490262975575','Headphones','Lightweight and portable with 15.6-inch Full HD display, 8GB RAM, and 256GB SSD storage.',695.30,637),('XR26878','0789770594260','External Hard Drive','2TB capacity, USB 3.0 connectivity, and durable enclosure for data protection.',120.15,453),('XW41959','7832516868866','Laptop','Wireless gaming mouse with high precision sensor and 9 programmable buttons.',133.56,716),('XY85400','2520200662887','Graphics Card','4GB GDDR6 memory, supports 4K gaming and multi-display setup.',173.14,259),('ZP61586','2241328104430','Monitor','27-inch 4K UHD monitor with HDR10 support and minimal bezel design.',901.65,436),('ZX36683','5683533063794','Tablet','High-performance device with a 6.5-inch OLED screen, 5G connectivity, and advanced camera system.',629.88,977);
/*!40000 ALTER TABLE `Products` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-04-23 19:03:52
