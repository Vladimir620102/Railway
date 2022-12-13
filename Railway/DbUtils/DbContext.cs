using Railway.Data.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Railway.Properties;

namespace Railway.DbUtils
{
    internal class DbContext
    {

        public static List<Country> Countries = new List<Country>();
        public static List<City> Cities = new List<City>();


        static string _connectionString = Properties.Settings.Default.ConnectionString;


        #region Country
        public static void SetCountries()
        {
            SqlConnection connection=null;
            try
            {
                connection = new SqlConnection(_connectionString);

                if (connection == null) return;
                Countries.Clear();


                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM country", connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read()) // построчно считываем данные
                {
                    object id = reader.GetValue(0);
                    object name = reader.GetValue(1);
                    object shortName = reader.GetValue(2);
                    Country country = new Country()
                    {
                        Id = (int)id,
                        Name = (string)name,
                        ShortName = shortName == DBNull.Value ? string.Empty : (string)shortName
                    };
                    Countries.Add(country);
                }
            }
            catch (SqlException e1)
            {
                MessageBox.Show(e1.Message);
            }
            catch (Exception e2)
            {
                MessageBox.Show(e2.Message);
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }

        }

        public static bool UpdateCountry(int countryId, string countryName)
        {

            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(_connectionString);
                connection.Open();
                SqlCommand updateCommand = new SqlCommand("Update Country SET Name = @CountryName WHERE Id = @CountryId");
                updateCommand.Parameters.Add("@CountryName", SqlDbType.NVarChar, 255, "Name");
                updateCommand.Parameters.Add("@CountryId", SqlDbType.Int, sizeof(int), "Id");
                updateCommand.Parameters[0].Value = countryName;
                updateCommand.Parameters[1].Value = countryId;
                updateCommand.Connection = connection;
                var count = updateCommand.ExecuteNonQuery();
                return count > 0;
            }
            catch (SqlException ex1)
            {
                MessageBox.Show(ex1.Message);
            }
            catch (Exception ex2)
            {
                MessageBox.Show(ex2.Message);
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }
            return false;
        }
        public static bool CheckExistsCountry(int countryId)
        {
            SetCountries();
            foreach (var c in Countries)
            {
                if (countryId == c.Id) return true;
            }
            return false;
        }
        public static bool CheckExistsCountry(string countryName)
        {
            SetCountries();
            foreach (var c in Countries)
            {
                if (countryName == c.Name) return true;
            }
            return false;
        }

