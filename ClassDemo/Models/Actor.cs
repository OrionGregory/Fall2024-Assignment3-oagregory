namespace ClassDemo.Models
{
    public class Actor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string IMDBLink { get; set; }
        public byte[]? Photo { get; set; }

        // Navigation property to establish the relationship with Movie
        public ICollection<MovieActor> MovieActors { get; set; } = new List<MovieActor>();

    }
}
