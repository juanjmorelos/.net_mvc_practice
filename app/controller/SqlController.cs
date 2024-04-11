using System;
using MySql.Data.MySqlClient;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Collections; // Asegúrate de tener esta referencia


public class SqlController {
    private static string server = "localhost";
    private static string port = "3306";
    private static string user = "root";
    private static string password = "";
    private static string dbName = "employee_database";
    private static string conectUrl = "server=" + server + "; port=" + port + "; user id=" + user + "; password=" + password + "; database=" + dbName + ";";
    MySqlConnection connection = new MySqlConnection();


    public SqlController() {

    }

    public void connectSql() {
        try {
            connection.ConnectionString = conectUrl;
            connection.Open();
        } catch (MySqlException err) {
            Console.WriteLine("Error: " + err.ToString());
        }
    }

    public void closeSQL() {
        connection.Close();
    }

    public async Task InsertData(HttpContext context) {
        var response = new JObject();
        try {
            var requestBody = await new StreamReader(context.Request.Body).ReadToEndAsync();
            var userData = JObject.Parse(requestBody);

            string name = userData["name"]?.ToString() ?? "";
            string lastName = userData["lastName"]?.ToString() ?? "";
            string position = userData["position"]?.ToString() ?? "";

            if(name != "" && lastName != "" && position != "") {
                connectSql();

                string sql = "INSERT INTO user_information VALUES (null, @name, @lastName, @position)";
                MySqlCommand command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@lastName", lastName);
                command.Parameters.AddWithValue("@position", position);

                int userId = Convert.ToInt32(await command.ExecuteScalarAsync());

                var user = new JObject();
                user["id"] = userId;
                user["name"] = name;
                user["lastName"] = lastName;
                user["position"] = position;

                response["success"] = true;
                response["msg"] = "Usuario agregado correctamente";
                response["user"] = user;

                context.Response.StatusCode = 200;
            } else {
                response["success"] = false;
                response["msg"] = "Datos faltantes";
                context.Response.StatusCode = 400;
            }
        } catch (Exception ex) {
            context.Response.StatusCode = 500;
            response["success"] = false;
            response["msg"] = "Ocurrió un error: " + ex.Message;
        }

        var jsonResponse = Newtonsoft.Json.JsonConvert.SerializeObject(response);
        await context.Response.WriteAsync(jsonResponse);
        closeSQL();
    }

    public async Task getPositions(HttpContext context) {
         var response = new JObject();
         List<PositionModel> position = new List<PositionModel>();
        try {
            connectSql();

            string sql = "SELECT * FROM position";

            MySqlCommand command = new MySqlCommand(sql, connection);
            MySqlDataReader reader = command.ExecuteReader();

            while(reader.Read()) {
                PositionModel positionModel = new PositionModel();
                positionModel.SetPositionId(reader.GetInt32(0));
                positionModel.SetPositionName(reader.GetString(1));
                position.Add(positionModel);
            }

            JArray jsonArray = new JArray();
            foreach (var pos in position) {
                JObject positionJson = new JObject();
                positionJson["positionId"] = pos.GetPositionId();
                positionJson["positionName"] = pos.GetPositionName();
                jsonArray.Add(positionJson);
            }

            response["success"] = true;
            response["msg"] = "Cargos obtenidos correctamente";
            response["positionData"] = jsonArray;

            context.Response.StatusCode = 200;
        } catch (Exception ex) {
            context.Response.StatusCode = 500;
            response["success"] = false;
            response["msg"] = "Ocurrió un error: " + ex.Message;
            Console.WriteLine("Error" + ex.ToString());
        }

        var jsonResponse = Newtonsoft.Json.JsonConvert.SerializeObject(response);
        await context.Response.WriteAsync(jsonResponse);
        closeSQL();
    }

