using pmashbotCS.Models;
using System.Linq;

namespace pmashbotCS.Repositories
{
    public static class StaticCommandsRepository
    {
        public static StaticCommands GetCommand(string keyword)
        {
            StaticCommands cmd = new();
            using (var context = new mashDbContext())
            {
                cmd = context.StaticCommands
                             .Where(x => x.Keyword == keyword)
                             .FirstOrDefault();
            }

            return cmd;
        }

        public static void CreateCommand(StaticCommands cmd)
        {
            if (string.IsNullOrEmpty(cmd.Keyword) || string.IsNullOrEmpty(cmd.Text))
            {
                throw new System.ArgumentException();
            }

            using (var context = new mashDbContext())
            {
                context.StaticCommands.Add(cmd);

                context.SaveChanges();
            }
        }

        public static void UpdateCommand(StaticCommands cmd)
        {
            if (string.IsNullOrEmpty(cmd.Keyword) || string.IsNullOrEmpty(cmd.Text))
            {
                throw new System.ArgumentException();
            }

            using (var context = new mashDbContext())
            {
                var existing = GetCommand(cmd.Keyword);
                existing.Text = cmd.Text;

                context.Update(existing);
                context.SaveChanges();
            }
        }

        public static void DeleteCommand(StaticCommands cmd)
        {
            if (string.IsNullOrEmpty(cmd.Keyword))
            {
                throw new System.ArgumentException();
            }

            using (var context = new mashDbContext())
            {
                context.Remove(GetCommand(cmd.Keyword));
                context.SaveChanges();
            }
        }

        public static bool CommandExists(string keyword)
        {
            return !(GetCommand(keyword) == null);
        }
    }
}
