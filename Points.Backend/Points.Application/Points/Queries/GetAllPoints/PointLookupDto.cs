using AutoMapper;
using Points.Application.Common.Mapping;
using Points.Domain;
using System;
using System.Collections.Generic;

namespace Points.Application.Points.Queries.GetAllPoints
{
    public class PointLookupDto : IMapWith<Point>
    {
        public Guid Id { get; set; }
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public int Radius { get; set; }
        public string Color { get; set; }
        public List<Comment> Comments { get; set; } = new List<Comment>();

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Point, PointLookupDto>()
                .ForMember(pointDto => pointDto.Id,
                    opt => opt.MapFrom(point => point.Id))
                .ForMember(pointDto => pointDto.PositionX,
                    opt => opt.MapFrom(point => point.PositionX))
                .ForMember(pointDto => pointDto.PositionY,
                    opt => opt.MapFrom(point => point.PositionY))
                .ForMember(pointDto => pointDto.Radius,
                    opt => opt.MapFrom(point => point.Radius))
                .ForMember(pointDto => pointDto.Color,
                    opt => opt.MapFrom(point => point.Color))
                .ForMember(pointDto => pointDto.Comments,
                    opt => opt.MapFrom(point => point.Comments));
        }
    }
}
