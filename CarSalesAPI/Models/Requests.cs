using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarSalesAPI.Models
{
    public class AddOrEditRequest
    {
        public bool isAdd { get; set; }
        public bool isEdit { get; set; }
        public bool isDelete { get; set; }
        public int ID { get; set; }
        public string Name { get; set; }
    }

    public class AddOrEditUserRequest
    {
        public bool isAdd { get; set; }
        public bool isEdit { get; set; }
        public bool isDelete { get; set; }
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
    }

    public class AddOrEditSeriesRequest
    {
        public bool isAdd { get; set; }
        public bool isEdit { get; set; }
        public bool isDelete { get; set; }
        public int BrandID { get; set; }
        public int ID { get; set; }
        public string Name { get; set; }
    }

    public class AddOrEditModelRequest
    {
        public bool isAdd { get; set; }
        public bool isEdit { get; set; }
        public bool isDelete { get; set; }
        public int SeriesID { get; set; }
        public int ID { get; set; }
        public string Name { get; set; }
    }

    public class GetCarRequest
    {
        public CarModel Car { get; set; }
        public CarDetailsModel CarDetails { get; set; }
    }

    public class AddCarRequest
    {
        public CarModel Car { get; set; }
        public CarDetailsModel CarDetails { get; set; }
        public List<CarDetailPhotosModel> CarPhotos { get; set; }
    }

    public class EditCarRequest
    {
        public bool isCar { get; set; }
        public bool isCarDetails { get; set; }
        public bool isPhotos { get; set; }
        public CarModel Car { get; set; }
        public CarDetailsModel CarDetails { get; set; }
        public List<CarDetailPhotosModel> CarPhotos { get; set; }
    }

    public class ChangeCarStatusRequest
    {
        public int CarID { get; set; }
        public bool checkIsDeleted { get; set; }
        public bool checkIsSold { get; set; }
        public bool checkIsPayed { get; set; }
        public bool Status { get; set; }
    }

    public class GetBrandIdOrSeriesId
    {
        public int BrandID { get; set; }
        public int SeriesID { get; set; }
    }
}