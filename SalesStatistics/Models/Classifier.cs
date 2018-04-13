//TODO:1 создаем абстрактный базовый класс для моделей TypeN_Classifier.cs
namespace SalesStatistics.Models {
    abstract class Classifier {
        public string ClassifierId { get; set; }
        public string ClassifierName { get; set; }
    }
}
