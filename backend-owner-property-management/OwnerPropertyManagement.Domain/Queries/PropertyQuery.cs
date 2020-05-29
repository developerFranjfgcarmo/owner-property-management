using System;
using System.Collections.Generic;
using System.Text;

namespace OwnerPropertyManagement.Domain.Queries
{
    public static class PropertyQuery
    {
        public static string GetAll = @"
        SELECT p.Id, p.Name, o.FirstName + ISNULL(o.Surname, '') AS Owner, t.Description AS Town, z.Description AS Zone, p.DistanceAirport, p.DistanceBeach, p.Active
        FROM     Property AS p INNER JOIN
                          Owner AS o ON o.Id = p.OwnerId INNER JOIN
                          Town AS t ON t.Id = p.TownId INNER JOIN
                          Zone AS z ON z.Id = t.ZoneId
        {0} --Where
        --{1} --Order
        OFFSET @take * (@page - 1) ROWS FETCH NEXT @take ROWS ONLY;
        SELECT count(p.Id)
        FROM     Property AS p INNER JOIN
                          Owner AS o ON o.Id = p.OwnerId INNER JOIN
                          Town AS t ON t.Id = p.TownId INNER JOIN
                          Zone AS z ON z.Id = t.ZoneId
        {0} --Where
        ";

        public static string GetAllWhere = @" WHERE p.OwnerId=@ownerId";
    }
}
