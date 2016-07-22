using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace BandTracker
{
  public class Venues
  {
    private int _id;
    private string _name;

    public Venues(string name, int id = 0)
    {
      _id = id;
      _name = name;
    }

    public void SetName(string newName)
    {
      _name = newName;
    }

    public int GetId()
    {
      return _id;
    }

    public string GetName()
    {
      return _name;
    }


    public static List<Venues> GetAll()
    {
      List<Venues> allVenues = new List<Venues>{};
      SqlConnection conn = DB.Connection();
      SqlDataReader rdr = null;
      conn.Open();
      SqlCommand cmd = new SqlCommand("SELECT * FROM venues;", conn);
      rdr = cmd.ExecuteReader();
      while (rdr.Read())
      {
        int venuesId = rdr.GetInt32(0);
        string venuesName = rdr.GetString(1);
        Venues newVenues = new Venues(venuesName, venuesId);
        allVenues.Add(newVenue);
        {
          if (rdr != null)
          {
            rdr.Close();
          }
          if (conn != null)
          {
           conn.Close();
          }
          return allVenues;
        }
      }

    }
  }
}
