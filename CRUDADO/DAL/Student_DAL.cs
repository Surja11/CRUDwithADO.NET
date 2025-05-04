using System.Diagnostics.Eventing.Reader;
using System.Security.Cryptography.Pkcs;
using CRUDADO.Models;
using Humanizer.Localisation.TimeToClockNotation;
using Microsoft.Data.SqlClient;


namespace CRUDADO.DAL
{
    public class Student_DAL
    {
        SqlConnection con = null;
        SqlCommand cmd = null;

        private readonly string _connectionString;
        public Student_DAL(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public List<Student> GetAllStudents()
        {
            List<Student> studentList = new List<Student>();
            
            using (con = new SqlConnection(_connectionString))
            {
                con.Open();
                
                string query = "select * from students";
                cmd = new SqlCommand(query, con);
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    Student stu = new Student();
                    stu.Roll = Convert.ToInt32(rd["Roll"]);
                    stu.FirstName = rd["FirstName"].ToString();
                    stu.LastName = rd["LastName"].ToString();
                    stu.Address = rd["Address"].ToString();
                    stu.Semester = rd["Semester"].ToString();
                    stu.Phone = Convert.ToInt32(rd["Phone"]);
                    stu.MarksObtained = Convert.ToInt32(rd["MarksObtained"]);

                    studentList.Add(stu);

                }
            }
            return studentList;
        }

        public bool Insert(Student model)
        {
            int id = 0;
            using (con = new SqlConnection(_connectionString))
            {
                con.Open();
                string query = "insert into students values(@FirstName, @LastName, @Semester, @Address,@Phone,@MarksObtained ) ";
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@FirstName", model.FirstName);
                cmd.Parameters.AddWithValue("@LastName", model.LastName);
                cmd.Parameters.AddWithValue("@Semester", model.Semester);
                cmd.Parameters.AddWithValue("@Address", model.Address);
                cmd.Parameters.AddWithValue("@Phone", model.Phone);
                cmd.Parameters.AddWithValue("@MarksObtained", model.MarksObtained);
               
               id = cmd.ExecuteNonQuery();

            }
            return id > 0 ? true : false;
        }


        public Student GetByRoll(int Roll)
        {
            Student stu = new Student();
            using (con = new SqlConnection(_connectionString))
            {
                con.Open();
                string query = "select * from students where Roll = @Roll";
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Roll", Roll);
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    stu.Roll = Convert.ToInt32(rd["Roll"]);
                      stu.FirstName = rd["FirstName"].ToString();
                    stu.LastName = rd["LastName"].ToString();
                    stu.Address = rd["Address"].ToString();
                    stu.Semester = rd["Semester"].ToString();
                    stu.Phone = Convert.ToInt32(rd["Phone"]);
                    stu.MarksObtained = Convert.ToInt32(rd["MarksObtained"]);
                }
            }
            return stu;
        }

        public bool Update(Student model)
        {
            int a = 0;
            using(con = new SqlConnection(_connectionString))
            {
                con.Open();
                string query = "update students set FirstName = @FirstName, LastName = @LastName, Semester = @Semester, Address = @Address, Phone = @Phone, MarksObtained = @MarksObtained where Roll = @Roll";
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Roll", model.Roll);
                cmd.Parameters.AddWithValue("@FirstName", model.FirstName);
                cmd.Parameters.AddWithValue("@LastName", model.LastName);
                cmd.Parameters.AddWithValue("@Semester", model.Semester);
                cmd.Parameters.AddWithValue("@Address", model.Address);
                cmd.Parameters.AddWithValue("@Phone", model.Phone);
                cmd.Parameters.AddWithValue("@MarksObtained", model.MarksObtained);
                a = cmd.ExecuteNonQuery();
              

            }
            return (a > 0) ? true : false;
        }
        public bool Delete(int Roll)
        {
            int a = 0;
            using (con = new SqlConnection(_connectionString))
            {
                con.Open();
                string query = "delete from  students where Roll = @Roll";
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Roll", Roll);
              
                a = cmd.ExecuteNonQuery();


            }
            return (a > 0) ? true : false;
        }


    }
}
