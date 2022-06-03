using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using CarSalesAPI.Models;

namespace CarSalesAPI.Controllers
{
    public class UserController : ApiController
    {
        [HttpPost, Route("api/User/GetUser")]
        public GetUserResponse GetUser(UserModel input)
        {
            try
            {
                using (var context = new CarSalesEntities())
                {
                    var data = context.Users.Single(x => x.ID == input.ID);

                    UserModel model = new UserModel()
                    {
                        ID = data.ID,
                        Mail = data.Mail,
                        Name = data.Name,
                        Surname = data.Surname,
                        Password = data.Password,
                        FullName = data.Name + " " + data.Surname
                    };

                    GetUserResponse res = new GetUserResponse()
                    {
                        GetUser = model,
                        Success = true,
                        Status = 1,
                        StatusMessage = "OK"
                    };

                    return res;
                }
            }
            catch (Exception _ex)
            {
                GetUserResponse res = new GetUserResponse()
                {
                    Success = false,
                    Status = 0,
                    StatusMessage = _ex.Message
                };

                return res;
            }
        }

        [HttpGet, Route("api/User/GetUsers")]
        public GetUsersResponse GetUsers()
        {
            try
            {
                using (var context = new CarSalesEntities())
                {
                    GetUsersResponse res = new GetUsersResponse()
                    {
                        GetUsers = new List<UserModel>()
                    };

                    var data = context.Users.Where(x => x.isDeleted == false);

                    foreach (var item in data)
                    {
                        UserModel model = new UserModel()
                        {
                            ID = item.ID,
                            Name = item.Name,
                            Surname = item.Surname,
                            Mail = item.Mail,
                            Password = item.Password,
                            FullName = item.Name + " " + item.Surname
                        };

                        res.GetUsers.Add(model);
                    }

                    res.Success = true;
                    res.Status = 1;
                    res.StatusMessage = "OK";
                    return res;
                }
            }
            catch (Exception _ex)
            {
                GetUsersResponse res = new GetUsersResponse()
                {
                    Success = false,
                    Status = 0,
                    StatusMessage = _ex.Message
                };

                return res;
            }
        }

        [HttpPost, Route("api/User/AddOrEditUser")]
        public BaseApiResponse AddOrEditUser(AddOrEditUserRequest input)
        {
            try
            {
                using (var context = new CarSalesEntities())
                {
                    if (input.isAdd)
                    {
                        Users data = new Users()
                        {
                            Name = input.Name,
                            Surname = input.Surname,
                            Mail = input.Mail,
                            Password = input.Password
                        };
                    }
                    else
                    {
                        var data = context.Users.Single(x => x.ID == input.ID);

                        if (input.isEdit)
                        {
                            data.Name = input.Name;
                            data.Surname = input.Surname;
                            data.Mail = input.Mail;
                            data.Password = input.Password;                            
                        }
                        else if (input.isDelete)
                        {
                            data.isDeleted = true;
                        }
                    }

                    context.SaveChanges();

                    BaseApiResponse res = new BaseApiResponse()
                    {
                        Success = true,
                        Status = 1,
                        StatusMessage = "OK"
                    };

                    return res;
                }
            }
            catch (Exception _ex)
            {
                BaseApiResponse res = new BaseApiResponse()
                {
                    Success = false,
                    Status = 0,
                    StatusMessage = _ex.Message
                };

                return res;
            }
        }
    }
}