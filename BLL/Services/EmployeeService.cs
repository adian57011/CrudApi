using BLL.DTOs;
using DAL;
using DAL.EF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class EmployeeService
    {
        public static bool CreateEmployee(EmployeeDTO obj)
        {
            var mapper = MapperService<EmployeeDTO, Employee>.GetMapper();

            Employee emp = mapper.Map<Employee>(obj);
            return DataAccess.EmployeeData().Create(emp);
        }

        public static bool UpdateEmployee(EmployeeDTO obj)
        {
            var mapper = MapperService<EmployeeDTO, Employee>.GetMapper();

            Employee emp = mapper.Map<Employee>(obj);
            return DataAccess.EmployeeData().Update(emp);
        }

        public static bool DeleteEmployee(int id)
        {
            return DataAccess.EmployeeData().Delete(id);
        }

        public static EmployeeDTO GetEmployee(int id)
        {
            var data = DataAccess.EmployeeData().Get(id);

            var mapper = MapperService<Employee, EmployeeDTO>.GetMapper();

            var empDTO = mapper.Map<EmployeeDTO>(data);
            return empDTO;
        }

        public static List<EmployeeDTO> GetEmployeeAll()
        {
            var data = DataAccess.EmployeeData().GetAll();

            var mapper = MapperService<Employee, EmployeeDTO>.GetMapper();

            var empDTOs = mapper.Map<List<EmployeeDTO>>(data);
            return empDTOs;
        }
    }
}
