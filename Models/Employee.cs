using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace APi.Models;

[Table("tb_m_employees")]   //Data Anotasi yaitu pake kurung [ ]
    public class Employee
    {
        [Key,Column("nik", TypeName = "nchar(5)")]
        public string NIK{ get; set; }

        [Required, Column("first_name", TypeName ="nvarchar(50)")]
        public string FirstName { get; set; }

        [Column("last_name"), MaxLength(50)]
        public string? LastName { get; set; }

        [Required, Column("birthdate")]
        public DateTime BirthDate { get; set; }

        [Required, Column("gender")]
        public GenderEnum Gender { get; set; }

        [Required, Column("hiring_date")]
        public DateTime HiringDate { get; set; } = DateTime.Now;

        [Required, Column("email"), MaxLength(50)]
        public string Email { get; set; }

        [Column("phone_number"), MaxLength(20)]
        public string? PhoneNumber { get; set; }

        [Column("manager_id", TypeName = "nchar(5)")]
        public string? ManagerId{ get; set; }


    //Cardinality
    [JsonIgnore]
    public ICollection<Profiling>? Profilings { get; set; }

    [JsonIgnore]
    public Account? Account { get; set; }

    [JsonIgnore]
    public ICollection<Employee>? Employees { get; set; }

    [JsonIgnore]
    public Employee? Managers { get; set; }
}
public enum GenderEnum
{
    Male,
    Female
}


