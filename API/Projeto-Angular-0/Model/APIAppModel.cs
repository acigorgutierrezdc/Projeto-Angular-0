using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIApp.Model
{
  [Keyless]
  public class APIAppModel
  {
        public int APIAppId { get; set; }
        public string nome { get; set; }
        public string email { get; set; }
    }
}
