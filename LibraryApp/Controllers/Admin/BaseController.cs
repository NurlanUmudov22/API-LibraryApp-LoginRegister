﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApp.Controllers.Admin
{
    [Route("api/admin/[controller]/[action]")]
    [ApiController]

    public class BaseController : ControllerBase
    {
    }
}
