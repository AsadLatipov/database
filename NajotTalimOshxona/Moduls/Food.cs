using System.ComponentModel.DataAnnotations;


namespace NajotTalimOshxona.Moduls
{
    internal class Food
    {

        [Required]
        public string Name { get; set; }

        [Required]
        public double Cost { get; set; }

        public bool IsActive { get; set; } = true;
            
        [Url]
        [Required]
        public string Photolink { get; set; }

        [Required]
        public string Description { get; set; }


    }
}
