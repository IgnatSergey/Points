using AutoMapper;
using Points.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Points.Application.Points.Queries.GetAllPoints
{
    public class PointListVm
    {
        public IList<PointLookupDto> Points { get; set; }
    }
}
