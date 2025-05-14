using System;
using System.ComponentModel.DataAnnotations;

namespace EduProject_TADProgrammer.Entities
{
    public class Semester
    {
        [Key]
        public long Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Name { get; set; } // Ví dụ: "HK1_2023-2024", "HK2_2023-2024"

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public string ?Description { get; set; } // Tùy chọn: Mô tả thêm về kỳ học
    }
}