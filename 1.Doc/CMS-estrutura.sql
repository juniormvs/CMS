-- MySQL dump 10.13  Distrib 5.7.17, for Win64 (x86_64)
--
-- ------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `Agenda`
--

DROP TABLE IF EXISTS `Agenda`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Agenda` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `DataInicio` datetime NOT NULL,
  `DataFim` datetime DEFAULT NULL,
  `Titulo` varchar(145) DEFAULT NULL,
  `Descricao` text,
  `Status_Id` int(11) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `fk_Agenda_Status1_idx` (`Status_Id`),
  CONSTRAINT `fk_Agenda_Status1` FOREIGN KEY (`Status_Id`) REFERENCES `Status` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `Ajuda`
--

DROP TABLE IF EXISTS `Ajuda`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Ajuda` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Titulo` varchar(145) NOT NULL,
  `Descricao` text NOT NULL,
  `AjudaTopicoId` int(11) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `fk_Ajuda_AjudaTopico1_idx` (`AjudaTopicoId`),
  CONSTRAINT `fk_Ajuda_AjudaTopico1` FOREIGN KEY (`AjudaTopicoId`) REFERENCES `AjudaTopico` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `AjudaTopico`
--

DROP TABLE IF EXISTS `AjudaTopico`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `AjudaTopico` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Titulo` varchar(145) NOT NULL,
  `Descricao` text,
  `AjudaTopicoId` int(11) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `fk_AjudaTopico_AjudaTopico1_idx` (`AjudaTopicoId`),
  CONSTRAINT `fk_AjudaTopico_AjudaTopico1` FOREIGN KEY (`AjudaTopicoId`) REFERENCES `AjudaTopico` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `Album`
--

DROP TABLE IF EXISTS `Album`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Album` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Nome` varchar(60) NOT NULL,
  `Descricao` text,
  `UrlAmigavel` varchar(145) DEFAULT NULL,
  `StatusId` int(11) NOT NULL,
  `CategoriaId` int(11) NOT NULL,
  `PostarNoFacebook` tinyint(1) NOT NULL DEFAULT '0',
  PRIMARY KEY (`Id`),
  KEY `fk_album_status1_idx` (`StatusId`),
  KEY `fk_Album_Categoria1_idx` (`CategoriaId`),
  CONSTRAINT `fk_Album_Categoria1` FOREIGN KEY (`CategoriaId`) REFERENCES `Categoria` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_album_status1` FOREIGN KEY (`StatusId`) REFERENCES `Status` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `Bairro`
--

DROP TABLE IF EXISTS `Bairro`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Bairro` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Nome` varchar(145) NOT NULL,
  `UrlAmigavel` varchar(145) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=243 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `Cardapio`
--

DROP TABLE IF EXISTS `Cardapio`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Cardapio` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Codigo` varchar(10) DEFAULT NULL,
  `Titulo` varchar(145) NOT NULL,
  `Ingredientes` text,
  `Preco` decimal(10,2) DEFAULT NULL,
  `Imagem` varchar(145) DEFAULT NULL,
  `CardapioCategoriaId` int(11) NOT NULL,
  `Status_Id` int(11) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `fk_Cardapio_CardapioCategoria1_idx` (`CardapioCategoriaId`),
  KEY `fk_Cardapio_Status1_idx` (`Status_Id`),
  CONSTRAINT `fk_Cardapio_CardapioCategoria1` FOREIGN KEY (`CardapioCategoriaId`) REFERENCES `CardapioCategoria` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_Cardapio_Status1` FOREIGN KEY (`Status_Id`) REFERENCES `Status` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `CardapioCategoria`
--

