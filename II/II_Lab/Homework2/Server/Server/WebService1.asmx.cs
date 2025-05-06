using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Security.Claims;
using System.Web.Services;

namespace Server
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class WebService1 : System.Web.Services.WebService
    {
        private readonly string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\Faculta\II\II_Lab\Homework2\Server\database.mdf;Integrated Security=True;Connect Timeout=30";

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public int Add(int a, int b)
        {
            return a + b;
        }

        [WebMethod]
        public int FtoC(int f)
        {
            return (int)((f - 32) * 5 / 9);
        }

        [WebMethod]
        public int CtoF(int c)
        {
            return (int)(c * 9 / 5 + 32);
        }

        [WebMethod]
        public DateTime GetDate()
        {
            return DateTime.Now;
        }

        [WebMethod]
        public int[] GetRandom()
        {
            Random random = new Random();
            int[] randomNumbers = new int[10];
            for (int i = 0; i < 5; i++)
            {
                randomNumbers[i] = random.Next(1, 101);
            }
            return randomNumbers;
        }

        [WebMethod]
        public float RonToEuro(float ron)
        {
            return ron / 4.9f;
        }


        [WebMethod]
        public string AddStudent(int id, string name, string surname, int uId, int cId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    // Start a transaction to ensure both inserts are handled atomically
                    using (SqlTransaction transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            // Insert the student into the Students table
                            string studentQuery = "INSERT INTO Students (id, name, surname, uId, cId) VALUES (@id, @name, @surname, @uId, @cId)";
                            using (SqlCommand studentCommand = new SqlCommand(studentQuery, connection, transaction))
                            {
                                studentCommand.Parameters.AddWithValue("@id", id);
                                studentCommand.Parameters.AddWithValue("@name", name);
                                studentCommand.Parameters.AddWithValue("@surname", surname);
                                studentCommand.Parameters.AddWithValue("@uId", uId);
                                studentCommand.Parameters.AddWithValue("@cId", cId);

                                int studentRowsAffected = studentCommand.ExecuteNonQuery();
                                if (studentRowsAffected == 0)
                                {
                                    transaction.Rollback();
                                    return "Failed to add student to Students table.";
                                }
                            }

                            // Insert the student into the Classes table
                            string classQuery = "INSERT INTO Classes (uId, sId, Id) VALUES (@uId, @sId, @cId)";
                            using (SqlCommand classCommand = new SqlCommand(classQuery, connection, transaction))
                            {
                                classCommand.Parameters.AddWithValue("@uId", uId);
                                classCommand.Parameters.AddWithValue("@sId", id);  // Add the student's id into the Classes table
                                classCommand.Parameters.AddWithValue("@cId", cId);

                                int classRowsAffected = classCommand.ExecuteNonQuery();
                                if (classRowsAffected == 0)
                                {
                                    transaction.Rollback();
                                    return "Failed to add student to Classes table.";
                                }
                            }

                            // Commit the transaction if everything is successful
                            transaction.Commit();
                            return "Student added successfully to both Students and Classes tables.";
                        }
                        catch (Exception ex)
                        {
                            // Rollback the transaction in case of any error
                            transaction.Rollback();
                            return $"Error: {ex.Message}";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }

        public class Student
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Surname { get; set; }
            public string UniversityName { get; set; }
            public string ClassName { get; set; }
        }

        [WebMethod]
        public List<Student> GetStudents()
        {
            List<Student> students = new List<Student>();

            // Query the database and populate the students list
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT id, name, surname, uId, cId FROM Students";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Student student = new Student
                    {
                        Id = (int)reader["id"],
                        Name = reader["name"].ToString(),
                        Surname = reader["surname"].ToString(),
                        UniversityName = GetUniversityName((int)reader["uId"]),  // Helper method to fetch university name
                        ClassName = GetClassName((int)reader["cId"])  // Helper method to fetch class name
                    };
                    students.Add(student);
                }
            }

            return students;
        }

        private string GetUniversityName(int uId)
        {
            string name;

            try
            {
                using(SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT name FROM Universities WHERE id = @uId";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@uId", uId);
                        name = (string)command.ExecuteScalar();
                    }
                }
            }
            catch (Exception ex)
            {
                name = $"Error: {ex.Message}";
            }

            return name;
        }

        private string GetClassName(int cId)
        {
            int id;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT id FROM Classes WHERE id = @cId";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@cId", cId);
                        id = (int)command.ExecuteScalar();
                    }
                }
            }
            catch (Exception ex)
            {
                id = -1; // or some other error handling
            }
            return id.ToString();
        }

        [WebMethod]
        public string UpdateStudent(int id, string name, string surname, int uId, int cId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "UPDATE Students SET name = @name, surname = @surname, uId = @uId, cId = @cId WHERE id = @id";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        command.Parameters.AddWithValue("@name", name);
                        command.Parameters.AddWithValue("@surname", surname);
                        command.Parameters.AddWithValue("@uId", uId);
                        command.Parameters.AddWithValue("@cId", cId);

                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0 ? "Student updated successfully" : "Failed to update student";
                    }
                }
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }

        [WebMethod]
        public string DeleteStudent(int id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "DELETE FROM Students WHERE id = @id";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);

                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0 ? "Student deleted successfully" : "Failed to delete student";
                    }
                }
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }


        [WebMethod]
        public string AddTeacher(int id, string name, string surname, int uId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO Teachers (id, name, surname, uId) VALUES (@id, @name, @surname, @uId)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        command.Parameters.AddWithValue("@name", name);
                        command.Parameters.AddWithValue("@surname", surname);
                        command.Parameters.AddWithValue("@uId", uId);

                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0 ? "Teacher added successfully" : "Failed to add teacher";
                    }
                }
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }

        [WebMethod]
        public string GetTeachers()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT id, name, surname, uId FROM Teachers";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        SqlDataReader reader = command.ExecuteReader();
                        string result = "";
                        while (reader.Read())
                        {
                            result += $"ID: {reader["id"]}, Name: {reader["name"]}, Surname: {reader["surname"]}, University ID: {reader["uId"]}\n";
                        }
                        return string.IsNullOrEmpty(result) ? "No teachers found" : result;
                    }
                }
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }


        [WebMethod]
        public string AddClass(int id, int uId, int sId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO Classes (id, uId, sId) VALUES (@id, @uId, @sId)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        command.Parameters.AddWithValue("@uId", uId);
                        command.Parameters.AddWithValue("@sId", sId);

                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0 ? "Class added successfully" : "Failed to add class";
                    }
                }
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }

        [WebMethod]
        public List<Class> GetClasses()
        {
            List<Class> classes = new List<Class>();

            // Query to get classes from the database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT id FROM Classes";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Class classItem = new Class
                    {
                        Id = (int)reader["id"],
                        ClassName = reader["id"].ToString()
                    };
                    classes.Add(classItem);
                }
            }

            return classes;
        }

        [WebMethod]
        public string AddUniversity(int id, string name, int? sId, int? tId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO Universities (id, name, sId, tId) VALUES (@id, @name, @sId, @tId)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        command.Parameters.AddWithValue("@name", name);

                        // Use DBNull.Value if sId or tId is null
                        command.Parameters.AddWithValue("@sId", sId.HasValue ? (object)sId.Value : DBNull.Value);
                        command.Parameters.AddWithValue("@tId", tId.HasValue ? (object)tId.Value : DBNull.Value);

                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0 ? "University added successfully" : "Failed to add university";
                    }
                }
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }

        public class University
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        public class Class
        {
            public int Id { get; set; }
            public string ClassName { get; set; }
        }

        [WebMethod]
        public List<University> GetUniversities()
        {
            List<University> universities = new List<University>();

            // Query to get universities from the database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT id, name FROM Universities";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    University university = new University
                    {
                        Id = (int)reader["id"],
                        Name = reader["name"].ToString()
                    };
                    universities.Add(university);
                }
            }

            return universities;
        }

    }
}
