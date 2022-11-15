using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Model.PortfolioViewModel;
using Models.ViewModel;
using Models.ViewModel.PortfolioViewModel;
using Services.Portfolio;

namespace MyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PortfolioController : ControllerBase
    {
        private readonly IPortfolioServices portfolioServices;
        public PortfolioController(IPortfolioServices portfolioServices)
        {
            this.portfolioServices = portfolioServices;
        }

        [HttpPost("SkillServiceTool")]
        public async Task<IActionResult> SkillServiceTool(OtherViewModel model)
        {
            var result = await portfolioServices.SkillServiceToolAsync(model);
            if (result.Status)
                return Ok(result);
            return BadRequest(result);
        }

        //Get All
        [HttpGet("GetAllById")]
        public async Task<IActionResult> GetAllByIdAsync(Guid Id)
        {
            var result = await portfolioServices.GetAllByIdAsync(Id);
            if (result.Status)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpGet("GetAllByName")]
        public async Task<IActionResult> GetAllByNameAsync(string Name)
        {
            var result = await portfolioServices.GetAllByNameAsync(Name);
            if (result.Status)
                return Ok(result);
            return BadRequest(result);
        }

        //Get
        [HttpGet("GetPersonalInfo")]
        public async Task<IActionResult> GetPersonalInfo()
        {
            var result = await portfolioServices.GetPersonalInfoAsync();
            if (result.Status)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpGet("GetSkill")]
        public async Task<IActionResult> GetSkill()
        {
            var result = await portfolioServices.GetSkillAsync();
            if (result.Status)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpGet("GetService")]
        public async Task<IActionResult> GetService()
        {
            var result = await portfolioServices.GetServiceAsync();
            if (result.Status)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpGet("GetProject")]
        public async Task<IActionResult> GetProject()
        {
            var result = await portfolioServices.GetProjectAsync();
            if (result.Status)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpGet("GetProjectType")]
        public async Task<IActionResult> GetProjectType()
        {
            var result = await portfolioServices.GetProjectTypeAsync();
            if (result.Status)
                return Ok(result);
            return BadRequest(result);
        }

        // Add or Update
        [HttpPost("AddOrUpdatePersonalInfo")]
        public async Task<IActionResult> AddOrUpdatePersonalInfo(PersonalInfoViewModel model)
        {
            var result = await portfolioServices.AddorUpdatePersonalInfoAsync(model);
            if (result.Status)
                return Ok(result);
            return BadRequest();
        }
        [HttpPost("AddOrUpdateSkill")]
        public async Task<IActionResult> AddOrUpdateSkill(SkillViewModel model)
        {
            var result = await portfolioServices.AddorUpdateSkillAsync(model);
            if (result.Status)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpPost("AddOrUpdateService")]
        public async Task<IActionResult> AddOrUpdateService(ServiceViewModel model)
        {
            var result = await portfolioServices.AddorUpdateServiceAsync(model);
            if (result.Status)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpPost("AddOrUpdateProject")]
        [DisableRequestSizeLimit, RequestFormLimits(MultipartBodyLengthLimit = int.MaxValue, ValueLengthLimit = int.MaxValue)]
        public async Task<IActionResult> AddOrUpdateProject(ProjectsViewModel model)
        {
            var result = await portfolioServices.AddorUpdateProjectAsync(model);
            if (result.Status)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpPost("AddOrUpdateProjectType")]
        public async Task<IActionResult> AddOrUpdateProjectType(ProjectTypeViewModel model)
        {
            var result = await portfolioServices.AddorUpdateProjectTypeAsync(model);
            if (result.Status)
                return Ok(result);
            return BadRequest(result);
        }

        //GetById
        [HttpGet("GetByPersonalInfoId")]
        public async Task<IActionResult> GetByPersonalInfoId(Guid PersonalInfoId)
        {
            var result = await portfolioServices.GetByPersonalInfoIdAsync(PersonalInfoId);
            if (result.Status)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpGet("GetBySkillId")]
        public async Task<IActionResult> GetBySkillId(Guid SkillId)
        {
            var result = await portfolioServices.GetBySkillIdAsync(SkillId);
            if (result.Status)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpGet("GetByServiceId")]
        public async Task<IActionResult> GetByServiceId(Guid ServiceId)
        {
            var result = await portfolioServices.GetByServiceIdAsync(ServiceId);
            if (result.Status)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpGet("GetByProjectId")]
        public async Task<IActionResult> GetByProjectId(Guid ProjectId)
        {
            var result = await portfolioServices.GetByProjectIdAsync(ProjectId);
            if (result.Status)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpGet("GetByProjectTypeId")]
        public async Task<IActionResult> GetByProjectTypeId(Guid ProjectTypeId)
        {
            var result = await portfolioServices.GetByProjectTypeIdAsync(ProjectTypeId);
            if (result.Status)
                return Ok(result);
            return BadRequest(result);
        }

        //Delete
        [HttpDelete("DeletePersonalInfo")]
        public async Task<IActionResult> DeletePersonalInfo(Guid PersonalInfoId)
        {
            var result = await portfolioServices.DeletePersonalInfoIdAsync(PersonalInfoId);
            if (result.Status)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpDelete("DeleteSkill")]
        public async Task<IActionResult> DeleteSkill(Guid SkillId)
        {
            var result = await portfolioServices.DeleteSkillIdAsync(SkillId);
            if (result.Status)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpDelete("DeleteService")]
        public async Task<IActionResult> DeleteService(Guid ServiceId)
        {
            var result = await portfolioServices.DeleteServiceIdAsync(ServiceId);
            if (result.Status)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpDelete("DeleteProject")]
        public async Task<IActionResult> DeleteProject(Guid ProjectId)
        {
            var result = await portfolioServices.DeleteProjectIdAsync(ProjectId);
            if (result.Status)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpDelete("DeleteProjectType")]
        public async Task<IActionResult> DeleteProjectType(Guid ProjectTypeId)
        {
            var result = await portfolioServices.DeleteProjectTypeIdAsync(ProjectTypeId);
            if (result.Status)
                return Ok(result);
            return BadRequest(result);
        }
    }
}
