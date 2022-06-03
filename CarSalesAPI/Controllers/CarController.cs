using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using CarSalesAPI.Models;

namespace CarSalesAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class CarController : ApiController
    {
        [HttpGet, Route("api/Car/GetOnSale")]
        public GetCarsResponse GetOnSale()
        {
            try
            {
                using (var context = new CarSalesEntities())
                {
                    GetCarsResponse res = new GetCarsResponse()
                    {
                        GetCars = new List<GetCarRequest>()
                    };

                    var data = context.Car.Where(x => x.isDeleted == false && x.isPayed == false && x.isSold == false);

                    foreach (var item in data)
                    {
                        GetCarRequest carReq = new GetCarRequest()
                        {
                            Car = new CarModel(),
                            CarDetails = new CarDetailsModel()
                        };

                        CarModel carModel = new CarModel()
                        {
                            ID = item.ID,
                            SalePrice = item.SalePrice,
                            Description = item.Description,
                            PublishDate = item.PublishDate,
                            Title = item.Title,
                        };

                        var photoData = context.CarDetailPhotos.Where(x => x.CarID == item.ID);

                        foreach (var photoItem in photoData)
                        {
                            if (photoItem.Line == 0)
                            {
                                carModel.HeaderPhoto = photoItem.PhotoLink;
                            }
                        }

                        carReq.Car = carModel;

                        var carDetailsData = context.CarDetails.SingleOrDefault(x => x.CarID == item.ID);

                        CarDetailsModel carDetailsModel = new CarDetailsModel()
                        {
                            Color = carDetailsData.Color,
                            Kilometer = carDetailsData.Kilometer,
                            Year = carDetailsData.Year,
                            BrandName = context.Brand.SingleOrDefault(x => x.ID == carDetailsData.BrandID).Name,
                            GearName = context.Fuel.SingleOrDefault(x => x.ID == carDetailsData.GearID).Name,
                            ModelName = context.Model.SingleOrDefault(x => x.ID == carDetailsData.ModelID).Name,
                            SeriesName = context.Series.SingleOrDefault(x => x.ID == carDetailsData.SeriesID).Name,
                        };

                        carReq.CarDetails = carDetailsModel;

                        res.GetCars.Add(carReq);
                    }

                    res.Success = true;
                    res.Status = 1;
                    res.StatusMessage = "OK";
                    return res;
                }
            }
            catch (Exception _ex)
            {
                GetCarsResponse res = new GetCarsResponse()
                {
                    Success = false,
                    Status = 0,
                    StatusMessage = _ex.Message
                };

                return res;
            }
        }

        [HttpGet, Route("api/Car/GetOnSold")]
        public GetCarsResponse GetOnSold()
        {
            try
            {
                using (var context = new CarSalesEntities())
                {
                    GetCarsResponse res = new GetCarsResponse()
                    {
                        GetCars = new List<GetCarRequest>()
                    };

                    var data = context.Car.Where(x => x.isSold == true);

                    foreach (var item in data)
                    {
                        GetCarRequest carReq = new GetCarRequest()
                        {
                            Car = new CarModel(),
                            CarDetails = new CarDetailsModel()
                        };

                        CarModel carModel = new CarModel()
                        {
                            ID = item.ID,
                            SalePrice = item.SalePrice,
                            Description = item.Description,
                            PublishDate = item.PublishDate,
                            Title = item.Title,
                            SoldDate = item.SoldDate,
                            SoldPrice = item.SoldPrice,
                            BoughtDate = item.BoughtDate,
                            BoughtPrice = item.BoughtPrice
                        };

                        var photoData = context.CarDetailPhotos.Where(x => x.CarID == item.ID);

                        foreach (var photoItem in photoData)
                        {
                            if (photoItem.Line == 0)
                            {
                                carModel.HeaderPhoto = photoItem.PhotoLink;
                            }
                        }

                        carReq.Car = carModel;

                        var carDetailsData = context.CarDetails.SingleOrDefault(x => x.CarID == item.ID);

                        CarDetailsModel carDetailsModel = new CarDetailsModel()
                        {
                            Color = carDetailsData.Color,
                            Kilometer = carDetailsData.Kilometer,
                            Year = carDetailsData.Year,
                            BrandName = context.Brand.SingleOrDefault(x => x.ID == carDetailsData.BrandID).Name,
                            GearName = context.Fuel.SingleOrDefault(x => x.ID == carDetailsData.GearID).Name,
                            ModelName = context.Model.SingleOrDefault(x => x.ID == carDetailsData.ModelID).Name,
                            SeriesName = context.Series.SingleOrDefault(x => x.ID == carDetailsData.SeriesID).Name,
                        };

                        carReq.CarDetails = carDetailsModel;

                        res.GetCars.Add(carReq);
                    }

                    res.Success = true;
                    res.Status = 1;
                    res.StatusMessage = "OK";
                    return res;
                }
            }
            catch (Exception _ex)
            {
                GetCarsResponse res = new GetCarsResponse()
                {
                    Success = false,
                    Status = 0,
                    StatusMessage = _ex.Message
                };

                return res;
            }
        }

        [HttpGet, Route("api/Car/GetOnPayed")]
        public GetCarsResponse GetOnPayed()
        {
            try
            {
                using (var context = new CarSalesEntities())
                {
                    GetCarsResponse res = new GetCarsResponse()
                    {
                        GetCars = new List<GetCarRequest>()
                    };

                    var data = context.Car.Where(x => x.isDeleted == false && x.isPayed == true && x.isSold == false);

                    foreach (var item in data)
                    {
                        GetCarRequest carReq = new GetCarRequest()
                        {
                            Car = new CarModel(),
                            CarDetails = new CarDetailsModel()
                        };

                        CarModel carModel = new CarModel()
                        {
                            ID = item.ID,
                            SalePrice = item.SalePrice,
                            Description = item.Description,
                            PublishDate = item.PublishDate,
                            Title = item.Title,
                            PayedNumber = item.PayedNumber
                        };

                        var photoData = context.CarDetailPhotos.Where(x => x.CarID == item.ID);

                        foreach (var photoItem in photoData)
                        {
                            if (photoItem.Line == 0)
                            {
                                carModel.HeaderPhoto = photoItem.PhotoLink;
                            }
                        }

                        carReq.Car = carModel;

                        var carDetailsData = context.CarDetails.SingleOrDefault(x => x.CarID == item.ID);

                        CarDetailsModel carDetailsModel = new CarDetailsModel()
                        {
                            Color = carDetailsData.Color,
                            Kilometer = carDetailsData.Kilometer,
                            Year = carDetailsData.Year,
                            BrandName = context.Brand.SingleOrDefault(x => x.ID == carDetailsData.BrandID).Name,
                            GearName = context.Fuel.SingleOrDefault(x => x.ID == carDetailsData.GearID).Name,
                            ModelName = context.Model.SingleOrDefault(x => x.ID == carDetailsData.ModelID).Name,
                            SeriesName = context.Series.SingleOrDefault(x => x.ID == carDetailsData.SeriesID).Name,
                        };

                        carReq.CarDetails = carDetailsModel;

                        res.GetCars.Add(carReq);
                    }

                    res.Success = true;
                    res.Status = 1;
                    res.StatusMessage = "OK";
                    return res;
                }
            }
            catch (Exception _ex)
            {
                GetCarsResponse res = new GetCarsResponse()
                {
                    Success = false,
                    Status = 0,
                    StatusMessage = _ex.Message
                };

                return res;
            }
        }

        [HttpGet, Route("api/Car/GetOnNotSale")]
        public GetCarsResponse GetOnNotSale()
        {
            try
            {
                using (var context = new CarSalesEntities())
                {
                    GetCarsResponse res = new GetCarsResponse()
                    {
                        GetCars = new List<GetCarRequest>()
                    };

                    var data = context.Car.Where(x => x.isDeleted == true && x.isPayed == false && x.isSold == false);

                    foreach (var item in data)
                    {
                        GetCarRequest carReq = new GetCarRequest()
                        {
                            Car = new CarModel(),
                            CarDetails = new CarDetailsModel()
                        };

                        CarModel carModel = new CarModel()
                        {
                            ID = item.ID,
                            SalePrice = item.SalePrice,
                            Description = item.Description,
                            PublishDate = item.PublishDate,
                            Title = item.Title,
                        };

                        var photoData = context.CarDetailPhotos.Where(x => x.CarID == item.ID);

                        foreach (var photoItem in photoData)
                        {
                            if(photoItem.Line == 0)
                            {
                                carModel.HeaderPhoto = photoItem.PhotoLink;
                            }
                        }

                        carReq.Car = carModel;

                        var carDetailsData = context.CarDetails.SingleOrDefault(x => x.CarID == item.ID);

                        CarDetailsModel carDetailsModel = new CarDetailsModel()
                        {
                            Color = carDetailsData.Color,
                            Kilometer = carDetailsData.Kilometer,
                            Year = carDetailsData.Year,
                            BrandName = context.Brand.SingleOrDefault(x => x.ID == carDetailsData.BrandID).Name,
                            GearName = context.Fuel.SingleOrDefault(x => x.ID == carDetailsData.GearID).Name,
                            ModelName = context.Model.SingleOrDefault(x => x.ID == carDetailsData.ModelID).Name,
                            SeriesName = context.Series.SingleOrDefault(x => x.ID == carDetailsData.SeriesID).Name,
                        };

                        carReq.CarDetails = carDetailsModel;

                        res.GetCars.Add(carReq);
                    }

                    res.Success = true;
                    res.Status = 1;
                    res.StatusMessage = "OK";
                    return res;
                }
            }
            catch (Exception _ex)
            {
                GetCarsResponse res = new GetCarsResponse()
                {
                    Success = false,
                    Status = 0,
                    StatusMessage = _ex.Message
                };

                return res;
            }
        }

        [HttpGet, Route("api/Car/GetCarForAdmin")]
        public GetCarResponse GetCarForAdmin(CarModel input)
        {
            try
            {
                using (var context = new CarSalesEntities())
                {
                    GetCarResponse res = new GetCarResponse()
                    {
                        Car = new CarModel(),
                        CarDetails = new CarDetailsModel(),
                        CarPhotos = new List<CarDetailPhotosModel>()
                    };

                    var carData = context.Car.SingleOrDefault(x => x.ID == input.ID);

                    CarModel carModel = new CarModel()
                    {
                        ID = carData.ID,
                        SalePrice = carData.SalePrice,
                        Description = carData.Description,
                        PublishDate = carData.PublishDate,
                        Title = carData.Title,
                        UserFullName = context.Users.SingleOrDefault(x => x.ID == carData.UserID).Name + " " + context.Users.SingleOrDefault(x => x.ID == carData.UserID).Surname,
                        BoughtDate = carData.BoughtDate,
                        BoughtPrice = carData.BoughtPrice
                    };

                    if (carData.isSold)
                    {
                        carModel.SoldDate = carData.SoldDate;
                        carModel.SoldPrice = carData.SoldPrice;
                    }

                    if (carData.isPayed)
                    {
                        carModel.PayedNumber = carData.PayedNumber;
                    }

                    res.Car = carModel;

                    var photoData = context.CarDetailPhotos.Where(x => x.CarID == input.ID);

                    foreach (var photoItem in photoData)
                    {
                        CarDetailPhotosModel carDetailPhotosModel = new CarDetailPhotosModel()
                        {
                            ID = photoItem.ID,
                            Line = photoItem.Line,
                            PhotoLink = photoItem.PhotoLink
                        };

                        res.CarPhotos.Add(carDetailPhotosModel);
                    }

                    res.CarPhotos = res.CarPhotos.OrderBy(x => x.Line).ToList();

                    var carDetailsData = context.CarDetails.SingleOrDefault(x => x.CarID == input.ID);

                    CarDetailsModel carDetailsModel = new CarDetailsModel()
                    {
                        Capacity = carDetailsData.Capacity,
                        Color = carDetailsData.Color,
                        Kilometer = carDetailsData.Kilometer,
                        Power = carDetailsData.Power,
                        Year = carDetailsData.Year,
                        BrandName = context.Brand.SingleOrDefault(x => x.ID == carDetailsData.BrandID).Name,
                        CaseName = context.Case.SingleOrDefault(x => x.ID == carDetailsData.CaseID).Name,
                        FuelName = context.Fuel.SingleOrDefault(x => x.ID == carDetailsData.FuelID).Name,
                        GearName = context.Fuel.SingleOrDefault(x => x.ID == carDetailsData.GearID).Name,
                        ModelName = context.Model.SingleOrDefault(x => x.ID == carDetailsData.ModelID).Name,
                        PlateName = context.Plate.SingleOrDefault(x => x.ID == carDetailsData.PlateID).Name,
                        SeriesName = context.Series.SingleOrDefault(x => x.ID == carDetailsData.SeriesID).Name,
                        TractionName = context.Traction.SingleOrDefault(x => x.ID == carDetailsData.TractionID).Name
                    };

                    res.CarDetails = carDetailsModel;

                    res.Success = true;
                    res.Status = 1;
                    res.StatusMessage = "OK";
                    return res;
                }
            }
            catch (Exception _ex)
            {
                GetCarResponse res = new GetCarResponse()
                {
                    Success = false,
                    Status = 0,
                    StatusMessage = _ex.Message
                };

                return res;
            }
        }
    

        [HttpGet, Route("api/Car/GetCar")]
        public GetCarResponse GetCar(CarModel input)
        {
            try
            {
                using (var context = new CarSalesEntities())
                {
                    GetCarResponse res = new GetCarResponse()
                    {
                        Car = new CarModel(),
                        CarDetails = new CarDetailsModel(),
                        CarPhotos = new List<CarDetailPhotosModel>()
                    };

                    var carData = context.Car.SingleOrDefault(x => x.ID == input.ID);

                    CarModel carModel = new CarModel()
                    {
                        ID = carData.ID,
                        SalePrice = carData.SalePrice,
                        Description = carData.Description,
                        PublishDate = carData.PublishDate,
                        Title = carData.Title,
                    };

                    res.Car = carModel;

                    var photoData = context.CarDetailPhotos.Where(x => x.CarID == input.ID);

                    foreach (var photoItem in photoData)
                    {
                        CarDetailPhotosModel carDetailPhotosModel = new CarDetailPhotosModel()
                        {
                            ID = photoItem.ID,
                            Line = photoItem.Line,
                            PhotoLink = photoItem.PhotoLink
                        };

                        res.CarPhotos.Add(carDetailPhotosModel);
                    }

                    res.CarPhotos = res.CarPhotos.OrderBy(x => x.Line).ToList();

                    var carDetailsData = context.CarDetails.SingleOrDefault(x => x.CarID == input.ID);

                    CarDetailsModel carDetailsModel = new CarDetailsModel()
                    {
                        Capacity = carDetailsData.Capacity,
                        Color = carDetailsData.Color,
                        Kilometer = carDetailsData.Kilometer,
                        Power = carDetailsData.Power,
                        Year = carDetailsData.Year,
                        BrandName = context.Brand.SingleOrDefault(x => x.ID == carDetailsData.BrandID).Name,
                        CaseName = context.Case.SingleOrDefault(x => x.ID == carDetailsData.CaseID).Name,
                        FuelName = context.Fuel.SingleOrDefault(x => x.ID == carDetailsData.FuelID).Name,
                        GearName = context.Fuel.SingleOrDefault(x => x.ID == carDetailsData.GearID).Name,
                        ModelName = context.Model.SingleOrDefault(x => x.ID == carDetailsData.ModelID).Name,
                        PlateName = context.Plate.SingleOrDefault(x => x.ID == carDetailsData.PlateID).Name,
                        SeriesName = context.Series.SingleOrDefault(x => x.ID == carDetailsData.SeriesID).Name,
                        TractionName = context.Traction.SingleOrDefault(x => x.ID == carDetailsData.TractionID).Name
                    };

                    res.CarDetails = carDetailsModel;

                    res.Success = true;
                    res.Status = 1;
                    res.StatusMessage = "OK";
                    return res;
                }
            }
            catch (Exception _ex)
            {
                GetCarResponse res = new GetCarResponse()
                {
                    Success = false,
                    Status = 0,
                    StatusMessage = _ex.Message
                };

                return res;
            }
        }

        [HttpPost, Route("api/Car/AddCar")]
        public BaseApiResponse AddCar(AddCarRequest input)
        {
            try
            {
                using (var context = new CarSalesEntities())
                {
                    Car carData = new Car()
                    {
                        BoughtDate = input.Car.BoughtDate,
                        BoughtPrice = input.Car.BoughtPrice,
                        Description = input.Car.Description,
                        PublishDate = DateTime.UtcNow,
                        SalePrice = input.Car.SalePrice,
                        Title = input.Car.Title,
                        UserID = input.Car.UserID,                        
                    };

                    var lastAddedCarID = context.Car.Add(carData).ID;

                    CarDetails carDetailsData = new CarDetails()
                    {
                        BrandID = input.CarDetails.BrandID,
                        Capacity = input.CarDetails.Capacity,
                        CarID = lastAddedCarID,
                        CaseID = input.CarDetails.CaseID,
                        Color = input.CarDetails.Color,
                        FuelID = input.CarDetails.FuelID,
                        GearID = input.CarDetails.GearID,
                        ModelID = input.CarDetails.ModelID,
                        Kilometer = input.CarDetails.Kilometer,
                        PlateID = input.CarDetails.PlateID,
                        Power = input.CarDetails.Power,
                        SeriesID = input.CarDetails.SeriesID,
                        TractionID = input.CarDetails.TractionID,
                        Year = input.CarDetails.Year
                    };

                    context.CarDetails.Add(carDetailsData);

                    if(input.CarPhotos.Count > 0)
                    {
                        foreach (var item in input.CarPhotos)
                        {
                            CarDetailPhotos carDetailPhotosData = new CarDetailPhotos()
                            {
                                CarID = lastAddedCarID,
                                Line = item.Line,
                                PhotoLink = item.PhotoLink
                            };

                            context.CarDetailPhotos.Add(carDetailPhotosData);
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

        [HttpPost, Route("api/Car/EditCar")]
        public BaseApiResponse EditCar(EditCarRequest input)
        {
            try
            {
                using (var context = new CarSalesEntities())
                {
                    if (input.isCar)
                    {
                        var data = context.Car.SingleOrDefault(x => x.ID == input.Car.ID);

                        data.Title = input.Car.Title;
                        data.Description = input.Car.Description;
                        data.SalePrice = input.Car.SalePrice;

                        context.SaveChanges();
                    }

                    if (input.isCarDetails)
                    {
                        var data = context.CarDetails.SingleOrDefault(x => x.CarID == input.Car.ID);

                        data.BrandID = input.CarDetails.BrandID;
                        data.CaseID = input.CarDetails.CaseID;
                        data.FuelID = input.CarDetails.FuelID;
                        data.GearID = input.CarDetails.GearID;
                        data.ModelID = input.CarDetails.ModelID;
                        data.PlateID = input.CarDetails.PlateID;
                        data.SeriesID = input.CarDetails.SeriesID;
                        data.TractionID = input.CarDetails.TractionID;
                        data.Capacity = input.CarDetails.Capacity;
                        data.Color = input.CarDetails.Color;
                        data.Kilometer = input.CarDetails.Kilometer;
                        data.Power = input.CarDetails.Power;
                        data.Year = input.CarDetails.Year;

                        context.SaveChanges();
                    }

                    if (input.isPhotos)
                    {
                        var data = context.CarDetailPhotos.Where(x => x.CarID == input.Car.ID);

                        foreach (var item in data)
                        {
                            foreach (var editedItem in input.CarPhotos)
                            {
                                if (item.ID == editedItem.ID)
                                {
                                    item.Line = editedItem.Line;
                                    item.PhotoLink = editedItem.PhotoLink;

                                    context.SaveChanges();
                                    break;
                                }
                            }                            
                        }
                    }

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

        [HttpPost, Route("api/Car/ChangeCarStatus")]
        public BaseApiResponse ChangeCarStatus(ChangeCarStatusRequest input)
        {
            try
            {
                using (var context = new CarSalesEntities())
                {
                    var data = context.Car.SingleOrDefault(x => x.ID == input.CarID);

                    if (input.checkIsDeleted)
                    {
                        data.isDeleted = input.Status;
                        context.SaveChanges();
                    }
                    else if (input.checkIsPayed)
                    {
                        data.isPayed = input.Status;
                        context.SaveChanges();
                    }
                    else if (input.checkIsSold)
                    {
                        data.isSold = input.Status;
                        context.SaveChanges();
                    }

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

        [HttpDelete, Route("api/Car/DeleteCar")]
        public BaseApiResponse DeleteCar(int input)
        {
            try
            {
                using(var context = new CarSalesEntities())
                {
                    var carDetailsData = context.CarDetails.Single(x => x.CarID == input);
                    context.CarDetails.Remove(carDetailsData);
                    context.SaveChanges();

                    var carDetailPhotosData = context.CarDetailPhotos.Where(x => x.CarID == input);

                    if(carDetailPhotosData != null)
                    {
                        foreach (var item in carDetailPhotosData)
                        {
                            context.CarDetailPhotos.Remove(item);
                            context.SaveChanges();
                        }
                    }

                    var carData = context.Car.Single(x => x.ID == input);
                    context.Car.Remove(carData);
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