DROP TABLE IF EXISTS `CardapioCategoria`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `CardapioCategoria` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Titulo` varchar(65) NOT NULL,
  `Descricao` text,
  `Imagem` varchar(65) DEFAULT NULL,
  `Bebida` tinyint(1) NOT NULL DEFAULT '0',
  `Status_Id` int(11) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `fk_CardapioCategoria_Status1_idx` (`Status_Id`),
  CONSTRAINT `fk_CardapioCategoria_Status1` FOREIGN KEY (`Status_Id`) REFERENCES `Status` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `Categoria`
--

DROP TABLE IF EXISTS `Categoria`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Categoria` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Nome` varchar(100) NOT NULL,
  `Descricao` varchar(300) DEFAULT NULL,
  `UrlAmigavel` varchar(145) NOT NULL,
  `StatusId` int(11) NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `UrlAmigavel_UNIQUE` (`UrlAmigavel`),
  KEY `fk_Categoria_Status1_idx` (`StatusId`),
  CONSTRAINT `fk_Categoria_Status1` FOREIGN KEY (`StatusId`) REFERENCES `Status` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `CategoriaPublicacao`
--

DROP TABLE IF EXISTS `CategoriaPublicacao`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `CategoriaPublicacao` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `CategoriaId` int(11) NOT NULL,
  `PublicacaoId` int(11) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `fk_categoria_has_publicacao_publicacao1_idx` (`PublicacaoId`),
  KEY `fk_categoria_has_publicacao_categoria1_idx` (`CategoriaId`),
  CONSTRAINT `fk_categoria_has_publicacao_categoria1` FOREIGN KEY (`CategoriaId`) REFERENCES `Categoria` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_categoria_has_publicacao_publicacao1` FOREIGN KEY (`PublicacaoId`) REFERENCES `Publicacao` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=15 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `ClienteParceiro`
--

DROP TABLE IF EXISTS `ClienteParceiro`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `ClienteParceiro` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Url` varchar(145) DEFAULT NULL,
  `Tipo` varchar(45) DEFAULT NULL,
  `PessoaId` int(11) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `fk_cliente_pessoa1_idx` (`PessoaId`),
  CONSTRAINT `fk_cliente_pessoa1` FOREIGN KEY (`PessoaId`) REFERENCES `Pessoa` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `ClienteParceiroCupomDesconto`
--

DROP TABLE IF EXISTS `ClienteParceiroCupomDesconto`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `ClienteParceiroCupomDesconto` (
  `ClienteParceiroId` int(11) NOT NULL,
  `CupomDescontoId` int(11) NOT NULL,
  PRIMARY KEY (`ClienteParceiroId`,`CupomDescontoId`),
  KEY `fk_ClienteParceiro_has_CupomDesconto_CupomDesconto1_idx` (`CupomDescontoId`),
  KEY `fk_ClienteParceiro_has_CupomDesconto_ClienteParceiro1_idx` (`ClienteParceiroId`),
  CONSTRAINT `fk_ClienteParceiro_has_CupomDesconto_ClienteParceiro1` FOREIGN KEY (`ClienteParceiroId`) REFERENCES `ClienteParceiro` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_ClienteParceiro_has_CupomDesconto_CupomDesconto1` FOREIGN KEY (`CupomDescontoId`) REFERENCES `CupomDesconto` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `Contador`
--

DROP TABLE IF EXISTS `Contador`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Contador` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Nome` varchar(65) NOT NULL,
  `Descricao` varchar(145) DEFAULT NULL,
  `Icone` varchar(45) DEFAULT NULL,
  `Valor` int(11) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `Contato`
--

DROP TABLE IF EXISTS `Contato`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Contato` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Valor` varchar(200) NOT NULL,
  `PessoaId` int(11) NOT NULL,
  `TipoContatoId` int(11) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `fk_Telefone_Pessoa1_idx` (`PessoaId`),
  KEY `fk_Telefone_TipoTelefone1_idx` (`TipoContatoId`),
  CONSTRAINT `fk_Telefone_Pessoa1` FOREIGN KEY (`PessoaId`) REFERENCES `Pessoa` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_Telefone_TipoTelefone1` FOREIGN KEY (`TipoContatoId`) REFERENCES `TipoContato` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `CupomDesconto`
--

DROP TABLE IF EXISTS `CupomDesconto`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `CupomDesconto` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Titulo` varchar(45) NOT NULL,
  `Codigo` varchar(45) NOT NULL,
  `DataValidade` datetime DEFAULT NULL,
  `Descricao` text,
  `TermosCondicoes` text,
  `StatusId` int(11) NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `Codigo_UNIQUE` (`Codigo`),
  KEY `fk_CupomDesconto_Status1_idx` (`StatusId`),
  CONSTRAINT `fk_CupomDesconto_Status1` FOREIGN KEY (`StatusId`) REFERENCES `Status` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `Depoimento`
