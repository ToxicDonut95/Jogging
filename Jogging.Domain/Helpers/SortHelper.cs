﻿namespace Jogging.Domain.Helpers
{
    public class SortHelper<T> : ISortHelper<T>
    {
        /*public IQueryable<T> ApplySort(ref IQueryable<T> entities, string orderByQueryString)
        {
            if (!entities.Any())
                return entities;

            if (string.IsNullOrWhiteSpace(orderByQueryString))
            {
                return entities;
            }

            var orderParams = orderByQueryString.Trim().Split(',');
            var propertyInfos = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            var orderQueryBuilder = new StringBuilder();

            foreach (var param in orderParams)
            {
                if (string.IsNullOrWhiteSpace(param))
                    continue;

                var propertyFromQueryName = param.Split(" ")[0];
                var objectProperty = propertyInfos.FirstOrDefault(pi => pi.Name.Equals(propertyFromQueryName, StringComparison.InvariantCultureIgnoreCase));

                if (objectProperty == null)
                    continue;

                var sortingOrder = param.EndsWith(" desc") ? "descending" : "ascending";

                orderQueryBuilder.Append($"{objectProperty.Name.ToString()} {sortingOrder}, ");
            }

            var orderQuery = orderQueryBuilder.ToString().TrimEnd(',', ' ');

            return Enumerable.OrderBy<T, string>(entities, orderQuery);// entities.OrderBy(orderQuery);
            
        }*/
        public IQueryable<T> ApplySort(ref IQueryable<T> entities, string? orderByQueryString)
        {
            throw new NotImplementedException();
        }
    }
}