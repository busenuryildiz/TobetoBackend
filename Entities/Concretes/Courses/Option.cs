using Core.Entities;

namespace Entities.Concretes.Courses;

public class Option : Entity<int>
{
    public string Answer { get; set; }
    // Diğer özellikler
    public int QuestionId { get; set; }
    public bool IsCorrect { get; set; }
    // Doğru şık olup olmadığını belirtmek için IsCorrect alanı
    public Question Question { get; set; }
    // Şık, bir soruya (Question) ait olabilir
}