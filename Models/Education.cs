using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace APi.Models
{
    [Table("tb_m_educations")]
    public class Education
    {
        [Key, Column("id")]
        public int Id { get; set; }

        [Required, Column("major")]
        public string Major { get; set; }

        [Required, Column("degree", TypeName = "nchar(2)")]
        public string Degree { get; set; }

        [Required, Column("gpa")]
        public float Gpa { get; set; }

        [Required, Column("university_id")]
        public int UniversityId { get; set; }


        //Cardinality and Relations 
        [JsonIgnore]
        [ForeignKey("UniversityId")]
        public University? University { get; set; } //Kalo dibuat objek gini maka one 

        [JsonIgnore]
        public ICollection<Profiling>? Profilings { get; set; }
    }


}
