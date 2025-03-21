﻿using HMSAPI.Model.GenericModel;

using HMSAPI.Model.TblHospitalDepartment;
using HMSAPI.Service.TblHospitalDept;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HMSAPI.Controllers.TblHospitalDept
{
    [Route("api/[controller]")]
    [ApiController]
    public class TblHospitalDeptController : ControllerBase
    {
        private readonly ITblHospitalDepartment _serviceTblHosDep;
        public TblHospitalDeptController(ITblHospitalDepartment TblHosDept)
        {
            _serviceTblHosDep = TblHosDept;
        }
        [HttpPost("[action]")]
        public async Task<APIResponseModel> Add(TblHospitalDepartmentModel DeptModel)
        {
            return await _serviceTblHosDep.Add(DeptModel);
        }

        [HttpPut("[action]")]
        public async Task<APIResponseModel> Update(TblHospitalDepartmentModel departmentModel)
        {
            return await _serviceTblHosDep.Update(departmentModel);
        }
        [HttpDelete("[action]")]
        public async Task<APIResponseModel> Delete(int id)
        {
            return await _serviceTblHosDep.Delete(id);
        }
        [HttpGet("[action]")]
        public async Task<APIResponseModel> GetByID(int id)
        {
            return await _serviceTblHosDep.GetByID(id);
        }

        [HttpGet("[action]")]
        public async Task<APIResponseModel> GetAll(string? searchBy = null)
        {
            return await _serviceTblHosDep.GetAll(searchBy);
        }
    }
}