--

DROP TABLE IF EXISTS `Depoimento`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Depoimento` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Autor` varchar(45) NOT NULL,
  `Texto` text NOT NULL,
  `Imagem` varchar(100) DEFAULT NULL,
  `StatusId` int(11) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `fk_depoimento_status1_idx` (`StatusId`),
  CONSTRAINT `fk_depoimento_status1` FOREIGN KEY (`StatusId`) REFERENCES `Status` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `Download`
--

DROP TABLE IF EXISTS `Download`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Download` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Titulo` varchar(145) NOT NULL,
  `MimeType` varchar(45) NOT NULL,
  `Descricao` text,
  `Arquivo` varchar(145) NOT NULL,
  `Status_Id` int(11) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `fk_Download_Status1_idx` (`Status_Id`),
  CONSTRAINT `fk_Download_Status1` FOREIGN KEY (`Status_Id`) REFERENCES `Status` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `Empresa`
--

DROP TABLE IF EXISTS `Empresa`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Empresa` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Resumo` text,
  `Endereco` text,
  `Logo` varchar(45) DEFAULT NULL,
  `Email` varchar(145) DEFAULT NULL,
  `PessoaId` int(11) NOT NULL,
  `TemaPainel` varchar(45) NOT NULL DEFAULT 'no-skin',
  `Latitute` varchar(45) DEFAULT NULL,
  `Longitude` varchar(45) DEFAULT NULL,
  `Telefone` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`Id`,`PessoaId`),
  KEY `fk_empresa_pessoa1_idx` (`PessoaId`),
  CONSTRAINT `fk_empresa_pessoa1` FOREIGN KEY (`PessoaId`) REFERENCES `Pessoa` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `Equipe`
--

DROP TABLE IF EXISTS `Equipe`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Equipe` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Foto` varchar(45) DEFAULT NULL,
  `DocumentoProfissional` varchar(45) DEFAULT NULL,
  `Cargo` varchar(45) NOT NULL,
  `PessoaId` int(11) NOT NULL,
  PRIMARY KEY (`Id`,`PessoaId`),
  KEY `fk_equipe_pessoa1_idx` (`PessoaId`),
  CONSTRAINT `fk_equipe_pessoa1` FOREIGN KEY (`PessoaId`) REFERENCES `Pessoa` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `Estado`
--

DROP TABLE IF EXISTS `Estado`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Estado` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `CodigoUf` int(11) NOT NULL,
  `Nome` varchar(50) NOT NULL,
  `Uf` char(2) NOT NULL,
  `Regiao` int(11) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=28 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `ImagemAlbum`
--

DROP TABLE IF EXISTS `ImagemAlbum`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `ImagemAlbum` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Imagem` varchar(145) NOT NULL,
  `Legenda` varchar(145) DEFAULT NULL,
  `Ordem` int(11) NOT NULL,
  `AlbumId` int(11) NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `Imagem_UNIQUE` (`Imagem`),
  KEY `fk_ImagemAlbum_Album1_idx` (`AlbumId`),
  CONSTRAINT `fk_ImagemAlbum_Album1` FOREIGN KEY (`AlbumId`) REFERENCES `Album` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `ImagemImovel`
--

DROP TABLE IF EXISTS `ImagemImovel`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `ImagemImovel` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Imagem` varchar(45) NOT NULL,
  `Ordem` int(11) DEFAULT NULL,
  `ImovelId` int(11) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `fk_ImagemPropriedade_Propriedade_idx` (`ImovelId`),
  CONSTRAINT `fk_ImagemPropriedade_Propriedade` FOREIGN KEY (`ImovelId`) REFERENCES `Imovel` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=56 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `ImagemPortifolio`
--

DROP TABLE IF EXISTS `ImagemPortifolio`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `ImagemPortifolio` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Imagem` varchar(145) NOT NULL,
  `Legenda` varchar(145) DEFAULT NULL,
  `Ordem` int(11) NOT NULL,
  `PortifolioId` int(11) NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `Imagem_UNIQUE` (`Imagem`),
  KEY `fk_ImagemPortifolio_Portifolio1_idx` (`PortifolioId`),
  CONSTRAINT `fk_ImagemPortifolio_Portifolio1` FOREIGN KEY (`PortifolioId`) REFERENCES `Portifolio` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `ImagemProduto`
