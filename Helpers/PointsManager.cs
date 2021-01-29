using pmashbotCS.Models;
using System.Linq;

namespace pmashbotCS.Helpers
{
    public class PointsManager
    {

        public int GetPoints(string user)
        {
            int points = 0;

            using (var context = new mashDbContext())
            {
                points = context.ViewerPoints
                                .Where(x => x.Viewer == user)
                                .Select(x => x.Points)
                                .Single();
            }

            return points;
        }
    }
}
