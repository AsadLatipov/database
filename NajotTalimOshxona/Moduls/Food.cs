using System.ComponentModel.DataAnnotations;


namespace NajotTalimOshxona.Moduls
{
    internal class Food
    {

        public int Count { get; set; } = 1;

        public bool IsActive { get; set; } = true;

        [Required]
        public string Name { get; set; }

        [Required]
        public double Cost { get; set; }

        [Url]
        [Required]
        public string Photolink { get; set; }


        [Required]
        public string Description { get; set; }


    }
}
