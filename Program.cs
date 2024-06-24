
using ConsoleApp1;
using ConsoleApp1.Dtos;
using ConsoleApp1.Services;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

//var connectionString = @"Server=JESUS;Database=Northwind;Integrated Security=true;";
//var connectionStringDma = @"Server=JESUS;Database=Dma03;Integrated Security=true;";

//var conn = new SqlConnection(connectionString);
//conn.Open();
//var query = "SELECT * FROM Products";
//var cmd = new SqlCommand(query, conn);

//// select sorgularinda istifade olunur
//SqlDataReader reader = cmd.ExecuteReader();

//while (reader.Read())
//{
//    for (int i = 0; i< reader.FieldCount; i++)
//    {
//        Console.Write(reader[i] + " ");
//    }
//    Console.WriteLine();
//    //or
//    //Console.WriteLine(reader["ProductId"]);
//}
//var query = "INSERT INTO Products VALUES(4,'Uzum', 2.49, 'description')";
//var cmd = new SqlCommand(query, conn);
//int modifiedRows =   cmd.ExecuteNonQuery();


//if(modifiedRows > 0)
//    Console.WriteLine("Affected");
//else
//    Console.WriteLine("Error occured");


//conn.Close();

//var query = "SELECT * FROM Categories";
//SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
//var categories = new DataTable();
//adapter.Fill(categories);
//foreach (DataRow category in categories.Rows)
//{
//    Console.WriteLine(category[0]);
//}

//var query1 = "SELECT * FROM Categories";
//var query2 = "SELECT * FROM Products";

//var adapter = new SqlDataAdapter(query1, conn);
//var set = new DataSet();
//adapter.Fill(set,"Categories");
//adapter.SelectCommand.CommandText = query2;
//adapter.Fill(set, "Products");

//foreach (DataTable item in set.Tables)
//{
//    Console.WriteLine(item.TableName);
//    foreach (DataRow data in item.Rows)
//    {
//        Console.WriteLine(data[0]);
//    }
//    Console.WriteLine("*********************");
//}


Identity identity = new Identity();

Menu.ShowMenu();

int choice = Convert.ToInt32(Console.ReadLine());

switch (choice)
{
    case 1:
        Console.WriteLine("Plese enter email");
        string email = Console.ReadLine();
        Console.WriteLine("Plese enter password");
        string password = Console.ReadLine();
        var res = identity.Login(email, password);
        if (res == null)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Password or email is not correct");
            Console.ResetColor();
        }
        else
        {
            Menu.LoginMenu(res);
        }
        break;
    case 2:
        var dto = new UserRegisterDto()
        {
            Name = "Leyla",
            Email = "leyla@gmail.com",
            Password = "leyla123@"
        };
        var register =  identity.Register(dto);
        if (register)
        {
            Console.WriteLine("Successfully registered");
        }
        else
        {
            Console.WriteLine("Invalid");
        }
        break;
    default:
        break;
}