using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using MySql.Data.MySqlClient;
using MySql.Data;


namespace Lab4
{
    public class AddoAssistant
    {
        string connectionString = "Server=localhost;Uid=root;Pwd=password;database=dpgiproductsdb";
        
        DataTable dt = null; 
        public DataTable TableLoad()
        {
            if (dt != null) return dt;
            dt = new DataTable();
            using (MySqlConnection сonnection = new MySqlConnection(connectionString)) 
            {
                MySqlCommand command = сonnection.CreateCommand(); 
                MySqlDataAdapter adapter = new MySqlDataAdapter(command); 
                command.CommandText = "Select id, article, unit, quantity, price from products";
                try
                {
                    adapter.Fill(dt);
                }
                catch (Exception)
                {
                    MessageBox.Show("Помилка підключення до БД");
                }
            }
            return dt;
        }

        public void DeleteItem(String id)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            MySqlCommand deleteCommand = new MySqlCommand($"delete from products where id = '{id}'", connection);
            connection.Open();
            deleteCommand.ExecuteNonQuery();
            connection.Close();
        }
        
        public void UpdateItem(String id, String article, String unit, String quantity, String price)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            MySqlCommand deleteCommand = new MySqlCommand($"update products set article = '{article}', unit='{unit}', quantity='{quantity}', price='{price}' where id = '{id}'", connection);
            connection.Open();
            deleteCommand.ExecuteNonQuery();
            connection.Close();
        }
        
        public void CreateItem(String article, String unit, String quantity, String price)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            MySqlCommand deleteCommand = new MySqlCommand($"insert into products (article, unit, quantity, price) values ('{article}', '{unit}', '{quantity}', '{price}')", connection);
            connection.Open();
            deleteCommand.ExecuteNonQuery();
            connection.Close();
        }

    }
}