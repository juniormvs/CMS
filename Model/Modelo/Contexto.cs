namespace Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Data.Entity.Validation;

    public partial class Contexto : DbContext
    {
        public Contexto()
            : base("name=cmsEntities")
        {
        }

        public virtual DbSet<Agenda> Agenda { get; set; }
        public virtual DbSet<Ajuda> Ajuda { get; set; }
        public virtual DbSet<AjudaTopico> AjudaTopico { get; set; }
        public virtual DbSet<Album> Album { get; set; }
        public virtual DbSet<AlbumPorCategoria> AlbumPorCategoria { get; set; }
        public virtual DbSet<Bairro> Bairro { get; set; }
        public virtual DbSet<Cardapio> Cardapio { get; set; }
        public virtual DbSet<CardapioCategoria> CardapioCategoria { get; set; }
        public virtual DbSet<CategoriaAlbum> CategoriaAlbum { get; set; }
        public virtual DbSet<CategoriaPortifolio> CategoriaPortifolio { get; set; }
        public virtual DbSet<CategoriaProduto> CategoriaProduto { get; set; }
        public virtual DbSet<CategoriaPublicacao> CategoriaPublicacao { get; set; }
        public virtual DbSet<Cidade> Cidade { get; set; }
        public virtual DbSet<Contador> Contador { get; set; }
        public virtual DbSet<Depoimento> Depoimento { get; set; }
        public virtual DbSet<DetalhePorImovel> DetalhePorImovel { get; set; }
        public virtual DbSet<Download> Download { get; set; }
        public virtual DbSet<Empresa> Empresa { get; set; }
        public virtual DbSet<Estado> Estado { get; set; }
        public virtual DbSet<ImagemAlbum> ImagemAlbum { get; set; }
        public virtual DbSet<ImagemImovel> ImagemImovel { get; set; }
        public virtual DbSet<ImagemPortifolio> ImagemPortifolio { get; set; }
        public virtual DbSet<ImagemProduto> ImagemProduto { get; set; }
        public virtual DbSet<ImagemPublicacao> ImagemPublicacao { get; set; }
        public virtual DbSet<ImoveInformacao> ImoveInformacao { get; set; }
        public virtual DbSet<Imovel> Imovel { get; set; }
        public virtual DbSet<ImovelDetalhe> ImovelDetalhe { get; set; }
        public virtual DbSet<Link> Link { get; set; }
        public virtual DbSet<Log> Log { get; set; }
        public virtual DbSet<Mensagem> Mensagem { get; set; }
        public virtual DbSet<PerfilPessoa> PerfilPessoa { get; set; }
        public virtual DbSet<Pessoa> Pessoa { get; set; }
        public virtual DbSet<Portifolio> Portifolio { get; set; }
        public virtual DbSet<PortifolioPorCategoria> PortifolioPorCategoria { get; set; }
        public virtual DbSet<Produto> Produto { get; set; }
        public virtual DbSet<ProdutoPorCategoria> ProdutoPorCategoria { get; set; }
        public virtual DbSet<Publicacao> Publicacao { get; set; }
        public virtual DbSet<PublicacaoPorCategoria> PublicacaoPorCategoria { get; set; }
        public virtual DbSet<Regiao> Regiao { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Servico> Servico { get; set; }
        public virtual DbSet<Slide> Slide { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<TipoContrato> TipoContrato { get; set; }
        public virtual DbSet<TipoImovel> TipoImovel { get; set; }
        public virtual DbSet<TipoServico> TipoServico { get; set; }
        public virtual DbSet<UserClaims> UserClaims { get; set; }
        public virtual DbSet<UserLogins> UserLogins { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Video> Video { get; set; }

        public virtual DbSet<Teste> Teste { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Agenda>()
                .Property(e => e.Titulo)
                .IsUnicode(false);

            modelBuilder.Entity<Agenda>()
                .Property(e => e.Descricao)
                .IsUnicode(false);

            modelBuilder.Entity<Ajuda>()
                .Property(e => e.Titulo)
                .IsUnicode(false);

            modelBuilder.Entity<Ajuda>()
                .Property(e => e.Descricao)
                .IsUnicode(false);

            modelBuilder.Entity<AjudaTopico>()
                .Property(e => e.Titulo)
                .IsUnicode(false);

            modelBuilder.Entity<AjudaTopico>()
                .Property(e => e.Descricao)
                .IsUnicode(false);

            modelBuilder.Entity<AjudaTopico>()
                .HasMany(e => e.Ajuda)
                .WithRequired(e => e.AjudaTopico)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AjudaTopico>()
                .HasMany(e => e.AjudaTopico1)
                .WithRequired(e => e.AjudaTopico2)
                .HasForeignKey(e => e.AjudaTopicoId);

            modelBuilder.Entity<Album>()
                .Property(e => e.Nome)
                .IsUnicode(false);

            modelBuilder.Entity<Album>()
                .Property(e => e.Descricao)
                .IsUnicode(false);

            modelBuilder.Entity<Album>()
                .Property(e => e.UrlAmigavel)
                .IsUnicode(false);

            modelBuilder.Entity<Album>()
                .HasMany(e => e.AlbumPorCategoria)
                .WithRequired(e => e.Album)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Album>()
                .HasMany(e => e.ImagemAlbum)
                .WithRequired(e => e.Album)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Bairro>()
                .Property(e => e.Nome)
                .IsUnicode(false);

            modelBuilder.Entity<Bairro>()
                .Property(e => e.UrlAmigavel)
                .IsUnicode(false);

            modelBuilder.Entity<Bairro>()
                .HasMany(e => e.Imovel)
                .WithRequired(e => e.Bairro)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Cardapio>()
                .Property(e => e.Codigo)
                .IsUnicode(false);

            modelBuilder.Entity<Cardapio>()
                .Property(e => e.Titulo)
                .IsUnicode(false);

            modelBuilder.Entity<Cardapio>()
                .Property(e => e.Ingredientes)
                .IsUnicode(false);

            modelBuilder.Entity<Cardapio>()
                .Property(e => e.Imagem)
                .IsUnicode(false);

            modelBuilder.Entity<CardapioCategoria>()
                .Property(e => e.Titulo)
                .IsUnicode(false);

            modelBuilder.Entity<CardapioCategoria>()
                .Property(e => e.Descricao)
                .IsUnicode(false);

            modelBuilder.Entity<CardapioCategoria>()
                .Property(e => e.Imagem)
                .IsUnicode(false);

            modelBuilder.Entity<CardapioCategoria>()
                .HasMany(e => e.Cardapio)
                .WithRequired(e => e.CardapioCategoria)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CategoriaAlbum>()
                .Property(e => e.Nome)
                .IsUnicode(false);

            modelBuilder.Entity<CategoriaAlbum>()
                .Property(e => e.Descricao)
                .IsUnicode(false);

            modelBuilder.Entity<CategoriaAlbum>()
                .Property(e => e.UrlAmigavel)
                .IsUnicode(false);

            modelBuilder.Entity<CategoriaAlbum>()
                .HasMany(e => e.AlbumPorCategoria)
                .WithRequired(e => e.CategoriaAlbum)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CategoriaPortifolio>()
                .Property(e => e.Nome)
                .IsUnicode(false);

            modelBuilder.Entity<CategoriaPortifolio>()
                .Property(e => e.Descricao)
                .IsUnicode(false);

            modelBuilder.Entity<CategoriaPortifolio>()
                .Property(e => e.UrlAmigavel)
                .IsUnicode(false);

            modelBuilder.Entity<CategoriaPortifolio>()
                .HasMany(e => e.PortifolioPorCategoria)
                .WithRequired(e => e.CategoriaPortifolio)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CategoriaProduto>()
                .Property(e => e.Nome)
                .IsUnicode(false);

            modelBuilder.Entity<CategoriaProduto>()
                .Property(e => e.Descricao)
                .IsUnicode(false);

            modelBuilder.Entity<CategoriaProduto>()
                .Property(e => e.UrlAmigavel)
                .IsUnicode(false);

            modelBuilder.Entity<CategoriaProduto>()
                .HasMany(e => e.ProdutoPorCategoria)
                .WithRequired(e => e.CategoriaProduto)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CategoriaPublicacao>()
                .Property(e => e.Nome)
                .IsUnicode(false);

            modelBuilder.Entity<CategoriaPublicacao>()
                .Property(e => e.Descricao)
                .IsUnicode(false);

            modelBuilder.Entity<CategoriaPublicacao>()
                .Property(e => e.UrlAmigavel)
                .IsUnicode(false);

            modelBuilder.Entity<CategoriaPublicacao>()
                .HasMany(e => e.PublicacaoPorCategoria)
                .WithRequired(e => e.CategoriaPublicacao)
                .HasForeignKey(e => e.CategoriaId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Cidade>()
                .Property(e => e.Nome)
                .IsUnicode(false);

            modelBuilder.Entity<Cidade>()
                .Property(e => e.Uf)
                .IsUnicode(false);

            modelBuilder.Entity<Cidade>()
                .Property(e => e.UrlAmigavel)
                .IsUnicode(false);

            modelBuilder.Entity<Cidade>()
                .HasMany(e => e.Imovel)
                .WithRequired(e => e.Cidade)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Contador>()
                .Property(e => e.Nome)
                .IsUnicode(false);

            modelBuilder.Entity<Contador>()
                .Property(e => e.Descricao)
                .IsUnicode(false);

            modelBuilder.Entity<Contador>()
                .Property(e => e.Icone)
                .IsUnicode(false);

            modelBuilder.Entity<Depoimento>()
                .Property(e => e.Autor)
                .IsUnicode(false);

            modelBuilder.Entity<Depoimento>()
                .Property(e => e.Texto)
                .IsUnicode(false);

            modelBuilder.Entity<Depoimento>()
                .Property(e => e.Imagem)
                .IsUnicode(false);

            modelBuilder.Entity<Download>()
                .Property(e => e.Titulo)
                .IsUnicode(false);

            modelBuilder.Entity<Download>()
                .Property(e => e.MimeType)
                .IsUnicode(false);

            modelBuilder.Entity<Download>()
                .Property(e => e.Descricao)
                .IsUnicode(false);

            modelBuilder.Entity<Download>()
                .Property(e => e.Arquivo)
                .IsUnicode(false);

            modelBuilder.Entity<Empresa>()
                .Property(e => e.Nome)
                .IsUnicode(false);

            modelBuilder.Entity<Empresa>()
                .Property(e => e.Descricao)
                .IsUnicode(false);

            modelBuilder.Entity<Empresa>()
                .Property(e => e.Resumo)
                .IsUnicode(false);

            modelBuilder.Entity<Empresa>()
                .Property(e => e.Endereco)
                .IsUnicode(false);

            modelBuilder.Entity<Empresa>()
                .Property(e => e.Telefone)
                .IsUnicode(false);

            modelBuilder.Entity<Empresa>()
                .Property(e => e.Whatsapp)
                .IsUnicode(false);

            modelBuilder.Entity<Empresa>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Empresa>()
                .Property(e => e.Imagem)
                .IsUnicode(false);

            modelBuilder.Entity<Empresa>()
                .Property(e => e.Logo)
                .IsUnicode(false);

            modelBuilder.Entity<Empresa>()
                .Property(e => e.TemaPainel)
                .IsUnicode(false);

            modelBuilder.Entity<Empresa>()
                .Property(e => e.Latitute)
                .IsUnicode(false);

            modelBuilder.Entity<Empresa>()
                .Property(e => e.Longitude)
                .IsUnicode(false);

            modelBuilder.Entity<Estado>()
                .Property(e => e.Nome)
                .IsUnicode(false);

            modelBuilder.Entity<Estado>()
                .Property(e => e.Uf)
                .IsUnicode(false);

            modelBuilder.Entity<ImagemAlbum>()
                .Property(e => e.Imagem)
                .IsUnicode(false);

            modelBuilder.Entity<ImagemAlbum>()
                .Property(e => e.Legenda)
                .IsUnicode(false);

            modelBuilder.Entity<ImagemImovel>()
                .Property(e => e.Imagem)
                .IsUnicode(false);

            modelBuilder.Entity<ImagemPortifolio>()
                .Property(e => e.Imagem)
                .IsUnicode(false);

            modelBuilder.Entity<ImagemPortifolio>()
                .Property(e => e.Legenda)
                .IsUnicode(false);

            modelBuilder.Entity<ImagemProduto>()
                .Property(e => e.Imagem)
                .IsUnicode(false);

            modelBuilder.Entity<ImagemProduto>()
                .Property(e => e.Legenda)
                .IsUnicode(false);

            modelBuilder.Entity<ImagemPublicacao>()
                .Property(e => e.Imagem)
                .IsUnicode(false);

            modelBuilder.Entity<ImagemPublicacao>()
                .Property(e => e.Legenda)
                .IsUnicode(false);

            modelBuilder.Entity<ImoveInformacao>()
                .Property(e => e.Disponibilidade)
                .IsUnicode(false);

            modelBuilder.Entity<ImoveInformacao>()
                .Property(e => e.LocalChave)
                .IsUnicode(false);

            modelBuilder.Entity<ImoveInformacao>()
                .Property(e => e.Informacao)
                .IsUnicode(false);

            modelBuilder.Entity<Imovel>()
                .Property(e => e.Codigo)
                .IsUnicode(false);

            modelBuilder.Entity<Imovel>()
                .Property(e => e.Descricao)
                .IsUnicode(false);

            modelBuilder.Entity<Imovel>()
                .Property(e => e.CentralNegocio)
                .IsUnicode(false);

            modelBuilder.Entity<Imovel>()
                .Property(e => e.PontosFortes)
                .IsUnicode(false);

            modelBuilder.Entity<Imovel>()
                .Property(e => e.Observacao)
                .IsUnicode(false);

            modelBuilder.Entity<Imovel>()
                .Property(e => e.Imagem)
                .IsUnicode(false);

            modelBuilder.Entity<Imovel>()
                .Property(e => e.UrlAmigavel)
                .IsUnicode(false);

            modelBuilder.Entity<Imovel>()
                .Property(e => e.UsuarioExclusao)
                .IsUnicode(false);

            modelBuilder.Entity<Imovel>()
                .Property(e => e.ObservacaoValor)
                .IsUnicode(false);

            modelBuilder.Entity<Imovel>()
                .Property(e => e.Pavimento)
                .IsUnicode(false);

            modelBuilder.Entity<Imovel>()
                .Property(e => e.Video)
                .IsUnicode(false);

            modelBuilder.Entity<Imovel>()
                .Property(e => e.Cep)
                .IsUnicode(false);

            modelBuilder.Entity<Imovel>()
                .Property(e => e.EnderecoGoogle)
                .IsUnicode(false);

            modelBuilder.Entity<Imovel>()
                .Property(e => e.Logradouro)
                .IsUnicode(false);

            modelBuilder.Entity<Imovel>()
                .Property(e => e.Numero)
                .IsUnicode(false);

            modelBuilder.Entity<Imovel>()
                .Property(e => e.Complemento)
                .IsUnicode(false);

            modelBuilder.Entity<Imovel>()
                .Property(e => e.Zona)
                .IsUnicode(false);

            modelBuilder.Entity<Imovel>()
                .Property(e => e.Regiao)
                .IsUnicode(false);

            modelBuilder.Entity<Imovel>()
                .Property(e => e.PontoReferencia)
                .IsUnicode(false);

            modelBuilder.Entity<Imovel>()
                .Property(e => e.Latitude)
                .IsUnicode(false);

            modelBuilder.Entity<Imovel>()
                .Property(e => e.Longitude)
                .IsUnicode(false);

            modelBuilder.Entity<Imovel>()
                .Property(e => e.UnMedidaTotal)
                .IsUnicode(false);

            modelBuilder.Entity<Imovel>()
                .Property(e => e.UnMedidaPrivativa)
                .IsUnicode(false);

            modelBuilder.Entity<Imovel>()
                .Property(e => e.UnMedidaConstruida)
                .IsUnicode(false);

            modelBuilder.Entity<Imovel>()
                .Property(e => e.UnMedidaTerreno)
                .IsUnicode(false);

            modelBuilder.Entity<Imovel>()
                .Property(e => e.UnMedidaTerrenoFrente)
                .IsUnicode(false);

            modelBuilder.Entity<Imovel>()
                .Property(e => e.UnMedidaTerrenoFundo)
                .IsUnicode(false);

            modelBuilder.Entity<Imovel>()
                .Property(e => e.UnMedidaTerrenoDireita)
                .IsUnicode(false);

            modelBuilder.Entity<Imovel>()
                .Property(e => e.UnMedidaTerrenoEsquerda)
                .IsUnicode(false);

            modelBuilder.Entity<Imovel>()
                .Property(e => e.UserId)
                .IsUnicode(false);

            modelBuilder.Entity<Imovel>()
                .Property(e => e.NomeCondominio)
                .IsUnicode(false);

            modelBuilder.Entity<Imovel>()
                .HasMany(e => e.DetalhePorImovel)
                .WithRequired(e => e.Imovel)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Imovel>()
                .HasMany(e => e.ImagemImovel)
                .WithRequired(e => e.Imovel)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Imovel>()
                .HasMany(e => e.ImoveInformacao)
                .WithRequired(e => e.Imovel)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ImovelDetalhe>()
                .Property(e => e.Grupo)
                .IsUnicode(false);

            modelBuilder.Entity<ImovelDetalhe>()
                .Property(e => e.Descricao)
                .IsUnicode(false);

            modelBuilder.Entity<ImovelDetalhe>()
                .HasMany(e => e.DetalhePorImovel)
                .WithRequired(e => e.ImovelDetalhe)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Link>()
                .Property(e => e.Titulo)
                .IsUnicode(false);

            modelBuilder.Entity<Link>()
                .Property(e => e.Url)
                .IsUnicode(false);

            modelBuilder.Entity<Link>()
                .Property(e => e.Target)
                .IsUnicode(false);

            modelBuilder.Entity<Log>()
                .Property(e => e.Thread)
                .IsUnicode(false);

            modelBuilder.Entity<Log>()
                .Property(e => e.Level)
                .IsUnicode(false);

            modelBuilder.Entity<Log>()
                .Property(e => e.Logger)
                .IsUnicode(false);

            modelBuilder.Entity<Log>()
                .Property(e => e.Message)
                .IsUnicode(false);

            modelBuilder.Entity<Log>()
                .Property(e => e.Exception)
                .IsUnicode(false);

            modelBuilder.Entity<Mensagem>()
                .Property(e => e.Remetente)
                .IsUnicode(false);

            modelBuilder.Entity<Mensagem>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Mensagem>()
                .Property(e => e.Assunto)
                .IsUnicode(false);

            modelBuilder.Entity<Mensagem>()
                .Property(e => e.Telefone)
                .IsUnicode(false);

            modelBuilder.Entity<Mensagem>()
                .Property(e => e.Conteudo)
                .IsUnicode(false);

            modelBuilder.Entity<PerfilPessoa>()
                .Property(e => e.Descricao)
                .IsUnicode(false);

            modelBuilder.Entity<PerfilPessoa>()
                .HasMany(e => e.Pessoa)
                .WithRequired(e => e.PerfilPessoa)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Pessoa>()
                .Property(e => e.Nome)
                .IsUnicode(false);

            modelBuilder.Entity<Pessoa>()
                .Property(e => e.Tipo)
                .IsUnicode(false);

            modelBuilder.Entity<Pessoa>()
                .Property(e => e.CpfCnpj)
                .IsUnicode(false);

            modelBuilder.Entity<Pessoa>()
                .Property(e => e.Imagem)
                .IsUnicode(false);

            modelBuilder.Entity<Pessoa>()
                .Property(e => e.Bio)
                .IsUnicode(false);

            modelBuilder.Entity<Pessoa>()
                .Property(e => e.Observacao)
                .IsUnicode(false);

            modelBuilder.Entity<Pessoa>()
                .Property(e => e.Interesse)
                .IsUnicode(false);

            modelBuilder.Entity<Pessoa>()
                .Property(e => e.Oferecido)
                .IsUnicode(false);

            modelBuilder.Entity<Pessoa>()
                .Property(e => e.Informacao)
                .IsUnicode(false);

            modelBuilder.Entity<Pessoa>()
                .Property(e => e.DocumentoProfissional)
                .IsUnicode(false);

            modelBuilder.Entity<Pessoa>()
                .Property(e => e.Telefone)
                .IsUnicode(false);

            modelBuilder.Entity<Pessoa>()
                .Property(e => e.Celular)
                .IsUnicode(false);

            modelBuilder.Entity<Pessoa>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Pessoa>()
                .Property(e => e.Whatsapp)
                .IsUnicode(false);

            modelBuilder.Entity<Pessoa>()
                .Property(e => e.Skype)
                .IsUnicode(false);

            modelBuilder.Entity<Pessoa>()
                .Property(e => e.ObservacaoTipoCadastro)
                .IsUnicode(false);

            modelBuilder.Entity<Pessoa>()
                .Property(e => e.Url)
                .IsUnicode(false);

            modelBuilder.Entity<Pessoa>()
                .HasMany(e => e.Imovel)
                .WithOptional(e => e.Pessoa)
                .HasForeignKey(e => e.CorretorPessoaId);

            modelBuilder.Entity<Pessoa>()
                .HasMany(e => e.Imovel1)
                .WithOptional(e => e.Pessoa1)
                .HasForeignKey(e => e.ProprietarioPessoaId);

            modelBuilder.Entity<Portifolio>()
                .Property(e => e.Nome)
                .IsUnicode(false);

            modelBuilder.Entity<Portifolio>()
                .Property(e => e.Descricao)
                .IsUnicode(false);

            modelBuilder.Entity<Portifolio>()
                .Property(e => e.DadosTecnico)
                .IsUnicode(false);

            modelBuilder.Entity<Portifolio>()
                .Property(e => e.Imagem)
                .IsUnicode(false);

            modelBuilder.Entity<Portifolio>()
                .Property(e => e.Url)
                .IsUnicode(false);

            modelBuilder.Entity<Portifolio>()
                .Property(e => e.UrlAmigavel)
                .IsUnicode(false);

            modelBuilder.Entity<Portifolio>()
                .HasMany(e => e.ImagemPortifolio)
                .WithRequired(e => e.Portifolio)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Portifolio>()
                .HasMany(e => e.PortifolioPorCategoria)
                .WithRequired(e => e.Portifolio)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Produto>()
                .Property(e => e.Nome)
                .IsUnicode(false);

            modelBuilder.Entity<Produto>()
                .Property(e => e.Descricao)
                .IsUnicode(false);

            modelBuilder.Entity<Produto>()
                .Property(e => e.DadosTecnico)
                .IsUnicode(false);

            modelBuilder.Entity<Produto>()
                .Property(e => e.Imagem)
                .IsUnicode(false);

            modelBuilder.Entity<Produto>()
                .Property(e => e.Video)
                .IsUnicode(false);

            modelBuilder.Entity<Produto>()
                .Property(e => e.UrlAmigavel)
                .IsUnicode(false);

            modelBuilder.Entity<Produto>()
                .HasMany(e => e.ImagemProduto)
                .WithRequired(e => e.Produto)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Produto>()
                .HasMany(e => e.ProdutoPorCategoria)
                .WithRequired(e => e.Produto)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Publicacao>()
                .Property(e => e.Titulo)
                .IsUnicode(false);

            modelBuilder.Entity<Publicacao>()
                .Property(e => e.Resumo)
                .IsUnicode(false);

            modelBuilder.Entity<Publicacao>()
                .Property(e => e.Texto)
                .IsUnicode(false);

            modelBuilder.Entity<Publicacao>()
                .Property(e => e.Imagem)
                .IsUnicode(false);

            modelBuilder.Entity<Publicacao>()
                .Property(e => e.UrlAmigavel)
                .IsUnicode(false);

            modelBuilder.Entity<Publicacao>()
                .Property(e => e.Autor)
                .IsUnicode(false);

            modelBuilder.Entity<Publicacao>()
                .HasMany(e => e.ImagemPublicacao)
                .WithRequired(e => e.Publicacao)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Regiao>()
                .Property(e => e.Nome)
                .IsUnicode(false);

            modelBuilder.Entity<Roles>()
                .Property(e => e.Id)
                .IsUnicode(false);

            modelBuilder.Entity<Roles>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Servico>()
                .Property(e => e.Nome)
                .IsUnicode(false);

            modelBuilder.Entity<Servico>()
                .Property(e => e.Resumo)
                .IsUnicode(false);

            modelBuilder.Entity<Servico>()
                .Property(e => e.Descricao)
                .IsUnicode(false);

            modelBuilder.Entity<Servico>()
                .Property(e => e.Icone)
                .IsUnicode(false);

            modelBuilder.Entity<Servico>()
                .Property(e => e.Imagem)
                .IsUnicode(false);

            modelBuilder.Entity<Servico>()
                .Property(e => e.UrlAmigavel)
                .IsUnicode(false);

            modelBuilder.Entity<Slide>()
                .Property(e => e.Imagem)
                .IsUnicode(false);

            modelBuilder.Entity<Slide>()
                .Property(e => e.Titulo)
                .IsUnicode(false);

            modelBuilder.Entity<Slide>()
                .Property(e => e.Subtitulo)
                .IsUnicode(false);

            modelBuilder.Entity<Slide>()
                .Property(e => e.Url)
                .IsUnicode(false);

            modelBuilder.Entity<Status>()
                .Property(e => e.Nome)
                .IsUnicode(false);

            modelBuilder.Entity<Status>()
                .HasMany(e => e.Imovel)
                .WithRequired(e => e.Status)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Status>()
                .HasMany(e => e.Publicacao)
                .WithRequired(e => e.Status)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TipoContrato>()
                .Property(e => e.Nome)
                .IsUnicode(false);

            modelBuilder.Entity<TipoContrato>()
                .Property(e => e.UrlAmigavel)
                .IsUnicode(false);

            modelBuilder.Entity<TipoContrato>()
                .HasMany(e => e.Imovel)
                .WithRequired(e => e.TipoContrato)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TipoImovel>()
                .Property(e => e.Nome)
                .IsUnicode(false);

            modelBuilder.Entity<TipoImovel>()
                .Property(e => e.UrlAmigavel)
                .IsUnicode(false);

            modelBuilder.Entity<TipoImovel>()
                .HasMany(e => e.Imovel)
                .WithRequired(e => e.TipoImovel)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TipoServico>()
                .Property(e => e.Nome)
                .IsUnicode(false);

            modelBuilder.Entity<TipoServico>()
                .HasMany(e => e.Servico)
                .WithRequired(e => e.TipoServico)
                .HasForeignKey(e => e.TipoId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UserClaims>()
                .Property(e => e.UserId)
                .IsUnicode(false);

            modelBuilder.Entity<UserClaims>()
                .Property(e => e.ClaimType)
                .IsUnicode(false);

            modelBuilder.Entity<UserClaims>()
                .Property(e => e.ClaimValue)
                .IsUnicode(false);

            modelBuilder.Entity<UserLogins>()
                .Property(e => e.LoginProvider)
                .IsUnicode(false);

            modelBuilder.Entity<UserLogins>()
                .Property(e => e.ProviderKey)
                .IsUnicode(false);

            modelBuilder.Entity<UserLogins>()
                .Property(e => e.UserId)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.Id)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.PasswordHash)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.SecurityStamp)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.PhoneNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.UserClaims)
                .WithRequired(e => e.Users)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.UserLogins)
                .WithRequired(e => e.Users)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.Roles)
                .WithMany(e => e.Users)
                .Map(m => m.ToTable("UserRoles", "cms-mainsoftware").MapLeftKey("UserId").MapRightKey("RoleId"));

            modelBuilder.Entity<Video>()
                .Property(e => e.YoutubeId)
                .IsUnicode(false);

            modelBuilder.Entity<Video>()
                .Property(e => e.Titulo)
                .IsUnicode(false);

            modelBuilder.Entity<Video>()
                .Property(e => e.Descricao)
                .IsUnicode(false);

            modelBuilder.Entity<Video>()
                .Property(e => e.UrlAmigavel)
                .IsUnicode(false);
        }
    }
}
