using AutoMapper;
using System.Collections.Generic;

namespace ShoppingList.Service.WebApi.Helper
{
    public static class MapperHelper
    {
        public static List<TDestination> MapperJsonToEntity<Tsource, TDestination>(List<Tsource> source)
        {
            List<TDestination> destination = new List<TDestination>();
            destination = Mapper.Map<List<Tsource>, List<TDestination>>(source);
            return destination;
        }

        public static TDestination MapperJsonToEntity<Tsource, TDestination>(Tsource source)
        {
            var destination = Mapper.Map<Tsource, TDestination>(source);
            return destination;
        }
    }
}