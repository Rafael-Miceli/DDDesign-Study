using System;
using System.Collections.Generic;
using ClientPatientManagement.Core.Interfaces;

namespace ClientPatientManagement.Core.Model
{
  public class Client : IEntity
  {
    public int Id { get; set; }
    public string FullName { get; set; }
    public string Salutation { get; set; }
    public string PreferredName { get; set; }
  }
}