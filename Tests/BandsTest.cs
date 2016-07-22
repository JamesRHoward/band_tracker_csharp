using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Xunit;

namespace BandTracker
{
  public class BandsTest : IDisposable
  {
    public BandsTest()
    {
        DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=band_tracker_test;Integrated Security=SSPI;";
    }
    [Fact]
    public void Test_GetAll_DatabaseEmptyAtFirst()
    {
      int result = Bands.GetAll().Count;

      Assert.Equal(0, result);
    }
    public void Dispose()
    {
      // Bands.DeleteAll();
    }
  }
}
