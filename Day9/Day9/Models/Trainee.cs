using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;
public enum Gender { Male, Female }
public class Trainee
{
    [Key]
    public int ID { get; set; }

    [Required, StringLength(100)]
    public string Name { get; set; }

    [Required]
    public Gender Gender { get; set; }

    [Required, EmailAddress]
    public string Email { get; set; }

    [Required, Phone]
    public string MobileNo { get; set; }

    [DataType(DataType.Date)]
    public DateTime Birthdate { get; set; }

    [ForeignKey("Trk")]
    public int TrackID { get; set; }
    public virtual Track? Trk { get; set; }
    public virtual ICollection<TraineeCourse>? TraineeCourses { get; set; }
}