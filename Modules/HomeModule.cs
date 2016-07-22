using System;
using System.Collections.Generic;
using Nancy;
using Nancy.ViewEngines.Razor;

namespace BandTracker
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"]= _ => {
        List<Venues> allVenues = Venues.GetAll();
        return View["index.cshtml", allVenues];
      };
      Post["/venue/add"] = _ => {
        Venues newVenue = new Venues(Request.Form["venue_name"]);
        newVenue.Save();
        List<Venues> allVenues = Venues.GetAll();
        return View["index.cshtml", allVenues];
      };
    }
  }
}
