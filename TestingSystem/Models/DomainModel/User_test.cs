namespace TestingSystem.Models.DomainModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("u1478686_testing_system.user_test")]
    public partial class User_test
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int user_id { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int test_id { get; set; }

        public int result { get; set; }

        public TimeSpan time { get; set; }

        public int scores { get; set; }

        public DateTime date_started { get; set; }

        [Column(TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime date_finished { get; set; }

        public virtual Test test { get; set; }

        public virtual User user { get; set; }
    }
}
