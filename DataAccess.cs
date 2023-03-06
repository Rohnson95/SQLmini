using Dapper;
using Npgsql;
using System.Configuration;
using System.Data;
namespace tempSQL
{
    internal class DataAccess
    {
        private static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }

        public static List<PersonModel> Persons()
        {
            using (IDbConnection cnn = new NpgsqlConnection(LoadConnectionString()))
            {
                var output = cnn.Query<PersonModel>("SELECT * FROM rjo_person", new DynamicParameters());
                return output.ToList();
            }
        }
        public static List<ProjectModel> Projects()
        {
            using (IDbConnection cnn = new NpgsqlConnection(LoadConnectionString()))
            {
                var output = cnn.Query<ProjectModel>("SELECT * FROM rjo_project", new DynamicParameters());
                return output.ToList();
            }
        }
        internal static void ProjectPerson(int project_id, int person_id, int hours)
        {
            using (IDbConnection cnn = new NpgsqlConnection(LoadConnectionString()))
            {
                cnn.Execute($@"INSERT INTO rjo_project_person (project_id,person_id,hours) VALUES({project_id},{person_id},{hours})", new DynamicParameters());
            }
        }

        internal static void NewPerson(string person_name)
        {
            using (IDbConnection cnn = new NpgsqlConnection(LoadConnectionString()))
            {
                cnn.Execute($@"INSERT INTO rjo_person (person_name) VALUES('{person_name}')", new DynamicParameters());
            }
        }
        internal static void UpdatePerson(int old_person_id, string new_person_name)
        {
            using (IDbConnection cnn = new NpgsqlConnection(LoadConnectionString()))
            {
                cnn.Execute($@"UPDATE rjo_person SET person_name ='{new_person_name}' WHERE id ={old_person_id}", new DynamicParameters());
            }
        }
        internal static void NewProject(string project_name)
        {
            using (IDbConnection cnn = new NpgsqlConnection(LoadConnectionString()))
            {
                cnn.Execute($@"INSERT INTO rjo_project (project_name) VALUES('{project_name}')", new DynamicParameters());
            }
        }
        internal static void UpdateProject(int old_person_id, string new_person_name)
        {
            using (IDbConnection cnn = new NpgsqlConnection(LoadConnectionString()))
            {
                cnn.Execute($@"UPDATE rjo_project SET project_name ='{new_person_name}' WHERE id ={old_person_id}", new DynamicParameters());
            }
        }
    }
}
