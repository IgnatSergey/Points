using System;
using System.Collections.Generic;

namespace Points.Domain
{
    public class Point
    {
        public Guid Id { get; set; }
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public int Radius { get; set; }
        public string Color { get; set; }
        public List<Comment> Comments { get; set; } = new List<Comment>();
    }
}
