using System;

namespace Lab8  
{
    // Перечисление для типа жизненного цикла растения
    public enum LifeCycle
    {
        Однолетнее,
        Двулетнее,
        Многолетнее
    }
    
    // Перечисление для категории растения
    public enum PlantCategory
    {
        Декоративное,
        Пищевое,
        Лекарственное
    }

    // Базовый класс Растение
    public class Plant
    {
        protected string name;
        protected double height;
        protected LifeCycle lifeCycle;
        protected PlantCategory category;
        
        // Конструктор базового класса
        public Plant(string name, double height, LifeCycle lifeCycle, PlantCategory category)
        {
            this.name = name;
            this.height = height;
            this.lifeCycle = lifeCycle;
            this.category = category;
        }
        
        // ВИРТУАЛЬНОЕ свойство (может быть переопределено)
        public virtual string Description
        {
            get { return $"Растение: {name}, Высота: {height}м, Жизненный цикл: {lifeCycle}"; }
        }
        
        // ВИРТУАЛЬНЫЙ метод (может быть переопределен)
        public virtual void Grow()
        {
            Console.WriteLine($"{name} растет...");
        }
        
        // Обычный метод базового класса
        public virtual string GetInfo()
        {
            return $"Название: {name}, Категория: {category}";
        }
        
        public string Name => name;
        public double Height => height;
    }
    
    // Производный класс Трава
    public class Grass : Plant
    {
        private bool isEdible;
        private int leafCount;
        
        // Вызов базового конструктора
        public Grass(string name, double height, LifeCycle lifeCycle, PlantCategory category, bool isEdible)
            : base(name, height, lifeCycle, category)
        {
            this.isEdible = isEdible;
            this.leafCount = 0;
        }
        
        // ПЕРЕОПРЕДЕЛЕННОЕ свойство
        public override string Description
        {
            get { return $"Трава: {name}, Высота: {height}м, Съедобная: {isEdible}, Листьев: {leafCount}"; }
        }
        
        // ПЕРЕОПРЕДЕЛЕННЫЙ метод с вызовом базового метода
        public override void Grow()
        {
            base.Grow(); // Вызов базового метода
            leafCount += 5;
            Console.WriteLine($"{name} (трава) быстро растет. Количество листьев: {leafCount}");
        }
        
        public override string GetInfo()
        {
            string baseInfo = base.GetInfo(); // Вызов базового метода
            return $"{baseInfo}, Съедобная: {isEdible}";
        }
    }
    
    // Производный класс Дерево
    public class Tree : Plant
    {
        private double trunkDiameter;
        private int age;
        
        // Вызов базового конструктора
        public Tree(string name, double height, LifeCycle lifeCycle, PlantCategory category, double trunkDiameter)
            : base(name, height, lifeCycle, category)
        {
            this.trunkDiameter = trunkDiameter;
            this.age = 0;
        }
        
        // ПЕРЕОПРЕДЕЛЕННОЕ свойство
        public override string Description
        {
            get { return $"Дерево: {name}, Высота: {height}м, Диаметр ствола: {trunkDiameter}см, Возраст: {age} лет"; }
        }
        
        // ПЕРЕОПРЕДЕЛЕННЫЙ метод с вызовом базового метода
        public override void Grow()
        {
            base.Grow(); // Вызов базового метода
            age++;
            trunkDiameter += 0.5;
            Console.WriteLine($"{name} (дерево) растет. Возраст: {age} лет, Диаметр ствола: {trunkDiameter}см");
        }
        
        public override string GetInfo()
        {
            string baseInfo = base.GetInfo(); // Вызов базового метода
            return $"{baseInfo}, Диаметр ствола: {trunkDiameter}см";
        }
        
        // Дополнительный метод специфичный для дерева
        public void ShedLeaves()
        {
            Console.WriteLine($"{name} сбрасывает листья...");
        }
    }
    
