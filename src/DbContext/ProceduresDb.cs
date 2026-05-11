// using Microsoft.EntityFrameworkCore;
// using Npgsql;

// namespace MyProject.Data;
// class ProceduresDb
// {
//     private readonly String _conection;

//     public ProceduresDb(AppDbContext conection)
//     {
//         _conection = conection.Database.GetDbConnection().ConnectionString;
//     }

//     private NpgsqlConnection GetConnection(){
//         return new NpgsqlConnection(_conection);
//     }

//     public int ExecuteProcedure(String sql, Dictionary<string,Object> parameters= null)
//     {
//         using (var conn = GetConnection())
//         {
//             conn.Open();

//             using(var cmd = new NpgsqlCommand(sql, conn))
//             {
//                 if (parameters==null) return;
//                 cmd.Parameters.AddWithValue(parameters.Keys, parameters.Values);

//                 return cmd.ExecuteNonQuery();
//             }

//         }




//     }

    
// }