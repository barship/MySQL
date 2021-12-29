using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

// WWW.W3school.com.cn/sql/sql_func_count.asp 基础数据库函数 Csharp直接连接MySQL
namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {

            Insert();
            Read();
            Update();
            Console.ReadKey();
            Delete();

        }

        static void Read()
        {
            //string connectStr = "server=127.0.0.1;port=3306;database=mygamedb;user=root;password=123456;";
            string connectStr = "server=127.0.0.1;port=3306;database=mygamedb;user=root;";
            MySqlConnection conn = new MySqlConnection(connectStr);
            try
            {
                conn.Open();
                //string sql = "select id,username,registerdate from users"; //查询指定列数据；
                //string sql = "select id,username,registerdate from users"; //查询指定列数据；
                string sql = "select * from users";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                //cmd.ExecuteReader(); //执行一些查询
                //cmd.ExecuteNonQuery(); //插入，删除
                //cmd.ExecuteScalar(); //执行一些查询，返回一个单个的值；
                MySqlDataReader reader = cmd.ExecuteReader(); //获取查询数据
                                                              //reader.Read()
                                                              //Console.WriteLine(reader[0].ToString() + reader[1] + reader[2])
                                                              //reader.Read()

                while (reader.Read())
                {
                    Console.WriteLine(reader[0].ToString() + reader[1] + reader[2]);
                }
                Console.WriteLine("已经建立连接");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                conn.Close();
            }
            Console.ReadKey();

        }

        //插入数据
        static void Insert()
        {
            //前提使用mysql workbench建立数据库
            //string connectStr = "server=127.0.0.1;port=3306;database=mygamedb;user=root;password=123456;";
            string connectStr = "server=127.0.0.1;port=3306;database=mygamedb;user=root;";
            //创建连接
            MySqlConnection conn = new MySqlConnection(connectStr); //并没有根据数据库进行连接

            try
            {
                conn.Open();
                //string sql = "insert into users(username,password,registerdate) values('cxaaa','aa','2014-01-08');" ; //插入数据
                string sql = "insert into users(username,password,registerdate) values('cxaaa','aa','" +
                              System.DateTime.Now + "')"; //插入数据加上当前时间

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                int result = cmd.ExecuteNonQuery(); //返回值是数据库中受影响的行数
            }

            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally //无论如何都会执行
            {
                conn.Close(); //关闭连接
            }
        }

        //修改数据
        static void Update()
        {
            //前提使用mysql workbench建立数据库
            //string connectStr = "server=127.0.0.1;port=3306;database=mygamedb;user=root;password=123456;";
            string connectStr = "server=127.0.0.1;port=3306;database=mygamedb;user=root;";
            //创建连接
            MySqlConnection conn = new MySqlConnection(connectStr); //并没有根据数据库进行连接

            try
            {
                conn.Open();
                //string sql = "insert into users(username,password,registerdate) values('cxaaa','aa','2014-01-08');" ; //插入数据
                //string sql = "update users set username='1123',password='adasw' where id=6"; //插入数据加上当前时间
                string sql = "update users set username='1123',password='adasw' where username='1122'";
                MySqlCommand cmd = new MySqlCommand(sql, conn);

                int result = cmd.ExecuteNonQuery(); //返回值是数据库中受影响的行数
                Console.WriteLine("hello world update\n");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally //无论如何都会执行
            {
                conn.Close(); //关闭连接
            }
        }

        //删除数据
        static void Delete()
        {
            //前提使用mysql workbench建立数据库
            //string connectStr = "server=127.0.0.1;port=3306;database=mygamedb;user=root;password=123456;";
            string connectStr = "server=127.0.0.1;port=3306;database=mygamedb;user=root;";
            //创建连接
            MySqlConnection conn = new MySqlConnection(connectStr); //并没有根据数据库进行连接

            try
            {
                conn.Open();
                //string sql = "insert into users(username,password,registerdate) values('cxaaa','aa','2014-01-08');" ; //插入数据

                //string sql = "delete from users where id=4"; //插入数据加上当前时间
                string sql = "delete from users where username='cxaaa'";
                //sql = "delete from users";
                MySqlCommand cmd = new MySqlCommand(sql, conn);

                int result = cmd.ExecuteNonQuery(); //返回值是数据库中受影响的行数
                Console.WriteLine("hello world delete\n");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally //无论如何都会执行
            {
                conn.Close(); //关闭连接
            }
        }
    
    }
}
