using Data.AppContext;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Models.Model.PortfolioModel;
using Models.Model.PortfolioViewModel;
using Models.ViewModel;
using Models.ViewModel.PortfolioViewModel;
using SharpCompress.Archives.Rar;
using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services.Portfolio
{
    public class PortfolioServices : IPortfolioServices
    {
        private readonly PortfolioDbContext context;
        public PortfolioServices(PortfolioDbContext context)
        {
            this.context = context;
        }

        //GetAll
        public async Task<Response<object>> GetAllByIdAsync(Guid Id)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(Id.ToString()))
                    return new Response<object>
                    {
                        Message = "Id Is Empty"
                    };


                var getPersnalInfo = await context.PersonalInfo.Where(x => x.PeronalInfoId == Id).ToListAsync();
                if (getPersnalInfo is null)
                    return new Response<object>
                    {
                        Message = "PersnalInfo Record Not Found",
                        Status = false
                    };

                var getSkills = await context.Skills.Where(x => x.PeronalinfoId == Id).ToListAsync();
                if (getSkills is null)
                    return new Response<object>
                    {
                        Message = "Skills Record Not Found",
                        Status = false
                    };

                var getServices = await context.Services.Where(x => x.PeronalinfoId == Id).ToListAsync();
                if (getServices is null)
                    return new Response<object>
                    {
                        Message = "Services Record Not Found",
                        Status = false
                    };

                var getTools = await context.Tools.Where(x => x.PeronalinfoId == Id).ToListAsync();
               
                var getProject = await context.Projects.Where(x => x.PeronalinfoId == Id).ToListAsync();
                if (getProject is null)
                    return new Response<object>
                    {
                        Message = "Project Record Not Found",
                        Status = false
                    };

                var getProjectType = await context.ProjectTypes.Where(x => x.PeronalinfoId == Id).ToListAsync();
                if (getProjectType is null)
                    return new Response<object>
                    {
                        Message = "Project Type Record Not Found",
                        Status = false
                    };

                return new Response<object>
                {
                    Message = "Record Found Successfully",
                    Status = true,
                    Data = new
                    {
                        PersnalInfo = getPersnalInfo,
                        Skills = getSkills,
                        Services = getServices,
                        Tools = getTools,
                        Projects = getProject,
                        ProjectType = getProjectType,
                    }
                };
            }
            catch
            {
                throw;
            }
        }
        public async Task<Response<object>> GetAllByNameAsync(string Name)
        {
            try
            {
                var data = await (from personalinfo in context.PersonalInfo
                                  join skill in context.Skills on personalinfo.PeronalInfoId equals skill.PeronalinfoId
                                  join service in context.Skills on personalinfo.PeronalInfoId equals service.PeronalinfoId
                                  join tool in context.Tools on personalinfo.PeronalInfoId equals tool.PeronalinfoId
                                  join project in context.Projects on personalinfo.PeronalInfoId equals project.PeronalinfoId
                                  join projecttype in context.ProjectTypes on personalinfo.PeronalInfoId equals projecttype.PeronalinfoId
                                  where personalinfo.FirstName == Name || personalinfo.LastName == Name
                                  select new
                                  {
                                      Id = personalinfo.PeronalInfoId,
                                      FirstName = personalinfo.FirstName,
                                      LastName = personalinfo.LastName,
                                      Backgroundimg = personalinfo.Backgroundimg,
                                      Profileimg = personalinfo.Profileimg,
                                      CV = personalinfo.Cv,
                                      Email = personalinfo.Email,
                                      PhoneNumber = personalinfo.PhoneNumber,
                                      Country = personalinfo.Country,
                                      City = personalinfo.City,
                                      Age = personalinfo.Age,
                                      Degree = personalinfo.Cv,
                                      Detail = personalinfo.Detail,
                                      Experience = personalinfo.Experience,
                                      CreatedDate = personalinfo.CreatedDate,
                                      UpdatedDate = personalinfo.UpdatedDate,
                                      SkillName = skill.Name,
                                      SkillPercentage = skill.Percentage,
                                      ServiceName = service.Name,
                                      ToolName = tool.Name,
                                      ProjectName = project.Name,
                                      ProjectImage = project.Img,
                                      ProjectUrl = project.Url,
                                      ProjectType = project.Type,
                                      ProjectTypeName = projecttype.Name,
                                  }).ToListAsync();
                if (data is null)
                    return new Response<object>
                    {
                        Message = "Record Not Found",
                        Status = false
                    };
                return new Response<object>
                {
                    Message = "Record Found Successfully",
                    Status = true,
                    Data = data
                };
            }
            catch
            {
                throw;
            }
        }

        //Get
        public async Task<Response<PersonalInfoViewModel>> GetPersonalInfoAsync()
        {
            try
            {
                var data = await context.PersonalInfo.ToListAsync();
                if (data is null)
                    return new Response<PersonalInfoViewModel>
                    {
                        Message = "Record Not Found",
                        Status = false
                    };
                return new Response<PersonalInfoViewModel>
                {
                    Message = "Record Found Successfully",
                    Status = true,
                    List = data.PersonalInfoMapperList()
                };
            }
            catch
            {
                throw;
            }
        }
        public async Task<Response<SkillViewModel>> GetSkillAsync()
        {
            try
            {
                var data = await context.Skills.ToListAsync();
                if (data is null)
                    return new Response<SkillViewModel>
                    {
                        Message = "Record Not Found",
                        Status = false
                    };
                return new Response<SkillViewModel>
                {
                    Message = "Record Found Successfully",
                    Status = true,
                    List = data.SkillMapperList()
                };
            }
            catch
            {
                throw;
            }
        }
        public async Task<Response<ServiceViewModel>> GetServiceAsync()
        {
            try
            {
                var data = await context.Services.ToListAsync();
                if (data is null)
                    return new Response<ServiceViewModel>
                    {
                        Message = "Record Not Found",
                        Status = false
                    };
                return new Response<ServiceViewModel>
                {
                    Message = "Record Found Successfully",
                    Status = true,
                    List = data.ServiceMapperList()
                };
            }
            catch
            {
                throw;
            }
        }
        public async Task<Response<ToolViewModel>> GetToolAsync()
        {
            try
            {
                var data = await context.Tools.ToListAsync();
                if (data is null)
                    return new Response<ToolViewModel>
                    {
                        Message = "Record Not Found",
                        Status = false
                    };
                return new Response<ToolViewModel>
                {
                    Message = "Record Found Successfully",
                    Status = true,
                    List = data.ToolMapperList()
                };
            }
            catch
            {
                throw;
            }
        }
        public async Task<Response<ProjectsViewModel>> GetProjectAsync()
        {
            try
            {
                var data = await context.Projects.ToListAsync();
                if (data is null)
                    return new Response<ProjectsViewModel>
                    {
                        Message = "Record Not Found",
                        Status = false
                    };
                return new Response<ProjectsViewModel>
                {
                    Message = "Record Found Successfully",
                    Status = true,
                    List = data.ProjectMapperList()
                };
            }
            catch
            {
                throw;
            }
        }
        public async Task<Response<ProjectTypeViewModel>> GetProjectTypeAsync()
        {
            try
            {
                var data = await context.ProjectTypes.ToListAsync();
                if (data is null)
                    return new Response<ProjectTypeViewModel>
                    {
                        Message = "Record Not Found",
                        Status = false
                    };
                return new Response<ProjectTypeViewModel>
                {
                    Message = "Record Found Successfully",
                    Status = true,
                    List = data.ProjectTypeMapperList()
                };
            }
            catch
            {
                throw;
            }
        }

        // Add or Update
        public async Task<Response<string>> AddorUpdatePersonalInfoAsync(PersonalInfoViewModel model)
        {
            //checking model 
            if (model is null)
                return new Response<string>
                {
                    Message = "Model is Empty",
                    Status = false
                };
            //checking profileimage and backgroundimage
            if (model.BackgroundBas64 is null && model.ProfileBas64 is null && model.CvBas64 is null)
                return new Response<string>
                {
                    Message = "Background, Profile Image & File is Not Found",
                    Status = false
                };

            byte[] backgroundBytes = Convert.FromBase64String(model.BackgroundBas64);
            MemoryStream backgroundStream = new MemoryStream(backgroundBytes);
            IFormFile Backgroundimg = new FormFile(backgroundStream, 0, backgroundBytes.Length, model.BackgroundName, model.BackgroundFileName);

            byte[] profileBytes = Convert.FromBase64String(model.BackgroundBas64);
            MemoryStream profileStream = new MemoryStream(profileBytes);
            IFormFile Profileimg = new FormFile(profileStream, 0, profileBytes.Length, model.ProfileName, model.ProfileFileName);

            byte[] cvBytes = Convert.FromBase64String(model.BackgroundBas64);
            MemoryStream cvStream = new MemoryStream(cvBytes);
            IFormFile Cv = new FormFile(cvStream, 0, cvBytes.Length, model.CvName, model.CvFileName);


            //checking file type or file extension
            var backgroundfiletype = Backgroundimg.FileName.Substring(Backgroundimg.FileName.LastIndexOf('.'));
            var profilefiletype = Profileimg.FileName.Substring(Profileimg.FileName.LastIndexOf('.'));

            if (backgroundfiletype != ".jpg" && backgroundfiletype != "jpeg" && backgroundfiletype != "png" && profilefiletype != ".jpg" && profilefiletype != "jpeg" && profilefiletype != "png")
                return new Response<string>
                {
                    Message = "File Extension Is Not Valid Support Only JPG,JPEG PNG",
                    Status = false
                };
            //create and checking directory
            var basedirectory = Directory.GetCurrentDirectory();
            var folderpath = "wwwroot/Images/Portfolio";
            var directorypath = Path.Combine(basedirectory, folderpath);
            if (!Directory.Exists(directorypath))
            {
                Directory.CreateDirectory(directorypath);
            }

            var backgroundfilename = Guid.NewGuid().ToString() + "_" + Backgroundimg.FileName;
            var profilefileName = Guid.NewGuid().ToString() + "_" + Profileimg.FileName;
            var cvName = Guid.NewGuid().ToString() + "_" + Cv.FileName;

            string backgroundfilePath = Path.Combine(directorypath, backgroundfilename);
            string profilefilePath = Path.Combine(directorypath, profilefileName);
            string cvPath = Path.Combine(directorypath, cvName);

            using (var filestream = new FileStream(backgroundfilePath, FileMode.Create))
            {
                Backgroundimg.CopyTo(filestream);
            }
            using (var filestream = new FileStream(profilefilePath, FileMode.Create))
            {
                Profileimg.CopyTo(filestream);
            }
            using (var filestream = new FileStream(cvPath, FileMode.Create))
            {
                Cv.CopyTo(filestream);
            }

            //AddorUpdate Personal Info 
            var result = await context.PersonalInfo.FirstOrDefaultAsync(x => x.PeronalInfoId == model.PeronalInfoId);
            if (result is not null)
            {
                var data = await context.PersonalInfo.FindAsync(model.PeronalInfoId);
                if (backgroundfilePath is not null)
                {
                    data.Backgroundimg = backgroundfilePath;
                }
                if (backgroundfilePath is not null)
                {
                    data.Profileimg = profilefilePath;
                }
                if (backgroundfilePath is not null)
                {
                    data.Cv = cvPath;
                }               
                data.FirstName = model.FirstName;
                data.LastName = model.LastName;
                data.Email = model.Email;
                data.PhoneNumber = model.PhoneNumber;
                data.Age = model.Age;
                data.Country = model.Country;
                data.City = model.City;
                data.Detail = model.Detail;
                data.Experience = model.Experience;
                data.UpdatedDate = DateTime.Now;
                this.context.Update(data);
                await context.SaveChangesAsync();
                return new Response<string>
                {
                    Message = "Data Updated Successfully",
                    Status = true
                };
            }
            else
            {
                PersonalInfo PI = new PersonalInfo();
                PI.Backgroundimg = backgroundfilePath;
                PI.Profileimg = profilefilePath;
                PI.Cv = cvPath;
                PI.FirstName = model.FirstName;
                PI.LastName = model.LastName;
                PI.Email = model.Email;
                PI.PhoneNumber = model.PhoneNumber;
                PI.Country = model.Country;
                PI.City = model.City;
                PI.Detail = model.Detail;
                PI.Experience = model.Experience;
                PI.CreatedDate = DateTime.Now;
                PI.UpdatedDate = DateTime.Now;
                await this.context.PersonalInfo.AddAsync(PI);
                await context.SaveChangesAsync();
                var ID = PI.PeronalInfoId;
                return new Response<string>
                {
                    Message = "Data Added Successfully",
                    Status = true,
                    Data = ID.ToString()
                };
            }
        }
        public async Task<Response<SkillViewModel>> AddorUpdateSkillAsync(SkillViewModel model)
        {
            try
            {
                if (model is null)
                    return new Response<SkillViewModel>
                    {
                        Message = "Model is Empty",
                        Status = false
                    };

                var result = await context.Skills.FirstOrDefaultAsync(x => x.SkillId == model.SkillId);
                if (result is not null)
                {
                    var data = await context.Skills.FindAsync(model.SkillId);
                    data.Name = model.Name;
                    data.Percentage = model.Percentage;
                    data.PeronalinfoId = model.PeronalinfoId;
                    this.context.Update(data);
                    await context.SaveChangesAsync();
                    return new Response<SkillViewModel>
                    {
                        Message = "Data Updated Successfully",
                        Status = true
                    };
                }
                else
                {
                    await this.context.Skills.AddAsync(model.SkillMapper());
                    await context.SaveChangesAsync();
                    return new Response<SkillViewModel>
                    {
                        Message = "Data Added Successfully",
                        Status = true
                    };
                }
            }
            catch
            {
                throw;
            }
        }
        public async Task<Response<ServiceViewModel>> AddorUpdateServiceAsync(ServiceViewModel model)
        {
            try
            {
                if (model is null)
                    return new Response<ServiceViewModel>
                    {
                        Message = "Model is Empty",
                        Status = false
                    };
                var result = await context.Services.FirstOrDefaultAsync(x => x.ServiceId == model.ServiceId);
                if (result is not null)
                {
                    var data = await context.Services.FindAsync(model.ServiceId);
                    data.Name = model.Name;
                    data.PeronalinfoId = model.PeronalinfoId;
                    this.context.Update(data);
                    await context.SaveChangesAsync();
                    return new Response<ServiceViewModel>
                    {
                        Message = "Data Updated Successfully",
                        Status = true
                    };
                }
                else
                {
                    await this.context.Services.AddAsync(model.ServiceMapper());
                    await context.SaveChangesAsync();
                    return new Response<ServiceViewModel>
                    {
                        Message = "Data Added Successfully",
                        Status = true
                    };
                }
            }
            catch
            {
                throw;
            }
        }
        public async Task<Response<ToolViewModel>> AddorUpdateToolAsync(ToolViewModel model)
        {
            try
            {
                if (model is null)
                    return new Response<ToolViewModel>
                    {
                        Message = "Model is Empty",
                        Status = false
                    };
                var result = await context.Tools.FirstOrDefaultAsync(x => x.ToolId == model.ToolId);
                if (result is not null)
                {
                    var data = await context.Tools.FindAsync(model.ToolId);
                    data.Name = model.Name;
                    data.PeronalinfoId = model.PeronalinfoId;
                    this.context.Update(data);
                    await context.SaveChangesAsync();
                    return new Response<ToolViewModel>
                    {
                        Message = "Data Updated Successfully",
                        Status = true
                    };
                }
                else
                {
                    await this.context.Tools.AddAsync(model.ToolMapper());
                    await context.SaveChangesAsync();
                    return new Response<ToolViewModel>
                    {
                        Message = "Data Added Successfully",
                        Status = true
                    };
                }
            }
            catch
            {
                throw;
            }
        }
        public async Task<Response<ProjectsViewModel>> AddorUpdateProjectAsync(ProjectsViewModel model)
        {
            try
            {
                if (model is null)
                    return new Response<ProjectsViewModel>
                    {
                        Message = "Model is Empty",
                        Status = false
                    };
                //checking ProjectImage 
                if (model.ImgBase64 is null)
                    return new Response<ProjectsViewModel>
                    {
                        Message = "Project Iamge is Not Found",
                        Status = false
                    };

                byte[] imageBytes = Convert.FromBase64String(model.ImgBase64);
                MemoryStream imageStream = new MemoryStream(imageBytes);
                IFormFile Img = new FormFile(imageStream, 0, imageBytes.Length, model.ImgName, model.ImgFileName);
                                
                //checking file type or file extension
                var filetype = Img.FileName.Substring(Img.FileName.LastIndexOf('.'));
                if (filetype != ".jpg" && filetype != "jpeg" && filetype != "png")
                    return new Response<ProjectsViewModel>
                    {
                        Message = "File Extension Is Not Valid Support Only JPG,JPEG PNG",
                        Status = false
                    };
                //create and checking directory
                var basedirectory = Directory.GetCurrentDirectory();
                var folderpath = "wwwroot/Images/Portfolio/ProjectImage";
                var directorypath = Path.Combine(basedirectory, folderpath);
                if (!Directory.Exists(directorypath))
                {
                    Directory.CreateDirectory(directorypath);
                }
                
                //iamge
                var imgfilename = Guid.NewGuid().ToString() + "_" + Img.FileName;
                string imagepath = Path.Combine(directorypath, imgfilename);
                using (var filestream = new FileStream(imagepath, FileMode.Create))
                {
                    Img.CopyTo(filestream);
                }

                var ProjectPath = "";
                if (model.ProjectFileBase64 is not null)
                {
                    byte[] fileBytes = Convert.FromBase64String(model.ProjectFileBase64);
                    MemoryStream fileStream = new MemoryStream(fileBytes);
                    IFormFile ProjectFile = new FormFile(fileStream, 0, fileBytes.Length, model.ProjectFName, model.ProjectFileName);

                    //ZipFile
                    var stream = ProjectFile.OpenReadStream();
                    var archive = new ZipArchive(stream);
                    foreach (ZipArchiveEntry entry in archive.Entries)
                    {
                        var filepath = entry.FullName.Substring(0, entry.FullName.LastIndexOf('/'));
                        var projectfolderpath = "wwwroot/Projects/" + filepath;
                        var projectdirectorypath = Path.Combine(basedirectory, projectfolderpath);
                        if (!Directory.Exists(projectdirectorypath))
                        {
                            Directory.CreateDirectory(projectdirectorypath);
                        }

                        int pos = entry.FullName.LastIndexOf("/") + 1;
                        var check = entry.FullName.Substring(pos, entry.FullName.Length - pos);
                        if (!string.IsNullOrEmpty(check))
                        {
                            entry.ExtractToFile(Path.Combine(projectdirectorypath, entry.Name), true);
                        }

                        int extensionPos = entry.Name.LastIndexOf(".") + 1;
                        var extension = entry.Name.Substring(extensionPos, entry.Name.Length - extensionPos);
                        if (extension.ToLower() == "html")
                        {
                            ProjectPath = projectdirectorypath+ "/" + entry.Name;
                        }
                    }
                }
                

                var result = await context.Projects.FirstOrDefaultAsync(x => x.ProjectId == model.ProjectId);
                if (result is not null)
                {
                    var data = await context.Projects.FindAsync(model.ProjectId);
                    data.Name = model.Name;
                    data.Img = imagepath;
                    if (model.ProjectFileBase64 is not null)
                    {
                        data.Url = ProjectPath;
                    }
                    else
                    {
                        data.Url = model.ProjectLink;
                    }
                    data.Type = model.Type;
                    data.PeronalinfoId = model.PeronalinfoId;
                    this.context.Update(data);
                    await context.SaveChangesAsync();
                    return new Response<ProjectsViewModel>
                    {
                        Message = "Data Updated Successfully",
                        Status = true
                    };
                }
                else
                {
                    Projects project = new Projects();
                    project.Name = model.Name;
                    project.Img = imagepath;
                    if (model.ProjectFileBase64 is not null)
                    {
                        project.Url = ProjectPath;
                    }
                    else
                    {
                        project.Url = model.ProjectLink;
                    }
                    project.Type = model.Type;
                    project.PeronalinfoId = model.PeronalinfoId;
                    await this.context.Projects.AddAsync(project);
                    await context.SaveChangesAsync();
                    return new Response<ProjectsViewModel>
                    {
                        Message = "Data Added Successfully",
                        Status = true
                    };
                }
            }
            catch
            {
                throw;
            }
        }
        public async Task<Response<ProjectTypeViewModel>> AddorUpdateProjectTypeAsync(ProjectTypeViewModel model)
        {
            try
            {
                if (model is null)
                    return new Response<ProjectTypeViewModel>
                    {
                        Message = "Model is Empty",
                        Status = false
                    };
                var result = await context.ProjectTypes.FirstOrDefaultAsync(x => x.ProjecttypeId == model.ProjecttypeId);
                if (result is not null)
                {
                    var data = await context.ProjectTypes.FindAsync(model.ProjecttypeId);
                    data.Name = model.Name;
                    data.PeronalinfoId = model.PeronalinfoId;
                    this.context.Update(data);
                    await context.SaveChangesAsync();
                    return new Response<ProjectTypeViewModel>
                    {
                        Message = "Data Updated Successfully",
                        Status = true
                    };
                }
                else
                {
                    await this.context.ProjectTypes.AddAsync(model.ProjectTypeMapper());
                    await context.SaveChangesAsync();
                    return new Response<ProjectTypeViewModel>
                    {
                        Message = "Data Added Successfully",
                        Status = true
                    };
                }
            }
            catch
            {
                throw;
            }
        }

        //GetById
        public async Task<Response<PersonalInfoViewModel>> GetByPersonalInfoIdAsync(Guid PersonalInfoId)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(PersonalInfoId.ToString()))
                    return new Response<PersonalInfoViewModel>
                    {
                        Message = "Id is Empty",
                        Status = false
                    };
                var data = await context.PersonalInfo.FindAsync(PersonalInfoId);
                if (data is null)
                    return new Response<PersonalInfoViewModel>
                    {
                        Message = "Record Not Found",
                        Status = false
                    };
                return new Response<PersonalInfoViewModel>
                {
                    Message = "Record Found Successfully",
                    Status = true,
                    Data = data.PersonalInfoMapper()
                };
            }
            catch
            {
                throw;
            }
        }
        public async Task<Response<SkillViewModel>> GetBySkillIdAsync(Guid SkillId)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(SkillId.ToString()))
                    return new Response<SkillViewModel>
                    {
                        Message = "Id is Empty",
                        Status = false
                    };
                var data = await context.Skills.FindAsync(SkillId);
                if (data is null)
                    return new Response<SkillViewModel>
                    {
                        Message = "Record Not Found",
                        Status = false
                    };
                return new Response<SkillViewModel>
                {
                    Message = "Record Found Successfully",
                    Status = true,
                    Data = data.SkillMapper()
                };
            }
            catch
            {
                throw;
            }
        }
        public async Task<Response<ServiceViewModel>> GetByServiceIdAsync(Guid ServiceId)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(ServiceId.ToString()))
                    return new Response<ServiceViewModel>
                    {
                        Message = "Id is Empty",
                        Status = false
                    };
                var data = await context.Services.FindAsync(ServiceId);
                if (data is null)
                    return new Response<ServiceViewModel>
                    {
                        Message = "Record Not Found",
                        Status = false
                    };
                return new Response<ServiceViewModel>
                {
                    Message = "Record Found Successfully",
                    Status = true,
                    Data = data.ServiceMapper()
                };
            }
            catch
            {
                throw;
            }
        }
        public async Task<Response<ToolViewModel>> GetByToolIdAsync(Guid ToolId)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(ToolId.ToString()))
                    return new Response<ToolViewModel>
                    {
                        Message = "Id is Empty",
                        Status = false
                    };
                var data = await context.Tools.FindAsync(ToolId);
                if (data is null)
                    return new Response<ToolViewModel>
                    {
                        Message = "Record Not Found",
                        Status = false
                    };
                return new Response<ToolViewModel>
                {
                    Message = "Record Found Successfully",
                    Status = true,
                    Data = data.ToolMapper()
                };
            }
            catch
            {
                throw;
            }
        }
        public async Task<Response<ProjectsViewModel>> GetByProjectIdAsync(Guid ProjectId)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(ProjectId.ToString()))
                    return new Response<ProjectsViewModel>
                    {
                        Message = "Id is Empty",
                        Status = false
                    };
                var data = await context.Projects.FindAsync(ProjectId);
                if (data is null)
                    return new Response<ProjectsViewModel>
                    {
                        Message = "Record Not Found",
                        Status = false
                    };
                return new Response<ProjectsViewModel>
                {
                    Message = "Record Found Successfully",
                    Status = true,
                    Data = data.ProjectMapper()
                };
            }
            catch
            {
                throw;
            }
        }
        public async Task<Response<ProjectTypeViewModel>> GetByProjectTypeIdAsync(Guid ProjectTypeId)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(ProjectTypeId.ToString()))
                    return new Response<ProjectTypeViewModel>
                    {
                        Message = "Id is Empty",
                        Status = false
                    };
                var data = await context.ProjectTypes.FindAsync(ProjectTypeId);
                if (data is null)
                    return new Response<ProjectTypeViewModel>
                    {
                        Message = "Record Not Found",
                        Status = false
                    };
                return new Response<ProjectTypeViewModel>
                {
                    Message = "Record Found Successfully",
                    Status = true,
                    Data = data.ProjectTypeMapper()
                };
            }
            catch
            {
                throw;
            }
        }

        //Delete
        public async Task<Response<PersonalInfoViewModel>> DeletePersonalInfoIdAsync(Guid PersonalInfoId)
        {
            if (string.IsNullOrWhiteSpace(PersonalInfoId.ToString()))
                return new Response<PersonalInfoViewModel>
                {
                    Message = "Id is Empty",
                    Status = false
                };
            var data = await context.PersonalInfo.FindAsync(PersonalInfoId);
            if (data is null)
                return new Response<PersonalInfoViewModel>
                {
                    Message = "Record Not Found",
                    Status = false
                };
            context.PersonalInfo.Remove(data);
            await context.SaveChangesAsync();
            return new Response<PersonalInfoViewModel>
            {
                Message = "Record Delted Successfully",
                Status = true
            };
        }
        public async Task<Response<SkillViewModel>> DeleteSkillIdAsync(Guid SkillId)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(SkillId.ToString()))
                    return new Response<SkillViewModel>
                    {
                        Message = "Id is Empty",
                        Status = false
                    };
                var data = await context.Skills.FindAsync(SkillId);
                if (data is null)
                    return new Response<SkillViewModel>
                    {
                        Message = "Record Not Found",
                        Status = false
                    };
                context.Skills.Remove(data);
                await context.SaveChangesAsync();
                return new Response<SkillViewModel>
                {
                    Message = "Record Delted Successfully",
                    Status = true
                };
            }
            catch
            {
                throw;
            }
        }
        public async Task<Response<ServiceViewModel>> DeleteServiceIdAsync(Guid ServiceId)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(ServiceId.ToString()))
                    return new Response<ServiceViewModel>
                    {
                        Message = "Id is Empty",
                        Status = false
                    };
                var data = await context.Services.FindAsync(ServiceId);
                if (data is null)
                    return new Response<ServiceViewModel>
                    {
                        Message = "Record Not Found",
                        Status = false
                    };
                context.Services.Remove(data);
                await context.SaveChangesAsync();
                return new Response<ServiceViewModel>
                {
                    Message = "Record Delted Successfully",
                    Status = true
                };
            }
            catch
            {
                throw;
            }
        }
        public async Task<Response<ToolViewModel>> DeleteToolIdAsync(Guid ToolId)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(ToolId.ToString()))
                    return new Response<ToolViewModel>
                    {
                        Message = "Id is Empty",
                        Status = false
                    };
                var data = await context.Tools.FindAsync(ToolId);
                if (data is null)
                    return new Response<ToolViewModel>
                    {
                        Message = "Record Not Found",
                        Status = false
                    };
                context.Tools.Remove(data);
                await context.SaveChangesAsync();
                return new Response<ToolViewModel>
                {
                    Message = "Record Delted Successfully",
                    Status = true
                };
            }
            catch
            {
                throw;
            }
        }
        public async Task<Response<ProjectsViewModel>> DeleteProjectIdAsync(Guid ProjectId)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(ProjectId.ToString()))
                    return new Response<ProjectsViewModel>
                    {
                        Message = "Id is Empty",
                        Status = false
                    };
                var data = await context.Projects.FindAsync(ProjectId);
                if (data is null)
                    return new Response<ProjectsViewModel>
                    {
                        Message = "Record Not Found",
                        Status = false
                    };
                context.Projects.Remove(data);
                await context.SaveChangesAsync();
                return new Response<ProjectsViewModel>
                {
                    Message = "Record Delted Successfully",
                    Status = true
                };
            }
            catch
            {
                throw;
            }
        }
        public async Task<Response<ProjectTypeViewModel>> DeleteProjectTypeIdAsync(Guid ProjectTypeId)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(ProjectTypeId.ToString()))
                    return new Response<ProjectTypeViewModel>
                    {
                        Message = "Id is Empty",
                        Status = false
                    };
                var data = await context.ProjectTypes.FindAsync(ProjectTypeId);
                if (data is null)
                    return new Response<ProjectTypeViewModel>
                    {
                        Message = "Record Not Found",
                        Status = false
                    };
                context.ProjectTypes.Remove(data);
                await context.SaveChangesAsync();
                return new Response<ProjectTypeViewModel>
                {
                    Message = "Record Delted Successfully",
                    Status = true
                };
            }
            catch
            {
                throw;
            }
        }

        public async Task<Response<OtherViewModel>> SkillServiceToolAsync(OtherViewModel model)
        {
            try
            {
                if (model is null)
                    return new Response<OtherViewModel>
                    {
                        Message = "Model is Empty",
                        Status = false
                    };
                bool update = false;
                bool add = false;
                foreach (var skills in model.Skills)
                {
                    var result = await context.Skills.FirstOrDefaultAsync(x => x.SkillId == skills.SkillId);
                    if (result is not null)
                    {
                        var data = await context.Skills.FindAsync(skills.SkillId);
                        data.Name = skills.Name;
                        data.Percentage = skills.Percentage;
                        data.PeronalinfoId = skills.PeronalinfoId;
                        this.context.Update(data);
                        update = true;
                    }
                    else
                    {
                        await this.context.Skills.AddAsync(skills.SkillMapper());
                        add = true;
                    }
                }
                await context.SaveChangesAsync();

                foreach (var services in model.Services)
                {
                    var result = await context.Services.FirstOrDefaultAsync(x => x.ServiceId == services.ServiceId);
                    if (result is not null)
                    {
                        var data = await context.Services.FindAsync(services.ServiceId);
                        data.Name = services.Name;
                        data.PeronalinfoId = services.PeronalinfoId;
                        this.context.Update(data);
                        update = true;
                    }
                    else
                    {
                        await this.context.Services.AddAsync(services.ServiceMapper());
                        add = true;
                    }
                }
                await context.SaveChangesAsync();

                foreach (var tools in model.Tools)
                {
                    var result = await context.Tools.FirstOrDefaultAsync(x => x.ToolId == tools.ToolId);
                    if (result is not null)
                    {
                        var data = await context.Services.FindAsync(tools.ToolId);
                        data.Name = tools.Name;
                        data.PeronalinfoId = tools.PeronalinfoId;
                        this.context.Update(data);
                        update = true;
                    }
                    else
                    {
                        await this.context.Tools.AddAsync(tools.ToolMapper());
                        add = true;
                    }
                }
                await context.SaveChangesAsync();

                var Message = "";
                if (update == true)
                {
                    Message = "Data Updated Successfully";
                }
                else if (update == true && add == true)
                {
                    Message = "Data Updated and Added Successfully";
                }
                else
                {
                    Message = "Data Added Successfully";
                }

                return new Response<OtherViewModel>
                {
                    Message = Message,
                    Status = true
                };

            }
            catch
            {
                throw;
            }
        }

    }
}
