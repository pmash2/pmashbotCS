using pmashbotCS.Models;
using System;
using System.Linq;

namespace pmashbotCS.Helpers
{
    public class PointsManager
    {

        public int GetPoints(string user)
        {
            return GetPointsRecord(user).Points;
        }

        public UserPoints GetPointsRecord(string user)
        {
            UserPoints pointsRecord;
            using (var context = new mashDbContext())
            {
                pointsRecord = context.UserPoints
                                .Where(x => x.Viewer == user.ToLower())
                                .FirstOrDefault();

                if (pointsRecord == null)
                {
                    UserPoints newRecord = new()
                    {
                        Viewer = user.ToLower(),
                        Points = 0
                    };

                    context.UserPoints.Add(newRecord);
                    pointsRecord = newRecord;
                    context.SaveChanges();
                }
            }

            return pointsRecord;
        }

        public void ChangePoints(string user, string giver, int points, string notes)
        {
            using (mashDbContext context = new())
            {
                var pointsRecord = GetPointsRecord(user);
                pointsRecord.Points += points;

                TransactionLog log = new()
                {
                    Points = points,
                    Receiver = user.ToLower(),
                    Giver = giver,
                    Date = DateTime.Now,
                    Notes = notes
                };

                context.UserPoints.Update(pointsRecord);
                context.TransactionLog.Add(log);
                context.SaveChanges();
            }
        }
    }
}
