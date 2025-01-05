using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerrainApp.API.DataAbstraction.Repository
{
    public interface IRepository <T>
    {
       
            public Task<string> Insert(T document);
            public Task<bool> Update(T document);
            public Task<bool> Delete(string id);

            public Task<T> GetById(string id);

            public Task<List<T>> GetAll();



        
    }
}
