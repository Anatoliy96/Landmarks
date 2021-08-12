using System;
using System.Collections.Generic;
using System.Text;

namespace LandMarkBLL.ObjectTransfering
{
    public class DaoToBloConverter<TSource, TDestination> : ObjectConverter<TSource, TDestination>
        where TSource : LandmarkDAL.Models.Common
        where TDestination : DTO.IDto
    {
    }
}
