// TODO:5 файл создается с помощью миграции, реализуем метод Seed для наполнения БД тестовыми данными (Update-Database )
namespace SalesStatistics.Migrations {
    using Data;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SalesStatistics.Data.SalesStatisticsContext> {
        public Configuration() {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SalesStatisticsContext context) {
            context.Set<Type1_Classifier>().AddOrUpdate(c => c.ClassifierId, new Type1_Classifier[] {
                new Type1_Classifier { ClassifierId="Classifier1Id1", ClassifierName = "Classifier1Name1"},
                new Type1_Classifier { ClassifierId="Classifier1Id2", ClassifierName = "Classifier1Name2"},
                new Type1_Classifier { ClassifierId="Classifier1Id3", ClassifierName = "Classifier1Name3"},
                new Type1_Classifier { ClassifierId="Classifier1Id4", ClassifierName = "Classifier1Name4"},
                new Type1_Classifier { ClassifierId="Classifier1Id5", ClassifierName = "Classifier1Name5"},
                new Type1_Classifier { ClassifierId="Classifier1Id6", ClassifierName = "Classifier1Name6"},
                new Type1_Classifier { ClassifierId="Classifier1Id7", ClassifierName = "Classifier1Name7"},
                new Type1_Classifier { ClassifierId="Classifier1Id8", ClassifierName = "Classifier1Name8"},
            });

            context.Set<Type2_Classifier>().AddOrUpdate(c => c.ClassifierId, new Type2_Classifier[] {
                new Type2_Classifier { ClassifierId="Classifier2Id1", ClassifierName = "Classifier2Name1"},
                new Type2_Classifier { ClassifierId="Classifier2Id2", ClassifierName = "Classifier2Name2"},
                new Type2_Classifier { ClassifierId="Classifier2Id3", ClassifierName = "Classifier2Name3"},
                new Type2_Classifier { ClassifierId="Classifier2Id4", ClassifierName = "Classifier2Name4"},
                new Type2_Classifier { ClassifierId="Classifier2Id5", ClassifierName = "Classifier2Name5"},
                new Type2_Classifier { ClassifierId="Classifier2Id6", ClassifierName = "Classifier2Name6"},
                new Type2_Classifier { ClassifierId="Classifier2Id7", ClassifierName = "Classifier2Name7"},
                new Type2_Classifier { ClassifierId="Classifier2Id8", ClassifierName = "Classifier2Name8"},
            });

            context.Set<Type3_Classifier>().AddOrUpdate(c => c.ClassifierId, new Type3_Classifier[] {
                new Type3_Classifier { ClassifierId="Classifier3Id1", ClassifierName = "Classifier3Name1"},
                new Type3_Classifier { ClassifierId="Classifier3Id2", ClassifierName = "Classifier3Name2"},
                new Type3_Classifier { ClassifierId="Classifier3Id3", ClassifierName = "Classifier3Name3"},
                new Type3_Classifier { ClassifierId="Classifier3Id4", ClassifierName = "Classifier3Name4"},
                new Type3_Classifier { ClassifierId="Classifier3Id5", ClassifierName = "Classifier3Name5"},
                new Type3_Classifier { ClassifierId="Classifier3Id6", ClassifierName = "Classifier3Name6"},
                new Type3_Classifier { ClassifierId="Classifier3Id7", ClassifierName = "Classifier3Name7"},
                new Type3_Classifier { ClassifierId="Classifier3Id8", ClassifierName = "Classifier3Name8"},
            });

            context.Set<Type4_Classifier>().AddOrUpdate(c => c.ClassifierId, new Type4_Classifier[] {
                new Type4_Classifier { ClassifierId="Classifier4Id1", ClassifierName = "Classifier4Name1"},
                new Type4_Classifier { ClassifierId="Classifier4Id2", ClassifierName = "Classifier4Name2"},
                new Type4_Classifier { ClassifierId="Classifier4Id3", ClassifierName = "Classifier4Name3"},
                new Type4_Classifier { ClassifierId="Classifier4Id4", ClassifierName = "Classifier4Name4"},
                new Type4_Classifier { ClassifierId="Classifier4Id5", ClassifierName = "Classifier4Name5"},
                new Type4_Classifier { ClassifierId="Classifier4Id6", ClassifierName = "Classifier4Name6"},
                new Type4_Classifier { ClassifierId="Classifier4Id7", ClassifierName = "Classifier4Name7"},
                new Type4_Classifier { ClassifierId="Classifier4Id8", ClassifierName = "Classifier4Name8"},
            });

            context.Set<SalesStatistic>().AddOrUpdate(ss => new { ss.Type1_ClassifierId, ss.Type2_ClassifierId, ss.ShipDate, ss.Type3_ClassifierId, ss.Type4_ClassifierId },
                new SalesStatistic[] {
                new SalesStatistic { Type1_ClassifierId="Classifier1Id2", Type2_ClassifierId = "Classifier2Id2", Type3_ClassifierId="Classifier3Id2", Type4_ClassifierId = "Classifier4Id2", ShipDate=DateTime.Parse("4/11/2018"), Amount=1},
                new SalesStatistic { Type1_ClassifierId="Classifier1Id2", Type2_ClassifierId = "Classifier2Id3", Type3_ClassifierId="Classifier3Id2", Type4_ClassifierId = "Classifier4Id3", ShipDate=DateTime.Parse("4/12/2018"), Amount=0},
                new SalesStatistic { Type1_ClassifierId="Classifier1Id1", Type2_ClassifierId = "Classifier2Id2", Type3_ClassifierId="Classifier3Id1", Type4_ClassifierId = "Classifier4Id2", ShipDate=DateTime.Parse("2/12/2018"), Amount=100},
                new SalesStatistic { Type1_ClassifierId="Classifier1Id5", Type2_ClassifierId = "Classifier2Id5", Type3_ClassifierId="Classifier3Id5", Type4_ClassifierId = "Classifier4Id5", ShipDate=DateTime.Parse("4/12/2018"), Amount=500},
                new SalesStatistic { Type1_ClassifierId="Classifier1Id1", Type2_ClassifierId = "Classifier2Id3", Type3_ClassifierId="Classifier3Id1", Type4_ClassifierId = "Classifier4Id3", ShipDate=DateTime.Parse("1/12/2018"), Amount=10},
                new SalesStatistic { Type1_ClassifierId="Classifier1Id7", Type2_ClassifierId = "Classifier2Id3", Type3_ClassifierId="Classifier3Id7", Type4_ClassifierId = "Classifier4Id3", ShipDate=DateTime.Parse("4/12/2018"), Amount=11},
                new SalesStatistic { Type1_ClassifierId="Classifier1Id3", Type2_ClassifierId = "Classifier2Id8", Type3_ClassifierId="Classifier3Id3", Type4_ClassifierId = "Classifier4Id8", ShipDate=DateTime.Parse("1/12/2017"), Amount=1000},
                new SalesStatistic { Type1_ClassifierId="Classifier1Id1", Type2_ClassifierId = "Classifier2Id1", Type3_ClassifierId="Classifier3Id1", Type4_ClassifierId = "Classifier4Id1", ShipDate=DateTime.Parse("4/12/2018"), Amount=30},

                new SalesStatistic { Type1_ClassifierId="Classifier1Id1", Type2_ClassifierId = "Classifier2Id2", Type3_ClassifierId="Classifier3Id2", Type4_ClassifierId = "Classifier4Id8", ShipDate=DateTime.Parse("5/11/2018"), Amount=11},
                new SalesStatistic { Type1_ClassifierId="Classifier1Id2", Type2_ClassifierId = "Classifier2Id3", Type3_ClassifierId="Classifier3Id3", Type4_ClassifierId = "Classifier4Id5", ShipDate=DateTime.Parse("4/12/2016"), Amount=15},
                new SalesStatistic { Type1_ClassifierId="Classifier1Id5", Type2_ClassifierId = "Classifier2Id2", Type3_ClassifierId="Classifier3Id1", Type4_ClassifierId = "Classifier4Id2", ShipDate=DateTime.Parse("2/12/2018"), Amount=111},
                new SalesStatistic { Type1_ClassifierId="Classifier1Id6", Type2_ClassifierId = "Classifier2Id6", Type3_ClassifierId="Classifier3Id5", Type4_ClassifierId = "Classifier4Id8", ShipDate=DateTime.Parse("4/11/2017"), Amount=500},
                new SalesStatistic { Type1_ClassifierId="Classifier1Id1", Type2_ClassifierId = "Classifier2Id3", Type3_ClassifierId="Classifier3Id5", Type4_ClassifierId = "Classifier4Id3", ShipDate=DateTime.Parse("1/12/2018"), Amount=12.6m},
                new SalesStatistic { Type1_ClassifierId="Classifier1Id5", Type2_ClassifierId = "Classifier2Id2", Type3_ClassifierId="Classifier3Id7", Type4_ClassifierId = "Classifier4Id5", ShipDate=DateTime.Parse("11/12/2018"), Amount=11.1m},
                new SalesStatistic { Type1_ClassifierId="Classifier1Id3", Type2_ClassifierId = "Classifier2Id5", Type3_ClassifierId="Classifier3Id8", Type4_ClassifierId = "Classifier4Id4", ShipDate=DateTime.Parse("1/12/2017"), Amount=1000},
                new SalesStatistic { Type1_ClassifierId="Classifier1Id1", Type2_ClassifierId = "Classifier2Id1", Type3_ClassifierId="Classifier3Id1", Type4_ClassifierId = "Classifier4Id1", ShipDate=DateTime.Parse("4/12/2018"), Amount=30},

                new SalesStatistic { Type1_ClassifierId="Classifier1Id1", Type2_ClassifierId = "Classifier2Id2", Type3_ClassifierId="Classifier3Id2", Type4_ClassifierId = "Classifier4Id7", ShipDate=DateTime.Parse("5/11/2018"), Amount=13.005m},
                new SalesStatistic { Type1_ClassifierId="Classifier1Id2", Type2_ClassifierId = "Classifier2Id3", Type3_ClassifierId="Classifier3Id4", Type4_ClassifierId = "Classifier4Id5", ShipDate=DateTime.Parse("4/12/2016"), Amount=15545},
                new SalesStatistic { Type1_ClassifierId="Classifier1Id5", Type2_ClassifierId = "Classifier2Id2", Type3_ClassifierId="Classifier3Id1", Type4_ClassifierId = "Classifier4Id7", ShipDate=DateTime.Parse("2/12/2018"), Amount=111.265m},
                new SalesStatistic { Type1_ClassifierId="Classifier1Id6", Type2_ClassifierId = "Classifier2Id6", Type3_ClassifierId="Classifier3Id5", Type4_ClassifierId = "Classifier4Id8", ShipDate=DateTime.Parse("3/11/2017"), Amount=500},
                new SalesStatistic { Type1_ClassifierId="Classifier1Id1", Type2_ClassifierId = "Classifier2Id3", Type3_ClassifierId="Classifier3Id5", Type4_ClassifierId = "Classifier4Id5", ShipDate=DateTime.Parse("1/12/2018"), Amount=12.0006m},
                new SalesStatistic { Type1_ClassifierId="Classifier1Id5", Type2_ClassifierId = "Classifier2Id2", Type3_ClassifierId="Classifier3Id7", Type4_ClassifierId = "Classifier4Id5", ShipDate=DateTime.Parse("1/11/2018"), Amount=12.1m},
                new SalesStatistic { Type1_ClassifierId="Classifier1Id3", Type2_ClassifierId = "Classifier2Id5", Type3_ClassifierId="Classifier3Id8", Type4_ClassifierId = "Classifier4Id6", ShipDate=DateTime.Parse("1/12/2017"), Amount=10},
                new SalesStatistic { Type1_ClassifierId="Classifier1Id1", Type2_ClassifierId = "Classifier2Id1", Type3_ClassifierId="Classifier3Id1", Type4_ClassifierId = "Classifier4Id1", ShipDate=DateTime.Parse("5/11/2018"), Amount=30},

                new SalesStatistic { Type1_ClassifierId="Classifier1Id4", Type2_ClassifierId = "Classifier2Id2", Type3_ClassifierId="Classifier3Id7", Type4_ClassifierId = "Classifier4Id5", ShipDate=DateTime.Parse("5/1/2018"), Amount=13.005m},
                new SalesStatistic { Type1_ClassifierId="Classifier1Id5", Type2_ClassifierId = "Classifier2Id4", Type3_ClassifierId="Classifier3Id6", Type4_ClassifierId = "Classifier4Id5", ShipDate=DateTime.Parse("4/12/2016"), Amount=15545},
                new SalesStatistic { Type1_ClassifierId="Classifier1Id3", Type2_ClassifierId = "Classifier2Id2", Type3_ClassifierId="Classifier3Id1", Type4_ClassifierId = "Classifier4Id7", ShipDate=DateTime.Parse("2/1/2018"), Amount=111.265m},
                new SalesStatistic { Type1_ClassifierId="Classifier1Id8", Type2_ClassifierId = "Classifier2Id4", Type3_ClassifierId="Classifier3Id8", Type4_ClassifierId = "Classifier4Id6", ShipDate=DateTime.Parse("3/11/2017"), Amount=500},
                new SalesStatistic { Type1_ClassifierId="Classifier1Id1", Type2_ClassifierId = "Classifier2Id3", Type3_ClassifierId="Classifier3Id5", Type4_ClassifierId = "Classifier4Id5", ShipDate=DateTime.Parse("1/1/2018"), Amount=12.0006m},
                new SalesStatistic { Type1_ClassifierId="Classifier1Id8", Type2_ClassifierId = "Classifier2Id4", Type3_ClassifierId="Classifier3Id7", Type4_ClassifierId = "Classifier4Id5", ShipDate=DateTime.Parse("1/1/2018"), Amount=12.1m},
                new SalesStatistic { Type1_ClassifierId="Classifier1Id5", Type2_ClassifierId = "Classifier2Id4", Type3_ClassifierId="Classifier3Id8", Type4_ClassifierId = "Classifier4Id1", ShipDate=DateTime.Parse("1/1/2017"), Amount=10},
                new SalesStatistic { Type1_ClassifierId="Classifier1Id1", Type2_ClassifierId = "Classifier2Id1", Type3_ClassifierId="Classifier3Id1", Type4_ClassifierId = "Classifier4Id1", ShipDate=DateTime.Parse("5/11/2018"), Amount=30},
            });


        }
    }
}
