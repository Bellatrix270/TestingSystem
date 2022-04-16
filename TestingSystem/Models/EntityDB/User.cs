using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestingSystem.Models.EntityDB
{
    [Table("u1478686_testing_system.users")]
    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            UserTest = new HashSet<UserTest>();
        }
        
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("login")]
        [StringLength(255)]
        public string Login { get; set; }

        [Required]
        [Column("password")]
        [StringLength(255)]
        public string Password { get; set; }

        [Required]
        [Column("first_name")]
        [StringLength(255)]
        public string FirstName { get; set; }

        [Required]
        [Column("last_name")]
        [StringLength(255)]
        public string LastName { get; set; }

        [Required]
        [Column("patronymic")]
        [StringLength(255)]
        public string Patronymic { get; set; }

        [Column(TypeName = "enum")]
        [Required]
        [StringLength(65532)]
        public string Role { get; set; }
        
        [Column("test_field")]
        [StringLength(255)]
        public string TestField { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserTest> UserTest { get; set; }
    }
}
