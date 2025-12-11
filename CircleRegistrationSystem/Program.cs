using CircleRegistrationSystem.Forms;
using CircleRegistrationSystem.Services;
using System.Windows.Forms;
using System;
using System.Configuration;
using System.Data.SqlClient;

static class Program
{
    [STAThread]
    // В Program.cs или Main()
    static void Main()
    {
      
        try
        {
            var connectionString = "Data Source=ADMIN-PC97;Initial Catalog=CircleRegistrationSystem;Integrated Security=True";

            // Проверка подключения
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                MessageBox.Show("SQL Server подключен!");
            }
        }
        // ПРОВЕРКА КОНФИГА
        catch (Exception ex)
        {
            MessageBox.Show($"Ошибка: {ex.Message}");
            return;
        }

     

        // ТЕСТ ПОДКЛЮЧЕНИЯ К БД
        

        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new MainForm());
    }
}