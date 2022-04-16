using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestingSystem.Models.EntityDB
{
    [Table("u1478686_testing_system.user_test")]
    public partial class UserTest
    {
        [Key]
        [Column("user_id", Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UserId { get; set; }

        [Key]
        [Column("test_id", Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TestId { get; set; }
        
        [Column("result")]
        public int Result { get; set; }

        [Column("time")]
        public TimeSpan Time { get; set; }
        
        [Column("scores")]
        public int Scores { get; set; }
        
        [Column("date_started")]
        public DateTime DateStarted { get; set; }

        [Column("date_finished" ,TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime DateFinished { get; set; }

        public virtual Test Test { get; set; }

        public virtual User User { get; set; }
    }
}
