using System;

namespace StudentCRUD.Models
{
    public class StudentViewModel
    {
        public int Id { get; set; }

        public int ClassId { get; set; }

        public int CountryId { get; set; }

        public string? Name { get; set; }

        public DateTime DateOfBirth { get; set; }
    }
}
