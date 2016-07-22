using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace BandTracker
{
  public class Venue
  {
    private int _id;
    private string _venueName;

    public Venue(string venueName, int id = 0)
    {
      _id = id;
      _venueName = venueName;
    }
    public int GetId()
    {
      return _id;
    }
    public string GetVenueName()
    {
      return _venueName;
    }
    public void SetVenueName()
    {
      _venueName = venueName;
    }
    public static List<Venue> GetAll()
    {
      List<Venue> allVenues = new List<Venue>{};
      SqlConnection conn = DB.Connection();
       SqlDataReader rdr = null;
       conn.Open();
       SqlCommand cmd = new SqlCommand("SELECT * FROM venues;", conn);
       rdr = cmd.ExecuteReader();
       while (rdr.Read())
    }
  }
}
