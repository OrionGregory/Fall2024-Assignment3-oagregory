namespace ClassDemo.Models
{
    public class ActorDetailsViewModel
    {
        public Actor Actor { get; set; }
        public List<Movie> Movies { get; set; }

        public ActorDetailsViewModel() { }

        public ActorDetailsViewModel(Actor actor, List<Movie> movies)
        {
            Actor = actor;
            Movies = movies;
        }
    }
}
