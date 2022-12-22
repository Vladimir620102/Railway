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
using System.Runtime.InteropServices.WindowsRuntime;
using System.Xml.Linq;
using Railway.Model;

namespace Railway.DbUtils
{
    internal class DbContext
    {

        public static List<Country> Countries = new List<Country>();
        public static List<City> Cities = new List<City>();
        public static List<Station> Stations = new List<Station>();
        public static List<Route> Routes = new List<Route>();
        public static List<Train> Trains = new List<Train>();
        public static List<CarType> CarTypes = new List<CarType>();

        static string _connectionString = Properties.Settings.Default.ConnectionString;


        #region Country
        public static void SetCountries()
        {
            SqlConnection connection = null;
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

                string sql = @"SELECT c1.[Id]
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

        public static City GetCity(int cityId)
        {
            SetCities();
            foreach (var c in Cities)
            {
                if (cityId == c.Id) return c;
            }
            return null;
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

        #region Station
        public static void SetStations()
        {
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(_connectionString);

                if (connection == null) return;
                Stations.Clear();
                connection.Open();
     
                string sql = "ticketservice.select_stations";

                SqlCommand command = new SqlCommand(sql, connection);
                command.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read()) // построчно считываем данные
                {
                    object id = reader.GetValue(0);
                    object number = reader.GetValue(1);
                    object stationName = reader.GetValue(2);
                    object cityName = reader.GetValue(3);
                    object cityId = reader.GetValue(4);
                    Station station = new Station()
                    {
                        Id = (int)id,
                        Number = (int)number,
                        Name = (string)stationName,
                        CityName = cityName == DBNull.Value ? string.Empty : (string)cityName,
                        CityId = cityId == DBNull.Value ? 0 : (int)cityId
                    };
                    Stations.Add(station);
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

        public static bool UpdateStation(Station newStation)
        {
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(_connectionString);
                connection.Open();
                SqlCommand updateCommand = new SqlCommand("Update Station SET Number = @StationNumber, Name = @StationName, City = @CityId WHERE Id = @StationId", connection);
                updateCommand.Parameters.Add("@StationNumber", SqlDbType.Int, sizeof(int), "Number");
                updateCommand.Parameters.Add("@StationName", SqlDbType.NVarChar, 255, "Name");
                updateCommand.Parameters.Add("@CityId", SqlDbType.Int, sizeof(int), "CityId");
                updateCommand.Parameters.Add("@StationId", SqlDbType.Int, sizeof(int), "Id");
                updateCommand.Parameters[0].Value = newStation.Number;
                updateCommand.Parameters[1].Value = newStation.Name;
                updateCommand.Parameters[2].Value = newStation.CityId;
                updateCommand.Parameters[3].Value = newStation.Id;

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
        public static bool CheckExistsStation(string stationName)
        {
            SetCities();
            foreach (var c in Stations)
            {
                if (stationName.Equals(c.Name)) return true;
            }
            return false;
        }

        public static bool AddStation(int number, string stationName, int cityId)
        {
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(_connectionString);
                connection.Open();
                SqlCommand insertCommand = new SqlCommand("INSERT INTO Station (number, name, cityId) VALUES ( @StationNumber, @StationName, @CityId) ", connection);
                insertCommand.Parameters.Add("@StationNumber", SqlDbType.Int, sizeof(int), "StationNumber");
                insertCommand.Parameters.Add("@StationName", SqlDbType.NVarChar, 255, "Name");
                insertCommand.Parameters.Add("@CityId", SqlDbType.Int, sizeof(int), "CityId");
                insertCommand.Parameters[0].Value = number;
                insertCommand.Parameters[1].Value = stationName;
                insertCommand.Parameters[2].Value = cityId;

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

        public static bool DeleteStation(int id)
        {
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(_connectionString);
                connection.Open();
                SqlCommand deleteCommand = new SqlCommand("DELETE FROM Station WHERE Id =  @Id ");
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

        public static Station GetStation(int stationId)
        {
            foreach (var c in Stations)
            {
                if (stationId == c.Id) return c;
            }
            return null;
        }

        #endregion Station

        #region Route
        public static void SetRoutes()
        {
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(_connectionString);

                if (connection == null) return;
                Routes.Clear();
                connection.Open();

                string sql = @"SELECT r.[Id]
      ,r.[number]
      ,r.[from_station_id]
	  ,s0.name
      ,r.[to_station_id]
	  ,s1.name
FROM [ROUTE] r
JOIN Station as s0 on s0.id = r.from_station_id
JOIN Station as s1 on s1.id = r.to_station_id
 ";
                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read()) // построчно считываем данные
                {
                    object id = reader.GetValue(0);
                    object number = reader.GetValue(1);
                    object departureStationId = reader.GetValue(2);
                    object departureStationName = reader.GetValue(3);
                    object arrivalStationId = reader.GetValue(4);
                    object arrivalStationName = reader.GetValue(5);
                    Route route = new Route()
                    {
                        Id = (int)id,
                        Number = (int)number,
                        ArrivalStationId = (int)arrivalStationId,
                        ArrivalStationName = (string)arrivalStationName,
                        DepartureStationId = (int)departureStationId,
                        DepartureStationName = (string)departureStationName,
                    };

                    var list = GetRouteScedule(route.Id);
                    foreach (var ri in list)
                    {
                        route.Items.Add(ri);
                    }
                    Routes.Add(route);
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

        static List<RouteItem> GetRouteScedule(int routeId)
        {
            SqlConnection connection = null;
            List<RouteItem> list = new List<RouteItem>();

            try
            {
                connection = new SqlConnection(_connectionString);

                if (connection == null) return null;
                connection.Open();

                string sql = @"SELECT r.route_Id
      ,r.station_id
	  ,r.arrival_time
      ,r.departure_time
FROM [ROUTE_SCEDULE] r
WHERE r.route_id = @RouteId
 ";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.Add("@RouteId", SqlDbType.Int, sizeof(int), "Route_Id");
                command.Parameters[0].Value = routeId;

                SqlDataReader reader = command.ExecuteReader();


                while (reader.Read()) // построчно считываем данные
                {
                    object station_id = reader.GetValue(1);
                    object arrivalTime = reader.GetValue(2);
                    object departureTime = reader.GetValue(3);
                    RouteItem routeItem = new RouteItem();
                    routeItem.Station = (int)station_id;
                    if (arrivalTime != DBNull.Value)
                        routeItem.ArrivalTime = (DateTime)arrivalTime;
                    if (departureTime != DBNull.Value)
                        routeItem.DepartureTime = (DateTime)departureTime;

                    list.Add(routeItem);
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
            return list;
        }


        public static bool AddRoute(Route route)
        {
            SqlConnection connection = null;
            SqlTransaction transaction = null;
            try
            {
                connection = new SqlConnection(_connectionString);
                connection.Open();
                transaction = connection.BeginTransaction();

                string sql = "INSERT INTO Route (number, from_station_id, to_station_id) VALUES ( @Number, @DepartureName, @ArrivalName)";

                SqlCommand insertCommand = new SqlCommand(sql, connection);

                insertCommand.Parameters.Add("@Number", SqlDbType.Int, sizeof(int), "Number");
                insertCommand.Parameters.Add("@DepartureName", SqlDbType.NVarChar, 255, "from_station_id");
                insertCommand.Parameters.Add("@ArrivalName", SqlDbType.NVarChar, 255, "to_station_id");
                insertCommand.Parameters[0].Value = route.Number;
                insertCommand.Parameters[1].Value = route.DepartureStationId;
                insertCommand.Parameters[2].Value = route.ArrivalStationId;

                insertCommand.Transaction = transaction;

                var count = insertCommand.ExecuteNonQuery();

                AddSceduleRoute(connection, transaction, route);

                transaction.Commit();
                return count > 0;
            }
            catch (SqlException ex1)
            {
                transaction.Rollback();
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
        static void AddSceduleRoute(SqlConnection conn, SqlTransaction transaction, Route route)
        {
            /*
             * [route_id]
      ,[station_id]
      ,[arrival_time]
      ,[departure_time]
             * */
            string sql = "INSERT INTO ROUTE_SCEDULE (route_id, station_id, arrival_time, departure_time) VALUES ( @RouteId, @StationId, @ArrivalTime, @DepartureTime)";

            SqlCommand insertCommand = new SqlCommand(sql, conn);

            insertCommand.Parameters.Add("@RouteId", SqlDbType.Int, sizeof(int), "Route_id");
            insertCommand.Parameters.Add("@StationId", SqlDbType.Int, sizeof(int), "Station_Id");
            insertCommand.Parameters.Add("@ArrivalTime", SqlDbType.DateTime, 32, "Arrival_time");
            insertCommand.Parameters.Add("@DepartureTime", SqlDbType.DateTime, 32, "Departure_Time");




            insertCommand.Transaction = transaction;



            foreach (var item in route.Items)
            {
                insertCommand.Parameters[0].Value = route.Id;
                insertCommand.Parameters[1].Value = item.Station;
                insertCommand.Parameters[2].Value = item.ArrivalTime.HasValue ? (object)item.ArrivalTime.Value : DBNull.Value;
                insertCommand.Parameters[3].Value = item.DepartureTime.HasValue ? (object)item.DepartureTime.Value : DBNull.Value;

                insertCommand.ExecuteNonQuery();
            }
        }

        static void DeleteSceduleRoute(SqlConnection conn, SqlTransaction transaction, Route route)
        {
            if (route == null) return;
            DeleteSceduleRoute(conn, transaction, route.Id);
        }
        static void DeleteSceduleRoute(SqlConnection conn, SqlTransaction transaction, int routeId)
        {

            string sql = "DELETE FROM [ROUTE_SCEDULE] WHERE Route_Id = @RouteId";

            SqlCommand deleteCommand = new SqlCommand(sql, conn);
            deleteCommand.Parameters.Add("@RouteId", SqlDbType.Int, sizeof(int), "Route_Id");
            deleteCommand.Parameters[0].Value = routeId;
            deleteCommand.Transaction = transaction;

            deleteCommand.ExecuteNonQuery();
        }

        public static void SaveRoute(Route route)
        {
            if (route == null) return;
            var r = GetRoute(route.Id);
            if (r == null) AddRoute(route);
            else UpdateRoute(route);
        }

        public static Route GetRoute(int routeId)
        {
            foreach (var r in Routes)
                if (r.Id == routeId)
                {
                    r.Items.Clear();
                    var list = GetRouteScedule(r.Id);
                    foreach (var ri in list)
                    {
                        r.Items.Add(ri);
                    }
                    return r;
                }
            return null;
        }

        public static bool UpdateRoute(Route route)
        {

            SqlTransaction transaction = null;
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(_connectionString);
                connection.Open();
                string sql = "Update ROUTE SET Number = @Number, from_station_id = @DepartureStationId, to_station_id = @ArrivalStationId WHERE Id = @RouteId";
                SqlCommand updateCommand = new SqlCommand(sql, connection);
                transaction = connection.BeginTransaction();

                updateCommand.Parameters.Add("@Number", SqlDbType.Int, sizeof(int), "Number");
                updateCommand.Parameters.Add("@DepartureStationId", SqlDbType.Int, sizeof(int), "from_station_id");
                updateCommand.Parameters.Add("@ArrivalStationId", SqlDbType.Int, sizeof(int), "to_station_id");
                updateCommand.Parameters.Add("@RouteId", SqlDbType.Int, sizeof(int), "Id");

                updateCommand.Parameters[0].Value = route.Number;
                updateCommand.Parameters[1].Value = route.DepartureStationId;
                updateCommand.Parameters[2].Value = route.ArrivalStationId;
                updateCommand.Parameters[3].Value = route.Id;

                updateCommand.Transaction = transaction;

                DeleteSceduleRoute(connection, transaction, route);
                AddSceduleRoute(connection, transaction, route);

                var count = updateCommand.ExecuteNonQuery();
                transaction.Commit();
                return count > 0;
            }
            catch (SqlException ex1)
            {
                transaction.Rollback();
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

        public static bool DeleteRoute(Route route)
        {
            if (route == null) return false;
            return DeleteRoute(route.Id);
        }
        public static bool DeleteRoute(int routeId)
        {
            SqlTransaction transaction = null;
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(_connectionString);
                connection.Open();
                string sql = "DELETE from ROUTE WHERE Id = @RouteId";
                SqlCommand deleteCommand = new SqlCommand(sql, connection);
                transaction = connection.BeginTransaction();

                deleteCommand.Parameters.Add("@RouteId", SqlDbType.Int, sizeof(int), "Id");
                deleteCommand.Parameters[0].Value = routeId;

                deleteCommand.Transaction = transaction;

                DeleteSceduleRoute(connection, transaction, routeId);

                var count = deleteCommand.ExecuteNonQuery();
                transaction.Commit();
                return count > 0;
            }
            catch (SqlException ex1)
            {
                transaction.Rollback();
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

        #endregion Route

        #region Train
        public static void SetTrains(int routeId)
        {

            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(_connectionString);

                if (connection == null) return;
                Trains.Clear();
                connection.Open();

                string sql = @"SELECT t.[id] as Id
      ,t.[number]   as Number
      ,t.[from_station_id] as from_station_id
        ,dep.Name as depName
      ,t.[to_station_id] as to_station_id
        ,arr.Name as arrName
      ,t.[departure] as departure
      ,t.[arrival] as arrival

FROM [TRAIN] t
JOIN Station as dep on dep.Id = t.[from_station_id]
join station as arr ON arr.Id = t.[to_station_id]

WHERE t.[routeId] = @RouteId
 ";
                SqlCommand command = new SqlCommand(sql, connection);

                command.Parameters.Add("@RouteId", SqlDbType.Int, sizeof(int), "Id");
                command.Parameters[0].Value = routeId;

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read()) // построчно считываем данные
                {
                    object id = reader.GetValue(0);
                    object number = reader.GetValue(1);
                    object departureStationId = reader.GetValue(2);
                    object departureStationName = reader.GetValue(3);
                    object arrivalStationId = reader.GetValue(4);
                    object arrivalStationName = reader.GetValue(5);
                    object departureTime = reader.GetValue(6);
                    object arrivalTime = reader.GetValue(7);
                    Train train = new Train()
                    {
                        Id = (int)id,
                        Number = (int)number,
                        DepartureStationId = (int)departureStationId,
                        DepartureStationName = (string)departureStationName,
                        ArrivalStationId = (int)arrivalStationId,
                        ArrivalStationName = (string)arrivalStationName,
                        Departure = (DateTime)departureTime,
                        Arrival = (DateTime)arrivalTime
                    };

                    Trains.Add(train);
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

        public static bool DeleteTrain(int trainId)
        {
            SqlTransaction transaction = null;
            SqlConnection connection = null;
            try
            {

                connection = new SqlConnection(_connectionString);
                connection.Open();
                string sql = "delete_train";
                SqlCommand deleteCommand = new SqlCommand(sql, connection);
                deleteCommand.CommandType = CommandType.StoredProcedure;
                SqlParameter trainParam = new SqlParameter
                {
                    ParameterName = "@train_id",
                    Value = trainId
                };

                deleteCommand.Parameters.Add(trainParam);

                transaction = connection.BeginTransaction();
                deleteCommand.Transaction = transaction;

                var count = deleteCommand.ExecuteNonQuery();
                transaction.Commit();
                return count > 0;
            }
            catch (SqlException ex1)
            {
                transaction.Rollback();
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

        public static bool AddTrain(Train train, int sharedVagon, int economVagon, int compartVagon, int businesVagon)
        {
            SqlTransaction transaction = null;
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(_connectionString);
                connection.Open();
                string sql = "insert_train_with_stock_with_seats";
                SqlCommand command = new SqlCommand(sql, connection);
                command.CommandType= CommandType.StoredProcedure;
                SqlParameter numberParam = new SqlParameter
                {
                    ParameterName = "@number",
                    Value = train.Number
                };
                SqlParameter departureStationParam = new SqlParameter
                {
                    ParameterName = "@from_station_id",
                    Value = train.DepartureStationId
                };
                SqlParameter arrivalStationParam = new SqlParameter
                {
                    ParameterName = "@to_station_id",
                    Value = train.ArrivalStationId
                };
                SqlParameter departureParam = new SqlParameter
                {
                    ParameterName = "@departure",
                    Value = train.Departure
                };
                SqlParameter arrivalParam = new SqlParameter
                {
                    ParameterName = "@arrival",
                    Value = train.Arrival
                };

                SqlParameter sharedVagonParam = new SqlParameter
                {
                    ParameterName = "@number_of_O_cars",
                    Value = sharedVagon
                };

                SqlParameter economVagonParam = new SqlParameter
                {
                    ParameterName = "@number_of_P_cars",
                    Value = economVagon
                };
                SqlParameter compartVagonParam = new SqlParameter
                {
                    ParameterName = "@number_of_K_cars",
                    Value = compartVagon
                };
                SqlParameter businesVagonParam = new SqlParameter
                {
                    ParameterName = "@number_of_SV_cars",
                    Value = sharedVagon
                };

                command.Parameters.Add(numberParam);
                command.Parameters.Add(departureStationParam);
                command.Parameters.Add(arrivalStationParam);
                command.Parameters.Add(departureParam);
                command.Parameters.Add(arrivalParam);
                command.Parameters.Add(sharedVagonParam);
                command.Parameters.Add(economVagonParam);
                command.Parameters.Add(compartVagonParam);
                command.Parameters.Add(businesVagonParam);

                transaction = connection.BeginTransaction();
                command.Transaction = transaction;

                var count = command.ExecuteNonQuery();
                transaction.Commit();
                return count > 0;
            }
            catch (SqlException ex1)
            {
                transaction.Rollback();
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

        public static int GetTrainId(Route route, DateTime date)
        {

            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(_connectionString);
                connection.Open();
                string sql = "ticketservice.select_train_by_date";
                SqlCommand command = new SqlCommand(sql, connection);
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter NumberParam = new SqlParameter
                {
                    ParameterName = "@Number",
                    Value = route.Number
                };

                SqlParameter dateParam = new SqlParameter
                {
                    ParameterName = "@Date",
                    SqlDbType = SqlDbType.Date,
                    Value = date.Date
                };

                command.Parameters.Add(NumberParam);
                command.Parameters.Add(dateParam);

                int trainId = -1;

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read()) // построчно считываем данные
                {
                    object id = reader.GetValue(0);
                    trainId = (int)id;
                }
                return trainId;
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
            return -1;
        }

        #endregion Train

        #region CarType
        public static void SetCarType()
        {
            if (CarTypes.Count > 0) return;
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(_connectionString);
                if (connection == null) return;

                CarTypes.Clear();
                connection.Open();

                SqlCommand command = new SqlCommand("select_car_types", connection);
                command.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read()) // построчно считываем данные
                {
                    object id = reader.GetValue(0);
                    object name = reader.GetValue(1);
                    object capacity = reader.GetValue(2);
                    CarType c = new CarType()
                    {
                        Id = (int)id,
                        Name = (string)name,
                        Capacity = capacity == DBNull.Value ? 0 : (int)capacity
                    };
                    CarTypes.Add(c);
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

        public static bool AddCarType(CarType carType)
        {
            SqlTransaction transaction = null;
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(_connectionString);
                connection.Open();
                string sql = "INSERT INTO CAR_TYPE (Name, Capacity) VALUES (@Name, @Capacity)";
                SqlCommand command = new SqlCommand(sql, connection);

                SqlParameter nameParam = new SqlParameter
                {
                    ParameterName = "@Name",
                    Value = carType.Name
                };
                SqlParameter capacityParam = new SqlParameter
                {
                    ParameterName = "@Capacity",
                    Value = carType.Capacity
                };
                command.Parameters.Add(nameParam);
                command.Parameters.Add(capacityParam);

                transaction = connection.BeginTransaction();
                command.Transaction = transaction;

                var count = command.ExecuteNonQuery();
                transaction.Commit();
                return count > 0;
            }
            catch (SqlException ex1)
            {
                transaction.Rollback();
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

        public static bool UpdateCarType(CarType carType)
        {
            SqlTransaction transaction = null;
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(_connectionString);
                connection.Open();
                string sql = "Update CAR_TYPE set Name = @Name, Capacity = @Capacity where Id = @Id";
                SqlCommand command = new SqlCommand(sql, connection);

                SqlParameter nameParam = new SqlParameter
                {
                    ParameterName = "@Name",
                    Value = carType.Name
                };
                SqlParameter capacityParam = new SqlParameter
                {
                    ParameterName = "@Capacity",
                    Value = carType.Capacity
                };
                SqlParameter idParam = new SqlParameter
                {
                    ParameterName = "@Id",
                    Value = carType.Id
                };

                command.Parameters.Add(nameParam);
                command.Parameters.Add(capacityParam);
                command.Parameters.Add(idParam);

                transaction = connection.BeginTransaction();
                command.Transaction = transaction;

                var count = command.ExecuteNonQuery();
                transaction.Commit();
                return count > 0;
            }
            catch (SqlException ex1)
            {
                transaction.Rollback();
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

        public static bool DeleteCarType(int carTypeId)
        {
            SqlTransaction transaction = null;
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(_connectionString);
                connection.Open();
                string sql = "DELETE FROM CAR_TYPE where Id = @Id";
                SqlCommand command = new SqlCommand(sql, connection);

                SqlParameter idParam = new SqlParameter
                {
                    ParameterName = "@Id",
                    Value = carTypeId
                };

                command.Parameters.Add(idParam);

                transaction = connection.BeginTransaction();
                command.Transaction = transaction;

                var count = command.ExecuteNonQuery();
                transaction.Commit();
                return count > 0;
            }
            catch (SqlException ex1)
            {
                transaction.Rollback();
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
            #endregion CarType

            #region Ticket
            public static List<Route> SelectTrainForTicket(int fromStationId, int toStationId)
        {
            List<Route> list = new List<Route>();
            SqlConnection connection = null;
            try
            {
                //@departure_id int,                 @arrival_id int
                            connection = new SqlConnection(_connectionString);
                connection.Open();
                string sql = "ticketservice.select_route_by_stations";
                SqlCommand command = new SqlCommand(sql, connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter fromParam = new SqlParameter
                {
                    ParameterName = "@departure_id",
                    Value = fromStationId
                };

                SqlParameter toParam = new SqlParameter
                {
                    ParameterName = "@arrival_id",
                    Value = toStationId
                };

                command.Parameters.Add(fromParam);
                command.Parameters.Add(toParam);

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read()) // построчно считываем данные
                {
                    object id = reader.GetValue(0);
                    object number  = reader.GetValue(1);
                    object from_station_id = reader.GetValue(2);
                    object departureName = reader.GetValue(3);
                    object to_station_id = reader.GetValue(4);
                    object arrivalName = reader.GetValue(5);
                    
                    Route c = new Route()
                    {
                        Id = (int)id,
                        Number = (int)number,
                        DepartureStationId = from_station_id == DBNull.Value ? -1 : (int)from_station_id,
                        DepartureStationName = departureName == DBNull.Value ? "" : (string)departureName,
                        ArrivalStationId = to_station_id == DBNull.Value ? -1 : (int)to_station_id,
                        ArrivalStationName = arrivalName == DBNull.Value ? "" : (string)arrivalName
                    };
                    list.Add(c);
                }
                return list;
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

            return list;
        }

        public static List<int> SelectByCarType(int trainId, int carType)
        {
            List<int> list = new List<int>();
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(_connectionString);
                connection.Open();
                string sql = "ticketservice.select_number_by_car_type";
                SqlCommand command = new SqlCommand(sql, connection);
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter carParam = new SqlParameter
                {
                    ParameterName = "@car_type",
                    Value = carType
                };

                SqlParameter trainParam = new SqlParameter
                {
                    ParameterName = "@train_Id",
                    Value = trainId
                };

                command.Parameters.Add(carParam);
                command.Parameters.Add(trainParam);

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read()) // построчно считываем данные
                {
                    
                    object number = reader.GetValue(0);
                    int temp = (number==DBNull.Value ? -1 : (int)number);
                    list.Add(temp);
                }
                return list;
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

            return null;
        }

        public static List<int> SelectByVagon(int trainId, int vagon)
        {
            List<int> list = new List<int>();
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(_connectionString);
                connection.Open();
                string sql =
@"SELECT s.seat_number FROM seat s
WHERE s.train_id = @train_id and s.car_number = @car_number
AND NOT EXISTS( SELECT 1 FROM TICKET t1 where t1.train_id = @train_id and t1.seat_id = s.id)
";

                SqlCommand command = new SqlCommand(sql, connection);

                
                SqlParameter carParam = new SqlParameter
                {
                    ParameterName = "@car_number",
                    Value = vagon
                };

                SqlParameter trainParam = new SqlParameter
                {
                    ParameterName = "@train_Id",
                    Value = trainId
                };

                command.Parameters.Add(carParam);
                command.Parameters.Add(trainParam);

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read()) // построчно считываем данные
                {

                    object number = reader.GetValue(0);
                    int temp = (number == DBNull.Value ? -1 : (int)number);
                    list.Add(temp);
                }
                return list;
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

            return null;
        }

        public static bool AddTicket(Ticket ticket)
        {
            SqlTransaction transaction = null;
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(_connectionString);
                connection.Open();
                string sql = "ticketservice.insert_ticket";
                SqlCommand command = new SqlCommand(sql, connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter trainIdParam = new SqlParameter
                {
                    ParameterName = "@train_id",
                    Value = ticket.TrainId
                };
                SqlParameter vagonParam = new SqlParameter
                {
                    ParameterName = "@car_number",
                    Value = ticket.Vagon
                };

                SqlParameter seatParam = new SqlParameter
                {
                    ParameterName = "@seat_number",
                    Value = ticket.Place
                };

                SqlParameter departureStationParam = new SqlParameter
                {
                    ParameterName = "@this_boarding_st_id",
                    Value = ticket.DepartureStationId
                };
                SqlParameter arrivalStationParam = new SqlParameter
                {
                    ParameterName = "@this_destination_st_id",
                    Value = ticket.ArrivalStationId
                };
                SqlParameter passangerParam = new SqlParameter
                {
                    ParameterName = "@passanger",
                    Value = ticket.Passanger
                };

                command.Parameters.Add(passangerParam);
                command.Parameters.Add(trainIdParam);
                command.Parameters.Add(vagonParam);
                command.Parameters.Add(seatParam);
                command.Parameters.Add(departureStationParam);
                command.Parameters.Add(arrivalStationParam);

                transaction = connection.BeginTransaction();
                command.Transaction = transaction;

                var count = command.ExecuteNonQuery();
                transaction.Commit();
                return count > 0;
            }
            catch (SqlException ex1)
            {
                transaction.Rollback();
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
        #endregion Ticket

    }
}