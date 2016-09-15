using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GarageManager.Models
{
    public class UserInfoModel
    {
        private GarageEntities db = new GarageEntities();

        public UserInformation GetUserInformation(string guId)
        {
            var info = db.UserInformations.FirstOrDefault(ui=>ui.Guid == guId);


            return info;
        }

        public void InstertUserInformation(UserInformation info)
        {
            try
            {
                db.UserInformations.Add(info);
                db.SaveChanges();
            }
            catch (Exception)
            {


            }
        }
    }
}