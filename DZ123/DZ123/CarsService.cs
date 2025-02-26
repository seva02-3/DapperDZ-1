using Dapper;
using Microsoft.Data.SqlClient;

namespace DZ123;

public class CarsService
{
    private string connectionString = "Data Source=localhost;Initial Catalog=CarsDB;Integrated Security=True;TrustServerCertificate=True";

    public void AddCar(Car car)
    {
        using (var connection = new SqlConnection(connectionString))
        {
            connection.Open();
            var sql = "INSERT INTO Cars (Brand, Model, Year, Price) VALUES (@Brand, @Model, @Year, @Price)";
            connection.Execute(sql, new { car.Brand, car.Model, car.Year, car.Price });
        }
    }

    public void UpdateCar(int carID, decimal price)
    {
        using (var connection = new SqlConnection(connectionString))
        {
            connection.Open();
            var sql = "UPDATE Cars SET Price = @Price WHERE Id = @Id";
            connection.Execute(sql, new { Id = carID, Price = price });
        }
    }

    public void DeleteCar(int carID)
    {
        using (var connection = new SqlConnection(connectionString))
        {
            connection.Open();
            var sql = "DELETE FROM Cars WHERE Id = @carID";
            connection.Execute(sql, new { carID }); 
        }
    }

    public void PrintCars()
    {
        using (var connection = new SqlConnection(connectionString))
        {
            connection.Open();
            var sql = "SELECT * FROM Cars";
            var cars = connection.Query<Car>(sql);

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Id}: {car.Brand} {car.Model} {car.Year} {car.Price}$");
            }
        }
    }

    public void PrintCarsByBrand(string brand)
    {
        using (var connection = new SqlConnection(connectionString))
        {
            connection.Open();
            var sql = "SELECT * FROM Cars WHERE Brand = Brand";
            var cars = connection.Query<Car>(sql);
            
            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Id}: {car.Brand} {car.Model} {car.Year} {car.Price}$");
            }
        }
    }
}