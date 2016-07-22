using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace BandTracker
{
  public class Venues
  {
    private int _id;
    private string _venue;

    public Venues(string venueName, int id = 0)
    {
      _id = id;
      _venue = venueName;
    }

    public void SetVenueName(string newVenueName)
    {
      _venue = newVenueName;
    }

    public int GetId()
    {
      return _id;
    }

    public string GetVenue()
    {
      return _venue;
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
        Venues newVenue = new Venues(venuesName, venuesId);
        allVenues.Add(newVenue);
      }
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
