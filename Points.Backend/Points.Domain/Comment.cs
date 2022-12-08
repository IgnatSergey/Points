using System;

namespace Points.Domain
{
    public class Comment
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public string BackgroundColor { get; set; }
        //public int PointForeignKey { get; set; }
        public Point Point { get; set; }
    }
}
