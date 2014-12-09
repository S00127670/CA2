using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace S00127670_CA2.Models
{
    //internal class MovieDbInit : DropCreateDatabaseAlways<MovieDb>
    //{
    //    protected override void Seed(MovieDb context)
    //    {
    //        var actors = new List<Actor>()
    //        {
    //            new Actor(){actorName="Will Ferrell", actorRole="Ron Burgundy"},
    //            new Actor(){actorName="Christina Applegate", actorRole="Veronica Corningstone"},
    //            new Actor(){actorName="Will Ferrell", actorRole="Dr. Rick Marshall"},
    //            new Actor(){actorName="Anna Friel", actorRole="Holly Cantrell"},
    //            new Actor(){actorName="Mark Wahlberg", actorRole="Bob Lee Swagger"},
    //            new Actor(){actorName="Kate Mara", actorRole="Sarah Fenn"},
    //            new Actor(){actorName="Johnny Depp", actorRole="Jack Sparrow"},
    //            new Actor(){actorName="Keira Knightley", actorRole="Elizabeth Swann"},
    //            new Actor(){actorName="Patrick Wilson", actorRole="Josh Lambert"},
    //            new Actor(){actorName="Rose Byrne", actorRole="Renai Lambert"},
    //            new Actor(){actorName="Rose Byrne", actorRole="Kelly Radner"},
    //            new Actor(){actorName="Zac Efron", actorRole="Teddy Sanders"}
    //        };
    //        actors.ForEach(a => context.actor.Add(a));
    //        context.SaveChanges();

    //        var movies = new List<Movie>()
    //        {
    //            new Movie()
    //            {
    //                movieTitle="Anchorman 2",
    //                movieGenre=MovieGenre.Comedy,
    //                movieAct = new List<MovieActor>()

    //            },
    //            new Movie()
    //            {
    //                movieTitle="Land of the Lost",
    //                movieGenre=MovieGenre.Animation,
    //                movieAct = new List<MovieActor>()
    //            },
    //            new Movie()
    //            {
    //                movieTitle="Shooter",
    //                movieGenre=MovieGenre.Action,
    //                movieAct = new List<MovieActor>()
    //            },
    //            new Movie()
    //            {
    //                movieTitle="Pirates of the Caribbean",
    //                movieGenre=MovieGenre.Adventure,
    //                movieAct = new List<MovieActor>()
                    
    //            },
    //            new Movie()
    //            {
    //                movieTitle="Insidious 2",
    //                movieGenre=MovieGenre.Horror,
    //                movieAct = new List<MovieActor>()
    //            },
    //            new Movie()
    //            {
    //                movieTitle="Bad Neighbours",
    //                movieGenre=MovieGenre.Comedy,
    //                movieAct = new List<MovieActor>()
    //            }           
    //        };
    //        movies.ForEach(m => context.movie.Add(m));
    //        context.SaveChanges();
    //    }
    //}

    public enum MovieGenre
    {
        Action, Adventure, Animation, Comedy, Horror
    }

    public class Movie
    {
        [Key]
        public int movieId { get; set; }
        [DisplayName("Title"), Required]
        public string movieTitle { get; set; }
        [DisplayName("Genre"), Required]
        public MovieGenre movieGenre { get; set; }
        public int actorId { get; set; }
        //public virtual List<MovieActor> movieAct { get; set; }
        [DisplayName("# (Actors)")]
        public virtual List<Actor> actors { get; set; }
        //public virtual List<Actor> actors
        //{
        //    get { return (movieAct == null) ? null : movieAct.Select(ma => ma.characters).ToList(); }
        //}
    }

    public class Actor
    {
        [Key]
        public int actorId { get; set; }
        [DisplayName("Name"), Required]
        public string actorName { get; set; }
        [DisplayName("Character"), Required]
        public string actorRole { get; set; }
        public int movieId { get; set; }
        //public virtual List<MovieActor> actorMovies { get; set; }
        //public virtual List<Movie> movies
        //{
        //    get { return (actorMovies == null) ? null : actorMovies.Select(am => am.films).ToList(); }
        //}
        [DisplayName("Movies")]
        public virtual Movie Movie { get; set; }
    }

    public class MovieDb : DbContext
    {
        public DbSet<Movie> movie { get; set; }
        public DbSet<Actor> actor { get; set; }
        //public DbSet<MovieActor> movieActors { get; set; }
        public MovieDb() : base("MovieDb") { }
    }

    //public class MovieActor
    //{
    //    [Key, Column(Order = 0)]
    //    public int movieId { get; set; }
    //    [Key, Column(Order = 1)]
    //    public int actorId { get; set; }
    //    public bool Discounted { get; set; }
    //    public virtual Movie films { get; set; }
    //    public virtual Actor characters { get; set; }
    //}

    public class MovieDbInit : DropCreateDatabaseAlways<MovieDb>
    {
        protected override void Seed(MovieDb context)
        {
            var seedMovieData = new List<Movie>()
            {
                new Movie(){movieTitle="Anchorman 2", movieGenre=MovieGenre.Comedy, actors=
                    new List<Actor>()
                    {
                        new Actor(){actorName="Will Ferrell", actorRole="Ron Burgundy"},
                        new Actor(){actorName="Christina Applegate", actorRole="Veronica Corningstone"}
                    }},
                new Movie(){movieTitle="Land of the Lost", movieGenre=MovieGenre.Animation, actors=
                    new List<Actor>()
                    {
                        new Actor(){actorName="Will Ferrell", actorRole="Dr. Rick Marshall"},
                        new Actor(){actorName="Anna Friel", actorRole="Holly Cantrell"}
                    }},
                new Movie(){movieTitle="Shooter", movieGenre=MovieGenre.Action, actors=
                    new List<Actor>()
                    {
                        new Actor(){actorName="Mark Wahlberg", actorRole="Bob Lee Swagger"},
                        new Actor(){actorName="Kate Mara", actorRole="Sarah Fenn"}
                    }},
                new Movie(){movieTitle="Pirates of the Caribbean", movieGenre=MovieGenre.Adventure, actors=
                    new List<Actor>()
                    {
                        new Actor(){actorName="Johnny Depp", actorRole="Jack Sparrow"},
                        new Actor(){actorName="Keira Knightley", actorRole="Elizabeth Swann"}
                    }},
                new Movie(){movieTitle="Insidious 2", movieGenre=MovieGenre.Horror, actors=
                    new List<Actor>()
                    {
                        new Actor(){actorName="Patrick Wilson", actorRole="Josh Lambert"},
                        new Actor(){actorName="Rose Byrne", actorRole="Renai Lambert"}
                    }},
                new Movie(){movieTitle="Bad Neighbours", movieGenre=MovieGenre.Comedy, actors=
                    new List<Actor>()
                    {
                        new Actor(){actorName="Rose Byrne", actorRole="Kelly Radner"},
                        new Actor(){actorName="Zac Efron", actorRole="Teddy Sanders"}
                    }}
            };
            seedMovieData.ForEach(m => context.movie.Add(m));
            context.SaveChanges();
            base.Seed(context);
        }
    }
}