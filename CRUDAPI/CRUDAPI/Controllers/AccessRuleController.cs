using CRUDAPI.Models;
using CRUDAPI.Services;
using CRUDAPI.Services.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDAPI.Controllers
{
    [Route("api/accessrule")]
    [ApiController]
    public class AccessRuleController : ControllerBase
    {
        private IAccessRuleRepository _accessRuleRepository;

        public AccessRuleController(IAccessRuleRepository repository)
        {
            _accessRuleRepository = repository;
        }

        [HttpGet]
        public IActionResult GetAllAccessRules()
        {
            return Ok(_accessRuleRepository.AllAccessRules());
        }

        [HttpGet("{ID}")]
        public IActionResult GetAccessRuleByID(int ID)
        {
            AccessRule foundAccessRule = _accessRuleRepository.AccessRuleByID(ID);
            if (foundAccessRule is null) return NotFound("Access rule not found!");
            else return Ok(foundAccessRule);
        }

        [HttpPost]
        public IActionResult AddAccessRule(CreateAccessRuleDto accessRule)
        {
            AccessRule newAccessRule = new AccessRule
            {
                RuleName = accessRule.RuleName,
                Permission = accessRule.Permission
            };
            return Ok(_accessRuleRepository.AddAccessRule(newAccessRule));
        }

        [HttpPut("{ID}")]
        public IActionResult UpdateAccessRule(int ID,CreateAccessRuleDto accessRule)
        {
            AccessRule foundAccessRule = _accessRuleRepository.AccessRuleByID(ID);
            if (foundAccessRule is null) return NotFound("Access rule not found!");
            else {
                AccessRule changedAccessRule = new AccessRule
                {
                    RuleName = accessRule.RuleName,
                    Permission = accessRule.Permission
                };
                return Ok(_accessRuleRepository.UpdateAccessRule(ID, changedAccessRule));
            };
        }

        [HttpDelete("{ID}")]
        public IActionResult DeleteAccessRule(int ID)
        {
            AccessRule foundAccessRule = _accessRuleRepository.AccessRuleByID(ID);
            if (foundAccessRule is null) return NotFound("Access rule not found!");
            else {
                _accessRuleRepository.DeleteAccessRule(ID);
                return Ok();
            }
        }

        [HttpGet("userlist/{ID}")]
        public IActionResult GetAccessRuleUserList(int ID)
        {
            AccessRule foundAccessRule = _accessRuleRepository.AccessRuleByID(ID);
            if (foundAccessRule is null) return NotFound("Access rule not found!");
            else return Ok(_accessRuleRepository.AccessRuleUserList(ID));
        }
    }
}