    public async Task InsertPosition(HttpContext context) {
        var response = new JObject();
        try {
            var requestBody = await new StreamReader(context.Request.Body).ReadToEndAsync();
            var userData = JObject.Parse(requestBody);

            string position = userData["position"]?.ToString() ?? "";

            if(position != "") {
                connectSql();

                string sql = "INSERT INTO position VALUES (null, @position)";
                MySqlCommand command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@position", position);

                await command.ExecuteNonQueryAsync();

                response["success"] = true;
                response["msg"] = "Cargo agregado correctamente";
                response["position"] = position;

                context.Response.StatusCode = 200;
            } else {
                response["success"] = false;
                response["msg"] = "Datos faltantes";
                context.Response.StatusCode = 400;
            }
        } catch (Exception ex) {
            context.Response.StatusCode = 500;
            response["success"] = false;
            response["msg"] = "Ocurrió un error: " + ex.Message;
        }

        var jsonResponse = Newtonsoft.Json.JsonConvert.SerializeObject(response);
        await context.Response.WriteAsync(jsonResponse);
        closeSQL();
    }

    public async Task getAllUsers(HttpContext context) {
         var response = new JObject();
         List<EmployeeModel> employees = new List<EmployeeModel>();
        try {
            connectSql();

            string sql = "SELECT u.userName, u.userLastName, p.postitionName FROM `user_information` u INNER JOIN `position` p ON u.positionId = p.positionId";

            MySqlCommand command = new MySqlCommand(sql, connection);
            MySqlDataReader reader = command.ExecuteReader();

            while(reader.Read()) {
                EmployeeModel employeeModel = new EmployeeModel();
                employeeModel.SetName(reader.GetString(0));
                employeeModel.SetLastName(reader.GetString(1));
                employeeModel.SetPosition(reader.GetString(2));
                employees.Add(employeeModel);
            }

            JArray jsonArray = new JArray();
            foreach (var pos in employees) {
                JObject employeesJson = new JObject();
                employeesJson["name"] = pos.GetName();
                employeesJson["lastName"] = pos.GetLastName();
                employeesJson["position"] = pos.GetPosition();
                jsonArray.Add(employeesJson);
            }

            response["success"] = true;
            response["msg"] = "Usuarios obtenidos correctamente";
            response["users"] = jsonArray;

            context.Response.StatusCode = 200;
        } catch (Exception ex) {
            context.Response.StatusCode = 500;
            response["success"] = false;
            response["msg"] = "Ocurrió un error: " + ex.Message;
            Console.WriteLine("Error" + ex.ToString());
        }

        var jsonResponse = Newtonsoft.Json.JsonConvert.SerializeObject(response);
        await context.Response.WriteAsync(jsonResponse);
        closeSQL();
    }

    public async Task getAllUsersByPosition(HttpContext context) {
        var response = new JObject();
        List<EmployeeModel> employees = new List<EmployeeModel>();
        var position = context.Request.RouteValues["position"];        
        try {
            connectSql();
            string sql = "SELECT u.userName, u.userLastName, p.postitionName FROM `user_information` u INNER JOIN `position` p ON u.positionId = p.positionId WHERE u.positionId = " + position;

            MySqlCommand command = new MySqlCommand(sql, connection);
            MySqlDataReader reader = command.ExecuteReader();

            while(reader.Read()) {
                EmployeeModel employeeModel = new EmployeeModel();
                employeeModel.SetName(reader.GetString(0));
                employeeModel.SetLastName(reader.GetString(1));
                employeeModel.SetPosition(reader.GetString(2));
                employees.Add(employeeModel);
            }

            JArray jsonArray = new JArray();
            foreach (var pos in employees) {
                JObject employeesJson = new JObject();
                employeesJson["name"] = pos.GetName();
                employeesJson["lastName"] = pos.GetLastName();
                employeesJson["position"] = pos.GetPosition();
                jsonArray.Add(employeesJson);
            }

            response["success"] = true;
            response["msg"] = "Usuarios obtenidos correctamente";
            response["users"] = jsonArray;

            context.Response.StatusCode = 200;
        } catch (Exception ex) {
            context.Response.StatusCode = 500;
            response["success"] = false;
            response["msg"] = "Ocurrió un error: " + ex.Message;
            Console.WriteLine("Error" + ex.ToString());
        }

        var jsonResponse = Newtonsoft.Json.JsonConvert.SerializeObject(response);
        await context.Response.WriteAsync(jsonResponse);
        closeSQL();
    }

}
