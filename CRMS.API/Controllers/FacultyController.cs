﻿using CRMS.Domain.Entities;
using CRMS.Infrastructure.Repositories.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacultyController(IGenericRepositoryInterface<Faculty> genericRepositoryInterface)
        : GenericController<Faculty>(genericRepositoryInterface)
    {
    }
}
