using System.Linq;
using Points.Domain;

namespace Points.Persistence
{
    public class DbInitializer
    {
        public static void Initialize(PointsDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            Point one = new Point { PositionX = 50, PositionY = 20, Radius = 10, Color = "b5b5b1" };
            Point two = new Point { PositionX = 300, PositionY = 200, Radius = 15, Color = "d63215" };
            Point three = new Point { PositionX = 500, PositionY = 300, Radius = 20, Color = "0ec469" };

            Comment comment1 = new Comment { Text = "comment1", BackgroundColor = "ffffff", Point = one };
            Comment comment2 = new Comment { Text = "comment2", BackgroundColor = "d6d618", Point = one };
            Comment comment3 = new Comment { Text = "comment3", BackgroundColor = "c4c2c3", Point = two };
            Comment comment4 = new Comment { Text = "comment4", BackgroundColor = "d6d618", Point = two };
            Comment comment5 = new Comment { Text = "comment5", BackgroundColor = "d6d618", Point = two };
            Comment comment6 = new Comment { Text = "looooooooong comment6", BackgroundColor = "d6d618", Point = two };
            Comment comment7 = new Comment { Text = "comment7", BackgroundColor = "d6d618", Point = two };
            Comment comment8 = new Comment { Text = "comment8", BackgroundColor = "d6d618", Point = two };
            Comment comment9 = new Comment { Text = "comment9", BackgroundColor = "d6d618", Point = two };
            Comment comment10 = new Comment { Text = "comment10", BackgroundColor = "d6d618", Point = three };
            Comment comment11 = new Comment { Text = "comment11", BackgroundColor = "c4c2c3", Point = three };
            Comment comment12 = new Comment { Text = "comment12", BackgroundColor = "d6d618", Point = three };
            Comment comment13 = new Comment { Text = "comment13", BackgroundColor = "c4c2c3", Point = three };


            if (!context.Points.Any())
            {
                context.AddRange(one, two, three);
                context.AddRange(comment1, comment2, comment3, comment4, comment5, comment6, comment7, comment8, comment9, comment10, comment11, comment12, comment13);
            }
            context.SaveChanges();
        }
    }
}