--

DROP TABLE IF EXISTS `ImagemProduto`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `ImagemProduto` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Imagem` varchar(145) NOT NULL,
  `Legenda` varchar(145) DEFAULT NULL,
  `Ordem` int(11) NOT NULL,
  `ProdutoId` int(11) NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `Imagem_UNIQUE` (`Imagem`),
  KEY `fk_ImagemProduto_Produto1_idx` (`ProdutoId`),
  CONSTRAINT `fk_ImagemProduto_Produto1` FOREIGN KEY (`ProdutoId`) REFERENCES `Produto` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `ImagemPublicacao`
--

DROP TABLE IF EXISTS `ImagemPublicacao`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `ImagemPublicacao` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Imagem` varchar(145) NOT NULL,
  `Legenda` varchar(145) DEFAULT NULL,
  `Ordem` int(11) NOT NULL,
  `PublicacaoId` int(11) NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `Imagem_UNIQUE` (`Imagem`),
  KEY `fk_ImagemPublicacao_Publicacao1_idx` (`PublicacaoId`),
  CONSTRAINT `fk_ImagemPublicacao_Publicacao1` FOREIGN KEY (`PublicacaoId`) REFERENCES `Publicacao` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `Imovel`
--

DROP TABLE IF EXISTS `Imovel`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Imovel` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Codigo` varchar(45) DEFAULT NULL,
  `Titulo` varchar(200) NOT NULL,
  `Descricao` text,
  `CentralNegocio` text,
  `Imagem` varchar(200) DEFAULT NULL,
  `Valor` decimal(10,2) DEFAULT NULL,
  `ValorCondominio` decimal(10,2) DEFAULT NULL,
  `AreaTotal` double DEFAULT NULL,
  `AreaConstruida` double DEFAULT NULL,
  `Dormitorio` int(11) DEFAULT NULL,
  `Suite` int(11) DEFAULT NULL,
  `Banheiro` int(11) DEFAULT NULL,
  `Garagem` int(11) DEFAULT NULL,
  `Endereco` text,
  `Cidade` varchar(145) DEFAULT NULL,
  `Uf` varchar(2) DEFAULT NULL,
  `Bairro` varchar(145) DEFAULT NULL,
  `Cep` varchar(12) DEFAULT NULL,
  `Latitude` varchar(45) DEFAULT NULL,
  `Longitude` varchar(45) DEFAULT NULL,
  `BairroUrl` varchar(145) DEFAULT NULL,
  `CidadeUrl` varchar(145) DEFAULT NULL,
  `UrlAmigavel` varchar(200) DEFAULT NULL,
  `TipoContratoId` int(11) NOT NULL DEFAULT '1',
  `TipoImovelId` int(11) NOT NULL DEFAULT '1',
  `StatusId` int(11) NOT NULL DEFAULT '1',
  `DataCadastro` datetime DEFAULT NULL,
  `DataExclusao` datetime DEFAULT NULL,
  `UsuarioExclusao` varchar(245) DEFAULT NULL,
  `Destaque` tinyint(1) NOT NULL DEFAULT '0',
  PRIMARY KEY (`Id`),
  KEY `fk_Propriedade_Status1_idx` (`StatusId`),
  KEY `fk_Imovel_TipoImovel1_idx` (`TipoImovelId`),
  KEY `fk_Imovel_TipoContrato1_idx` (`TipoContratoId`),
  CONSTRAINT `fk_Imovel_TipoContrato1` FOREIGN KEY (`TipoContratoId`) REFERENCES `TipoContrato` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_Imovel_TipoImovel1` FOREIGN KEY (`TipoImovelId`) REFERENCES `TipoImovel` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_Propriedade_Status1` FOREIGN KEY (`StatusId`) REFERENCES `Status` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=22 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `Link`
