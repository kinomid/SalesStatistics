// TODO:4 Добавляем модель SalesStatisticsContext и описываем конфигурацию императивно в коде и создаем миграцию ( Enable-Migrations, Add-Migration)

using SalesStatistics.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesStatistics.Data {
    class SalesStatisticsContext : DbContext {
        public SalesStatisticsContext()
            : base(nameOrConnectionString: "Server=.;Database=SalesStatistics;Trusted_Connection=True;") {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            modelBuilder.Entity<SalesStatistic>().HasKey(ss => new { ss.Type1_ClassifierId, ss.Type2_ClassifierId, ss.Type3_ClassifierId, ss.Type4_ClassifierId, ss.ShipDate });
            modelBuilder.Entity<SalesStatistic>().Property(ss => ss.Type1_ClassifierId).HasMaxLength(50).IsRequired().IsUnicode();
            modelBuilder.Entity<SalesStatistic>().Property(ss => ss.Type2_ClassifierId).HasMaxLength(50).IsRequired().IsUnicode();
            modelBuilder.Entity<SalesStatistic>().Property(ss => ss.Type3_ClassifierId).HasMaxLength(50).IsRequired().IsUnicode();
            modelBuilder.Entity<SalesStatistic>().Property(ss => ss.Type4_ClassifierId).HasMaxLength(50).IsRequired().IsUnicode();
            modelBuilder.Entity<SalesStatistic>().Property(ss => ss.Amount).HasColumnType("numeric").HasPrecision(28, 12);
            modelBuilder.Entity<SalesStatistic>().Property(ss => ss.ShipDate).HasColumnType("date");
            modelBuilder.Entity<SalesStatistic>().HasRequired(ss => ss.Type1_Classiifer).WithMany().HasForeignKey(ss => ss.Type1_ClassifierId);
            modelBuilder.Entity<SalesStatistic>().HasRequired(ss => ss.Type2_Classiifer).WithMany().HasForeignKey(ss => ss.Type2_ClassifierId);
            modelBuilder.Entity<SalesStatistic>().HasRequired(ss => ss.Type3_Classiifer).WithMany().HasForeignKey(ss => ss.Type3_ClassifierId);
            modelBuilder.Entity<SalesStatistic>().HasRequired(ss => ss.Type4_Classiifer).WithMany().HasForeignKey(ss => ss.Type4_ClassifierId);


            modelBuilder.Entity<Type1_Classifier>().HasKey(c => c.ClassifierId);
            modelBuilder.Entity<Type1_Classifier>().Property(c => c.ClassifierId).HasMaxLength(50).IsRequired().IsUnicode();
            modelBuilder.Entity<Type1_Classifier>().Property(c => c.ClassifierName).HasMaxLength(50).IsRequired().IsUnicode();

            modelBuilder.Entity<Type2_Classifier>().HasKey(c => c.ClassifierId);
            modelBuilder.Entity<Type2_Classifier>().Property(c => c.ClassifierId).HasMaxLength(50).IsRequired().IsUnicode();
            modelBuilder.Entity<Type2_Classifier>().Property(c => c.ClassifierName).HasMaxLength(50).IsRequired().IsUnicode();

            modelBuilder.Entity<Type3_Classifier>().HasKey(c => c.ClassifierId);
            modelBuilder.Entity<Type3_Classifier>().Property(c => c.ClassifierId).HasMaxLength(50).IsRequired().IsUnicode();
            modelBuilder.Entity<Type3_Classifier>().Property(c => c.ClassifierName).HasMaxLength(50).IsRequired().IsUnicode();

            modelBuilder.Entity<Type4_Classifier>().HasKey(c => c.ClassifierId);
            modelBuilder.Entity<Type4_Classifier>().Property(c => c.ClassifierId).HasMaxLength(50).IsRequired().IsUnicode();
            modelBuilder.Entity<Type4_Classifier>().Property(c => c.ClassifierName).HasMaxLength(50).IsRequired().IsUnicode();
        }


    }
}
