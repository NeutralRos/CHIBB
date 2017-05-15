using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CHIBB.Models
{
    public class SenorsRepository : ISensorsRepository
    {
        private readonly CHIBBContext _context;

        public SenorsRepository(CHIBBContext newContext)
        {
            this._context = newContext;
        }


        public IEnumerable<Sensorvalues> GetAll()
        {
            return _context.Sensorvalues.ToList();
        }

        
    }
}