--

DROP TABLE IF EXISTS `Link`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Link` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Titulo` varchar(100) NOT NULL,
  `Url` varchar(145) NOT NULL,
  `Target` varchar(45) NOT NULL DEFAULT '_blank',
  `StatusId` int(11) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `fk_link_status1_idx` (`StatusId`),
  CONSTRAINT `fk_link_status1` FOREIGN KEY (`StatusId`) REFERENCES `Status` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `Log`
--

DROP TABLE IF EXISTS `Log`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Log` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Datetime` timestamp NULL DEFAULT NULL,
  `Thread` text,
  `Level` text,
  `Logger` text,
  `Message` text,
  `Exception` text,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `Mensagem`
--

DROP TABLE IF EXISTS `Mensagem`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Mensagem` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Remetente` varchar(145) NOT NULL,
  `Email` varchar(145) NOT NULL,
  `Assunto` varchar(60) DEFAULT NULL,
  `Telefone` varchar(45) DEFAULT NULL,
  `Conteudo` text NOT NULL,
  `Data` datetime NOT NULL,
  `Lida` tinyint(1) NOT NULL DEFAULT '0',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `Municipio`
--

DROP TABLE IF EXISTS `Municipio`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Municipio` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Codigo` int(11) NOT NULL,
  `Nome` varchar(255) NOT NULL,
  `Uf` char(2) NOT NULL,
  `UrlAmigavel` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=5571 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `Perfil`
--

