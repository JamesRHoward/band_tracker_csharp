using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace BandTracker
{
  public class Bands
  {
    private int _id;
    private string _band;

    public Bands(string bandName, int id = 0)
    {
      _id = id;
      _band = bandName;
    }

    public void SetBandName(string newBandName)
    {
      _band = newBandName;
    }

    public int GetId()
    {
      return _id;
    }

    public string GetBand()
    {
      return _band;
    }
  }
}
