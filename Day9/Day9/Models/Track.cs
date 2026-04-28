using System.ComponentModel.DataAnnotations;

public class Track
{
    [Key]
    public int ID { get; set; }

    [Required, StringLength(50)]
    public string Name { get; set; }

    [StringLength(200)]
    public string Description { get; set; }
    public virtual IEnumerable<Trainee>? Trainees { get; set; }
}