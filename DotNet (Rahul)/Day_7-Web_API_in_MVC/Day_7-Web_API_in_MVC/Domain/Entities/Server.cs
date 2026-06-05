using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Day_7_Web_API_in_MVC.Domain.Entities
{

    public partial class Server
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        [Unicode(false)]
        public string IpAddress { get; set; } = null!;
        public int RamGb { get; set; }

        public bool IsOnline { get; set; }
    }
}