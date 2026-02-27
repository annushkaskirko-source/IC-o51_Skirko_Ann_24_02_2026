using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IC_o51_Skirko_Ann_08_02_2026.Models
{
    // Модель квесту (тільки дані)
    public class Quest
    {
        // Унікальний ідентифікатор
        public int Id { get; set; }

        public string Name { get; private set; }
        public string Description { get; private set; }
        public QuestCategory Category { get; private set; }
        public QuestDifficulty Difficulty { get; private set; }
        public QuestStatus Status { get; private set; }
        public int ExperienceReward { get; private set; }

        // Дата створення
        public DateTime CreatedDate { get; private set; }

        // Дата виконання
        public DateTime? CompletedDate { get; private set; }
        
        // Конструктор
        public Quest(string name,
                     string description,
                     QuestCategory category,
                     QuestDifficulty difficulty)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Назва квесту не може бути порожньою.");

            Name = name;
            Description = description;
            Category = category;
            Difficulty = difficulty;
            Status = QuestStatus.Active;
            CreatedDate = DateTime.Now;
            ExperienceReward = CalculateReward();
        }

        // Розрахунок нагороди
        private int CalculateReward()
        {
            switch (Difficulty)
            {
                case QuestDifficulty.Easy: return 20;
                case QuestDifficulty.Medium: return 50;
                case QuestDifficulty.Hard: return 100;
                default: return 0;
            }
        }

        // Виконати квест
        public void Complete()
        {
            if (Status == QuestStatus.Active)
            {
                Status = QuestStatus.Completed;
                CompletedDate = DateTime.Now;
            }
        }

        // Відображення в ListBox
        public override string ToString()
        {
            return $"[{Id}] {Name} | {Category} | {Difficulty} | {Status}";
        }
    }
}
