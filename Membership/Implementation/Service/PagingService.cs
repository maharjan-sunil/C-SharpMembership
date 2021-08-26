using Membership.Models;
using System;
using System.Linq;

namespace Membership.Implementation.Service
{
    public static class PagingService
    {
        public static IQueryable<T> QueryRecordsForPage<T>(IQueryable<T> query, int currentPage, int pageSize)
        {
            if (pageSize > 0)
                query = query.Skip(((int)currentPage - 1) * (int)pageSize).Take((int)pageSize);
            return query;
        }

        public static PagerModel CalculateTotalPageAndRecords(PagerModel model, int total)
        {
            model.TotalRecords = (int)total;
            if (model.RecordPerPage > 0)
                model.TotalPages = Convert.ToInt32((Math.Ceiling(Convert.ToDecimal(total) / Convert.ToDecimal(model.RecordPerPage))));
            if (model.TotalRecords > 0 && (model.TotalPages * model.RecordPerPage) < model.TotalRecords)
                model.TotalPages += 1;
            return model;
        }
    }
}