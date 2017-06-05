namespace IDZ_ASP.NET.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class FootballDB : DbContext
    {
        public FootballDB()
            : base("name=FootballDB")
        {
        }

        public virtual DbSet<Аренда_игрока> Аренда_игрока { get; set; }
        public virtual DbSet<Государство> Государство { get; set; }
        public virtual DbSet<Достижения_игрока> Достижения_игрока { get; set; }
        public virtual DbSet<Достижения_клуба> Достижения_клуба { get; set; }
        public virtual DbSet<Игроки> Игроки { get; set; }
        public virtual DbSet<Клубы> Клубы { get; set; }
        public virtual DbSet<Контракт_игрока_с_клубом> Контракт_игрока_с_клубом { get; set; }
        public virtual DbSet<Контракт_тренера_с_клубом> Контракт_тренера_с_клубом { get; set; }
        public virtual DbSet<Персоны> Персоны { get; set; }
        public virtual DbSet<Позиции_игроков> Позиции_игроков { get; set; }
        public virtual DbSet<Сезоны> Сезоны { get; set; }
        public virtual DbSet<Статистика_игрока> Статистика_игрока { get; set; }
        public virtual DbSet<Тренеры> Тренеры { get; set; }
        public virtual DbSet<Чемпионат> Чемпионат { get; set; }
        public virtual DbSet<Чемпионат_в_сезоне> Чемпионат_в_сезоне { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Государство>()
                .Property(e => e.Наименование)
                .IsUnicode(false);

            modelBuilder.Entity<Государство>()
                .HasMany(e => e.Клубы)
                .WithOptional(e => e.Государство)
                .HasForeignKey(e => e.Страна);

            modelBuilder.Entity<Государство>()
                .HasMany(e => e.Персоны)
                .WithOptional(e => e.Государство)
                .HasForeignKey(e => e.Гражданство);

            modelBuilder.Entity<Достижения_игрока>()
                .Property(e => e.Название)
                .IsUnicode(false);

            modelBuilder.Entity<Достижения_клуба>()
                .Property(e => e.Наименование)
                .IsUnicode(false);

            modelBuilder.Entity<Игроки>()
                .HasMany(e => e.Достижения_игрока)
                .WithRequired(e => e.Игроки)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Игроки>()
                .HasMany(e => e.Контракт_игрока_с_клубом)
                .WithRequired(e => e.Игроки)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Клубы>()
                .Property(e => e.Название)
                .IsUnicode(false);

            modelBuilder.Entity<Клубы>()
                .HasMany(e => e.Аренда_игрока)
                .WithRequired(e => e.Клубы)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Клубы>()
                .HasMany(e => e.Достижения_клуба)
                .WithRequired(e => e.Клубы)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Клубы>()
                .HasMany(e => e.Контракт_игрока_с_клубом)
                .WithRequired(e => e.Клубы)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Клубы>()
                .HasMany(e => e.Контракт_тренера_с_клубом)
                .WithRequired(e => e.Клубы)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Контракт_игрока_с_клубом>()
                .HasMany(e => e.Аренда_игрока)
                .WithRequired(e => e.Контракт_игрока_с_клубом)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Контракт_игрока_с_клубом>()
                .HasMany(e => e.Статистика_игрока)
                .WithRequired(e => e.Контракт_игрока_с_клубом)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Персоны>()
                .Property(e => e.Фамилия)
                .IsUnicode(false);

            modelBuilder.Entity<Персоны>()
                .Property(e => e.Имя)
                .IsUnicode(false);

            modelBuilder.Entity<Персоны>()
                .Property(e => e.Отчество)
                .IsUnicode(false);

            modelBuilder.Entity<Персоны>()
                .Property(e => e.Вес)
                .HasPrecision(5, 2);

            modelBuilder.Entity<Персоны>()
                .HasOptional(e => e.Игроки)
                .WithRequired(e => e.Персоны);

            modelBuilder.Entity<Персоны>()
                .HasOptional(e => e.Тренеры)
                .WithRequired(e => e.Персоны);

            modelBuilder.Entity<Позиции_игроков>()
                .Property(e => e.Название)
                .IsUnicode(false);

            modelBuilder.Entity<Позиции_игроков>()
                .HasMany(e => e.Аренда_игрока)
                .WithRequired(e => e.Позиции_игроков)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Позиции_игроков>()
                .HasMany(e => e.Контракт_игрока_с_клубом)
                .WithRequired(e => e.Позиции_игроков)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Сезоны>()
                .HasMany(e => e.Достижения_игрока)
                .WithRequired(e => e.Сезоны)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Тренеры>()
                .HasMany(e => e.Контракт_тренера_с_клубом)
                .WithRequired(e => e.Тренеры)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Чемпионат>()
                .Property(e => e.Название)
                .IsUnicode(false);

            modelBuilder.Entity<Чемпионат>()
                .HasMany(e => e.Чемпионат_в_сезоне)
                .WithRequired(e => e.Чемпионат)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Чемпионат_в_сезоне>()
                .HasMany(e => e.Достижения_клуба)
                .WithRequired(e => e.Чемпионат_в_сезоне)
                .WillCascadeOnDelete(false);
        }
    }
}
