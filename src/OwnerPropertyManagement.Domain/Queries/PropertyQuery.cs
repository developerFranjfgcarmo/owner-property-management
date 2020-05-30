namespace OwnerPropertyManagement.Domain.Queries
{
    public static class PropertyQuery
    {
        public static string GetAll = @"
        SELECT * FROM (SELECT p.Id, p.Name, o.FirstName + o.Surname AS Owner, t.Description AS Town, z.Description AS Zone, p.DistanceAirport, p.DistanceBeach, p.Active, p.OwnerId, DENSE_RANK() OVER (ORDER BY p.Id) rn
        FROM     Property AS p INNER JOIN
                          Owner AS o ON o.Id = p.OwnerId INNER JOIN
                          Town AS t ON t.Id = p.TownId INNER JOIN
                          Zone AS z ON z.Id = t.ZoneId
                            {0}
                        ) Properties
						  WHERE rn >  @Take * (@Page - 1) AND rn <= (@Page * @Take)
         ;
 
        SELECT count(p.Id)
        FROM     Property AS p INNER JOIN
                          Owner AS o ON o.Id = p.OwnerId INNER JOIN
                          Town AS t ON t.Id = p.TownId INNER JOIN
                          Zone AS z ON z.Id = t.ZoneId
        {0} 
        ";

        public static string GetAllWhere = @" WHERE p.OwnerId=@OwnerId";
    }
}