DROP TABLE IF EXISTS `Perfil`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Perfil` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Nome` varchar(45) NOT NULL,
  `Descricao` text,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `Nome_UNIQUE` (`Nome`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `Pessoa`
--

DROP TABLE IF EXISTS `Pessoa`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Pessoa` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Nome` varchar(145) NOT NULL,
  `Bio` text,
  `Imagem` varchar(145) DEFAULT NULL,
  `Observacao` text,
  `CpfCnpj` varchar(20) DEFAULT NULL,
  `Tipo` varchar(20) DEFAULT NULL,
  `DataCadastro` date NOT NULL,
  `DataNascimento` date DEFAULT NULL,
  `Telefone` varchar(20) DEFAULT NULL,
  `Celular` varchar(20) DEFAULT NULL,
  `Whatsapp` varchar(20) DEFAULT NULL,
  `Email` varchar(245) DEFAULT NULL,
  `StatusId` int(11) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `fk_Pessoa_status1_idx` (`StatusId`),
  CONSTRAINT `fk_Pessoa_status1` FOREIGN KEY (`StatusId`) REFERENCES `Status` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=30 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `Portifolio`
--

DROP TABLE IF EXISTS `Portifolio`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Portifolio` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Nome` varchar(145) NOT NULL,
  `Descricao` text,
  `DadosTecnico` text,
  `Imagem` varchar(145) DEFAULT NULL,
  `Url` varchar(145) DEFAULT NULL,
  `UrlAmigavel` varchar(145) DEFAULT NULL,
  `StatusId` int(11) NOT NULL,
  `CategoriaId` int(11) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `fk_Portifolio_Status1_idx` (`StatusId`),
  KEY `fk_Portifolio_Categoria1_idx` (`CategoriaId`),
  CONSTRAINT `fk_Portifolio_Categoria1` FOREIGN KEY (`CategoriaId`) REFERENCES `Categoria` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_Portifolio_Status1` FOREIGN KEY (`StatusId`) REFERENCES `Status` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `Produto`
--

DROP TABLE IF EXISTS `Produto`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Produto` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Nome` varchar(145) NOT NULL,
  `Descricao` text,
  `DadosTecnico` text,
  `Imagem` varchar(45) DEFAULT NULL,
  `Video` varchar(45) DEFAULT NULL,
  `Preco` decimal(10,2) DEFAULT NULL,
  `UrlAmigavel` varchar(145) NOT NULL,
  `StatusId` int(11) NOT NULL,
  `CategoriaId` int(11) NOT NULL,
  `PostarNoFacebook` tinyint(1) NOT NULL DEFAULT '0',
  PRIMARY KEY (`Id`),
  UNIQUE KEY `UrlAmigavel_UNIQUE` (`UrlAmigavel`),
  KEY `fk_Produto_Status1_idx` (`StatusId`),
  KEY `fk_Produto_Categoria1_idx` (`CategoriaId`),
  CONSTRAINT `fk_Produto_Categoria1` FOREIGN KEY (`CategoriaId`) REFERENCES `Categoria` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_Produto_Status1` FOREIGN KEY (`StatusId`) REFERENCES `Status` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `Promocao`
--

DROP TABLE IF EXISTS `Promocao`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Promocao` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Titulo` varchar(145) NOT NULL,
  `Descricao` text,
  `Resumo` text,
  `Imagem` varchar(145) DEFAULT NULL,
  `Url` varchar(145) DEFAULT NULL,
  `DataInicio` datetime DEFAULT NULL,
  `DataFim` datetime DEFAULT NULL,
  `StatusId` int(11) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `fk_Promocao_Status1_idx` (`StatusId`),
  CONSTRAINT `fk_Promocao_Status1` FOREIGN KEY (`StatusId`) REFERENCES `Status` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `Publicacao`
--

DROP TABLE IF EXISTS `Publicacao`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Publicacao` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Titulo` varchar(140) NOT NULL,
  `Resumo` varchar(200) DEFAULT NULL,
  `Texto` text NOT NULL,
  `Imagem` varchar(145) DEFAULT NULL,
  `DataPublicacao` datetime NOT NULL,
  `DataAtualizacao` datetime DEFAULT NULL,
  `ExibirComoPopup` tinyint(1) NOT NULL DEFAULT '0',
  `ExibirImagem` tinyint(1) NOT NULL DEFAULT '1',
  `UrlAmigavel` varchar(145) NOT NULL,
  `PostarNoFacebook` tinyint(1) NOT NULL DEFAULT '0',
  `StatusId` int(11) NOT NULL,
  `Autor` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `UrlAmigavel_UNIQUE` (`UrlAmigavel`),
  KEY `fk_publicacao_status1_idx` (`StatusId`),
  CONSTRAINT `fk_publicacao_status1` FOREIGN KEY (`StatusId`) REFERENCES `Status` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=34 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `Rede`
--

DROP TABLE IF EXISTS `Rede`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Rede` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Nome` varchar(100) NOT NULL,
  `UrlBase` varchar(145) DEFAULT NULL,
  `Icone` varchar(100) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `RedeSocial`
--

DROP TABLE IF EXISTS `RedeSocial`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `RedeSocial` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Url` varchar(245) NOT NULL,
  `RedeId` int(11) NOT NULL,
  `PessoaId` int(11) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `fk_rede_social_rede1_idx` (`RedeId`),
  KEY `fk_rede_social_pessoa1_idx` (`PessoaId`),
  CONSTRAINT `fk_rede_social_pessoa1` FOREIGN KEY (`PessoaId`) REFERENCES `Pessoa` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_rede_social_rede1` FOREIGN KEY (`RedeId`) REFERENCES `Rede` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `Regiao`
--

DROP TABLE IF EXISTS `Regiao`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Regiao` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Nome` varchar(50) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `Servico`
--

DROP TABLE IF EXISTS `Servico`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Servico` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Nome` varchar(45) NOT NULL,
  `Resumo` varchar(120) DEFAULT NULL,
  `Descricao` text,
  `Icone` varchar(45) DEFAULT NULL,
  `Imagem` varchar(145) DEFAULT NULL,
  `UrlAmigavel` varchar(145) DEFAULT NULL,
  `TipoId` int(11) NOT NULL,
  `StatusId` int(11) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `fk_servico_tipo1_idx` (`TipoId`),
  KEY `fk_servico_status1_idx` (`StatusId`),
  CONSTRAINT `fk_servico_status1` FOREIGN KEY (`StatusId`) REFERENCES `Status` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_servico_tipo1` FOREIGN KEY (`TipoId`) REFERENCES `TipoServico` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=15 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `Slide`
--

DROP TABLE IF EXISTS `Slide`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Slide` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Imagem` text NOT NULL,
  `Titulo` varchar(60) DEFAULT NULL,
  `Subtitulo` varchar(145) DEFAULT NULL,
  `Url` text,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `Status`
--

DROP TABLE IF EXISTS `Status`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Status` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Nome` varchar(45) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `TipoContato`
--

DROP TABLE IF EXISTS `TipoContato`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `TipoContato` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Descricao` varchar(45) NOT NULL,
  `Icone` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `TipoContrato`
--

DROP TABLE IF EXISTS `TipoContrato`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `TipoContrato` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Nome` varchar(45) NOT NULL,
  `UrlAmigavel` varchar(45) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `TipoImovel`
--

DROP TABLE IF EXISTS `TipoImovel`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `TipoImovel` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Nome` varchar(45) NOT NULL,
  `UrlAmigavel` varchar(45) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=15 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `TipoServico`
--

DROP TABLE IF EXISTS `TipoServico`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `TipoServico` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Nome` varchar(45) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `Usuario`
--

DROP TABLE IF EXISTS `Usuario`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Usuario` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Email` varchar(145) NOT NULL,
  `Senha` text NOT NULL,
  `PessoaId` int(11) NOT NULL,
  `PerfilId` int(11) NOT NULL,
  PRIMARY KEY (`Id`,`PessoaId`),
  UNIQUE KEY `Email_UNIQUE` (`Email`),
  KEY `fk_usuario_pessoa1_idx` (`PessoaId`),
  KEY `fk_Usuario_Perfil1_idx` (`PerfilId`),
  CONSTRAINT `fk_Usuario_Perfil1` FOREIGN KEY (`PerfilId`) REFERENCES `Perfil` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_usuario_pessoa1` FOREIGN KEY (`PessoaId`) REFERENCES `Pessoa` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `Video`
--

DROP TABLE IF EXISTS `Video`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Video` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `YoutubeId` varchar(45) NOT NULL,
  `Titulo` varchar(145) NOT NULL,
  `Descricao` text,
  `UrlAmigavel` varchar(145) NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `UrlAmigavel_UNIQUE` (`UrlAmigavel`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Temporary view structure for view `VwBairro`
--

DROP TABLE IF EXISTS `VwBairro`;
/*!50001 DROP VIEW IF EXISTS `VwBairro`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
/*!50001 CREATE VIEW `VwBairro` AS SELECT 
 1 AS `Id`,
 1 AS `NomeBairro`,
 1 AS `BairroUrl`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `VwCidade`
--

DROP TABLE IF EXISTS `VwCidade`;
/*!50001 DROP VIEW IF EXISTS `VwCidade`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
/*!50001 CREATE VIEW `VwCidade` AS SELECT 
 1 AS `Id`,
 1 AS `NomeCidade`,
 1 AS `CidadeUrl`*/;
SET character_set_client = @saved_cs_client;

--
-- Final view structure for view `VwBairro`
--

/*!50001 DROP VIEW IF EXISTS `VwBairro`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8 */;
/*!50001 SET character_set_results     = utf8 */;
/*!50001 SET collation_connection      = utf8_general_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50001 VIEW `VwBairro` AS select uuid() AS `Id`,`Imovel`.`Bairro` AS `NomeBairro`,`Imovel`.`BairroUrl` AS `BairroUrl` from `Imovel` group by `Imovel`.`Bairro` order by `Imovel`.`Bairro` */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `VwCidade`
--

/*!50001 DROP VIEW IF EXISTS `VwCidade`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8 */;
/*!50001 SET character_set_results     = utf8 */;
/*!50001 SET collation_connection      = utf8_general_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50001 VIEW `VwCidade` AS select uuid() AS `Id`,`Imovel`.`Cidade` AS `NomeCidade`,`Imovel`.`CidadeUrl` AS `CidadeUrl` from `Imovel` group by `Imovel`.`Cidade` order by `Imovel`.`Cidade` */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2017-11-01  6:36:44
