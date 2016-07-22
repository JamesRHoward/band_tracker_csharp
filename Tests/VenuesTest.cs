using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Xunit;

namespace BandTracker
{
  public class VenuesTest : IDisposable
  {
    public VenuesTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=band_tracker_test;Integrated Security=SSPI;";
    }
    [Fact]
    public void Test_GetAll_DatabaseEmptyAtFirst()
    {
      int result = Venues.GetAll().Count;

      Assert.Equal(0, result);
    }
    public void Dispose()
    {
      // Venues.DeleteAll();
    }
  }
}
