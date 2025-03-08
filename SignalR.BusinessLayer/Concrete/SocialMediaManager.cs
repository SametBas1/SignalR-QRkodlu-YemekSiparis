using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Abstract;
using SignalR.EntityLayer.Entities;

namespace SignalR.BusinessLayer.Concrete
{
    public class SocialMediaManager : ISocialMediaService
    {
        private readonly ISocialMediaDal _socialmediaDal;

        public SocialMediaManager(ISocialMediaDal socialmediaDal)
        {
            _socialmediaDal = socialmediaDal;
        }

        public void TAdd(SocialMedia entity)
        {
            _socialmediaDal.Add(entity);
        }

        public void TDelete(SocialMedia entity)
        {
            _socialmediaDal.Delete(entity);
        }

        public SocialMedia TGetByID(int id)
        {
            return _socialmediaDal.GetByID(id);
        }

        public List<SocialMedia> TGetListAll()
        {
            return _socialmediaDal.GetListAll();
        }

        public void TUpdate(SocialMedia entity)
        {
            _socialmediaDal.Update(entity);
        }
    }
}
