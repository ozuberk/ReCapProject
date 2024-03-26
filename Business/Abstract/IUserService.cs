using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService
    {
        IDataResult<List<Users>> GetAll();
        IDataResult<Users> GetById(int id);
        IResult Update(Users user);
        IResult Delete(Users user);
        IResult Add(Users user);
    }
}