        public static bool AddCountry(string countryName)
        {
            if (CheckExistsCountry(countryName))
            {
                MessageBox.Show($"Страна {countryName} уже есть в справочнике");
                return false;
            }
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(_connectionString);
                connection.Open();
                SqlCommand insertCommand = new SqlCommand("INSERT INTO Country (Name) VALUES (@CountryName) ");
                insertCommand.Parameters.Add("@CountryName", SqlDbType.NVarChar, 255, "Name");
                insertCommand.Parameters[0].Value = countryName;
                insertCommand.Connection = connection;
                var count = insertCommand.ExecuteNonQuery();
                return count > 0;
            }
            catch (SqlException ex1)
            {
                MessageBox.Show(ex1.Message);
            }
            catch (Exception ex2)
            {
                MessageBox.Show(ex2.Message);
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }
            return false;
        }

        public static bool DeleteCountry(int id)
        {
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(_connectionString);
                connection.Open();
                SqlCommand deleteCommand = new SqlCommand("DELETE FROM Country WHERE Id =  @Id ");
                deleteCommand.Parameters.Add("@Id", SqlDbType.Int, 255, "Id");
                deleteCommand.Parameters[0].Value = id;
                deleteCommand.Connection = connection;

                var count = deleteCommand.ExecuteNonQuery();
                return count > 0;
            }
            catch (SqlException ex1)
            {
                MessageBox.Show(ex1.Message);
            }
            catch (Exception ex2)
            {
                MessageBox.Show(ex2.Message);
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }
            return false;
        }
        #endregion Country

        #region City
        public static void SetCities()
        {
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(_connectionString);

                if (connection == null) return;
                Cities.Clear();
                connection.Open();

                string sql = @"SELECT TOP (1000) c1.[Id]
      ,c1.[Country]
	  ,c2.[Name] as CountryName
      ,c1.[Name] as CityName
  FROM [CITY] AS c1
  JOIN COUNTRY AS c2 ON c2.Id = c1.Country";
                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read()) // построчно считываем данные
                {
                    object id = reader.GetValue(0);
                    object countryId = reader.GetValue(1);
                    object countryName = reader.GetValue(2);
                    object cityName = reader.GetValue(3);
                    City city = new City()
                    {
                        Id = (int)id,
                        CountryId = countryId == DBNull.Value ? -1 : (int)countryId,
                        Name = (string)cityName,
                        CountryName = countryName == DBNull.Value ? string.Empty : (string)countryName
                    };
                    Cities.Add(city);
                }
            }
            catch (SqlException e1)
            {
                MessageBox.Show(e1.Message);
            }
            catch (Exception e2)
            {
                MessageBox.Show(e2.Message);
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }

        }

        public static bool UpdateCity(City newCity)
        {
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(_connectionString);
                connection.Open();
                SqlCommand updateCommand = new SqlCommand("Update City SET Name = @CityName, Country = @CountryId WHERE Id = @CityId", connection);
                updateCommand.Parameters.Add("@CityName", SqlDbType.NVarChar, 255, "Name");
                updateCommand.Parameters.Add("@CountryId", SqlDbType.Int, sizeof(int), "Country");
                updateCommand.Parameters.Add("@CityId", SqlDbType.Int, sizeof(int), "Id");
                updateCommand.Parameters[0].Value = newCity.Name;
                updateCommand.Parameters[1].Value = newCity.CountryId;
                updateCommand.Parameters[2].Value = newCity.Id;

                var count = updateCommand.ExecuteNonQuery();
                return count > 0;
            }
            catch (SqlException ex1)
            {
                MessageBox.Show(ex1.Message);
            }
            catch (Exception ex2)
            {
                MessageBox.Show(ex2.Message);
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }
            return false;
        }
        public static bool CheckExistsCity(int cityId)
        {
            SetCities();
            foreach (var c in Cities)
            {
                if (cityId == c.Id) return true;
            }
            return false;
        }
        public static bool CheckExistsCity(string cityName, int countryId)
        {
            SetCities();
            foreach (var c in Cities)
            {
                if (cityName.Equals(c.Name) && countryId == c.CountryId) return true;
            }
            return false;
        }

        public static bool AddCity(string cityName, int countryId)
        {
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(_connectionString);
                connection.Open();
                SqlCommand insertCommand = new SqlCommand("INSERT INTO City (Country, Name) VALUES ( @CountryId, @CityName) ", connection);
                insertCommand.Parameters.Add("@CountryId", SqlDbType.Int, sizeof(int), "Country");
                insertCommand.Parameters.Add("@CityName", SqlDbType.NVarChar, 255, "Name");
                insertCommand.Parameters[0].Value = countryId;
                insertCommand.Parameters[1].Value = cityName;

                var count = insertCommand.ExecuteNonQuery();
                return count > 0;
            }
            catch (SqlException ex1)
            {
                MessageBox.Show(ex1.Message);
            }
            catch (Exception ex2)
            {
                MessageBox.Show(ex2.Message);
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }
            return false;
        }

        public static bool DeleteCity(int id)
        {
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(_connectionString);
                connection.Open();
                SqlCommand deleteCommand = new SqlCommand("DELETE FROM City WHERE Id =  @Id ");
                deleteCommand.Parameters.Add("@Id", SqlDbType.Int, 255, "Id");
                deleteCommand.Parameters[0].Value = id;
                deleteCommand.Connection = connection;

                var count = deleteCommand.ExecuteNonQuery();
                return count > 0;
            }
            catch (SqlException ex1)
            {
                MessageBox.Show(ex1.Message);
            }
            catch (Exception ex2)
            {
                MessageBox.Show(ex2.Message);
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }
            return false;
        }
        #endregion City

    }
}
