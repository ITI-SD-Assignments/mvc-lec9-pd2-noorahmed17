using System.ComponentModel.DataAnnotations;

public class Course
{
    [Key]
    public int ID { get; set; }

    [Required, StringLength(100)]
    public string Topic { get; set; }

    [Range(0, 100)]
    public float Grade { get; set; }

    // Navigation Property
    public virtual ICollection<TraineeCourse>? TraineeCourses { get; set; }
}