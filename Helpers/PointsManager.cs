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

        public ViewerPoints GetPointsRecord(string user)
        {
            ViewerPoints pointsRecord;
            using (var context = new mashDbContext())
            {
                pointsRecord = context.ViewerPoints
                                .Where(x => x.Viewer == user)
                                .FirstOrDefault();

                if (pointsRecord == null)
                {
                    ViewerPoints newRecord = new()
                    {
                        Viewer = user,
                        Points = 0
                    };

                    context.ViewerPoints.Add(newRecord);
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
                    Receiver = user,
                    Giver = giver,
                    Date = DateTime.Now,
                    Notes = notes
                };

                context.ViewerPoints.Update(pointsRecord);
                context.TransactionLog.Add(log);
                context.SaveChanges();
            }
        }
    }
}
