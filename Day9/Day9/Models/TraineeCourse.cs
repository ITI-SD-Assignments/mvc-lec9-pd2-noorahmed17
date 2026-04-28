using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class TraineeCourse
{
    [ForeignKey("Trainee")]
    public int TraineeID { get; set; }

    [ForeignKey("Course")]
    public int CourseID { get; set; }
    public float Grade { get; set; }
    public virtual Trainee? Trainee { get; set; }
    public virtual Course? Course { get; set; }
}