    // Производный класс Кустарник
    public class Shrub : Plant
    {
        private int branchCount;
        private bool hasThorns;
        
        // Вызов базового конструктора
        public Shrub(string name, double height, LifeCycle lifeCycle, PlantCategory category, int branchCount, bool hasThorns)
            : base(name, height, lifeCycle, category)
        {
            this.branchCount = branchCount;
            this.hasThorns = hasThorns;
        }
        
        // ПЕРЕОПРЕДЕЛЕННОЕ свойство
        public override string Description
        {
            get { return $"Кустарник: {name}, Высота: {height}м, Веток: {branchCount}, Шипы: {hasThorns}"; }
        }
        
        // ПЕРЕОПРЕДЕЛЕННЫЙ метод с вызовом базового метода
        public override void Grow()
        {
            base.Grow(); // Вызов базового метода
            branchCount += 2;
            Console.WriteLine($"{name} (кустарник) разрастается. Количество веток: {branchCount}");
        }
        
        public override string GetInfo()
        {
            string baseInfo = base.GetInfo(); // Вызов базового метода
            return $"{baseInfo}, Веток: {branchCount}, Шипы: {hasThorns}";
        }
    }

    public class Lab8 
    {
        public static void Run_1()
        {
            Console.WriteLine("=== ИЕРАРХИЯ КЛАССОВ: РАСТЕНИЯ ===\n");
            
            // Создание массива объектов базового типа (полиморфизм)
            Plant[] plants = new Plant[6];
            
            // Заполнение массива объектами производных классов
            plants[0] = new Grass("Пшеница", 0.8, LifeCycle.Однолетнее, PlantCategory.Пищевое, true);
            plants[1] = new Grass("Газонная трава", 0.1, LifeCycle.Многолетнее, PlantCategory.Декоративное, false);
            plants[2] = new Tree("Дуб", 25.0, LifeCycle.Многолетнее, PlantCategory.Декоративное, 150);
            plants[3] = new Tree("Яблоня", 5.0, LifeCycle.Многолетнее, PlantCategory.Пищевое, 30);
            plants[4] = new Shrub("Роза", 1.5, LifeCycle.Многолетнее, PlantCategory.Декоративное, 10, true);
            plants[5] = new Shrub("Смородина", 1.2, LifeCycle.Многолетнее, PlantCategory.Пищевое, 8, false);
            
            Console.WriteLine("1. Демонстрация полиморфизма через массив:\n");
            
            // Полиморфное поведение: вызов переопределенных методов
            foreach (Plant plant in plants)
            {
                Console.WriteLine(plant.Description); // Переопределенное свойство
                plant.Grow(); // Переопределенный метод
                Console.WriteLine(plant.GetInfo());
                Console.WriteLine(new string('-', 50));
            }
            
            Console.WriteLine("\n2. Демонстрация вызова базовых методов:\n");
            
            // Работа с конкретными типами
            Tree oak = (Tree)plants[2];
            oak.ShedLeaves(); // Метод специфичный для Tree
            
            Console.WriteLine("\n=== Полиморфизм в программе ===");
            Console.WriteLine("1. Массив объявлен как Plant[], но хранит объекты Grass, Tree, Shrub");
            Console.WriteLine("2. В цикле вызывается plant.Grow() - выполняется своя версия для каждого типа");
            Console.WriteLine("3. Свойство Description тоже переопределено в каждом классе");

            Console.WriteLine("\n=== Что реализовано ===");
            Console.WriteLine("- Enum: LifeCycle и PlantCategory");
            Console.WriteLine("- Переопределение свойства: Description (virtual/override)");
            Console.WriteLine("- Переопределение метода: Grow() и GetInfo()");
            Console.WriteLine("- Вызов конструктора базового класса: base(...)");
            Console.WriteLine("- Вызов метода базового класса: base.Grow(), base.GetInfo()");
        }
    }
}
